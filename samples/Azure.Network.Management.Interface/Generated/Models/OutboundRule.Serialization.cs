// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class OutboundRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(AllocatedOutboundPorts))
            {
                writer.WritePropertyName("allocatedOutboundPorts"u8);
                writer.WriteNumberValue(AllocatedOutboundPorts.Value);
            }
            if (Optional.IsCollectionDefined(FrontendIPConfigurations))
            {
                writer.WritePropertyName("frontendIPConfigurations"u8);
                writer.WriteStartArray();
                foreach (var item in FrontendIPConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(BackendAddressPool))
            {
                writer.WritePropertyName("backendAddressPool"u8);
                writer.WriteObjectValue(BackendAddressPool);
            }
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToString());
            }
            if (Optional.IsDefined(EnableTcpReset))
            {
                writer.WritePropertyName("enableTcpReset"u8);
                writer.WriteBooleanValue(EnableTcpReset.Value);
            }
            if (Optional.IsDefined(IdleTimeoutInMinutes))
            {
                writer.WritePropertyName("idleTimeoutInMinutes"u8);
                writer.WriteNumberValue(IdleTimeoutInMinutes.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static OutboundRule DeserializeOutboundRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> type = default;
            Optional<string> id = default;
            Optional<int> allocatedOutboundPorts = default;
            Optional<IList<SubResource>> frontendIPConfigurations = default;
            Optional<SubResource> backendAddressPool = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<LoadBalancerOutboundRuleProtocol> protocol = default;
            Optional<bool> enableTcpReset = default;
            Optional<int> idleTimeoutInMinutes = default;
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
                        if (property0.NameEquals("allocatedOutboundPorts"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            allocatedOutboundPorts = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("frontendIPConfigurations"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<SubResource> array = new List<SubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DeserializeSubResource(item));
                            }
                            frontendIPConfigurations = array;
                            continue;
                        }
                        if (property0.NameEquals("backendAddressPool"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            backendAddressPool = DeserializeSubResource(property0.Value);
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
                        if (property0.NameEquals("protocol"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protocol = new LoadBalancerOutboundRuleProtocol(property0.Value.GetString());
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
                        if (property0.NameEquals("idleTimeoutInMinutes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            idleTimeoutInMinutes = property0.Value.GetInt32();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new OutboundRule(id.Value, name.Value, etag.Value, type.Value, Optional.ToNullable(allocatedOutboundPorts), Optional.ToList(frontendIPConfigurations), backendAddressPool.Value, Optional.ToNullable(provisioningState), Optional.ToNullable(protocol), Optional.ToNullable(enableTcpReset), Optional.ToNullable(idleTimeoutInMinutes));
        }
    }
}
