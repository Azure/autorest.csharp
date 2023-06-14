// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class StopwordsTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Stopwords))
            {
                writer.WritePropertyName("stopwords"u8);
                writer.WriteStartArray();
                foreach (var item in Stopwords)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(StopwordsList))
            {
                writer.WritePropertyName("stopwordsList"u8);
                writer.WriteStringValue(StopwordsList.Value.ToSerialString());
            }
            if (Optional.IsDefined(IgnoreCase))
            {
                writer.WritePropertyName("ignoreCase"u8);
                writer.WriteBooleanValue(IgnoreCase.Value);
            }
            if (Optional.IsDefined(RemoveTrailingStopWords))
            {
                writer.WritePropertyName("removeTrailing"u8);
                writer.WriteBooleanValue(RemoveTrailingStopWords.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static StopwordsTokenFilter DeserializeStopwordsTokenFilter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> stopwords = default;
            Optional<StopwordsList> stopwordsList = default;
            Optional<bool> ignoreCase = default;
            Optional<bool> removeTrailing = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("stopwords"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    stopwords = array;
                    continue;
                }
                if (property.NameEquals("stopwordsList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    stopwordsList = property.Value.GetString().ToStopwordsList();
                    continue;
                }
                if (property.NameEquals("ignoreCase"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    ignoreCase = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("removeTrailing"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    removeTrailing = property.Value.GetBoolean();
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
            return new StopwordsTokenFilter(odataType, name, Optional.ToList(stopwords), Optional.ToNullable(stopwordsList), Optional.ToNullable(ignoreCase), Optional.ToNullable(removeTrailing));
        }
    }
}
