// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class BlobServiceItems
    {
        internal static BlobServiceItems DeserializeBlobServiceItems(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<BlobServiceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BlobServiceData> array = new List<BlobServiceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobServiceData.DeserializeBlobServiceData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new BlobServiceItems(Optional.ToList(value));
        }
    }
}
