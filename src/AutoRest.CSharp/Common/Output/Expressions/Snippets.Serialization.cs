// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Serializations
        {
            public static StringExpression WireFormat = Literal("W");
            public static StringExpression JsonFormat = Literal("J");
            public static StringExpression XmlFormat = Literal("X");
            public static StringExpression BicepFormat = Literal("bicep");
            public static StringExpression MultipartFormat = Literal("MFD");

            public static MethodBodyStatement WrapInCheckInRawData(ValueExpression? rawDataExpression, string propertyName, MethodBodyStatement statement)
            {
                if (rawDataExpression == null || !Configuration.EnableInternalRawData)
                {
                    return statement;
                }

                var rawDataDict = new DictionaryExpression(typeof(string), typeof(BinaryData), new NullConditionalExpression(rawDataExpression));
                var condition = NotEqual(rawDataDict.ContainsKey(Literal(propertyName)), True);

                if (statement is IfStatement ifStatement)
                {
                    return ifStatement with
                    {
                        Condition = And(condition, ifStatement.Condition)
                    };
                }

                return new IfStatement(condition)
                {
                    statement
                };
            }

            // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
            public static MethodBodyStatement WrapInCheckNotWire(bool shouldExcludeInWire, ValueExpression? format, MethodBodyStatement statement)
            {
                // if format is null, indicating the model reader writer is not enabled
                if (format == null)
                {
                    // when the model reader writer is not enabled, we just omit the serialization when it should not be included.
                    if (shouldExcludeInWire)
                    {
                        return EmptyStatement;
                    }
                    else
                    {
                        return statement;
                    }
                }

                if (!shouldExcludeInWire)
                    return statement;

                // we need to wrap a check `format != "W"` around the statement
                // if the statement is not an IfStatement, we just create an IfStatement and return
                // if the statement is an IfStatement, we could add the condition to its condition which should simplify the generated code.
                /* it looks like, if we have
                 *  if (outer)
                 *  {
                 *      if (inner) { DoSomething(); }
                 *  }
                 * we could always simplify this to:
                 *  if (outer && inner)
                 *  {
                 *      DoSomething();
                 *  }
                 * these are exactly the same.
                 * 1. When outer is false, inner is never calculated, and DoSomething will not be execute
                 * 2. When outer is true, inner is calculated, and DoSomething will be execute when inner is true
                 * These hold true for both snippets
                 *
                 * These statements are only true when it is a IfStatement. If the statement is IfElseStatement with an else branch, they are no longer equivalent.
                 */

                var isNotWireCondition = NotEqual(format, WireFormat);
                if (statement is IfStatement ifStatement)
                {
                    return ifStatement with
                    {
                        Condition = And(isNotWireCondition, ifStatement.Condition)
                    };
                }

                return new IfStatement(isNotWireCondition)
                {
                    statement
                };
            }

            public static MethodBodyStatement ValidateJsonFormat(ModelReaderWriterOptionsExpression? options, CSharpType? iModelTInterface, ValidationType validationType)
                => ValidateFormat(options, JsonFormat, iModelTInterface, validationType).ToArray();

            // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
            private static IEnumerable<MethodBodyStatement> ValidateFormat(ModelReaderWriterOptionsExpression? options, ValueExpression formatValue, CSharpType? iModelTInterface, ValidationType validationType)
            {
                if (options == null || iModelTInterface == null)
                    yield break; // if options expression is null, we skip outputting the following statements
                /*
                    var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
                    if (format != <formatValue>)
                    {
                        throw new FormatException($"The model {nameof(ThisModel)} does not support '{format}' format.");
                    }
                 */
                yield return GetConcreteFormat(options, iModelTInterface, out var format);

                yield return new IfStatement(NotEqual(format, formatValue))
                {
                    ThrowValidationFailException(format, iModelTInterface.Arguments[0], validationType)
                };

                yield return EmptyLine; // always outputs an empty line here because we will always have other statements after this
            }

            public static MethodBodyStatement GetConcreteFormat(ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface, out TypedValueExpression format)
                => Var("format", new TypedTernaryConditionalOperator(
                    Equal(options.Format, WireFormat),
                    new StringExpression(This.CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.GetFormatFromOptions), options)),
                    options.Format), out format);

            public static MethodBodyStatement ThrowValidationFailException(ValueExpression format, CSharpType typeOfT, ValidationType validationType)
                => Throw(New.Instance(
                    typeof(FormatException),
                    new FormattableStringExpression($"The model {{{0}}} does not support {(validationType == ValidationType.Write ? "writing" : "reading")} '{{{1}}}' format.", new[]
                    {
                        Nameof(typeOfT),
                        format
                    })));

            public enum ValidationType
            {
                Write,
                Read
            }
        }
    }
}
