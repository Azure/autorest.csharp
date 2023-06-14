// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class StoragePrivateEndpointConnectionListResult
    {
        internal static StoragePrivateEndpointConnectionListResult DeserializeStoragePrivateEndpointConnectionListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<StoragePrivateEndpointConnectionData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
