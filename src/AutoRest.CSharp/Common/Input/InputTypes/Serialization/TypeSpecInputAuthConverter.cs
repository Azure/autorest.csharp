// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputAuthConverter : JsonConverter<InputAuth>
    {
        public override InputAuth? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ReadInputAuth(ref reader, options);

        public override void Write(Utf8JsonWriter writer, InputAuth value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputAuth? ReadInputAuth(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
            }

            InputOAuth2Auth? oAuth2 = null;
            InputApiKeyAuth? apiKey = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadComplexType("apiKey", options, ref apiKey)
                    || reader.TryReadComplexType("oAuth2", options, ref oAuth2);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            return new InputAuth(apiKey, oAuth2);
        }
    }
}
