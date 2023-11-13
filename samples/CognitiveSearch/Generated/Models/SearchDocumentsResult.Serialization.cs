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
    public partial class SearchDocumentsResult : IUtf8JsonSerializable, IJsonModel<SearchDocumentsResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SearchDocumentsResult>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<SearchDocumentsResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<SearchDocumentsResult>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<SearchDocumentsResult>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Count))
                {
                    writer.WritePropertyName("@odata.count"u8);
                    writer.WriteNumberValue(Count.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Coverage))
                {
                    writer.WritePropertyName("@search.coverage"u8);
                    writer.WriteNumberValue(Coverage.Value);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsCollectionDefined(Facets))
                {
                    writer.WritePropertyName("@search.facets"u8);
                    writer.WriteStartObject();
                    foreach (var item in Facets)
                    {
                        writer.WritePropertyName(item.Key);
                        if (item.Value == null)
                        {
                            writer.WriteNullValue();
                            continue;
                        }
                        writer.WriteStartArray();
                        foreach (var item0 in item.Value)
                        {
                            writer.WriteObjectValue(item0);
                        }
                        writer.WriteEndArray();
                    }
                    writer.WriteEndObject();
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(NextPageParameters))
                {
                    writer.WritePropertyName("@search.nextPageParameters"u8);
                    writer.WriteObjectValue(NextPageParameters);
                }
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Results)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(NextLink))
                {
                    writer.WritePropertyName("@odata.nextLink"u8);
                    writer.WriteStringValue(NextLink);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        SearchDocumentsResult IJsonModel<SearchDocumentsResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchDocumentsResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSearchDocumentsResult(document.RootElement, options);
        }

        internal static SearchDocumentsResult DeserializeSearchDocumentsResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<long> odataCount = default;
            Optional<double> searchCoverage = default;
            Optional<IReadOnlyDictionary<string, IList<FacetResult>>> searchFacets = default;
            Optional<SearchRequest> searchNextPageParameters = default;
            IReadOnlyList<SearchResult> value = default;
            Optional<string> odataNextLink = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    odataCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("@search.coverage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchCoverage = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@search.facets"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, IList<FacetResult>> dictionary = new Dictionary<string, IList<FacetResult>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            List<FacetResult> array = new List<FacetResult>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(FacetResult.DeserializeFacetResult(item));
                            }
                            dictionary.Add(property0.Name, array);
                        }
                    }
                    searchFacets = dictionary;
                    continue;
                }
                if (property.NameEquals("@search.nextPageParameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    searchNextPageParameters = SearchRequest.DeserializeSearchRequest(property.Value);
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    List<SearchResult> array = new List<SearchResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SearchResult.DeserializeSearchResult(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("@odata.nextLink"u8))
                {
                    odataNextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SearchDocumentsResult(Optional.ToNullable(odataCount), Optional.ToNullable(searchCoverage), Optional.ToDictionary(searchFacets), searchNextPageParameters.Value, value, odataNextLink.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SearchDocumentsResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchDocumentsResult)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        SearchDocumentsResult IPersistableModel<SearchDocumentsResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SearchDocumentsResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSearchDocumentsResult(document.RootElement, options);
        }

        string IPersistableModel<SearchDocumentsResult>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
