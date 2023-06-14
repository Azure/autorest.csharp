// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ListSynonymMapsResult
    {
        internal static ListSynonymMapsResult DeserializeListSynonymMapsResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SynonymMap> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SynonymMap> array = new List<SynonymMap>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SynonymMap.DeserializeSynonymMap(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new ListSynonymMapsResult(value);
        }
    }
}
