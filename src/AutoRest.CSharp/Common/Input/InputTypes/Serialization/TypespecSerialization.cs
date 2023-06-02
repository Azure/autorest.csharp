// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal static class TypespecSerialization
    {
        public static InputNamespace? Deserialize(string json)
        {
            var referenceHandler = new TypespecReferenceHandler();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = referenceHandler,
                AllowTrailingCommas = true
            };

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.Converters.Add(new RequestMethodConverter());
            options.Converters.Add(new TypespecInputTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputListTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputDictionaryTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputEnumTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputEnumTypeValueConverter(referenceHandler));
            options.Converters.Add(new TypespecInputModelTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputModelPropertyConverter(referenceHandler));
            options.Converters.Add(new TypespecInputConstantConverter(referenceHandler));
            options.Converters.Add(new TypespecInputLiteralTypeConverter(referenceHandler));
            options.Converters.Add(new TypespecInputUnionTypeConverter(referenceHandler));
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
