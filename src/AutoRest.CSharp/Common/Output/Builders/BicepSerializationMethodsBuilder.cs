// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using Constant = AutoRest.CSharp.Output.Models.Shared.Constant;
using ConstantExpression = AutoRest.CSharp.Common.Output.Expressions.ValueExpressions.ConstantExpression;
using Parameter = AutoRest.CSharp.Output.Models.Shared.Parameter;
using ValidationType = AutoRest.CSharp.Output.Models.Shared.ValidationType;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class BicepSerializationMethodsBuilder
    {
        private const string SerializeBicepMethodName = "SerializeBicep";
        private const string AppendChildObjectMethodName = "AppendChildObject";

        private static readonly Parameter Spaces =
            new Parameter("spaces", null, typeof(int), null, ValidationType.None, null);

        private static readonly Parameter ChildObject = new Parameter("childObject", null, typeof(object),
            null, ValidationType.None, null);

        private static readonly Parameter StringBuilderParameter =
            new Parameter("stringBuilder", null, typeof(StringBuilder), null, ValidationType.None, null);

        private static readonly Parameter IndentFirstLine =
            new Parameter("indentFirstLine", null, typeof(bool), null, ValidationType.None, null);

        private static readonly ValueExpression FormatExpression = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options).Format;

        public static IEnumerable<Method> BuildBicepSerializationMethods(BicepObjectSerialization objectSerialization)
        {
            yield return new Method(
                new MethodSignature(
                    SerializeBicepMethodName,
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    typeof(BinaryData),
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                WriteSerializeBicep(objectSerialization).ToArray());

            yield return new Method(
                new MethodSignature(
                    AppendChildObjectMethodName,
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    null,
                    null,
                    new Parameter[]
                    {
                        new Parameter("stringBuilder", null, typeof(StringBuilder), null, ValidationType.None,
                            null),
                        ChildObject, KnownParameters.Serializations.Options, Spaces, IndentFirstLine
                    }),
                WriteAppendChildObject().ToArray());
        }

        private static IEnumerable<MethodBodyStatement> WriteSerializeBicep(BicepObjectSerialization objectSerialization)
        {
            VariableReference stringBuilder = new VariableReference(typeof(StringBuilder), "builder");
            yield return Declare(stringBuilder, New.Instance(typeof(StringBuilder)));

            VariableReference bicepOptions = new VariableReference(typeof(BicepModelReaderWriterOptions), "bicepOptions");
            yield return Declare(bicepOptions, new AsExpression(KnownParameters.Serializations.Options, typeof(BicepModelReaderWriterOptions)));

            VariableReference hasObjectOverride = new VariableReference(typeof(bool), "hasObjectOverride");
            VariableReference propertyOverrides = new VariableReference(typeof(IDictionary<string, string>), "propertyOverrides");
            yield return Declare(propertyOverrides, Null);
            yield return Declare(
                hasObjectOverride,
                And(
                    new BoolExpression(NotEqual(bicepOptions, Null)),
                    new BoolExpression(bicepOptions.Property(nameof(BicepModelReaderWriterOptions.ParameterOverrides))
                        .Invoke("TryGetValue", This, new KeywordExpression("out", propertyOverrides)))));

            var hasPropertyOverride = new VariableReference(typeof(bool), "hasPropertyOverride");
            yield return Declare(hasPropertyOverride, BoolExpression.False);
            var propertyOverride = new VariableReference(typeof(string), "propertyOverride");
            yield return Declare(propertyOverride, Null);

            var propertyOverrideVariables = new PropertyOverrideVariables(propertyOverrides, hasObjectOverride,
                hasPropertyOverride, propertyOverride);

            yield return EmptyLine;

            var stringBuilderExpression = new StringBuilderExpression(stringBuilder);

            yield return stringBuilderExpression.AppendLine("{");
            yield return EmptyLine;

            foreach (MethodBodyStatement methodBodyStatement in WriteProperties(objectSerialization.Properties, stringBuilderExpression, 2, objectSerialization.IsResourceData, propertyOverrideVariables))
            {
                yield return methodBodyStatement;
            }

            yield return stringBuilderExpression.AppendLine("}");
            yield return Return(BinaryDataExpression.FromString(stringBuilder.Invoke(nameof(StringBuilderParameter.ToString))));
        }

        private static IEnumerable<MethodBodyStatement> WriteProperties(
            IEnumerable<BicepPropertySerialization> properties,
            StringBuilderExpression stringBuilder,
            int spaces,
            bool isResourceData,
            PropertyOverrideVariables propertyOverrideVariables)
        {
            var indent = new string(' ', spaces);
            var propertyList = properties.ToList();
            BicepPropertySerialization? name = null;
            BicepPropertySerialization? location = null;
            BicepPropertySerialization? tags = null;
            BicepPropertySerialization? type = null;

            if (isResourceData)
            {
                name = propertyList.FirstOrDefault(p => p.SerializedName == "name");
                location = propertyList.FirstOrDefault(p => p.SerializedName == "location");
                tags = propertyList.FirstOrDefault(p => p.SerializedName == "tags");
                type = propertyList.FirstOrDefault(p => p.SerializedName == "type");
            }

            // The top level ResourceData properties should be written first in the payload. Type should not be included
            // as it will be put in the outer envelope.
            if (name != null)
            {
                foreach (MethodBodyStatement methodBodyStatement in WriteProperty(stringBuilder, spaces, name, indent, propertyOverrideVariables))
                {
                    yield return methodBodyStatement;
                };
            }

            if (location != null)
            {
                foreach (MethodBodyStatement methodBodyStatement in WriteProperty(stringBuilder, spaces, location, indent, propertyOverrideVariables))
                {
                    yield return methodBodyStatement;
                };
            }

            if (tags != null)
            {
                foreach (MethodBodyStatement methodBodyStatement in WriteProperty(stringBuilder, spaces, tags, indent, propertyOverrideVariables))
                {
                    yield return methodBodyStatement;
                };
            }

            foreach (BicepPropertySerialization property in propertyList)
            {
                if (property == name || property == location || property == tags || property == type)
                {
                    continue;
                }
                foreach (MethodBodyStatement methodBodyStatement in WriteProperty(stringBuilder, spaces, property, indent, propertyOverrideVariables))
                {
                    yield return methodBodyStatement;
                }
            }
        }

        private static IEnumerable<MethodBodyStatement> WriteProperty(
            StringBuilderExpression stringBuilder,
            int spaces,
            BicepPropertySerialization property,
            string indent,
            PropertyOverrideVariables propertyOverrideVariables)
        {
            if (property.ValueSerialization == null)
            {
                // Flattened property
                yield return new[]
                {
                    stringBuilder.Append($"{indent}{property.SerializedName}:"),
                    stringBuilder.AppendLine(" {"),
                    WriteProperties(property.PropertySerializations!, stringBuilder, spaces + 2, false, propertyOverrideVariables).ToArray(),
                    stringBuilder.AppendLine($"{indent}}}")
                };
            }
            else
            {
                foreach (MethodBodyStatement statement in SerializeProperty(stringBuilder, property, spaces, propertyOverrideVariables))
                {
                    yield return statement;
                }
            }
        }

        private static IEnumerable<MethodBodyStatement> WriteAppendChildObject()
        {
            VariableReference indent = new VariableReference(typeof(string), "indent");
            yield return Declare(indent, New.Instance(typeof(string), Literal(' '), Spaces));

            VariableReference data = new VariableReference(typeof(BinaryData), "data");

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
            var stringBuilder = new StringBuilderExpression(new ParameterReference(StringBuilderParameter));
            var line = new VariableReference(typeof(string), "line");
            var inMultilineString = new VariableReference(typeof(bool), "inMultilineString");
            yield return Declare(inMultilineString, BoolExpression.False);
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
        }

        private static IEnumerable<MethodBodyStatement> SerializeProperty(
            StringBuilderExpression stringBuilder,
            BicepPropertySerialization property,
            int spaces,
            PropertyOverrideVariables propertyOverrideVariables)
        {
            var indent = new string(' ', spaces);
            yield return Assign(
                propertyOverrideVariables.HasPropertyOverride,
                new BoolExpression(
                    And(
                        new BoolExpression(propertyOverrideVariables.HasObjectOverride),
                        new BoolExpression(propertyOverrideVariables.PropertyOverrides.Invoke("TryGetValue", Nameof(property.Value),
                            new KeywordExpression("out", propertyOverrideVariables.PropertyOverride))))));

            var propertyNameString = $"{indent}{property.SerializedName}: ";
            // we write the properties if there is a value or an override for that property
            yield return WrapInIsDefinedOrPropertyOverride(
                property,
                propertyOverrideVariables.HasPropertyOverride,
                WrapInIsNotEmptyOrPropertyOverride(
                    property,
                    propertyOverrideVariables.HasPropertyOverride,
                new[]
                    {
                        stringBuilder.Append(propertyNameString),
                        new IfElseStatement(
                            new BoolExpression(propertyOverrideVariables.HasPropertyOverride),
                            stringBuilder.AppendLine(new FormattableStringExpression($"{{0}}",propertyOverrideVariables.PropertyOverride)),
                            property.CustomSerializationMethodName is {} serializationMethodName
                                ? InvokeCustomBicepSerializationMethod(serializationMethodName, stringBuilder)
                                : SerializeExpression(stringBuilder, propertyNameString, property.ValueSerialization!, property.Value, spaces))
                    }));

            yield return EmptyLine;
        }

        private static MethodBodyStatement SerializeExpression(
            StringBuilderExpression stringBuilder,
            string propertyName,
            BicepSerialization valueSerialization,
            ValueExpression expression,
            int spaces,
            bool isArrayElement = false)
        {
            return valueSerialization switch
            {
                BicepArraySerialization array => SerializeArray(
                    stringBuilder,
                    propertyName,
                    array,
                    new EnumerableExpression(TypeFactory.GetElementType(array.ImplementationType), expression),
                    spaces),
                BicepDictionarySerialization dictionary => SerializeDictionary(
                    stringBuilder,
                    propertyName,
                    dictionary,
                    new DictionaryExpression(dictionary.Type.Arguments[0], dictionary.Type.Arguments[1], expression),
                    spaces),
                BicepValueSerialization value => SerializeValue(
                    stringBuilder,
                    propertyName,
                    value,
                    expression,
                    spaces,
                    isArrayElement),
                _ => throw new NotSupportedException()
            };
        }

        private static MethodBodyStatement SerializeArray(
            StringBuilderExpression stringBuilder,
            string propertyName,
            BicepArraySerialization arraySerialization,
            EnumerableExpression array,
            int spaces)
        {
            string indent = new string(' ', spaces);
            return new[]
            {
                stringBuilder.AppendLine("["),
                new ForeachStatement("item", array, out var item)
                {
                    CheckCollectionItemForNull(stringBuilder, arraySerialization.ValueSerialization, item),
                    SerializeExpression(stringBuilder, propertyName, arraySerialization.ValueSerialization, item, spaces, true)
                },
                stringBuilder.AppendLine($"{indent}]"),
            };
        }

        private static MethodBodyStatement SerializeDictionary(
            StringBuilderExpression stringBuilder,
            string propertyName,
            BicepDictionarySerialization dictionarySerialization,
            DictionaryExpression dictionary,
            int spaces)
        {
            var indent = new string(' ', spaces);

            return new[]
            {
                stringBuilder.AppendLine("{"),
                new ForeachStatement("item", dictionary, out KeyValuePairExpression keyValuePair)
                {
                    stringBuilder.Append(
                        new FormattableStringExpression(
                            $"{indent}{indent}'{{0}}': ", keyValuePair.Key)),
                    CheckCollectionItemForNull(stringBuilder, dictionarySerialization.ValueSerialization, keyValuePair.Value),
                    SerializeExpression(stringBuilder, propertyName, dictionarySerialization.ValueSerialization, keyValuePair.Value, spaces + 2)
                },
                stringBuilder.AppendLine($"{indent}}}")
            };
        }

        private static MethodBodyStatement SerializeValue(
            StringBuilderExpression stringBuilder,
            string propertyName,
            BicepValueSerialization valueSerialization,
            ValueExpression expression,
            int spaces,
            bool isArrayElement = false)
        {

            var indent = isArrayElement ? new string(' ', spaces + 2) : new string(' ', 0);

            if (valueSerialization.Type.IsFrameworkType)
            {
                return SerializeFrameworkTypeValue(stringBuilder, valueSerialization, expression, indent);
            }

            if (valueSerialization.Type.IsValueType)
            {
                switch (valueSerialization.Type.Implementation)
                {
                    case EnumType { IsNumericValueType: true } enumType:
                        return stringBuilder.AppendLine(
                            new EnumExpression(
                                enumType,
                                expression.NullableStructValue(valueSerialization.Type))
                                .Invoke(nameof(ToString)));
                    case EnumType enumType:
                        return stringBuilder.AppendLine(
                            new FormattableStringExpression(
                                $"{indent}'{{0}}'",
                                new EnumExpression(
                                        enumType,
                                        expression.NullableStructValue(valueSerialization.Type))
                                .ToSerial()));
                    default:
                        return stringBuilder.AppendLine(new FormattableStringExpression("{0}{1}",
                            expression.Invoke(nameof(ToString))));
                }
            }

            var currentIndent = new VariableReference(typeof(int), "currentIndent");
            var emptyObjectLength = new VariableReference(typeof(int), "emptyObjectLength");
            var length = new VariableReference(typeof(int), "length");

            // If the child object is empty, we will remove it and the property name from the bicep.

            int childObjectIndent = isArrayElement ? spaces + 2 : spaces;

            return new MethodBodyStatement[]
            {
                Declare(currentIndent, new ConstantExpression(new Constant(childObjectIndent, typeof(int)))),
                Declare(
                    emptyObjectLength,
                    new BinaryOperatorExpression("+",
                        new BinaryOperatorExpression("+",
                            new BinaryOperatorExpression("+",
                                    // 2 chars for open and close brace
                                    new ConstantExpression(new Constant(2, typeof(int))),
                                currentIndent),
                            // 2 new lines
                            new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine)).Property(nameof(string.Length))),
                        new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine)).Property(nameof(string.Length)))),
                Declare(length, stringBuilder.Property(nameof(StringBuilder.Length))),
                new InvokeStaticMethodStatement(
                    null,
                    AppendChildObjectMethodName,
                    new[]
                    {
                        stringBuilder, expression, KnownParameters.Serializations.Options,
                        currentIndent,
                        isArrayElement ? BoolExpression.True : BoolExpression.False
                    }),
                    new IfStatement(
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
                                Literal(propertyName).Property(nameof(string.Length))))
                    }
            };
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(
            StringBuilderExpression stringBuilder,
            BicepValueSerialization valueSerialization,
            ValueExpression expression,
            string indent)
        {
            var frameworkType = valueSerialization.Type.FrameworkType;
            if (frameworkType == typeof(Nullable<>))
            {
                frameworkType = valueSerialization.Type.Arguments[0].FrameworkType;
            }

            expression = expression.NullableStructValue(valueSerialization.Type);

            if (frameworkType == typeof(Uri))
            {
                return stringBuilder.AppendLine(
                    new FormattableStringExpression($"{indent}'{{0}}'",
                        expression.Property(nameof(Uri.AbsoluteUri))));
            }

            if (frameworkType == typeof(string))
            {
                return new IfElseStatement(
                    new BoolExpression(
                        expression.Invoke(nameof(string.Contains),
                            new TypeReference(typeof(Environment)).Property(nameof(Environment.NewLine)))),
                    new[]
                    {
                        stringBuilder.AppendLine($"{indent}'''"),
                        stringBuilder.AppendLine(new FormattableStringExpression("{0}'''", expression))
                    },
                    stringBuilder.AppendLine(new FormattableStringExpression($"{indent}'{{0}}'", expression)));
            }

            if (frameworkType == typeof(int))
            {
                return stringBuilder.AppendLine(new FormattableStringExpression($"{indent}{{0}}", expression));
            }

            if (frameworkType == typeof(TimeSpan))
            {
                return new[]
                {
                    Var(
                        "formattedTimeSpan",
                        new StringExpression(new InvokeStaticMethodExpression(typeof(TypeFormatters),
                            nameof(TypeFormatters.ToString), new[] { expression, Literal("P") })),
                        out var timeSpanVariable),
                    stringBuilder.AppendLine(new FormattableStringExpression(
                        $"{indent}'{{0}}'",
                        timeSpanVariable))
                };
            }

            if (frameworkType == typeof(DateTimeOffset) || frameworkType == typeof(DateTime))
            {
                return new[]
                {
                    Var(
                        "formattedDateTimeString",
                        new StringExpression(new InvokeStaticMethodExpression(typeof(TypeFormatters),
                            nameof(TypeFormatters.ToString), new[] { expression, Literal("o") })),
                        out var dateTimeStringVariable),
                    stringBuilder.AppendLine(new FormattableStringExpression(
                        $"{indent}'{{0}}'",
                        dateTimeStringVariable))
                };
            }

            if (frameworkType == typeof(bool))
            {
                return new[]
                {
                    Var(
                        "boolValue",
                        new StringExpression(new TernaryConditionalOperator(
                            Equal(expression, BoolExpression.True),
                            Literal("true"), Literal("false"))),
                        out var boolVariable),
                    stringBuilder.AppendLine(new FormattableStringExpression($"{indent}{{0}}", boolVariable))
                };
            }

            return stringBuilder.AppendLine(new FormattableStringExpression($"{indent}'{{0}}'", expression.Invoke(nameof(ToString))));
        }

        private static MethodBodyStatement CheckCollectionItemForNull(
            StringBuilderExpression stringBuilder,
            BicepSerialization valueSerialization,
            ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfStatement(Equal(value, Null)) { stringBuilder.Append("null"), Continue }
                : EmptyStatement;

        private static bool CollectionItemRequiresNullCheckInSerialization(BicepSerialization serialization) =>
            // nullable value type, like int?
            serialization is { IsNullable: true } and BicepValueSerialization { Type.IsValueType: true } ||
            // list or dictionary
            serialization is BicepArraySerialization or BicepDictionarySerialization ||
            // framework reference type, e.g. byte[]
            serialization is BicepValueSerialization { Type: { IsValueType: false, IsFrameworkType: true } };

        public static MethodBodyStatement WrapInIsDefinedOrPropertyOverride(BicepPropertySerialization serialization, ValueExpression propertyOverride, MethodBodyStatement statement)
        {
            return TypeFactory.IsCollectionType(serialization.Value.Type) && !TypeFactory.IsReadOnlyMemory(serialization.Value.Type)
                ? new IfStatement(Or(InvokeOptional.IsCollectionDefined(serialization.Value), new BoolExpression(propertyOverride))) { statement }
                : new IfStatement(Or(InvokeOptional.IsDefined(serialization.Value), new BoolExpression(propertyOverride))) { statement };
        }

        public static MethodBodyStatement WrapInIsNotEmptyOrPropertyOverride(BicepPropertySerialization serialization, ValueExpression propertyOverride, MethodBodyStatement statement)
        {
            return TypeFactory.IsCollectionType(serialization.Value.Type) && !TypeFactory.IsReadOnlyMemory(serialization.Value.Type)
                ? new IfStatement(Or(
                    new BoolExpression(InvokeStaticMethodExpression.Extension(typeof(Enumerable), nameof(Enumerable.Any), serialization.Value)),
                    new BoolExpression(propertyOverride)))
                {
                    statement
                }
                : statement;
        }

        private record struct PropertyOverrideVariables(ValueExpression PropertyOverrides, ValueExpression HasObjectOverride, ValueExpression HasPropertyOverride, ValueExpression PropertyOverride)
        {
        }
    }
}
