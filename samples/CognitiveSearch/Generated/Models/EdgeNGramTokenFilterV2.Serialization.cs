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
    public partial class EdgeNGramTokenFilterV2 : IUtf8JsonSerializable, IModelJsonSerializable<EdgeNGramTokenFilterV2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<EdgeNGramTokenFilterV2>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<EdgeNGramTokenFilterV2>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<EdgeNGramTokenFilterV2>(this, options.Format);

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
            if (Optional.IsDefined(Side))
            {
                writer.WritePropertyName("side"u8);
                writer.WriteStringValue(Side.Value.ToSerialString());
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

        internal static EdgeNGramTokenFilterV2 DeserializeEdgeNGramTokenFilterV2(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> minGram = default;
            Optional<int> maxGram = default;
            Optional<EdgeNGramTokenFilterSide> side = default;
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
                if (property.NameEquals("side"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    side = property.Value.GetString().ToEdgeNGramTokenFilterSide();
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
            return new EdgeNGramTokenFilterV2(odataType, name, Optional.ToNullable(minGram), Optional.ToNullable(maxGram), Optional.ToNullable(side), rawData);
        }

        EdgeNGramTokenFilterV2 IModelJsonSerializable<EdgeNGramTokenFilterV2>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<EdgeNGramTokenFilterV2>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEdgeNGramTokenFilterV2(doc.RootElement, options);
        }

        BinaryData IModelSerializable<EdgeNGramTokenFilterV2>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<EdgeNGramTokenFilterV2>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        EdgeNGramTokenFilterV2 IModelSerializable<EdgeNGramTokenFilterV2>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<EdgeNGramTokenFilterV2>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEdgeNGramTokenFilterV2(doc.RootElement, options);
        }

        public static implicit operator RequestContent(EdgeNGramTokenFilterV2 model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator EdgeNGramTokenFilterV2(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEdgeNGramTokenFilterV2(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
