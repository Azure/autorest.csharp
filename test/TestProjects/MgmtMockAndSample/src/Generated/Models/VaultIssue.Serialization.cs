// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class VaultIssue
    {
        internal static VaultIssue DeserializeVaultIssue(JsonElement element)
        {
            Optional<string> type = default;
            Optional<string> description = default;
            Optional<int> sev = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sev"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sev = property.Value.GetInt32();
                    continue;
                }
            }
            return new VaultIssue(type.Value, description.Value, Optional.ToNullable(sev));
        }
    }
}
