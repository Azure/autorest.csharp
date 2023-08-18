// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal class ExampleMockValueBuilder
    {
        public const string MockExampleKey = "mock-example";

        private const string EndpointMockValue = "<https://my-service.azure.com>";

        private readonly static ConcurrentDictionary<InputType, InputExampleValue> _cache = new();

        public static InputClientExample BuildClientExample(InputClient client)
        {
            var clientParameterExamples = new List<InputParameterExample>();
            foreach (var parameter in client.Parameters)
            {
                var parameterExample = BuildParameterExample(parameter);
                clientParameterExamples.Add(parameterExample);
            }

            return new(clientParameterExamples);
        }

        public static InputOperationExample BuildOperationExample(InputOperation operation)
        {
            var parameterExamples = new List<InputParameterExample>();
            foreach (var parameter in operation.Parameters)
            {
                var parameterExample = BuildParameterExample(parameter);
                parameterExamples.Add(parameterExample);
            }

            return new(parameterExamples);
        }

        private static InputParameterExample BuildParameterExample(InputParameter parameter)
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

            var exampleValue = BuildExampleValue(parameter.Type, parameter.Name, new HashSet<InputModelType>());
            return new(parameter, exampleValue);
        }

        private static InputExampleValue BuildExampleValue(InputType type, string? hint, HashSet<InputModelType> visitedModels) => type switch
        {
            InputListType listType => BuildListExampleValue(listType, hint, visitedModels),
            InputDictionaryType dictionaryType => BuildDictionaryExampleValue(dictionaryType, hint, visitedModels),
            InputEnumType enumType => BuildEnumExampleValue(enumType),
            InputPrimitiveType primitiveType => BuildPrimitiveExampleValue(primitiveType, hint),
            InputLiteralType literalType => InputExampleValue.Value(literalType, literalType.Value),
            InputModelType modelType => BuildModelExampleValue(modelType, visitedModels),
            InputUnionType unionType => BuildExampleValue(unionType.UnionItemTypes.First(), hint, visitedModels),
            _ => InputExampleValue.Object(type, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildListExampleValue(InputListType listType, string? hint, HashSet<InputModelType> visitedModels)
        {
            var exampleElementValue = BuildExampleValue(listType.ElementType, hint, visitedModels);

            return InputExampleValue.List(listType, new[] { exampleElementValue });
        }

        private static InputExampleValue BuildDictionaryExampleValue(InputDictionaryType dictionaryType, string? hint, HashSet<InputModelType> visitedModels)
        {
            var exampleValue = BuildExampleValue(dictionaryType.ValueType, hint, visitedModels);

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
            InputTypeKind.Stream => InputExampleValue.Value(primitiveType, "<filePath>"),
            InputTypeKind.Boolean => InputExampleValue.Value(primitiveType, true),
            InputTypeKind.Date => InputExampleValue.Value(primitiveType, "2022-05-10"),
            InputTypeKind.DateTime => InputExampleValue.Value(primitiveType, "2022-05-10T14:57:31.2311892-04:00"),
            InputTypeKind.DateTimeISO8601 => InputExampleValue.Value(primitiveType, "2022-05-10T18:57:31.2311892Z"),
            InputTypeKind.DateTimeRFC1123 => InputExampleValue.Value(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypeKind.DateTimeRFC3339 => InputExampleValue.Value(primitiveType, "2022-05-10T18:57:31.2311892Z"),
            InputTypeKind.DateTimeRFC7231 => InputExampleValue.Value(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypeKind.DateTimeUnix => InputExampleValue.Value(primitiveType, "1652209051"),
            InputTypeKind.Float32 => InputExampleValue.Value(primitiveType, 123.45f),
            InputTypeKind.Float64 => InputExampleValue.Value(primitiveType, 123.45d),
            InputTypeKind.Float128 => InputExampleValue.Value(primitiveType, 123.45m),
            InputTypeKind.Guid => InputExampleValue.Value(primitiveType, "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"),
            InputTypeKind.Int32 => InputExampleValue.Value(primitiveType, 1234),
            InputTypeKind.Int64 => InputExampleValue.Value(primitiveType, 1234L),
            InputTypeKind.String => string.IsNullOrWhiteSpace(hint) ? InputExampleValue.Value(primitiveType, "<String>") : InputExampleValue.Value(primitiveType, $"<{hint}>"),
            InputTypeKind.DurationISO8601 => InputExampleValue.Value(primitiveType, "PT1H23M45S"),
            InputTypeKind.DurationConstant => InputExampleValue.Value(primitiveType, "01:23:45"),
            InputTypeKind.Time => InputExampleValue.Value(primitiveType, "01:23:45"),
            InputTypeKind.Uri => InputExampleValue.Value(primitiveType, "http://localhost:3000"),
            InputTypeKind.DurationSeconds => InputExampleValue.Value(primitiveType, 10),
            InputTypeKind.DurationSecondsFloat => InputExampleValue.Value(primitiveType, 10f),
            _ => InputExampleValue.Object(primitiveType, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildModelExampleValue(InputModelType model, HashSet<InputModelType> visitedModels)
        {
            if (_cache.TryGetValue(model, out var value))
                return value;

            var dict = new Dictionary<string, InputExampleValue>();
            var result = InputExampleValue.Object(model, dict);
            visitedModels.Add(model);
            _cache.TryAdd(model, result);
            // iterate all the properties
            foreach (var modelOrBase in model.GetSelfAndBaseModels())
            {
                foreach (var property in modelOrBase.Properties)
                {
                    if (visitedModels.Contains(property.Type) || property.IsReadOnly)
                        continue;

                    var exampleValue = BuildExampleValue(property.Type, property.SerializedName, visitedModels);

                    dict.Add(property.SerializedName, exampleValue);
                }
            }

            return result;
        }
    }
}
