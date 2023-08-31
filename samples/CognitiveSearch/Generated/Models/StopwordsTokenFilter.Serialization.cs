// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class StopwordsTokenFilter : IUtf8JsonSerializable, IModelJsonSerializable<StopwordsTokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<StopwordsTokenFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<StopwordsTokenFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<StopwordsTokenFilter>(this, options.Format);

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
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static StopwordsTokenFilter DeserializeStopwordsTokenFilter(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new StopwordsTokenFilter(odataType, name, Optional.ToList(stopwords), Optional.ToNullable(stopwordsList), Optional.ToNullable(ignoreCase), Optional.ToNullable(removeTrailing), rawData);
        }

        StopwordsTokenFilter IModelJsonSerializable<StopwordsTokenFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<StopwordsTokenFilter>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeStopwordsTokenFilter(doc.RootElement, options);
        }

        BinaryData IModelSerializable<StopwordsTokenFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<StopwordsTokenFilter>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        StopwordsTokenFilter IModelSerializable<StopwordsTokenFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<StopwordsTokenFilter>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeStopwordsTokenFilter(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="StopwordsTokenFilter"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="StopwordsTokenFilter"/> to convert. </param>
        public static implicit operator RequestContent(StopwordsTokenFilter model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="StopwordsTokenFilter"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator StopwordsTokenFilter(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeStopwordsTokenFilter(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
