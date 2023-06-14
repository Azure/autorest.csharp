// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DictionaryDecompounderTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("wordList"u8);
            writer.WriteStartArray();
            foreach (var item in WordList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(MinWordSize))
            {
                writer.WritePropertyName("minWordSize"u8);
                writer.WriteNumberValue(MinWordSize.Value);
            }
            if (Optional.IsDefined(MinSubwordSize))
            {
                writer.WritePropertyName("minSubwordSize"u8);
                writer.WriteNumberValue(MinSubwordSize.Value);
            }
            if (Optional.IsDefined(MaxSubwordSize))
            {
                writer.WritePropertyName("maxSubwordSize"u8);
                writer.WriteNumberValue(MaxSubwordSize.Value);
            }
            if (Optional.IsDefined(OnlyLongestMatch))
            {
                writer.WritePropertyName("onlyLongestMatch"u8);
                writer.WriteBooleanValue(OnlyLongestMatch.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static DictionaryDecompounderTokenFilter DeserializeDictionaryDecompounderTokenFilter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> wordList = default;
            Optional<int> minWordSize = default;
            Optional<int> minSubwordSize = default;
            Optional<int> maxSubwordSize = default;
            Optional<bool> onlyLongestMatch = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("wordList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    wordList = array;
                    continue;
                }
                if (property.NameEquals("minWordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minWordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("minSubwordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minSubwordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxSubwordSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxSubwordSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("onlyLongestMatch"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    onlyLongestMatch = property.Value.GetBoolean();
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
            return new DictionaryDecompounderTokenFilter(odataType, name, wordList, Optional.ToNullable(minWordSize), Optional.ToNullable(minSubwordSize), Optional.ToNullable(maxSubwordSize), Optional.ToNullable(onlyLongestMatch));
        }
    }
}
