// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class FirewallPolicyFilterRuleCollectionAction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ActionType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ActionType.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyFilterRuleCollectionAction DeserializeFirewallPolicyFilterRuleCollectionAction(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FirewallPolicyFilterRuleCollectionActionType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new FirewallPolicyFilterRuleCollectionActionType(property.Value.GetString());
                    continue;
                }
            }
            return new FirewallPolicyFilterRuleCollectionAction(Optional.ToNullable(type));
        }
    }
}
