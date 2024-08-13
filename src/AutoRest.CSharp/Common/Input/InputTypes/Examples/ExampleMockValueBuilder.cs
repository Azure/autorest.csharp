﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.InputTypes;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal class ExampleMockValueBuilder
    {
        public const string ShortVersionMockExampleKey = "ShortVersion";
        public const string MockExampleAllParameterKey = "AllParameters";

        private static readonly string EndpointMockValue = Configuration.ApiTypes.EndPointSampleValue;

        private readonly static ConcurrentDictionary<InputType, InputTypeExample> _cache = new();

        public static IReadOnlyList<InputHttpOperationExample> BuildOperationExamples(InputOperation operation)
        {
            return new[]
            {
                BuildOperationExample(operation, ShortVersionMockExampleKey, false),
                BuildOperationExample(operation, MockExampleAllParameterKey, true)
            };
        }

        private static InputHttpOperationExample BuildOperationExample(InputOperation operation, string name, bool useAllParameters)
        {
            var parameterExamples = new List<InputParameterExample>(operation.Parameters.Count);
            foreach (var  parameter in operation.Parameters)
            {
                if (!useAllParameters && !parameter.IsRequired)
                {
                    continue;
                }
                var parameterExample = BuildParameterExample(parameter, useAllParameters);
                parameterExamples.Add(parameterExample);
            }

            return new(name, null, string.Empty, parameterExamples);
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
                InputTypeExample value;
                if (parameter.Type is InputLiteralType { Value: not null } literalValue)
                {
                    value = InputTypeExample.Value(parameter.Type, literalValue.Value);
                }
                else if (parameter.DefaultValue != null)
                {
                    // when it is constant, it could have DefaultValue
                    value = InputTypeExample.Value(parameter.Type, parameter.DefaultValue.Value);
                }
                else if (parameter.Type is InputUnionType unionType && unionType.VariantTypes[0] is InputLiteralType literalType)
                {
                    // or it could be a union of literal types
                    value = InputTypeExample.Value(parameter.Type, literalType.Value);
                }
                else if (parameter.Type is InputEnumType enumType && enumType.Values[0].Value is { } enumValue)
                {
                    // or it could be an enum of a few values
                    value = InputTypeExample.Value(parameter.Type, enumValue);
                }
                else
                {
                    // fallback to null
                    value = InputTypeExample.Null(parameter.Type);
                }
                return new(parameter, value);
            }

            // if the parameter is endpoint
            if (parameter.IsEndpoint)
            {
                var value = InputTypeExample.Value(parameter.Type, EndpointMockValue);
                return new(parameter, value);
            }

            if (parameter.DefaultValue != null)
            {
                var value = InputTypeExample.Value(parameter.Type, parameter.DefaultValue.Value);
                return new(parameter, value);
            }

            var exampleValue = BuildExampleValue(parameter.Type, parameter.Name, useAllParameters, new HashSet<InputModelType>());
            return new(parameter, exampleValue);
        }

        private static InputTypeExample BuildExampleValue(InputType type, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels) => type switch
        {
            InputListType listType => BuildListExampleValue(listType, hint, useAllParameters, visitedModels),
            InputDictionaryType dictionaryType => BuildDictionaryExampleValue(dictionaryType, hint, useAllParameters, visitedModels),
            InputEnumType enumType => BuildEnumExampleValue(enumType),
            InputPrimitiveType primitiveType => BuildPrimitiveExampleValue(primitiveType, hint),
            InputLiteralType literalType => InputTypeExample.Value(literalType, literalType.Value),
            InputModelType modelType => BuildModelExampleValue(modelType, useAllParameters, visitedModels),
            InputUnionType unionType => BuildExampleValue(unionType.VariantTypes[0], hint, useAllParameters, visitedModels),
            InputNullableType nullableType => BuildExampleValue(nullableType.Type, hint, useAllParameters, visitedModels),
            InputDateTimeType dateTimeType => BuildDateTimeExampleValue(dateTimeType),
            InputDurationType durationType => BuildDurationExampleValue(durationType),
            _ => InputTypeExample.Object(type, new Dictionary<string, InputTypeExample>())
        };

        private static InputTypeExample BuildListExampleValue(InputListType listType, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            var exampleElementValue = BuildExampleValue(listType.ValueType, hint, useAllParameters, visitedModels);

            return InputTypeExample.List(listType, new[] { exampleElementValue });
        }

        private static InputTypeExample BuildDictionaryExampleValue(InputDictionaryType dictionaryType, string? hint, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            var exampleValue = BuildExampleValue(dictionaryType.ValueType, hint, useAllParameters, visitedModels);

            return InputTypeExample.Object(dictionaryType, new Dictionary<string, InputTypeExample>
            {
                ["key"] = exampleValue
            });
        }

        private static InputTypeExample BuildEnumExampleValue(InputEnumType enumType)
        {
            var enumValue = enumType.Values.First();
            return InputTypeExample.Value(enumType, enumValue.Value);
        }

        private static InputTypeExample BuildPrimitiveExampleValue(InputPrimitiveType primitiveType, string? hint) => primitiveType.Kind switch
        {
            InputPrimitiveTypeKind.Stream => InputTypeExample.Stream(primitiveType, "<filePath>"),
            InputPrimitiveTypeKind.Boolean => InputTypeExample.Value(primitiveType, true),
            InputPrimitiveTypeKind.PlainDate => InputTypeExample.Value(primitiveType, "2022-05-10"),
            InputPrimitiveTypeKind.Float32 => InputTypeExample.Value(primitiveType, 123.45f),
            InputPrimitiveTypeKind.Float64 => InputTypeExample.Value(primitiveType, 123.45d),
            InputPrimitiveTypeKind.Decimal or InputPrimitiveTypeKind.Decimal128 => InputTypeExample.Value(primitiveType, 123.45m),
            InputPrimitiveTypeKind.Int8 => InputTypeExample.Value(primitiveType, (sbyte)123),
            InputPrimitiveTypeKind.UInt8 => InputTypeExample.Value(primitiveType, (byte)123),
            InputPrimitiveTypeKind.Int32 => InputTypeExample.Value(primitiveType, 1234),
            InputPrimitiveTypeKind.Int64 => InputTypeExample.Value(primitiveType, 1234L),
            InputPrimitiveTypeKind.SafeInt => InputTypeExample.Value(primitiveType, 1234L),
            InputPrimitiveTypeKind.String => primitiveType.CrossLanguageDefinitionId switch
            {
                InputPrimitiveType.UuidId => InputTypeExample.Value(primitiveType, "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"),
                _ => string.IsNullOrWhiteSpace(hint) ? InputTypeExample.Value(primitiveType, "<String>") : InputTypeExample.Value(primitiveType, $"<{hint}>")
            },
            InputPrimitiveTypeKind.PlainTime => InputTypeExample.Value(primitiveType, "01:23:45"),
            InputPrimitiveTypeKind.Url => InputTypeExample.Value(primitiveType, "http://localhost:3000"),
            _ => InputTypeExample.Object(primitiveType, new Dictionary<string, InputTypeExample>())
        };

        private static InputTypeExample BuildDateTimeExampleValue(InputDateTimeType dateTimeType) => dateTimeType.Encode switch
        {
            DateTimeKnownEncoding.Rfc7231 => InputTypeExample.Value(dateTimeType.WireType, "Tue, 10 May 2022 18:57:31 GMT"),
            DateTimeKnownEncoding.Rfc3339 => InputTypeExample.Value(dateTimeType.WireType, "2022-05-10T18:57:31.2311892Z"),
            DateTimeKnownEncoding.UnixTimestamp => InputTypeExample.Value(dateTimeType.WireType, 1652209051),
            _ => InputTypeExample.Null(dateTimeType)
        };

        private static InputTypeExample BuildDurationExampleValue(InputDurationType durationType) => durationType.Encode switch
        {
            DurationKnownEncoding.Iso8601 => InputTypeExample.Value(durationType.WireType, "PT1H23M45S"),
            DurationKnownEncoding.Seconds => durationType.WireType.Kind switch
            {
                InputPrimitiveTypeKind.Int32 => InputTypeExample.Value(durationType.WireType, 10),
                InputPrimitiveTypeKind.Float or InputPrimitiveTypeKind.Float32 => InputTypeExample.Value(durationType.WireType, 10f),
                _ => InputTypeExample.Value(durationType.WireType, 3.141592)
            },
            _ => InputTypeExample.Null(durationType)
        };

        private static InputTypeExample BuildModelExampleValue(InputModelType model, bool useAllParameters, HashSet<InputModelType> visitedModels)
        {
            if (visitedModels.Contains(model))
                return InputTypeExample.Null(model);

            var dict = new Dictionary<string, InputTypeExample>();
            var result = InputTypeExample.Object(model, dict);
            visitedModels.Add(model);
            // if this model has a discriminator, we should return a derived type
            if (model.DiscriminatorProperty != null)
            {
                var derived = model.DerivedModels.FirstOrDefault();
                if (derived is null)
                {
                    return InputTypeExample.Null(model);
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

                    InputTypeExample exampleValue;
                    if (property.IsDiscriminator)
                    {
                        exampleValue = InputTypeExample.Value(property.Type, model.DiscriminatorValue!);
                    }
                    else if (property.ConstantValue is { Value: { } constantValue })
                    {
                        exampleValue = InputTypeExample.Value(property.Type, constantValue);
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
