// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal class RequestMethodConverter : JsonConverter<RequestMethod>
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
