// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtMockAndSample.Models
{
    internal partial class VaultListResult
    {
        internal static VaultListResult DeserializeVaultListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<VaultData> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultData> array = new List<VaultData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultData.DeserializeVaultData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new VaultListResult(value ?? new ChangeTrackingList<VaultData>(), nextLink);
        }
    }
}
