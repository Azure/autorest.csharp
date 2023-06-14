// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AutocompleteResult
    {
        internal static AutocompleteResult DeserializeAutocompleteResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<double> searchCoverage = default;
            IReadOnlyList<AutocompleteItem> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@search.coverage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchCoverage = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    List<AutocompleteItem> array = new List<AutocompleteItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AutocompleteItem.DeserializeAutocompleteItem(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new AutocompleteResult(Optional.ToNullable(searchCoverage), value);
        }
    }
}
