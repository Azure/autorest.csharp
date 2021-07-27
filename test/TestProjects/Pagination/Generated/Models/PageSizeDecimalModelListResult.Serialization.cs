// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Pagination;

namespace Pagination.Models
{
    internal partial class PageSizeDecimalModelListResult
    {
        internal static PageSizeDecimalModelListResult DeserializePageSizeDecimalModelListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PageSizeDecimalModelData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<PageSizeDecimalModelData> array = new List<PageSizeDecimalModelData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PageSizeDecimalModelData.DeserializePageSizeDecimalModelData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new PageSizeDecimalModelListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
