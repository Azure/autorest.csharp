// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Field : IUtf8JsonSerializable, IJsonModel<Field>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Field>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Field>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<Field>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<Field>)} interface");
            }

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
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        Field IJsonModel<Field>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Field)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeField(document.RootElement, options);
        }

        internal static Field DeserializeField(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

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
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                        array.Add(DeserializeField(item));
                    }
                    fields = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Field(name, type, Optional.ToNullable(key), Optional.ToNullable(retrievable), Optional.ToNullable(searchable), Optional.ToNullable(filterable), Optional.ToNullable(sortable), Optional.ToNullable(facetable), Optional.ToNullable(analyzer), Optional.ToNullable(searchAnalyzer), Optional.ToNullable(indexAnalyzer), Optional.ToList(synonymMaps), Optional.ToList(fields), serializedAdditionalRawData);
        }

        BinaryData IModel<Field>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Field)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Field IModel<Field>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Field)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeField(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Field>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
