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
    public partial class NGramTokenizer : IUtf8JsonSerializable, IModelJsonSerializable<NGramTokenizer>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NGramTokenizer>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NGramTokenizer>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenizer>(this, options.Format);

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
            if (Optional.IsCollectionDefined(TokenChars))
            {
                writer.WritePropertyName("tokenChars"u8);
                writer.WriteStartArray();
                foreach (var item in TokenChars)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static NGramTokenizer DeserializeNGramTokenizer(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> minGram = default;
            Optional<int> maxGram = default;
            Optional<IList<TokenCharacterKind>> tokenChars = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("tokenChars"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TokenCharacterKind> array = new List<TokenCharacterKind>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToTokenCharacterKind());
                    }
                    tokenChars = array;
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
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new NGramTokenizer(odataType, name, Optional.ToNullable(minGram), Optional.ToNullable(maxGram), Optional.ToList(tokenChars), serializedAdditionalRawData);
        }

        NGramTokenizer IModelJsonSerializable<NGramTokenizer>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenizer>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeNGramTokenizer(doc.RootElement, options);
        }

        BinaryData IModelSerializable<NGramTokenizer>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenizer>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        NGramTokenizer IModelSerializable<NGramTokenizer>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<NGramTokenizer>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeNGramTokenizer(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="NGramTokenizer"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="NGramTokenizer"/> to convert. </param>
        public static implicit operator RequestContent(NGramTokenizer model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="NGramTokenizer"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator NGramTokenizer(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeNGramTokenizer(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
