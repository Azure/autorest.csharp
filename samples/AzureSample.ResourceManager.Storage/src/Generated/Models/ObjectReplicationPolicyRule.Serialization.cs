// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace AzureSample.ResourceManager.Storage.Models
{
    public partial class ObjectReplicationPolicyRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(RuleId))
            {
                writer.WritePropertyName("ruleId"u8);
                writer.WriteStringValue(RuleId);
            }
            writer.WritePropertyName("sourceContainer"u8);
            writer.WriteStringValue(SourceContainer);
            writer.WritePropertyName("destinationContainer"u8);
            writer.WriteStringValue(DestinationContainer);
            if (Optional.IsDefined(Filters))
            {
                writer.WritePropertyName("filters"u8);
                writer.WriteObjectValue(Filters);
            }
            writer.WriteEndObject();
        }

        internal static ObjectReplicationPolicyRule DeserializeObjectReplicationPolicyRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ruleId = default;
            string sourceContainer = default;
            string destinationContainer = default;
            ObjectReplicationPolicyFilter filters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ruleId"u8))
                {
                    ruleId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceContainer"u8))
                {
                    sourceContainer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationContainer"u8))
                {
                    destinationContainer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filters = ObjectReplicationPolicyFilter.DeserializeObjectReplicationPolicyFilter(property.Value);
                    continue;
                }
            }
            return new ObjectReplicationPolicyRule(ruleId, sourceContainer, destinationContainer, filters);
        }
    }
}
