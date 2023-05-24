// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    internal partial class FirewallPolicyNatRuleCollectionAction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ActionType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ActionType.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyNatRuleCollectionAction DeserializeFirewallPolicyNatRuleCollectionAction(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FirewallPolicyNatRuleCollectionActionType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new FirewallPolicyNatRuleCollectionActionType(property.Value.GetString());
                    continue;
                }
            }
            return new FirewallPolicyNatRuleCollectionAction(Optional.ToNullable(type));
        }
    }
}
