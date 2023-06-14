// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<Indexer> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
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
