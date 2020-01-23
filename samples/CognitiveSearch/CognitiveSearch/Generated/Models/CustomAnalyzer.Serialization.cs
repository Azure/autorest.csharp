// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CustomAnalyzer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tokenizer");
            writer.WriteStringValue(Tokenizer.ToString());
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
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static CustomAnalyzer DeserializeCustomAnalyzer(JsonElement element)
        {
            CustomAnalyzer result = new CustomAnalyzer();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokenizer"))
                {
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
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
