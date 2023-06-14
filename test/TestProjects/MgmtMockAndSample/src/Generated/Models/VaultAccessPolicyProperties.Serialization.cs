// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class VaultAccessPolicyProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("accessPolicies"u8);
            writer.WriteStartArray();
            foreach (var item in AccessPolicies)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static VaultAccessPolicyProperties DeserializeVaultAccessPolicyProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<AccessPolicyEntry> accessPolicies = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("accessPolicies"u8))
                {
                    List<AccessPolicyEntry> array = new List<AccessPolicyEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AccessPolicyEntry.DeserializeAccessPolicyEntry(item));
                    }
                    accessPolicies = array;
                    continue;
                }
            }
            return new VaultAccessPolicyProperties(accessPolicies);
        }
    }
}
