// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class UnknownFirewallPolicyRuleCollection : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ruleCollectionType"u8);
            writer.WriteStringValue(RuleCollectionType.ToString());
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
            }
            writer.WriteEndObject();
        }

        internal static UnknownFirewallPolicyRuleCollection DeserializeUnknownFirewallPolicyRuleCollection(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FirewallPolicyRuleCollectionType ruleCollectionType = "Unknown";
            Optional<string> name = default;
            Optional<int> priority = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ruleCollectionType"u8))
                {
                    ruleCollectionType = new FirewallPolicyRuleCollectionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    priority = property.Value.GetInt32();
                    continue;
                }
            }
            return new UnknownFirewallPolicyRuleCollection(ruleCollectionType, name.Value, Optional.ToNullable(priority));
        }
    }
}
