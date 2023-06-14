// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class ListBlobInventoryPolicy
    {
        internal static ListBlobInventoryPolicy DeserializeListBlobInventoryPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<BlobInventoryPolicyData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BlobInventoryPolicyData> array = new List<BlobInventoryPolicyData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobInventoryPolicyData.DeserializeBlobInventoryPolicyData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new ListBlobInventoryPolicy(Optional.ToList(value));
        }
    }
}
