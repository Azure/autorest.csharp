// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtPagination;

namespace MgmtPagination.Models
{
    internal partial class PageSizeFloatModelListResult
    {
        internal static PageSizeFloatModelListResult DeserializePageSizeFloatModelListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PageSizeFloatModelData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PageSizeFloatModelData> array = new List<PageSizeFloatModelData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageSizeFloatModelData.DeserializePageSizeFloatModelData(item));
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
            return new PageSizeFloatModelListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
