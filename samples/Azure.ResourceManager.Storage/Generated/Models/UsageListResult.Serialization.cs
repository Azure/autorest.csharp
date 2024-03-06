// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class UsageListResult
    {
        internal static UsageListResult DeserializeUsageListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<StorageUsage> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StorageUsage> array = new List<StorageUsage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageUsage.DeserializeStorageUsage(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new UsageListResult(value ?? new ChangeTrackingList<StorageUsage>());
        }
    }
}
