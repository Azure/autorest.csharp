// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using ReferenceTypes.Models;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(ReferenceTypesPrivateLinkServiceConnectionStateConverter))]
    public partial class ReferenceTypesPrivateLinkServiceConnectionState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status");
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(ActionsRequired))
            {
                writer.WritePropertyName("actionsRequired");
                writer.WriteStringValue(ActionsRequired);
            }
            writer.WriteEndObject();
        }

        internal static ReferenceTypesPrivateLinkServiceConnectionState DeserializeReferenceTypesPrivateLinkServiceConnectionState(JsonElement element)
        {
            Optional<ReferenceTypesPrivateEndpointServiceConnectionStatus> status = default;
            Optional<string> description = default;
            Optional<string> actionsRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new ReferenceTypesPrivateEndpointServiceConnectionStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionsRequired"))
                {
                    actionsRequired = property.Value.GetString();
                    continue;
                }
            }
            return new ReferenceTypesPrivateLinkServiceConnectionState(Optional.ToNullable(status), description.Value, actionsRequired.Value);
        }

        internal partial class ReferenceTypesPrivateLinkServiceConnectionStateConverter : JsonConverter<ReferenceTypesPrivateLinkServiceConnectionState>
        {
            public override void Write(Utf8JsonWriter writer, ReferenceTypesPrivateLinkServiceConnectionState model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ReferenceTypesPrivateLinkServiceConnectionState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeReferenceTypesPrivateLinkServiceConnectionState(document.RootElement);
            }
        }
    }
}
