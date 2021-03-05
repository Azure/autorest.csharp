// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class BlobServiceItems
    {
        internal static BlobServiceItems DeserializeBlobServiceItems(JsonElement element)
        {
            Optional<IReadOnlyList<BlobServiceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
