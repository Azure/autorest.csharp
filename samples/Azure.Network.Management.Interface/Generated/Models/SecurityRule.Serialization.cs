// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class SecurityRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Id != null)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Description != null)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Protocol.HasValue)
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToString());
            }
            if (SourcePortRange != null)
            {
                writer.WritePropertyName("sourcePortRange"u8);
                writer.WriteStringValue(SourcePortRange);
            }
            if (DestinationPortRange != null)
            {
                writer.WritePropertyName("destinationPortRange"u8);
                writer.WriteStringValue(DestinationPortRange);
            }
            if (SourceAddressPrefix != null)
            {
                writer.WritePropertyName("sourceAddressPrefix"u8);
                writer.WriteStringValue(SourceAddressPrefix);
            }
            if (!(SourceAddressPrefixes is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("sourceAddressPrefixes"u8);
                writer.WriteStartArray();
                foreach (var item in SourceAddressPrefixes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(SourceApplicationSecurityGroups is ChangeTrackingList<ApplicationSecurityGroup> collection0 && collection0.IsUndefined))
            {
                writer.WritePropertyName("sourceApplicationSecurityGroups"u8);
                writer.WriteStartArray();
                foreach (var item in SourceApplicationSecurityGroups)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (DestinationAddressPrefix != null)
            {
                writer.WritePropertyName("destinationAddressPrefix"u8);
                writer.WriteStringValue(DestinationAddressPrefix);
            }
            if (!(DestinationAddressPrefixes is ChangeTrackingList<string> collection1 && collection1.IsUndefined))
            {
                writer.WritePropertyName("destinationAddressPrefixes"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationAddressPrefixes)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(DestinationApplicationSecurityGroups is ChangeTrackingList<ApplicationSecurityGroup> collection2 && collection2.IsUndefined))
            {
                writer.WritePropertyName("destinationApplicationSecurityGroups"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationApplicationSecurityGroups)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(SourcePortRanges is ChangeTrackingList<string> collection3 && collection3.IsUndefined))
            {
                writer.WritePropertyName("sourcePortRanges"u8);
                writer.WriteStartArray();
                foreach (var item in SourcePortRanges)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(DestinationPortRanges is ChangeTrackingList<string> collection4 && collection4.IsUndefined))
            {
                writer.WritePropertyName("destinationPortRanges"u8);
                writer.WriteStartArray();
                foreach (var item in DestinationPortRanges)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Access.HasValue)
            {
                writer.WritePropertyName("access"u8);
                writer.WriteStringValue(Access.Value.ToString());
            }
            if (Priority.HasValue)
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
            }
            if (Direction.HasValue)
            {
                writer.WritePropertyName("direction"u8);
                writer.WriteStringValue(Direction.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SecurityRule DeserializeSecurityRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string etag = default;
            string id = default;
            string description = default;
            SecurityRuleProtocol? protocol = default;
            string sourcePortRange = default;
            string destinationPortRange = default;
            string sourceAddressPrefix = default;
            IList<string> sourceAddressPrefixes = default;
            IList<ApplicationSecurityGroup> sourceApplicationSecurityGroups = default;
            string destinationAddressPrefix = default;
            IList<string> destinationAddressPrefixes = default;
            IList<ApplicationSecurityGroup> destinationApplicationSecurityGroups = default;
            IList<string> sourcePortRanges = default;
            IList<string> destinationPortRanges = default;
            SecurityRuleAccess? access = default;
            int? priority = default;
            SecurityRuleDirection? direction = default;
            ProvisioningState? provisioningState = default;
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
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("protocol"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protocol = new SecurityRuleProtocol(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("sourcePortRange"u8))
                        {
                            sourcePortRange = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("destinationPortRange"u8))
                        {
                            destinationPortRange = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("sourceAddressPrefix"u8))
                        {
                            sourceAddressPrefix = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("sourceAddressPrefixes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            sourceAddressPrefixes = array;
                            continue;
                        }
                        if (property0.NameEquals("sourceApplicationSecurityGroups"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationSecurityGroup> array = new List<ApplicationSecurityGroup>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ApplicationSecurityGroup.DeserializeApplicationSecurityGroup(item));
                            }
                            sourceApplicationSecurityGroups = array;
                            continue;
                        }
                        if (property0.NameEquals("destinationAddressPrefix"u8))
                        {
                            destinationAddressPrefix = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("destinationAddressPrefixes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            destinationAddressPrefixes = array;
                            continue;
                        }
                        if (property0.NameEquals("destinationApplicationSecurityGroups"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationSecurityGroup> array = new List<ApplicationSecurityGroup>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ApplicationSecurityGroup.DeserializeApplicationSecurityGroup(item));
                            }
                            destinationApplicationSecurityGroups = array;
                            continue;
                        }
                        if (property0.NameEquals("sourcePortRanges"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            sourcePortRanges = array;
                            continue;
                        }
                        if (property0.NameEquals("destinationPortRanges"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            destinationPortRanges = array;
                            continue;
                        }
                        if (property0.NameEquals("access"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            access = new SecurityRuleAccess(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("priority"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            priority = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("direction"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            direction = new SecurityRuleDirection(property0.Value.GetString());
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
            return new SecurityRule(
                id,
                name,
                etag,
                description,
                protocol,
                sourcePortRange,
                destinationPortRange,
                sourceAddressPrefix,
                sourceAddressPrefixes ?? new ChangeTrackingList<string>(),
                sourceApplicationSecurityGroups ?? new ChangeTrackingList<ApplicationSecurityGroup>(),
                destinationAddressPrefix,
                destinationAddressPrefixes ?? new ChangeTrackingList<string>(),
                destinationApplicationSecurityGroups ?? new ChangeTrackingList<ApplicationSecurityGroup>(),
                sourcePortRanges ?? new ChangeTrackingList<string>(),
                destinationPortRanges ?? new ChangeTrackingList<string>(),
                access,
                priority,
                direction,
                provisioningState);
        }
    }
}
