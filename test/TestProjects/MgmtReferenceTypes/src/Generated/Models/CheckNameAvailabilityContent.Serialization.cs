// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using MgmtReferenceTypes;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(CheckNameAvailabilityContentConverter))]
    public partial class CheckNameAvailabilityContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(ResourceType);
            writer.WriteEndObject();
        }

        internal static CheckNameAvailabilityContent DeserializeCheckNameAvailabilityContent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            ResourceType type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
            }
            return new CheckNameAvailabilityContent(name, type);
        }

        internal partial class CheckNameAvailabilityContentConverter : JsonConverter<CheckNameAvailabilityContent>
        {
            public override void Write(Utf8JsonWriter writer, CheckNameAvailabilityContent model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }

            public override CheckNameAvailabilityContent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeCheckNameAvailabilityContent(document.RootElement);
            }
        }
    }
}
