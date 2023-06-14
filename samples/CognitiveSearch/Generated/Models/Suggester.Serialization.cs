// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Suggester : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("searchMode"u8);
            writer.WriteStringValue(SearchMode.ToSerialString());
            writer.WritePropertyName("sourceFields"u8);
            writer.WriteStartArray();
            foreach (var item in SourceFields)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static Suggester DeserializeSuggester(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            SearchMode searchMode = default;
            IList<string> sourceFields = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("searchMode"u8))
                {
                    searchMode = property.Value.GetString().ToSearchMode();
                    continue;
                }
                if (property.NameEquals("sourceFields"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    sourceFields = array;
                    continue;
                }
            }
            return new Suggester(name, searchMode, sourceFields);
        }
    }
}
