// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputServiceMethodResponseConverter : JsonConverter<InputServiceMethodResponse>
    {
        public override InputServiceMethodResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ReadInputServiceMethodResponse(ref reader, options);

        public override void Write(Utf8JsonWriter writer, InputServiceMethodResponse value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputServiceMethodResponse ReadInputServiceMethodResponse(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
            }
            InputType? type = null;
            IReadOnlyList<string>? resultSegments = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadComplexType("type", options, ref type)
                    || reader.TryReadComplexType("resultSegments", options, ref resultSegments);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var response = new InputServiceMethodResponse(type, resultSegments ?? []);

            return response;
        }
    }
}
