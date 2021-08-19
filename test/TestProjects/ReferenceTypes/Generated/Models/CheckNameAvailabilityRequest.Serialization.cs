// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(CheckNameAvailabilityRequestConverter))]
    public partial class CheckNameAvailabilityRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Type))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            writer.WriteEndObject();
        }

        internal static CheckNameAvailabilityRequest DeserializeCheckNameAvailabilityRequest(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new CheckNameAvailabilityRequest(name.Value, type.Value);
        }

        internal partial class CheckNameAvailabilityRequestConverter : JsonConverter<CheckNameAvailabilityRequest>
        {
            public override void Write(Utf8JsonWriter writer, CheckNameAvailabilityRequest model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override CheckNameAvailabilityRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeCheckNameAvailabilityRequest(document.RootElement);
            }
        }
    }
}
