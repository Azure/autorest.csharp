// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateEndpointConnectionDataConverter))]
    public partial class PrivateEndpointConnectionData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(PrivateEndpoint))
            {
                writer.WritePropertyName("privateEndpoint");
                writer.WriteObjectValue(PrivateEndpoint);
            }
            if (Optional.IsDefined(PrivateLinkServiceConnectionState))
            {
                writer.WritePropertyName("privateLinkServiceConnectionState");
                writer.WriteObjectValue(PrivateLinkServiceConnectionState);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static PrivateEndpointConnectionData DeserializePrivateEndpointConnectionData(JsonElement element)
        {
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            ResourceManager.Models.SystemData systemData = default;
            Optional<PrivateEndpoint> privateEndpoint = default;
            Optional<ReferenceTypesPrivateLinkServiceConnectionState> privateLinkServiceConnectionState = default;
            Optional<ReferenceTypesPrivateEndpointConnectionProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = (ResourceType)property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("privateEndpoint"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateEndpoint = PrivateEndpoint.DeserializePrivateEndpoint(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("privateLinkServiceConnectionState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateLinkServiceConnectionState = ReferenceTypesPrivateLinkServiceConnectionState.DeserializeReferenceTypesPrivateLinkServiceConnectionState(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            provisioningState = new ReferenceTypesPrivateEndpointConnectionProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PrivateEndpointConnectionData(id, name, type, systemData, privateEndpoint.Value, privateLinkServiceConnectionState.Value, Optional.ToNullable(provisioningState));
        }

        internal partial class PrivateEndpointConnectionDataConverter : JsonConverter<PrivateEndpointConnectionData>
        {
            public override void Write(Utf8JsonWriter writer, PrivateEndpointConnectionData model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override PrivateEndpointConnectionData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializePrivateEndpointConnectionData(document.RootElement);
            }
        }
    }
}
