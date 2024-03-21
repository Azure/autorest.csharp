// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
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

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class BicepSerializationMethodsBuilder
    {
        private const string SerializeBicepMethodName = "SerializeBicep";
        private const string TransformFlattenedOverridesMethodName = "TransformFlattenedOverrides";
        private static Parameter BicepOptions = new Parameter("bicepOptions", null, typeof(BicepModelReaderWriterOptions), null, ValidationType.None, null);
        private static Parameter PropertyOverrides = new Parameter("propertyOverrides", null, typeof(IDictionary<string, string>), null, ValidationType.None, null);

        public static IEnumerable<Method> BuildPerTypeBicepSerializationMethods(BicepObjectSerialization objectSerialization)
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
                WriteSerializeBicep(objectSerialization).AsStatement());

            if (objectSerialization.FlattenedProperties.Count > 0)
            {
                yield return new Method(
                    new MethodSignature(
                        TransformFlattenedOverridesMethodName,
                        null,
                        null,
                        MethodSignatureModifiers.Private,
                        null,
                        null,
                        new Parameter[] { BicepOptions, PropertyOverrides }),
                    WriteTransformFlattenedOverrides(objectSerialization));
            }
        }

        private static MethodBodyStatement WriteTransformFlattenedOverrides(BicepObjectSerialization objectSerialization)
        {
            if (objectSerialization.FlattenedProperties.Count == 0)
            {
                return EmptyStatement;
            }

            var bicepOptions = new ParameterReference(BicepOptions);
            var objectOverrides = bicepOptions.Property(nameof(BicepModelReaderWriterOptions.PropertyOverrides));
            var propertyOverrides = new ParameterReference(PropertyOverrides);

            var forLoop = new ForeachStatement(
                "item",
                new EnumerableExpression(
                    typeof(IDictionary<string, string>),
                    new InvokeStaticMethodExpression(typeof(Enumerable), nameof(Enumerable.ToList),
                        new[] { propertyOverrides })),
                out var item);
            var switchStatement = new SwitchStatement(item.Property("Key"));
            forLoop.Add(switchStatement);

            foreach (var property in objectSerialization.FlattenedProperties)
            {
                var stack = property.BuildHierarchyStack();
                var instanceName = stack.Last().Declaration.Name;
                var childPropertyName = stack.Pop().Declaration.Name;
                var propertyDictionary = new VariableReference(typeof(Dictionary<string, string>), "propertyDictionary");

                switchStatement.Add(
                    new SwitchCase(Literal(property.Declaration.Name), new MethodBodyStatement[]
                    {
                        Declare(propertyDictionary, New.Instance(typeof(Dictionary<string, string>))),
                        propertyDictionary.Invoke(
                            "Add",
                            Literal(childPropertyName),
                            item.Property("Value")).ToStatement(),
                        objectOverrides.Invoke(
                            "Add",
                            This.Property(instanceName),
                            propertyDictionary).ToStatement(),
                        new KeywordStatement("break", null)
                }));
            }
            switchStatement.Add(SwitchCase.Default(Continue));

            return forLoop;
        }

        public static SwitchCase BuildBicepWriteSwitchCase(BicepObjectSerialization bicep, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(
                Serializations.BicepFormat,
                Return(
                    new InvokeInstanceMethodExpression(
                        null,
                        new MethodSignature(
                            $"SerializeBicep",
                            null,
                            null,
                            MethodSignatureModifiers.Private,
                            typeof(BinaryData),
                            null,
                            new[]
                            {
                                KnownParameters.Serializations.Options
                            }),
                        new ValueExpression[]
                        {
                            options
                        })));
        }

        private static List<MethodBodyStatement> WriteSerializeBicep(BicepObjectSerialization objectSerialization)
        {
            var statements = new List<MethodBodyStatement>();
            VariableReference stringBuilder = new VariableReference(typeof(StringBuilder), "builder");
            statements.Add(Declare(stringBuilder, New.Instance(typeof(StringBuilder))));

            VariableReference bicepOptions = new VariableReference(typeof(BicepModelReaderWriterOptions), "bicepOptions");
            statements.Add(Declare(bicepOptions, new AsExpression(KnownParameters.Serializations.Options, typeof(BicepModelReaderWriterOptions))));

            VariableReference hasObjectOverride = new VariableReference(typeof(bool), "hasObjectOverride");
            VariableReference propertyOverrides = new VariableReference(typeof(IDictionary<string, string>), "propertyOverrides");
            statements.Add(Declare(propertyOverrides, Null));
            statements.Add(Declare(
                hasObjectOverride,
                And(
                    new BoolExpression(NotEqual(bicepOptions, Null)),
                    new BoolExpression(bicepOptions.Property(nameof(BicepModelReaderWriterOptions.PropertyOverrides))
                        .Invoke("TryGetValue", This, new KeywordExpression("out", propertyOverrides))))));
            var hasPropertyOverride = new VariableReference(typeof(bool), "hasPropertyOverride");
            statements.Add(Declare(hasPropertyOverride, BoolExpression.False));
            var propertyOverride = new VariableReference(typeof(string), "propertyOverride");
            statements.Add(Declare(propertyOverride, Null));

            statements.Add(EmptyLine);

            if (objectSerialization.FlattenedProperties.Count > 0)
            {
                statements.Add(new IfStatement(new BoolExpression(NotEqual(PropertyOverrides, Null)))
                {
                    This.Invoke(TransformFlattenedOverridesMethodName, bicepOptions, propertyOverrides)
                        .ToStatement()
                });
                statements.Add(EmptyLine);
            }

            var propertyOverrideVariables = new PropertyOverrideVariables(propertyOverrides, hasObjectOverride,
                hasPropertyOverride, propertyOverride);

            statements.Add(EmptyLine);

            var stringBuilderExpression = new StringBuilderExpression(stringBuilder);
            statements.Add(stringBuilderExpression.AppendLine("{"));
            statements.Add(EmptyLine);
            foreach (MethodBodyStatement methodBodyStatement in WriteProperties(objectSerialization.Properties, stringBuilderExpression, 2, objectSerialization.IsResourceData, propertyOverrideVariables))
            {
                statements.Add(methodBodyStatement);
            }
            statements.Add(stringBuilderExpression.AppendLine("}"));
            statements.Add(Return(BinaryDataExpression.FromString(stringBuilder.Invoke(nameof(StringBuilder.ToString)))));

            return statements;
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

            var formattedPropertyName = $"{indent}{property.SerializedName}: ";
            // we write the properties if there is a value or an override for that property
            yield return WrapInIsDefinedOrPropertyOverride(
                property,
                propertyOverrideVariables.HasPropertyOverride,
                WrapInIsNotEmptyOrPropertyOverride(
                    property,
                    propertyOverrideVariables.HasPropertyOverride,
                new[]
                    {
                        stringBuilder.Append(formattedPropertyName),
                        new IfElseStatement(
                            new BoolExpression(propertyOverrideVariables.HasPropertyOverride),
                            stringBuilder.AppendLine(new FormattableStringExpression($"{{0}}",propertyOverrideVariables.PropertyOverride)),
                            property.CustomSerializationMethodName is {} serializationMethodName
                                ? InvokeCustomBicepSerializationMethod(serializationMethodName, stringBuilder)
                                : SerializeExpression(stringBuilder, formattedPropertyName, property.ValueSerialization!, property.Value, spaces))
                    }));

            yield return EmptyLine;
        }

        private static MethodBodyStatement SerializeExpression(
            StringBuilderExpression stringBuilder,
            string formattedPropertyName,
            BicepSerialization valueSerialization,
            ValueExpression expression,
            int spaces,
            bool isArrayElement = false)
        {
            return valueSerialization switch
            {
                BicepArraySerialization array => SerializeArray(
                    stringBuilder,
                    formattedPropertyName,
                    array,
                    new EnumerableExpression(TypeFactory.GetElementType(array.ImplementationType), expression),
                    spaces),
                BicepDictionarySerialization dictionary => SerializeDictionary(
                    stringBuilder,
                    formattedPropertyName,
                    dictionary,
                    new DictionaryExpression(dictionary.Type.Arguments[0], dictionary.Type.Arguments[1], expression),
                    spaces),
                BicepValueSerialization value => SerializeValue(
                    stringBuilder,
                    formattedPropertyName,
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
            string formattedPropertyName,
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

            return new MethodBodyStatement[]
            {
                BicepSerializationTypeProvider.Instance.AppendChildObject(
                    stringBuilder,
                    expression,
                    new ConstantExpression(new Constant(isArrayElement ? spaces + 2 : spaces, typeof(int))),
                        isArrayElement ? BoolExpression.True : BoolExpression.False,
                        Literal(formattedPropertyName))
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
            if (serialization.Value.Type is { IsNullable: false, IsValueType: true })
            {
                    return statement;
            }

            return TypeFactory.IsCollectionType(serialization.Value.Type) && !TypeFactory.IsReadOnlyMemory(serialization.Value.Type)
                ? new IfStatement(Or(InvokeOptional.IsCollectionDefined(serialization.Value), new BoolExpression(propertyOverride))) { statement }
                : new IfStatement(Or(OptionalTypeProvider.Instance.IsDefined(serialization.Value), new BoolExpression(propertyOverride))) { statement };
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
