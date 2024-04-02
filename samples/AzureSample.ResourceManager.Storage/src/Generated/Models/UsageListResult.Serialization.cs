// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace AzureSample.ResourceManager.Storage.Models
{
    internal partial class UsageListResult
    {
        internal static UsageListResult DeserializeUsageListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<AzureSampleResourceManagerStorageUsage> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureSampleResourceManagerStorageUsage> array = new List<AzureSampleResourceManagerStorageUsage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureSampleResourceManagerStorageUsage.DeserializeAzureSampleResourceManagerStorageUsage(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new UsageListResult(value ?? new ChangeTrackingList<AzureSampleResourceManagerStorageUsage>());
        }
    }
}
