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
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                AllowTrailingCommas = true
            };

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.Converters.Add(new RequestMethodConverter(options));

            return JsonSerializer.Deserialize<InputNamespace>(json, options);
        }

        private class RequestMethodConverter : JsonConverter<RequestMethod>
        {
            private readonly JsonConverter<string> _stringConverter;

            public RequestMethodConverter(JsonSerializerOptions options)
            {
                _stringConverter = (JsonConverter<string>)options.GetConverter(typeof(string));
            }

            public override RequestMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var stringValue = _stringConverter.Read(ref reader, typeof(string), options);
                return stringValue != null ? RequestMethod.Parse(stringValue) : RequestMethod.Get;
            }

            public override void Write(Utf8JsonWriter writer, RequestMethod value, JsonSerializerOptions options)
            {
                _stringConverter.Write(writer, value.Method, options);
            }
        }
    }
}
