// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class StorageAccountListResult
    {
        internal static StorageAccountListResult DeserializeStorageAccountListResult(JsonElement element)
        {
            Optional<IReadOnlyList<StorageAccount>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StorageAccount> array = new List<StorageAccount>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StorageAccount.DeserializeStorageAccount(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new StorageAccountListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
