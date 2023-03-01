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
    internal partial class ListBlobInventoryPolicy
    {
        internal static ListBlobInventoryPolicy DeserializeListBlobInventoryPolicy(JsonElement element)
        {
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
