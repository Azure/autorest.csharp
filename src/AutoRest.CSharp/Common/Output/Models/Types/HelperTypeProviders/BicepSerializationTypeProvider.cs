// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BicepSerializationTypeProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<BicepSerializationTypeProvider> _instance = new(() => new BicepSerializationTypeProvider(Configuration.HelperNamespace, null));
        public static BicepSerializationTypeProvider Instance => _instance.Value;
        private const string AppendChildObjectMethodName = "AppendChildObject";

        internal Parameter StringBuilderParameter { get; } =
            new Parameter("stringBuilder", null, typeof(StringBuilder), null, ValidationType.None, null);

        private readonly Parameter IndentFirstLine =
            new Parameter("indentFirstLine", null, typeof(bool), null, ValidationType.None, null);

        private readonly Parameter FormattedPropertyName =
            new Parameter("formattedPropertyName", null, typeof(string), null, ValidationType.None, null);

        private readonly Parameter Spaces =
            new Parameter("spaces", null, typeof(int), null, ValidationType.None, null);

        private readonly Parameter ChildObject = new Parameter("childObject", null, typeof(object),
            null, ValidationType.None, null);

        private BicepSerializationTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
        }

        protected override string DefaultName => "BicepSerializationHelpers";

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return new Method(
                new MethodSignature(
                    AppendChildObjectMethodName,
                    null,
                    null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    null,
                    null,
                    new Parameter[]
                    {
                        new Parameter("stringBuilder", null, typeof(StringBuilder), null, ValidationType.None,
                            null),
                        ChildObject,
                        KnownParameters.Serializations.Options,
                        Spaces,
                        IndentFirstLine,
                        FormattedPropertyName
                    }),
                WriteAppendChildObject().ToArray());
        }

        private IEnumerable<MethodBodyStatement> WriteAppendChildObject()
        {
            VariableReference indent = new VariableReference(typeof(string), "indent");
            yield return Declare(indent, New.Instance(typeof(string), Literal(' '), Spaces));

            VariableReference data = new VariableReference(typeof(BinaryData), "data");

            var emptyObjectLength = new VariableReference(typeof(int), "emptyObjectLength");
            var length = new VariableReference(typeof(int), "length");
            var stringBuilder = new StringBuilderExpression(new ParameterReference(StringBuilderParameter));

            yield return Declare(
                emptyObjectLength,
                new BinaryOperatorExpression("+",
                    new BinaryOperatorExpression("+",
                        new BinaryOperatorExpression("+",
                            // 2 chars for open and close brace
                            new ConstantExpression(new Constant(2, typeof(int))),
                            Spaces),
                        // 2 new lines
                        new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine))
                            .Property(nameof(string.Length))),
                    new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine))
                        .Property(nameof(string.Length))));

            yield return Declare(length, stringBuilder.Property(nameof(StringBuilder.Length)));

            var inMultilineString = new VariableReference(typeof(bool), "inMultilineString");
            yield return Declare(inMultilineString, BoolExpression.False);
            yield return EmptyLine;

            yield return Declare(
                data,
                new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write),
                    new[]
                    {
                        new ParameterReference(ChildObject),
                        new ParameterReference(KnownParameters.Serializations.Options)
                    }));
            VariableReference lines = new VariableReference(typeof(string[]), "lines");
            yield return Declare(
                lines,
                new InvokeInstanceMethodExpression(
                    new InvokeInstanceMethodExpression(data, nameof(ToString), Array.Empty<ValueExpression>(), null,
                        false),
                    nameof(string.Split),
                    new ValueExpression[]
                    {
                        new InvokeInstanceMethodExpression(
                            new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine)), nameof(string.ToCharArray),
                            Array.Empty<ValueExpression>(), null, false),
                        new TypeReference(typeof(StringSplitOptions)).Property(nameof(StringSplitOptions.RemoveEmptyEntries))
                    },
                    null,
                    false)
            );
            var line = new VariableReference(typeof(string), "line");

            yield return new ForStatement("i", new ListExpression(typeof(string), lines), out var indexer)
            {
                Declare(line, new IndexerExpression(lines, indexer)),
                // if this is a multiline string, we do not apply the indentation, except for the first line containing only the ''' which is handled
                // in the subsequent if statement
                new IfStatement(new BoolExpression(inMultilineString))
                    {
                        new IfStatement(new BoolExpression(line.Invoke(nameof(string.Contains), Literal("'''"))))
                        {
                            Assign(new BoolExpression(inMultilineString), BoolExpression.False)
                        },
                        stringBuilder.AppendLine(line),
                        Continue
                    },
                new IfStatement(new BoolExpression(line.Invoke(nameof(string.Contains), Literal("'''"))))
                {
                    Assign(new BoolExpression(inMultilineString), BoolExpression.True),
                    stringBuilder.AppendLine(new FormattableStringExpression("{0}{1}",indent, line)),
                    Continue
                },
                new IfElseStatement(
                    And(Equal(indexer, new ConstantExpression(new Constant(0, typeof(int)))),
                        Not(new BoolExpression(IndentFirstLine))),
                    stringBuilder.AppendLine(new FormattableStringExpression("{0}", line)),
                    stringBuilder.AppendLine(new FormattableStringExpression("{0}{1}", indent, line)))
            };

            yield return new IfStatement(
                new BoolExpression(
                    Equal(
                        stringBuilder.Property(nameof(StringBuilder.Length)),
                        new BinaryOperatorExpression("+", length, emptyObjectLength))))
            {
                Assign(
                    stringBuilder.Property(nameof(StringBuilder.Length)),
                    new BinaryOperatorExpression(
                        "-",
                        new BinaryOperatorExpression(
                            "-",
                            stringBuilder.Property(nameof(StringBuilder.Length)),
                            emptyObjectLength),
                        Literal(new StringExpression(FormattedPropertyName)).Property(nameof(string.Length))))
            };
        }

        internal InvokeStaticMethodStatement AppendChildObject(
            ValueExpression stringBuilder,
            ValueExpression expression,
            ConstantExpression spaces,
            BoolExpression isArrayElement,
            StringExpression formattedPropertyName)
        {
            return new InvokeStaticMethodStatement(
                Type,
                "AppendChildObject",
                new[]
                {
                    stringBuilder, expression, KnownParameters.Serializations.Options, spaces, isArrayElement,
                    formattedPropertyName
                });
        }
    }
}
