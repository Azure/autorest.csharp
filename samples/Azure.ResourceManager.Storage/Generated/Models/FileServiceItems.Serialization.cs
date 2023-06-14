// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class FileServiceItems
    {
        internal static FileServiceItems DeserializeFileServiceItems(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<FileServiceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
