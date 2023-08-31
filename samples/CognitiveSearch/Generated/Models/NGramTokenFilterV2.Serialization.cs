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
    public partial class NGramTokenFilterV2 : IUtf8JsonSerializable, IModelJsonSerializable<NGramTokenFilterV2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NGramTokenFilterV2>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NGramTokenFilterV2>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenFilterV2>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(MinGram))
            {
                writer.WritePropertyName("minGram"u8);
                writer.WriteNumberValue(MinGram.Value);
            }
            if (Optional.IsDefined(MaxGram))
            {
                writer.WritePropertyName("maxGram"u8);
                writer.WriteNumberValue(MaxGram.Value);
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

        internal static NGramTokenFilterV2 DeserializeNGramTokenFilterV2(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> minGram = default;
            Optional<int> maxGram = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minGram"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxGram"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxGram = property.Value.GetInt32();
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
            return new NGramTokenFilterV2(odataType, name, Optional.ToNullable(minGram), Optional.ToNullable(maxGram), rawData);
        }

        NGramTokenFilterV2 IModelJsonSerializable<NGramTokenFilterV2>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenFilterV2>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeNGramTokenFilterV2(doc.RootElement, options);
        }

        BinaryData IModelSerializable<NGramTokenFilterV2>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenFilterV2>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        NGramTokenFilterV2 IModelSerializable<NGramTokenFilterV2>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenFilterV2>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeNGramTokenFilterV2(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="NGramTokenFilterV2"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="NGramTokenFilterV2"/> to convert. </param>
        public static implicit operator RequestContent(NGramTokenFilterV2 model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="NGramTokenFilterV2"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator NGramTokenFilterV2(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeNGramTokenFilterV2(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
