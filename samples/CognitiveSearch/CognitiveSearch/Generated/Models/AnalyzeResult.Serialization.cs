// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AnalyzeResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Tokens != null)
            {
                writer.WritePropertyName("tokens");
                writer.WriteStartArray();
                foreach (var item in Tokens)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static AnalyzeResult DeserializeAnalyzeResult(JsonElement element)
        {
            AnalyzeResult result = new AnalyzeResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokens"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Tokens = new List<TokenInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Tokens.Add(TokenInfo.DeserializeTokenInfo(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
