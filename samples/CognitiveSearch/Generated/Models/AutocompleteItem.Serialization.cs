// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AutocompleteItem
    {
        internal static AutocompleteItem DeserializeAutocompleteItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            string queryPlusText = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queryPlusText"u8))
                {
                    queryPlusText = property.Value.GetString();
                    continue;
                }
            }
            return new AutocompleteItem(text, queryPlusText);
        }
    }
}
