// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal static class CadlSerialization
    {
        public static InputNamespace? Deserialize(string json)
        {
            var referenceHandler = new CadlReferenceHandler();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = referenceHandler,
                AllowTrailingCommas = true
            };

            var inputTypeConverter = new CadlInputTypeConverter(referenceHandler);

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.Converters.Add(new RequestMethodConverter());
            options.Converters.Add(inputTypeConverter);
            options.Converters.Add(new CadlInputListTypeConverter(referenceHandler));
            options.Converters.Add(new CadlInputDictionaryTypeConverter(referenceHandler));
            options.Converters.Add(new CadlInputEnumTypeConverter(referenceHandler));
            options.Converters.Add(new CadlInputEnumTypeValueConverter(referenceHandler));
            options.Converters.Add(new CadlInputModelTypeConverter(referenceHandler));
            options.Converters.Add(new CadlInputModelPropertyConverter(referenceHandler));
            options.Converters.Add(new CadlInputConstantConverter(referenceHandler));
            options.Converters.Add(new CadlInputLiteralTypeConverter(referenceHandler));
            options.Converters.Add(new CadlInputUnionTypeConverter(referenceHandler));
            return JsonSerializer.Deserialize<InputNamespace>(json, options);
        }

        private class RequestMethodConverter : JsonConverter<RequestMethod>
        {
            public override RequestMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException();
                }

                var stringValue = reader.GetString();
                return stringValue != null ? RequestMethod.Parse(stringValue) : RequestMethod.Get;
            }

            public override void Write(Utf8JsonWriter writer, RequestMethod value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Method.AsSpan());
            }
        }
    }
}
