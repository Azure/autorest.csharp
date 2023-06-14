// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountListKeysResult
    {
        internal static StorageAccountListKeysResult DeserializeStorageAccountListKeysResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<StorageAccountKey>> keys = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keys"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StorageAccountKey> array = new List<StorageAccountKey>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageAccountKey.DeserializeStorageAccountKey(item));
                    }
                    keys = array;
                    continue;
                }
            }
            return new StorageAccountListKeysResult(Optional.ToList(keys));
        }
    }
}
