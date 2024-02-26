// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class StorageAccountListResult
    {
        internal static StorageAccountListResult DeserializeStorageAccountListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<StorageAccountData> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StorageAccountData> array = new List<StorageAccountData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageAccountData.DeserializeStorageAccountData(item));
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
            return new StorageAccountListResult(value ?? new ChangeTrackingList<StorageAccountData>(), nextLink);
        }
    }
}
