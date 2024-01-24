﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal class ExampleMockValueBuilder
    {
        public const string ShortVersionMockExampleKey = "ShortVersion";
        public const string MockExampleAllParameterKey = "AllParameters";

        private static readonly string EndpointMockValue = Configuration.ApiTypes.EndPointSampleValue;

        private readonly static ConcurrentDictionary<InputType, InputExampleValue> _cache = new();

        public static InputClientExample BuildClientExample(InputClient client, bool useAllParameters)
        {
            _cache.Clear();
            var clientParameterExamples = new List<InputParameterExample>();
            foreach (var parameter in client.Parameters)
            {
                if (!useAllParameters && !parameter.IsRequired)
                {
                    continue;
                }
                var parameterExample = BuildParameterExample(parameter, useAllParameters);
                clientParameterExamples.Add(parameterExample);
            }

            return new(client, clientParameterExamples);
        }

        public static InputOperationExample BuildOperationExample(InputOperation operation, bool useAllParameters)
        {
            _cache.Clear();

            var parameterExamples = new List<InputParameterExample>();
            foreach (var parameter in operation.Parameters)
            {
                if (!useAllParameters && !parameter.IsRequired)
                {
                    continue;
                }
                var parameterExample = BuildParameterExample(parameter, useAllParameters);
                parameterExamples.Add(parameterExample);
            }

            return new(operation, parameterExamples);
        }

        private static InputParameterExample BuildParameterExample(InputParameter parameter, bool useAllParameters)
        {
            // if the parameter is constant, we just put the constant into the example value instead of mocking a new one
            if (parameter.Kind == InputOperationParameterKind.Constant)
            {
                InputExampleValue value;
                if (parameter.DefaultValue != null)
                {
                    // when it is constant, it could have DefaultValue
                    value = InputExampleValue.Value(parameter.Type, parameter.DefaultValue.Value);
                }
                else if (parameter.Type is InputUnionType unionType && unionType.UnionItemTypes.First() is InputLiteralType literalType)
                {
                    // or it could be a union of literal types
                    value = InputExampleValue.Value(parameter.Type, literalType.Value);
                }
                else
                {
                    // fallback to null
                    value = InputExampleValue.Null(parameter.Type);
                }
                return new(parameter, value);
            }

            // if the parameter is endpoint
            if (parameter.IsEndpoint)
            {
                var value = InputExampleValue.Value(parameter.Type, EndpointMockValue);
                return new(parameter, value);
            }

            if (parameter.DefaultValue != null)
            {
                var value = InputExampleValue.Value(parameter.Type, parameter.DefaultValue.Value);
                return new(parameter, value);
            }

            var exampleValue = BuildExampleValue(parameter.Type, parameter.Name, useAllParameters, new HashSet<InputModelType>());
            return new(parameter, exampleValue);
        }

        private static InputExampleValue BuildExampleValue(InputType type, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels) => type switch
        {
            InputListType listType => BuildListExampleValue(listType, hint, useAllParameters, visitedModels),
            InputDictionaryType dictionaryType => BuildDictionaryExampleValue(dictionaryType, hint, useAllParameters, visitedModels),
            InputEnumType enumType => BuildEnumExampleValue(enumType),
            InputPrimitiveType primitiveType => BuildPrimitiveExampleValue(primitiveType, hint),
            InputLiteralType literalType => InputExampleValue.Value(literalType, literalType.Value),
            InputModelType modelType => BuildModelExampleValue(modelType, useAllParameters, visitedModels),
            InputUnionType unionType => BuildExampleValue(unionType.UnionItemTypes.First(), hint, useAllParameters, visitedModels),
            _ => InputExampleValue.Object(type, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildListExampleValue(InputListType listType, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            var exampleElementValue = BuildExampleValue(listType.ElementType, hint, useAllParameters, visitedModels);

            return InputExampleValue.List(listType, new[] { exampleElementValue });
        }

        private static InputExampleValue BuildDictionaryExampleValue(InputDictionaryType dictionaryType, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            var exampleValue = BuildExampleValue(dictionaryType.ValueType, hint, useAllParameters, visitedModels);

            return InputExampleValue.Object(dictionaryType, new Dictionary<string, InputExampleValue>
            {
                ["key"] = exampleValue
            });
        }

        private static InputExampleValue BuildEnumExampleValue(InputEnumType enumType)
        {
            var enumValue = enumType.AllowedValues.First();
            return InputExampleValue.Value(enumType, enumValue.Value);
        }

        private static InputExampleValue BuildPrimitiveExampleValue(InputPrimitiveType primitiveType, string? hint) => primitiveType.Kind switch
        {
            InputTypePrimitiveKind.Stream => InputExampleValue.Stream(primitiveType, "<filePath>"),
            InputTypePrimitiveKind.Boolean => InputExampleValue.Value(primitiveType, true),
            InputTypePrimitiveKind.Date => InputExampleValue.Value(primitiveType, "2022-05-10"),
            InputTypePrimitiveKind.DateTime => InputExampleValue.Value(primitiveType, "2022-05-10T14:57:31.2311892-04:00"),
            InputTypePrimitiveKind.DateTimeRFC1123 => InputExampleValue.Value(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypePrimitiveKind.DateTimeRFC3339 => InputExampleValue.Value(primitiveType, "2022-05-10T18:57:31.2311892Z"),
            InputTypePrimitiveKind.DateTimeRFC7231 => InputExampleValue.Value(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypePrimitiveKind.DateTimeUnix => InputExampleValue.Value(primitiveType, 1652209051),
            InputTypePrimitiveKind.Float32 => InputExampleValue.Value(primitiveType, 123.45f),
            InputTypePrimitiveKind.Float64 => InputExampleValue.Value(primitiveType, 123.45d),
            InputTypePrimitiveKind.Float128 => InputExampleValue.Value(primitiveType, 123.45m),
            InputTypePrimitiveKind.Guid => InputExampleValue.Value(primitiveType, "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"),
            InputTypePrimitiveKind.Int32 => InputExampleValue.Value(primitiveType, 1234),
            InputTypePrimitiveKind.Int64 => InputExampleValue.Value(primitiveType, 1234L),
            InputTypePrimitiveKind.String => string.IsNullOrWhiteSpace(hint) ? InputExampleValue.Value(primitiveType, "<String>") : InputExampleValue.Value(primitiveType, $"<{hint}>"),
            InputTypePrimitiveKind.DurationISO8601 => InputExampleValue.Value(primitiveType, "PT1H23M45S"),
            InputTypePrimitiveKind.DurationConstant => InputExampleValue.Value(primitiveType, "01:23:45"),
            InputTypePrimitiveKind.Time => InputExampleValue.Value(primitiveType, "01:23:45"),
            InputTypePrimitiveKind.Uri => InputExampleValue.Value(primitiveType, "http://localhost:3000"),
            InputTypePrimitiveKind.DurationSeconds => InputExampleValue.Value(primitiveType, 10),
            InputTypePrimitiveKind.DurationSecondsFloat => InputExampleValue.Value(primitiveType, 10f),
            _ => InputExampleValue.Object(primitiveType, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildModelExampleValue(InputModelType model, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            if (visitedModels.Contains(model))
                return InputExampleValue.Null(model);

            var dict = new Dictionary<string, InputExampleValue>();
            var result = InputExampleValue.Object(model, dict);
            visitedModels.Add(model);
            // if this model has a discriminator, we should return a derived type
            if (model.DiscriminatorPropertyName != null)
            {
                var derived = model.DerivedModels.FirstOrDefault();
                if (derived is null)
                {
                    return InputExampleValue.Null(model);
                }
                else
                {
                    model = derived;
                }
            }
            // then, we just iterate all the properties
            foreach (var modelOrBase in model.GetSelfAndBaseModels())
            {
                foreach (var property in modelOrBase.Properties)
                {
                    if (property.IsReadOnly)
                        continue;

                    if (!useAllParameters && !property.IsRequired)
                        continue;

                    // this means a property is defined both on the base and derived type, we skip other occurrences only keep the first
                    // which means we only keep the property defined in the lowest layer (derived types)
                    if (dict.ContainsKey(property.SerializedName))
                        continue;

                    InputExampleValue exampleValue;
                    if (property.IsDiscriminator)
                    {
                        exampleValue = InputExampleValue.Value(property.Type, model.DiscriminatorValue!);
                    }
                    else
                    {
                        exampleValue = BuildExampleValue(property.Type, property.SerializedName, useAllParameters, visitedModels);
                    }

                    dict.Add(property.SerializedName, exampleValue);
                }
            }

            return result;
        }
    }
}
