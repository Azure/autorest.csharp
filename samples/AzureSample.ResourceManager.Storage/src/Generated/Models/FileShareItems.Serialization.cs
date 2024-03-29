// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace AzureSample.ResourceManager.Storage.Models
{
    internal partial class FileShareItems
    {
        internal static FileShareItems DeserializeFileShareItems(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<FileShareData> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FileShareData> array = new List<FileShareData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FileShareData.DeserializeFileShareData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new FileShareItems(value ?? new ChangeTrackingList<FileShareData>(), nextLink);
        }
    }
}
