// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SearchResult
    {
        internal static SearchResult DeserializeSearchResult(JsonElement element)
        {
            SearchResult result;
            double? searchscore = default;
            IDictionary<string, IList<string>> searchhighlights = default;
            IDictionary<string, object> additionalProperties = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@search.score"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchscore = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@search.highlights"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, IList<string>> array = new Dictionary<string, IList<string>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        IList<string> value;
                        List<string> array0 = new List<string>();
                        foreach (var item in property0.Value.EnumerateArray())
                        {
                            array0.Add(item.GetString());
                        }
                        value = array0;
                        array.Add(property0.Name, value);
                    }
                    searchhighlights = array;
                    continue;
                }
                additionalProperties.Add(property.Name, property.Value.GetObject());
            }
            result = new SearchResult(searchscore, searchhighlights, additionalProperties);
            return result;
        }
    }
}
