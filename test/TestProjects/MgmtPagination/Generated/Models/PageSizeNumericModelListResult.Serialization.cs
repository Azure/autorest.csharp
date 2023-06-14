// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    internal partial class PageSizeNumericModelListResult
    {
        internal static PageSizeNumericModelListResult DeserializePageSizeNumericModelListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PageSizeNumericModelData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PageSizeNumericModelData> array = new List<PageSizeNumericModelData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageSizeNumericModelData.DeserializePageSizeNumericModelData(item));
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
            return new PageSizeNumericModelListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
