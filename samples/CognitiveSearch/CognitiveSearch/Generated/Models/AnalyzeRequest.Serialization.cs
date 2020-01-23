// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AnalyzeRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            if (Analyzer != null)
            {
                writer.WritePropertyName("analyzer");
                writer.WriteStringValue(Analyzer.Value.ToString());
            }
            if (Tokenizer != null)
            {
                writer.WritePropertyName("tokenizer");
                writer.WriteStringValue(Tokenizer.Value.ToString());
            }
            if (TokenFilters != null)
            {
                writer.WritePropertyName("tokenFilters");
                writer.WriteStartArray();
                foreach (var item in TokenFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (CharFilters != null)
            {
                writer.WritePropertyName("charFilters");
                writer.WriteStartArray();
                foreach (var item in CharFilters)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static AnalyzeRequest DeserializeAnalyzeRequest(JsonElement element)
        {
            AnalyzeRequest result = new AnalyzeRequest();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("analyzer"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Analyzer = new AnalyzerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tokenizer"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Tokenizer = new TokenizerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tokenFilters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.TokenFilters = new List<TokenFilterName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.TokenFilters.Add(new TokenFilterName(item.GetString()));
                    }
                    continue;
                }
                if (property.NameEquals("charFilters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CharFilters = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.CharFilters.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
