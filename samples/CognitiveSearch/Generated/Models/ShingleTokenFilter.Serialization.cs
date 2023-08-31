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
    public partial class ShingleTokenFilter : IUtf8JsonSerializable, IModelJsonSerializable<ShingleTokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ShingleTokenFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ShingleTokenFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ShingleTokenFilter>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(MaxShingleSize))
            {
                writer.WritePropertyName("maxShingleSize"u8);
                writer.WriteNumberValue(MaxShingleSize.Value);
            }
            if (Optional.IsDefined(MinShingleSize))
            {
                writer.WritePropertyName("minShingleSize"u8);
                writer.WriteNumberValue(MinShingleSize.Value);
            }
            if (Optional.IsDefined(OutputUnigrams))
            {
                writer.WritePropertyName("outputUnigrams"u8);
                writer.WriteBooleanValue(OutputUnigrams.Value);
            }
            if (Optional.IsDefined(OutputUnigramsIfNoShingles))
            {
                writer.WritePropertyName("outputUnigramsIfNoShingles"u8);
                writer.WriteBooleanValue(OutputUnigramsIfNoShingles.Value);
            }
            if (Optional.IsDefined(TokenSeparator))
            {
                writer.WritePropertyName("tokenSeparator"u8);
                writer.WriteStringValue(TokenSeparator);
            }
            if (Optional.IsDefined(FilterToken))
            {
                writer.WritePropertyName("filterToken"u8);
                writer.WriteStringValue(FilterToken);
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

        internal static ShingleTokenFilter DeserializeShingleTokenFilter(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> maxShingleSize = default;
            Optional<int> minShingleSize = default;
            Optional<bool> outputUnigrams = default;
            Optional<bool> outputUnigramsIfNoShingles = default;
            Optional<string> tokenSeparator = default;
            Optional<string> filterToken = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxShingleSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxShingleSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("minShingleSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minShingleSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("outputUnigrams"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outputUnigrams = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("outputUnigramsIfNoShingles"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outputUnigramsIfNoShingles = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tokenSeparator"u8))
                {
                    tokenSeparator = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filterToken"u8))
                {
                    filterToken = property.Value.GetString();
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
            return new ShingleTokenFilter(odataType, name, Optional.ToNullable(maxShingleSize), Optional.ToNullable(minShingleSize), Optional.ToNullable(outputUnigrams), Optional.ToNullable(outputUnigramsIfNoShingles), tokenSeparator.Value, filterToken.Value, rawData);
        }

        ShingleTokenFilter IModelJsonSerializable<ShingleTokenFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ShingleTokenFilter>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeShingleTokenFilter(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ShingleTokenFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ShingleTokenFilter>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ShingleTokenFilter IModelSerializable<ShingleTokenFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ShingleTokenFilter>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeShingleTokenFilter(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ShingleTokenFilter"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ShingleTokenFilter"/> to convert. </param>
        public static implicit operator RequestContent(ShingleTokenFilter model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ShingleTokenFilter"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ShingleTokenFilter(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeShingleTokenFilter(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
