// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class StorageAccountListKeysResult
    {
        internal static StorageAccountListKeysResult DeserializeStorageAccountListKeysResult(JsonElement element)
        {
            IReadOnlyList<StorageAccountKey> keys = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keys"))
                {
                    List<StorageAccountKey> array = new List<StorageAccountKey>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageAccountKey.DeserializeStorageAccountKey(item));
                    }
                    keys = array;
                    continue;
                }
            }
            return new StorageAccountListKeysResult(keys);
        }
    }
}
