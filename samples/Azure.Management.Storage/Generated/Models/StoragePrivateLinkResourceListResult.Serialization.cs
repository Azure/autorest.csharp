// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    internal partial class StoragePrivateLinkResourceListResult
    {
        internal static StoragePrivateLinkResourceListResult DeserializeStoragePrivateLinkResourceListResult(JsonElement element)
        {
            Optional<IReadOnlyList<StoragePrivateLinkResource>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StoragePrivateLinkResource> array = new List<StoragePrivateLinkResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StoragePrivateLinkResource.DeserializeStoragePrivateLinkResource(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new StoragePrivateLinkResourceListResult(Optional.ToList(value));
        }
    }
}
