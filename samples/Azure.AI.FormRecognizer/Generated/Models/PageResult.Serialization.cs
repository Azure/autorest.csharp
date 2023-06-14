// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int page = default;
            Optional<int> clusterId = default;
            Optional<IReadOnlyList<KeyValuePair>> keyValuePairs = default;
            Optional<IReadOnlyList<DataTable>> tables = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("page"u8))
                {
                    page = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("clusterId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    clusterId = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("keyValuePairs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                if (property.NameEquals("tables"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
