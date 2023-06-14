// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    [JsonConverter(typeof(ExactMatchModel11Converter))]
    public partial class ExactMatchModel11 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static ExactMatchModel11 DeserializeExactMatchModel11(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
            }
            return new ExactMatchModel11(name.Value, Optional.ToNullable(type));
        }

        internal partial class ExactMatchModel11Converter : JsonConverter<ExactMatchModel11>
        {
            public override void Write(Utf8JsonWriter writer, ExactMatchModel11 model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ExactMatchModel11 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeExactMatchModel11(document.RootElement);
            }
        }
    }
}
