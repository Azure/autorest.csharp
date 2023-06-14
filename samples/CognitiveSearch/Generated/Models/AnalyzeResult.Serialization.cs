// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AnalyzeResult
    {
        internal static AnalyzeResult DeserializeAnalyzeResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TokenInfo> tokens = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokens"u8))
                {
                    List<TokenInfo> array = new List<TokenInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TokenInfo.DeserializeTokenInfo(item));
                    }
                    tokens = array;
                    continue;
                }
            }
            return new AnalyzeResult(tokens);
        }
    }
}
