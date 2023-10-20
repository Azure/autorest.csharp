// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateEndpointConnectionDataConverter))]
    public partial class PrivateEndpointConnectionData : IUtf8JsonSerializable, IModelJsonSerializable<PrivateEndpointConnectionData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PrivateEndpointConnectionData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PrivateEndpointConnectionData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SystemData))
            {
                writer.WritePropertyName("systemData"u8);
                JsonSerializer.Serialize(writer, SystemData);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(PrivateEndpoint))
                {
                    writer.WritePropertyName("privateEndpoint"u8);
                    writer.WriteObjectValue(PrivateEndpoint);
                }
                if (Optional.IsDefined(ConnectionState))
                {
                    writer.WritePropertyName("privateLinkServiceConnectionState"u8);
                    writer.WriteObjectValue(ConnectionState);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState.Value.ToString());
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        PrivateEndpointConnectionData IModelJsonSerializable<PrivateEndpointConnectionData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateEndpointConnectionData(document.RootElement, options);
        }

        internal static PrivateEndpointConnectionData DeserializePrivateEndpointConnectionData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<PrivateEndpoint> privateEndpoint = default;
            Optional<MgmtReferenceTypesPrivateLinkServiceConnectionState> privateLinkServiceConnectionState = default;
            Optional<MgmtReferenceTypesPrivateEndpointConnectionProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("privateEndpoint"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateEndpoint = PrivateEndpoint.DeserializePrivateEndpoint(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("privateLinkServiceConnectionState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateLinkServiceConnectionState = MgmtReferenceTypesPrivateLinkServiceConnectionState.DeserializeMgmtReferenceTypesPrivateLinkServiceConnectionState(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PrivateEndpointConnectionData(id, name, type, systemData.Value, privateEndpoint.Value, privateLinkServiceConnectionState.Value, Optional.ToNullable(provisioningState));
        }

        BinaryData IModelSerializable<PrivateEndpointConnectionData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        PrivateEndpointConnectionData IModelSerializable<PrivateEndpointConnectionData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePrivateEndpointConnectionData(document.RootElement, options);
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
