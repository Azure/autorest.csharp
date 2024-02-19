// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Field : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            if (Optional.IsDefined(Key))
            {
                writer.WritePropertyName("key"u8);
                writer.WriteBooleanValue(Key.Value);
            }
            if (Optional.IsDefined(Retrievable))
            {
                writer.WritePropertyName("retrievable"u8);
                writer.WriteBooleanValue(Retrievable.Value);
            }
            if (Optional.IsDefined(Searchable))
            {
                writer.WritePropertyName("searchable"u8);
                writer.WriteBooleanValue(Searchable.Value);
            }
            if (Optional.IsDefined(Filterable))
            {
                writer.WritePropertyName("filterable"u8);
                writer.WriteBooleanValue(Filterable.Value);
            }
            if (Optional.IsDefined(Sortable))
            {
                writer.WritePropertyName("sortable"u8);
                writer.WriteBooleanValue(Sortable.Value);
            }
            if (Optional.IsDefined(Facetable))
            {
                writer.WritePropertyName("facetable"u8);
                writer.WriteBooleanValue(Facetable.Value);
            }
            if (Optional.IsDefined(Analyzer))
            {
                writer.WritePropertyName("analyzer"u8);
                writer.WriteStringValue(Analyzer.Value.ToString());
            }
            if (Optional.IsDefined(SearchAnalyzer))
            {
                writer.WritePropertyName("searchAnalyzer"u8);
                writer.WriteStringValue(SearchAnalyzer.Value.ToString());
            }
            if (Optional.IsDefined(IndexAnalyzer))
            {
                writer.WritePropertyName("indexAnalyzer"u8);
                writer.WriteStringValue(IndexAnalyzer.Value.ToString());
            }
            if (Optional.IsCollectionDefined(SynonymMaps))
            {
                writer.WritePropertyName("synonymMaps"u8);
                writer.WriteStartArray();
                foreach (var item in SynonymMaps)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Fields))
            {
                writer.WritePropertyName("fields"u8);
                writer.WriteStartArray();
                foreach (var item in Fields)
                {
                    if (item != null)
                    {
                        writer.WriteObjectValue(item);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static Field DeserializeField(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            DataType type = default;
            Optional<bool> key = default;
            Optional<bool> retrievable = default;
            Optional<bool> searchable = default;
            Optional<bool> filterable = default;
            Optional<bool> sortable = default;
            Optional<bool> facetable = default;
            Optional<AnalyzerName> analyzer = default;
            Optional<AnalyzerName> searchAnalyzer = default;
            Optional<AnalyzerName> indexAnalyzer = default;
            Optional<IList<string>> synonymMaps = default;
            Optional<IList<Field>> fields = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new DataType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("key"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    key = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("retrievable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retrievable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("searchable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("filterable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filterable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("sortable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sortable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("facetable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    facetable = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("analyzer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    analyzer = new AnalyzerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("searchAnalyzer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchAnalyzer = new AnalyzerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("indexAnalyzer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    indexAnalyzer = new AnalyzerName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("synonymMaps"u8))
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
                    synonymMaps = array;
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Field> array = new List<Field>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(DeserializeField(item));
                        }
                    }
                    fields = array;
                    continue;
                }
            }
            return new Field(name, type, Optional.ToNullable(key), Optional.ToNullable(retrievable), Optional.ToNullable(searchable), Optional.ToNullable(filterable), Optional.ToNullable(sortable), Optional.ToNullable(facetable), Optional.ToNullable(analyzer), Optional.ToNullable(searchAnalyzer), Optional.ToNullable(indexAnalyzer), Optional.ToList(synonymMaps), Optional.ToList(fields));
        }
    }
}
