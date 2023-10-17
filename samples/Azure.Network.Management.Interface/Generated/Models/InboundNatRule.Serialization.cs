// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class InboundNatRule : IUtf8JsonSerializable, IModelJsonSerializable<InboundNatRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<InboundNatRule>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<InboundNatRule>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Type))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(FrontendIPConfiguration))
                {
                    writer.WritePropertyName("frontendIPConfiguration"u8);
                    writer.WriteObjectValue(FrontendIPConfiguration);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(BackendIPConfiguration))
                {
                    writer.WritePropertyName("backendIPConfiguration"u8);
                    writer.WriteObjectValue(BackendIPConfiguration);
                }
                if (Optional.IsDefined(Protocol))
                {
                    writer.WritePropertyName("protocol"u8);
                    writer.WriteStringValue(Protocol.Value.ToString());
                }
                if (Optional.IsDefined(FrontendPort))
                {
                    writer.WritePropertyName("frontendPort"u8);
                    writer.WriteNumberValue(FrontendPort.Value);
                }
                if (Optional.IsDefined(BackendPort))
                {
                    writer.WritePropertyName("backendPort"u8);
                    writer.WriteNumberValue(BackendPort.Value);
                }
                if (Optional.IsDefined(IdleTimeoutInMinutes))
                {
                    writer.WritePropertyName("idleTimeoutInMinutes"u8);
                    writer.WriteNumberValue(IdleTimeoutInMinutes.Value);
                }
                if (Optional.IsDefined(EnableFloatingIP))
                {
                    writer.WritePropertyName("enableFloatingIP"u8);
                    writer.WriteBooleanValue(EnableFloatingIP.Value);
                }
                if (Optional.IsDefined(EnableTcpReset))
                {
                    writer.WritePropertyName("enableTcpReset"u8);
                    writer.WriteBooleanValue(EnableTcpReset.Value);
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

        InboundNatRule IModelJsonSerializable<InboundNatRule>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInboundNatRule(document.RootElement, options);
        }

        BinaryData IModelSerializable<InboundNatRule>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        InboundNatRule IModelSerializable<InboundNatRule>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeInboundNatRule(document.RootElement, options);
        }

        internal static InboundNatRule DeserializeInboundNatRule(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> type = default;
            Optional<string> id = default;
            Optional<SubResource> frontendIPConfiguration = default;
            Optional<NetworkInterfaceIPConfiguration> backendIPConfiguration = default;
            Optional<TransportProtocol> protocol = default;
            Optional<int> frontendPort = default;
            Optional<int> backendPort = default;
            Optional<int> idleTimeoutInMinutes = default;
            Optional<bool> enableFloatingIP = default;
            Optional<bool> enableTcpReset = default;
            Optional<ProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
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
                        if (property0.NameEquals("frontendIPConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            frontendIPConfiguration = DeserializeSubResource(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("backendIPConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            backendIPConfiguration = NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("protocol"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protocol = new TransportProtocol(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("frontendPort"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            frontendPort = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("backendPort"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            backendPort = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("idleTimeoutInMinutes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            idleTimeoutInMinutes = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("enableFloatingIP"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableFloatingIP = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("enableTcpReset"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableTcpReset = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new InboundNatRule(id.Value, name.Value, etag.Value, type.Value, frontendIPConfiguration.Value, backendIPConfiguration.Value, Optional.ToNullable(protocol), Optional.ToNullable(frontendPort), Optional.ToNullable(backendPort), Optional.ToNullable(idleTimeoutInMinutes), Optional.ToNullable(enableFloatingIP), Optional.ToNullable(enableTcpReset), Optional.ToNullable(provisioningState));
        }
    }
}
