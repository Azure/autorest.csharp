// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    internal partial class PageSizeInt32ModelListResult
    {
        internal static PageSizeInt32ModelListResult DeserializePageSizeInt32ModelListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PageSizeInt32ModelData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PageSizeInt32ModelData> array = new List<PageSizeInt32ModelData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageSizeInt32ModelData.DeserializePageSizeInt32ModelData(item));
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
            return new PageSizeInt32ModelListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
