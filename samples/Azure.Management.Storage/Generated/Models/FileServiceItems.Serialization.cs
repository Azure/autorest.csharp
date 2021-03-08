// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class FileServiceItems
    {
        internal static FileServiceItems DeserializeFileServiceItems(JsonElement element)
        {
            Optional<IReadOnlyList<FileServiceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<FileServiceData> array = new List<FileServiceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FileServiceData.DeserializeFileServiceData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new FileServiceItems(Optional.ToList(value));
        }
    }
}
