// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Management.Storage;

namespace Azure.Management.Storage.Models
{
    internal partial class StoragePrivateEndpointConnectionListResult
    {
        internal static StoragePrivateEndpointConnectionListResult DeserializeStoragePrivateEndpointConnectionListResult(JsonElement element)
        {
            Optional<IReadOnlyList<StoragePrivateEndpointConnectionData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StoragePrivateEndpointConnectionData> array = new List<StoragePrivateEndpointConnectionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StoragePrivateEndpointConnectionData.DeserializeStoragePrivateEndpointConnectionData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new StoragePrivateEndpointConnectionListResult(Optional.ToList(value));
        }
    }
}
