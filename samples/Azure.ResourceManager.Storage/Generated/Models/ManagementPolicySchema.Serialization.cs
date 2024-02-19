// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class ManagementPolicySchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("rules"u8);
            writer.WriteStartArray();
            foreach (var item in Rules)
            {
                if (item != null)
                {
                    writer.WriteObjectValue(item);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static ManagementPolicySchema DeserializeManagementPolicySchema(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ManagementPolicyRule> rules = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rules"u8))
                {
                    List<ManagementPolicyRule> array = new List<ManagementPolicyRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(ManagementPolicyRule.DeserializeManagementPolicyRule(item));
                        }
                    }
                    rules = array;
                    continue;
                }
            }
            return new ManagementPolicySchema(rules);
        }
    }
}
