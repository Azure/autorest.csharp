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
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> odataMetadata = default;
            Optional<IReadOnlyList<TableResponseProperties>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("odata.metadata"u8))
                {
                    odataMetadata = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
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
            return new TableQueryResponse(odataMetadata.Value, Optional.ToList(value));
        }
    }
}