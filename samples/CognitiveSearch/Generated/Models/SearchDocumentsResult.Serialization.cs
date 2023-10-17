// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class SearchDocumentsResult : IUtf8JsonSerializable, IModelJsonSerializable<SearchDocumentsResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SearchDocumentsResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SearchDocumentsResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Count))
            {
                writer.WritePropertyName("@odata.count"u8);
                writer.WriteNumberValue(Count.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Coverage))
            {
                writer.WritePropertyName("@search.coverage"u8);
                writer.WriteNumberValue(Coverage.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(Facets))
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
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(NextPageParameters))
            {
                writer.WritePropertyName("@search.nextPageParameters"u8);
                writer.WriteObjectValue(NextPageParameters);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Results)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("@odata.nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }

        SearchDocumentsResult IModelJsonSerializable<SearchDocumentsResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSearchDocumentsResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<SearchDocumentsResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        SearchDocumentsResult IModelSerializable<SearchDocumentsResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSearchDocumentsResult(document.RootElement, options);
        }

        internal static SearchDocumentsResult DeserializeSearchDocumentsResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            }
            return new SearchDocumentsResult(Optional.ToNullable(odataCount), Optional.ToNullable(searchCoverage), Optional.ToDictionary(searchFacets), searchNextPageParameters.Value, value, odataNextLink.Value);
        }
    }
}
