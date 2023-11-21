// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Serializations
        {
            public const string XmlWriteMethodName = "_Write";

            public static StringExpression WireFormat = Literal("W");
            public static StringExpression JsonFormat = Literal("J");
            public static StringExpression XmlFormat = Literal("X");

            public static BoolExpression IsNotWireFormat(ValueExpression format)
                => NotEqual(format, WireFormat);

            public static MethodBodyStatement WrapInCheckNotWire(PropertySerialization serialization, ValueExpression format, MethodBodyStatement statement)
            {
                if (!serialization.ShouldExcludeInWireSerialization)
                    return statement;

                return new IfStatement(IsNotWireFormat(format))
                {
                    statement
                };
            }

            public static MethodBodyStatement ValidateJsonFormat(ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface)
                => ValidateFormat(options, JsonFormat, iModelTInterface).ToArray();

            public static MethodBodyStatement ValidateXmlFormat(ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface)
                => ValidateFormat(options, XmlFormat, iModelTInterface).ToArray();

            private static IEnumerable<MethodBodyStatement> ValidateFormat(ModelReaderWriterOptionsExpression options, ValueExpression formatValue, CSharpType iModelTInterface)
            {
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
                    ThrowValidationFailException(format, iModelTInterface.Arguments[0])
                };
            }

            public static MethodBodyStatement GetConcreteFormat(ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface, out TypedValueExpression format)
                => Var("format", new TypedTernaryConditionalOperator(
                    Equal(options.Format, WireFormat),
                    new StringExpression(This.CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.GetFormatFromOptions), options)),
                    options.Format), out format);

            public static MethodBodyStatement ThrowValidationFailException(ValueExpression format, CSharpType typeOfT)
                => Throw(New.Instance(
                    typeof(InvalidOperationException),
                    new FormattableStringExpression("The model {0} does not support '{1}' format.", new[]
                    {
                        Nameof(typeOfT),
                        format
                    })));
        }
    }
}
