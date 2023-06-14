// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TokenInfo
    {
        internal static TokenInfo DeserializeTokenInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string token = default;
            int startOffset = default;
            int endOffset = default;
            int position = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("token"u8))
                {
                    token = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startOffset"u8))
                {
                    startOffset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("endOffset"u8))
                {
                    endOffset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("position"u8))
                {
                    position = property.Value.GetInt32();
                    continue;
                }
            }
            return new TokenInfo(token, startOffset, endOffset, position);
        }
    }
}
