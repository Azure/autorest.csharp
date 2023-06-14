// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    internal partial class PageSizeIntegerModelListResult
    {
        internal static PageSizeIntegerModelListResult DeserializePageSizeIntegerModelListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PageSizeIntegerModelData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PageSizeIntegerModelData> array = new List<PageSizeIntegerModelData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageSizeIntegerModelData.DeserializePageSizeIntegerModelData(item));
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
            return new PageSizeIntegerModelListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
