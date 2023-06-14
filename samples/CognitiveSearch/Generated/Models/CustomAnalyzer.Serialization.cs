// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
            writer.WritePropertyName("tokenizer"u8);
            writer.WriteStringValue(Tokenizer.ToString());
            if (Optional.IsCollectionDefined(TokenFilters))
            {
                writer.WritePropertyName("tokenFilters"u8);
                writer.WriteStartArray();
                foreach (var item in TokenFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(CharFilters))
            {
                writer.WritePropertyName("charFilters"u8);
                writer.WriteStartArray();
                foreach (var item in CharFilters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static CustomAnalyzer DeserializeCustomAnalyzer(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            TokenizerName tokenizer = default;
            Optional<IList<TokenFilterName>> tokenFilters = default;
            Optional<IList<CharFilterName>> charFilters = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokenizer"u8))
                {
                    tokenizer = new TokenizerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tokenFilters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TokenFilterName> array = new List<TokenFilterName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new TokenFilterName(item.GetString()));
                    }
                    tokenFilters = array;
                    continue;
                }
                if (property.NameEquals("charFilters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CharFilterName> array = new List<CharFilterName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CharFilterName(item.GetString()));
                    }
                    charFilters = array;
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new CustomAnalyzer(odataType, name, tokenizer, Optional.ToList(tokenFilters), Optional.ToList(charFilters));
        }
    }
}
