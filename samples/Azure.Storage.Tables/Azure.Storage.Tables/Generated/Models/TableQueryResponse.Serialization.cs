// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class TableQueryResponse
    {
        internal static TableQueryResponse DeserializeTableQueryResponse(JsonElement element)
        {
            string odatametadata = default;
            IList<TableResponseProperties> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("odata.metadata"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odatametadata = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TableResponseProperties> array = new List<TableResponseProperties>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TableResponseProperties.DeserializeTableResponseProperties(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new TableQueryResponse(odatametadata, value);
        }
    }
}
