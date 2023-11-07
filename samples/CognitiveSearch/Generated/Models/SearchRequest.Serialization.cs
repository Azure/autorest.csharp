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
    public partial class SearchRequest : IUtf8JsonSerializable, IJsonModel<SearchRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SearchRequest>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<SearchRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IncludeTotalResultCount))
            {
                writer.WritePropertyName("count"u8);
                writer.WriteBooleanValue(IncludeTotalResultCount.Value);
            }
            if (Optional.IsCollectionDefined(Facets))
            {
                writer.WritePropertyName("facets"u8);
                writer.WriteStartArray();
                foreach (var item in Facets)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Filter))
            {
                writer.WritePropertyName("filter"u8);
                writer.WriteStringValue(Filter);
            }
            if (Optional.IsDefined(HighlightFields))
            {
                writer.WritePropertyName("highlight"u8);
                writer.WriteStringValue(HighlightFields);
            }
            if (Optional.IsDefined(HighlightPostTag))
            {
                writer.WritePropertyName("highlightPostTag"u8);
                writer.WriteStringValue(HighlightPostTag);
            }
            if (Optional.IsDefined(HighlightPreTag))
            {
                writer.WritePropertyName("highlightPreTag"u8);
                writer.WriteStringValue(HighlightPreTag);
            }
            if (Optional.IsDefined(MinimumCoverage))
            {
                writer.WritePropertyName("minimumCoverage"u8);
                writer.WriteNumberValue(MinimumCoverage.Value);
            }
            if (Optional.IsDefined(OrderBy))
            {
                writer.WritePropertyName("orderby"u8);
                writer.WriteStringValue(OrderBy);
            }
            if (Optional.IsDefined(QueryType))
            {
                writer.WritePropertyName("queryType"u8);
                writer.WriteStringValue(QueryType.Value.ToSerialString());
            }
            if (Optional.IsCollectionDefined(ScoringParameters))
            {
                writer.WritePropertyName("scoringParameters"u8);
                writer.WriteStartArray();
                foreach (var item in ScoringParameters)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ScoringProfile))
            {
                writer.WritePropertyName("scoringProfile"u8);
                writer.WriteStringValue(ScoringProfile);
            }
            if (Optional.IsDefined(SearchText))
            {
                writer.WritePropertyName("search"u8);
                writer.WriteStringValue(SearchText);
            }
            if (Optional.IsDefined(SearchFields))
            {
                writer.WritePropertyName("searchFields"u8);
                writer.WriteStringValue(SearchFields);
            }
            if (Optional.IsDefined(SearchMode))
            {
                writer.WritePropertyName("searchMode"u8);
                writer.WriteStringValue(SearchMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(Select))
            {
                writer.WritePropertyName("select"u8);
                writer.WriteStringValue(Select);
            }
            if (Optional.IsDefined(Skip))
            {
                writer.WritePropertyName("skip"u8);
                writer.WriteNumberValue(Skip.Value);
            }
            if (Optional.IsDefined(Top))
            {
                writer.WritePropertyName("top"u8);
                writer.WriteNumberValue(Top.Value);
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

        SearchRequest IJsonModel<SearchRequest>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSearchRequest(document.RootElement, options);
        }

        internal static SearchRequest DeserializeSearchRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> count = default;
            Optional<IList<string>> facets = default;
            Optional<string> filter = default;
            Optional<string> highlight = default;
            Optional<string> highlightPostTag = default;
            Optional<string> highlightPreTag = default;
            Optional<double> minimumCoverage = default;
            Optional<string> orderby = default;
            Optional<QueryType> queryType = default;
            Optional<IList<string>> scoringParameters = default;
            Optional<string> scoringProfile = default;
            Optional<string> search = default;
            Optional<string> searchFields = default;
            Optional<SearchMode> searchMode = default;
            Optional<string> select = default;
            Optional<int> skip = default;
            Optional<int> top = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    count = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("facets"u8))
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
                    facets = array;
                    continue;
                }
                if (property.NameEquals("filter"u8))
                {
                    filter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("highlight"u8))
                {
                    highlight = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("highlightPostTag"u8))
                {
                    highlightPostTag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("highlightPreTag"u8))
                {
                    highlightPreTag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("minimumCoverage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minimumCoverage = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("orderby"u8))
                {
                    orderby = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queryType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    queryType = property.Value.GetString().ToQueryType();
                    continue;
                }
                if (property.NameEquals("scoringParameters"u8))
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
                    scoringParameters = array;
                    continue;
                }
                if (property.NameEquals("scoringProfile"u8))
                {
                    scoringProfile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("search"u8))
                {
                    search = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("searchFields"u8))
                {
                    searchFields = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("searchMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchMode = property.Value.GetString().ToSearchMode();
                    continue;
                }
                if (property.NameEquals("select"u8))
                {
                    select = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("skip"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    skip = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("top"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    top = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SearchRequest(Optional.ToNullable(count), Optional.ToList(facets), filter.Value, highlight.Value, highlightPostTag.Value, highlightPreTag.Value, Optional.ToNullable(minimumCoverage), orderby.Value, Optional.ToNullable(queryType), Optional.ToList(scoringParameters), scoringProfile.Value, search.Value, searchFields.Value, Optional.ToNullable(searchMode), select.Value, Optional.ToNullable(skip), Optional.ToNullable(top), serializedAdditionalRawData);
        }

        BinaryData IModel<SearchRequest>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchRequest)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        SearchRequest IModel<SearchRequest>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSearchRequest(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<SearchRequest>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
