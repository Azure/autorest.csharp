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
    public partial class ClassicSimilarity : IUtf8JsonSerializable, IModelJsonSerializable<ClassicSimilarity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ClassicSimilarity>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ClassicSimilarity>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ClassicSimilarity>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
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

        internal static ClassicSimilarity DeserializeClassicSimilarity(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string odataType = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ClassicSimilarity(odataType, rawData);
        }

        ClassicSimilarity IModelJsonSerializable<ClassicSimilarity>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ClassicSimilarity>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeClassicSimilarity(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ClassicSimilarity>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ClassicSimilarity>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ClassicSimilarity IModelSerializable<ClassicSimilarity>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ClassicSimilarity>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeClassicSimilarity(doc.RootElement, options);
        }

        public static implicit operator RequestContent(ClassicSimilarity model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ClassicSimilarity(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeClassicSimilarity(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
