// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    internal partial class SearchError
    {
        internal static SearchError DeserializeSearchError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> code = default;
            string message = default;
            Optional<IReadOnlyList<SearchError>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<SearchError> array = new List<SearchError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeSearchError(item));
                    }
                    details = array;
                    continue;
                }
            }
            return new SearchError(code.Value, message, Optional.ToList(details));
        }
    }
}
