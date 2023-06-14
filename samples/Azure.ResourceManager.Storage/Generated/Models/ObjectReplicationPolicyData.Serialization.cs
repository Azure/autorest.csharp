// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class ObjectReplicationPolicyData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(SourceAccount))
            {
                writer.WritePropertyName("sourceAccount"u8);
                writer.WriteStringValue(SourceAccount);
            }
            if (Optional.IsDefined(DestinationAccount))
            {
                writer.WritePropertyName("destinationAccount"u8);
                writer.WriteStringValue(DestinationAccount);
            }
            if (Optional.IsCollectionDefined(Rules))
            {
                writer.WritePropertyName("rules"u8);
                writer.WriteStartArray();
                foreach (var item in Rules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ObjectReplicationPolicyData DeserializeObjectReplicationPolicyData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> policyId = default;
            Optional<DateTimeOffset> enabledTime = default;
            Optional<string> sourceAccount = default;
            Optional<string> destinationAccount = default;
            Optional<IList<ObjectReplicationPolicyRule>> rules = default;
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
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("policyId"u8))
                        {
                            policyId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("enabledTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enabledTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("sourceAccount"u8))
                        {
                            sourceAccount = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("destinationAccount"u8))
                        {
                            destinationAccount = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("rules"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ObjectReplicationPolicyRule> array = new List<ObjectReplicationPolicyRule>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ObjectReplicationPolicyRule.DeserializeObjectReplicationPolicyRule(item));
                            }
                            rules = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ObjectReplicationPolicyData(id, name, type, systemData.Value, policyId.Value, Optional.ToNullable(enabledTime), sourceAccount.Value, destinationAccount.Value, Optional.ToList(rules));
        }
    }
}
