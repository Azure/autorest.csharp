// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ListIndexersResult
    {
        internal static ListIndexersResult DeserializeListIndexersResult(JsonElement element)
        {
            IList<Indexer> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Indexer> array = new List<Indexer>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Indexer.DeserializeIndexer(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new ListIndexersResult(value);
        }
    }
}
