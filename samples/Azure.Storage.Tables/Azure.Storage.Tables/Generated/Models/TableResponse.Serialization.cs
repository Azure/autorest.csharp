// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class TableResponse
    {
        internal static TableResponse DeserializeTableResponse(JsonElement element)
        {
            string odatametadata = default;
            string tableName = default;
            string odatatype = default;
            string odataid = default;
            string odataeditLink = default;
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
                if (property.NameEquals("TableName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tableName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odatatype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odataid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.editLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odataeditLink = property.Value.GetString();
                    continue;
                }
            }
            return new TableResponse(odatametadata, tableName, odatatype, odataid, odataeditLink);
        }
    }
}
