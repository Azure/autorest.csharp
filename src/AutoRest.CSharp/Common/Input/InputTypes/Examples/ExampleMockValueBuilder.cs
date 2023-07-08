// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal class ExampleMockValueBuilder
    {
        public static IEnumerable<InputClientExample> Build(IEnumerable<InputClient> inputClients)
        {
            foreach (var client in inputClients)
            {
                // construct the mock example value for a client
                var exampleOperations = new List<InputOperationExample>();
                foreach (var operation in client.Operations)
                {
                    var exampleOperation = BuildExampleOperation(operation);
                    exampleOperations.Add(exampleOperation);
                }

                var exampleClientParameters = new List<InputParameterExample>();
                foreach (var clientParameter in client.Parameters)
                {
                    // client parameters should always be primitive types, therefore it does not really need a dictionary for visited models
                    var parameterExample = BuildExampleParameter(clientParameter, new Dictionary<InputType, InputExampleValue>());
                    exampleClientParameters.Add(parameterExample);
                }

                yield return new InputClientExample(client, exampleOperations, exampleClientParameters);
            }
        }

        private static InputOperationExample BuildExampleOperation(InputOperation operation)
        {
            // build the mock values for the parameters
            var visitedModels = new Dictionary<InputType, InputExampleValue>();

            var exampleParameters = new List<InputParameterExample>();
            foreach (var parameter in operation.Parameters)
            {
                var exampleParameter = BuildExampleParameter(parameter, visitedModels);
                exampleParameters.Add(exampleParameter);
            }

            return new(operation, exampleParameters);
        }

        private static InputParameterExample BuildExampleParameter(InputParameter parameter, Dictionary<InputType, InputExampleValue> visitedModels)
        {
            // if the parameter is constant, we just put the constant into the example value instead of mocking a new one
            if (parameter.Kind == InputOperationParameterKind.Constant)
            {
                InputExampleValue value;
                if (parameter.DefaultValue != null)
                {
                    // when it is constant, it could have DefaultValue
                    value = InputExampleValue.FromRawValue(parameter.Type, parameter.DefaultValue.Value);
                }
                else if (parameter.Type is InputUnionType unionType && unionType.UnionItemTypes.First() is InputLiteralType literalType)
                {
                    // or it could be a union of literal types
                    value = InputExampleValue.FromRawValue(parameter.Type, literalType.Value);
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
                var value = InputExampleValue.FromRawValue(parameter.Type, GetEndpoint());
                return new(parameter, value);
            }

            if (parameter.DefaultValue != null)
            {
                var value = InputExampleValue.FromRawValue(parameter.Type, parameter.DefaultValue.Value);
                return new(parameter, value);
            }

            var exampleValue = BuildExampleValue(parameter.Type, parameter.Name, visitedModels);
            return new(parameter, exampleValue);
        }

        private static InputExampleValue BuildExampleValue(InputType type, string? hint, Dictionary<InputType, InputExampleValue> visitedModels) => type switch
        {
            InputListType listType => BuildListExampleValue(listType, hint, visitedModels),
            InputDictionaryType dictionaryType => BuildDictionaryExampleValue(dictionaryType, hint, visitedModels),
            InputEnumType enumType => BuildEnumExampleValue(enumType),
            InputPrimitiveType primitiveType => BuildPrimitiveExampleValue(primitiveType, hint),
            InputLiteralType literalType => InputExampleValue.FromRawValue(literalType, literalType.Value),
            InputModelType modelType => BuildModelExampleValue(modelType, visitedModels),
            _ => InputExampleValue.FromDictionary(type, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildListExampleValue(InputListType listType, string? hint, Dictionary<InputType, InputExampleValue> visitedModels)
        {
            var exampleElementValue = BuildExampleValue(listType.ElementType, hint, visitedModels);

            return InputExampleValue.FromList(listType, new[] { exampleElementValue });
        }

        private static InputExampleValue BuildDictionaryExampleValue(InputDictionaryType dictionaryType, string? hint, Dictionary<InputType, InputExampleValue> visitedModels)
        {
            var exampleValue = BuildExampleValue(dictionaryType.ValueType, hint, visitedModels);

            return InputExampleValue.FromDictionary(dictionaryType, new Dictionary<string, InputExampleValue>
            {
                ["key"] = exampleValue
            });
        }

        private static InputExampleValue BuildEnumExampleValue(InputEnumType enumType)
        {
            var enumValue = enumType.AllowedValues.First();
            return InputExampleValue.FromRawValue(enumType, enumValue.Value);
        }

        private static InputExampleValue BuildPrimitiveExampleValue(InputPrimitiveType primitiveType, string? hint) => primitiveType.Kind switch
        {
            InputTypeKind.Stream => InputExampleValue.FromRawValue(primitiveType, "<filePath>"),
            InputTypeKind.Boolean => InputExampleValue.FromRawValue(primitiveType, true),
            InputTypeKind.Date => InputExampleValue.FromRawValue(primitiveType, "2022-05-10"),
            InputTypeKind.DateTime => InputExampleValue.FromRawValue(primitiveType, "2022-05-10T14:57:31.2311892-04:00"),
            InputTypeKind.DateTimeISO8601 => InputExampleValue.FromRawValue(primitiveType, "2022-05-10T18:57:31.2311892Z"),
            InputTypeKind.DateTimeRFC1123 => InputExampleValue.FromRawValue(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypeKind.DateTimeRFC3339 => InputExampleValue.FromRawValue(primitiveType, "2022-05-10T18:57:31.2311892Z"),
            InputTypeKind.DateTimeRFC7231 => InputExampleValue.FromRawValue(primitiveType, "Tue, 10 May 2022 18:57:31 GMT"),
            InputTypeKind.DateTimeUnix => InputExampleValue.FromRawValue(primitiveType, "1652209051"),
            InputTypeKind.Float32 => InputExampleValue.FromRawValue(primitiveType, 123.45f),
            InputTypeKind.Float64 => InputExampleValue.FromRawValue(primitiveType, 123.45d),
            InputTypeKind.Float128 => InputExampleValue.FromRawValue(primitiveType, 123.45m),
            InputTypeKind.Guid => InputExampleValue.FromRawValue(primitiveType, "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"),
            InputTypeKind.Int32 => InputExampleValue.FromRawValue(primitiveType, 1234),
            InputTypeKind.Int64 => InputExampleValue.FromRawValue(primitiveType, 1234L),
            InputTypeKind.String => string.IsNullOrWhiteSpace(hint) ? InputExampleValue.FromRawValue(primitiveType, "<String>") : InputExampleValue.FromRawValue(primitiveType, $"<{hint}>"),
            InputTypeKind.DurationISO8601 => InputExampleValue.FromRawValue(primitiveType, "PT1H23M45S"),
            InputTypeKind.DurationConstant => InputExampleValue.FromRawValue(primitiveType, "01:23:45"),
            InputTypeKind.Time => InputExampleValue.FromRawValue(primitiveType, "01:23:45"),
            InputTypeKind.Uri => InputExampleValue.FromRawValue(primitiveType, "http://localhost:3000"),
            InputTypeKind.DurationSeconds => InputExampleValue.FromRawValue(primitiveType, 10),
            InputTypeKind.DurationSecondsFloat => InputExampleValue.FromRawValue(primitiveType, 10f),
            _ => InputExampleValue.FromDictionary(primitiveType, new Dictionary<string, InputExampleValue>())
        };

        private static InputExampleValue BuildModelExampleValue(InputModelType model, Dictionary<InputType, InputExampleValue> visitedModels)
        {
            if (visitedModels.TryGetValue(model, out var value))
                return value;

            var dict = new Dictionary<string, InputExampleValue>();
            var result = InputExampleValue.FromDictionary(model, dict);
            visitedModels.Add(model, result);
            // iterate all the properties
            foreach (var modelOrBase in model.GetSelfAndBaseModels())
            {
                foreach (var property in modelOrBase.Properties)
                {
                    if (visitedModels.ContainsKey(property.Type) || property.IsReadOnly)
                        continue;

                    var exampleValue = BuildExampleValue(property.Type, property.SerializedName, visitedModels);

                    dict.Add(property.SerializedName, exampleValue);
                }
            }

            return result;
        }

        private static string GetEndpoint()
        {
            return "<https://my-service.azure.com>";
        }
    }
}
