// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class NetworkRuleSet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Bypass.HasValue)
            {
                writer.WritePropertyName("bypass"u8);
                writer.WriteStringValue(Bypass.Value.ToString());
            }
            if (!(ResourceAccessRules is ChangeTrackingList<ResourceAccessRule> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("resourceAccessRules"u8);
                writer.WriteStartArray();
                foreach (var item in ResourceAccessRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(VirtualNetworkRules is ChangeTrackingList<VirtualNetworkRule> collection0 && collection0.IsUndefined))
            {
                writer.WritePropertyName("virtualNetworkRules"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualNetworkRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(IpRules is ChangeTrackingList<IPRule> collection1 && collection1.IsUndefined))
            {
                writer.WritePropertyName("ipRules"u8);
                writer.WriteStartArray();
                foreach (var item in IpRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("defaultAction"u8);
            writer.WriteStringValue(DefaultAction.ToSerialString());
            writer.WriteEndObject();
        }

        internal static NetworkRuleSet DeserializeNetworkRuleSet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Bypass> bypass = default;
            Optional<IList<ResourceAccessRule>> resourceAccessRules = default;
            Optional<IList<VirtualNetworkRule>> virtualNetworkRules = default;
            Optional<IList<IPRule>> ipRules = default;
            DefaultAction defaultAction = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("bypass"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bypass = new Bypass(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resourceAccessRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceAccessRule> array = new List<ResourceAccessRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceAccessRule.DeserializeResourceAccessRule(item));
                    }
                    resourceAccessRules = array;
                    continue;
                }
                if (property.NameEquals("virtualNetworkRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualNetworkRule> array = new List<VirtualNetworkRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualNetworkRule.DeserializeVirtualNetworkRule(item));
                    }
                    virtualNetworkRules = array;
                    continue;
                }
                if (property.NameEquals("ipRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IPRule> array = new List<IPRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(IPRule.DeserializeIPRule(item));
                    }
                    ipRules = array;
                    continue;
                }
                if (property.NameEquals("defaultAction"u8))
                {
                    defaultAction = property.Value.GetString().ToDefaultAction();
                    continue;
                }
            }
            return new NetworkRuleSet(Optional.ToNullable(bypass), Optional.ToList(resourceAccessRules), Optional.ToList(virtualNetworkRules), Optional.ToList(ipRules), defaultAction);
        }
    }
}
