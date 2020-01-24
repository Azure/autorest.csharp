// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ListDataSourcesResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (DataSources != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStartArray();
                foreach (var item in DataSources)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static ListDataSourcesResult DeserializeListDataSourcesResult(JsonElement element)
        {
            ListDataSourcesResult result = new ListDataSourcesResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DataSources = new List<DataSource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.DataSources.Add(DataSource.DeserializeDataSource(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
