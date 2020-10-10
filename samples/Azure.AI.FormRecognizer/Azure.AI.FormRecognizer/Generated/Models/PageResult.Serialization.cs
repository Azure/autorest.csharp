// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class PageResult
    {
        internal static PageResult DeserializePageResult(JsonElement element)
        {
            int page = default;
            Optional<int> clusterId = default;
            Optional<IReadOnlyList<KeyValuePair>> keyValuePairs = default;
            Optional<IReadOnlyList<DataTable>> tables = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("page"))
                {
                    page = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("clusterId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    clusterId = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("keyValuePairs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<KeyValuePair> array = new List<KeyValuePair>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(KeyValuePair.DeserializeKeyValuePair(item));
                    }
                    keyValuePairs = array;
                    continue;
                }
                if (property.NameEquals("tables"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<DataTable> array = new List<DataTable>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DataTable.DeserializeDataTable(item));
                    }
                    tables = array;
                    continue;
                }
            }
            return new PageResult(page, Optional.ToNullable(clusterId), Optional.ToList(keyValuePairs), Optional.ToList(tables));
        }
    }
}
