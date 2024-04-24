// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using Constant = AutoRest.CSharp.Output.Models.Shared.Constant;
using ConstantExpression = AutoRest.CSharp.Common.Output.Expressions.ValueExpressions.ConstantExpression;
using Parameter = AutoRest.CSharp.Output.Models.Shared.Parameter;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class BicepSerializationMethodsBuilder
    {
        private const string SerializeBicepMethodName = "SerializeBicep";

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
        }

        private static MethodBodyStatement WriteFlattenedPropertiesWithOverrides(string wirePath, StringBuilderExpression stringBuilder, ValueExpression propertyOverride, int spaces)
        {
            var parts = wirePath.Split('.');

            var body = new List<MethodBodyStatement>();

            // opening brace
            body.Add(stringBuilder.AppendLine("{"));

            // nested property names and opening braces
            for (int i = 1; i < parts.Length; i++)
            {
                spaces += 2;
                var indent = new string(' ', spaces);
                if (i == parts.Length - 1)
                {
                    body.Add(stringBuilder.Append($"{indent}{parts[i]}: "));
                }
                else
                {
                    body.Add(stringBuilder.AppendLine($"{indent}{parts[i]}: {{"));
                }
            }

            // value
            body.Add(stringBuilder.AppendLine(propertyOverride));

            // closing braces
            for (int i = parts.Length - 1; i >= 1; i--)
            {
                spaces -= 2;
                var indent = new string(' ', spaces);
                body.Add(stringBuilder.AppendLine($"{indent}}}"));
            }

            return body;
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

            var propertyOverrideVariables = new PropertyOverrideVariables(
                bicepOptions,
                propertyOverrides,
                hasObjectOverride,
                hasPropertyOverride,
                propertyOverride,
                objectSerialization);

            statements.Add(EmptyLine);

            var stringBuilderExpression = new StringBuilderExpression(stringBuilder);
            statements.Add(stringBuilderExpression.AppendLine("{"));
            statements.Add(EmptyLine);
            foreach (MethodBodyStatement methodBodyStatement in WriteProperties(objectSerialization.Serializations, stringBuilderExpression, 2, objectSerialization.IsResourceData, propertyOverrideVariables))
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
                // Flattened property - this is different than the other flattening scenario where models with a single property are flattened
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
            bool isFlattened = false;
            bool wasFlattened = false;
            string? wirePath = null;
            string? childPropertyName = null;

            // is the property that we are trying to serialize a flattened property? If so, we need to use the name of the childmost property for overrides.
            ValueExpression overridePropertyName = Nameof(property.Value);
            string? previouslyFlattenedProperty = null;
            if (property.Property!.FlattenedProperty != null)
            {
                overridePropertyName = Literal(property.Property!.FlattenedProperty.Declaration.Name);
                isFlattened = true;
            }
            else if (WasPreviouslyFlattened(propertyOverrideVariables.serialization, property.Property, out previouslyFlattenedProperty, out wirePath))
            {
                wasFlattened = true;
                childPropertyName = ((SerializableObjectType)property.Property.ValueType.Implementation).Properties
                    .Single(
                        // find the property of the child object that corresponds to the next piece of the wirepath
                        p => p.GetWirePath() == string.Join(".", wirePath!.Split('.').Skip(1))).Declaration.Name;
            }

            yield return Assign(
                propertyOverrideVariables.HasPropertyOverride,
                new BoolExpression(
                    And(
                        new BoolExpression(propertyOverrideVariables.HasObjectOverride),
                        new BoolExpression(propertyOverrideVariables.PropertyOverrides.Invoke("TryGetValue", overridePropertyName,
                            new KeywordExpression("out", propertyOverrideVariables.PropertyOverride))))));

            var formattedPropertyName = $"{indent}{property.SerializedName}: ";
            var propertyDictionary = new VariableReference(typeof(Dictionary<string, string>), "propertyDictionary");

            // we write the properties if there is a value or an override for that property

            wirePath = isFlattened ? property.Property.FlattenedProperty!.GetWirePath() : wirePath;


            yield return new IfElseStatement(
                new IfStatement(new BoolExpression(propertyOverrideVariables.HasPropertyOverride))
                {
                    stringBuilder.Append(formattedPropertyName),
                    new[]
                    {
                        isFlattened
                            ? WriteFlattenedPropertiesWithOverrides(wirePath!, stringBuilder, propertyOverrideVariables.PropertyOverride, spaces)
                            : stringBuilder.AppendLine(propertyOverrideVariables.PropertyOverride)
                    }
                },
                ConstructElseStatement());

            MethodBodyStatement ConstructElseStatement()
            {
                if (wasFlattened)
                {
                    return new IfElseStatement(
                        new IfStatement(
                            new BoolExpression(
                                And(
                                    new BoolExpression(propertyOverrideVariables.HasObjectOverride),
                                    new BoolExpression(propertyOverrideVariables.PropertyOverrides.Invoke("TryGetValue",
                                        Literal(previouslyFlattenedProperty),
                                        new KeywordExpression("out", propertyOverrideVariables.PropertyOverride))))))
                        {
                            stringBuilder.Append(formattedPropertyName),
                            new IfElseStatement(
                                Equal(property.Value, Null),
                                WriteFlattenedPropertiesWithOverrides(wirePath!, stringBuilder,
                                    propertyOverrideVariables.PropertyOverride, spaces),
                                new[]
                                {
                                    Declare(propertyDictionary, New.Instance(typeof(Dictionary<string, string>))),
                                    propertyDictionary.Invoke(
                                        "Add",
                                        Literal(childPropertyName),
                                        propertyOverrideVariables.PropertyOverride).ToStatement(),
                                    propertyOverrideVariables.BicepOptions
                                        .Property(nameof(BicepModelReaderWriterOptions.PropertyOverrides)).Invoke(
                                            "Add",
                                            property.Value,
                                            propertyDictionary).ToStatement(),
                                    InvokeAppendChildObject(stringBuilder, property, spaces, formattedPropertyName)
                                })
                        },
                        WrapInIsDefined(property,
                            new[]
                            {
                                WrapInIsNotEmpty(property,
                                    new[]
                                    {
                                        stringBuilder.Append(formattedPropertyName),
                                        InvokeAppendChildObject(stringBuilder, property, spaces,
                                            formattedPropertyName)
                                    })
                            })
                    );
                }

                return WrapInIsDefined(property,
                    new[]
                    {
                        WrapInIsNotEmpty(property,
                            new[]
                            {
                                stringBuilder.Append(formattedPropertyName),
                                InvokeAppendChildObject(stringBuilder, property, spaces,
                                    formattedPropertyName)
                            })
                    });
            }

            yield return EmptyLine;
        }

        private static MethodBodyStatement InvokeAppendChildObject(StringBuilderExpression stringBuilder, BicepPropertySerialization property, int spaces, string formattedPropertyName)
        {
            return property.CustomSerializationMethodName is {} serializationMethodName
                ? InvokeCustomBicepSerializationMethod(serializationMethodName, stringBuilder)
                : SerializeExpression(stringBuilder, formattedPropertyName, property.ValueSerialization!, property.Value, spaces);
        }


        private static bool WasPreviouslyFlattened(BicepObjectSerialization serialization, ObjectTypeProperty property, out string? previouslyFlattenedProperty, out string? wirePath)
        {
            previouslyFlattenedProperty = null;
            wirePath = null;

            if (serialization.CustomizationType == null)
            {
                return false;
            }

            string? path = null;
            var previous = serialization.CustomizationType.GetMembers().SingleOrDefault(
                m => m.Kind == SymbolKind.Property && m.GetAttributes()
                    .Any(a =>
                    {
                        if (a.AttributeClass?.Name == "WirePath"
                            && a.ApplicationSyntaxReference != null)
                        {
                            // Get the path from the attribute. We can't use ConstructorArguments because the WirePath attribute is internal
                            // so Roslyn doesn't populate them.
                            path =
                                a.ApplicationSyntaxReference.SyntaxTree.ToString()
                                    .AsSpan()
                                    .Slice(a.ApplicationSyntaxReference.Span.Start,
                                        a.ApplicationSyntaxReference.Span.Length).ToString().Split('(', ')')[1];

                            // strip enclosing quotes
                            path = path.Substring(1, path.Length - 2);
                            if (path.Contains($"{property.GetWirePath()}."))
                            {
                                return true;
                            }
                        }

                        return false;
                    }));

            wirePath = path;
            previouslyFlattenedProperty = previous?.Name;
            return previouslyFlattenedProperty != null;
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
                    new EnumerableExpression(array.ImplementationType.ElementType, expression),
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

        public static MethodBodyStatement WrapInIsDefined(BicepPropertySerialization serialization, MethodBodyStatement statement)
        {
            if (serialization.Value.Type is { IsNullable: false, IsValueType: true })
            {
                    return statement;
            }

            return serialization.Value.Type.IsCollection && !serialization.Value.Type.IsReadOnlyMemory
                ? new IfStatement(InvokeOptional.IsCollectionDefined(serialization.Value)) { statement }
                : new IfStatement(OptionalTypeProvider.Instance.IsDefined(serialization.Value)) { statement };
        }

        public static MethodBodyStatement WrapInIsNotEmpty(BicepPropertySerialization serialization, MethodBodyStatement statement)
        {
            return serialization.Value.Type.IsCollection && !serialization.Value.Type.IsReadOnlyMemory
                ? new IfStatement(
                    new BoolExpression(InvokeStaticMethodExpression.Extension(typeof(Enumerable), nameof(Enumerable.Any), serialization.Value)))
                {
                    statement
                }
                : statement;
        }

        private record struct PropertyOverrideVariables(
            ValueExpression BicepOptions,
            ValueExpression PropertyOverrides,
            ValueExpression HasObjectOverride,
            ValueExpression HasPropertyOverride,
            ValueExpression PropertyOverride,
            BicepObjectSerialization serialization)
        {
        }
    }
}
