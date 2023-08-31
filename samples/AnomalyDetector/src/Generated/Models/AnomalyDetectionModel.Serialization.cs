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

namespace AnomalyDetector.Models
{
    public partial class AnomalyDetectionModel : IUtf8JsonSerializable, IModelJsonSerializable<AnomalyDetectionModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AnomalyDetectionModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AnomalyDetectionModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("createdTime"u8);
            writer.WriteStringValue(CreatedTime, "O");
            writer.WritePropertyName("lastUpdatedTime"u8);
            writer.WriteStringValue(LastUpdatedTime, "O");
            if (Optional.IsDefined(ModelInfo))
            {
                writer.WritePropertyName("modelInfo"u8);
                ((IModelJsonSerializable<ModelInfo>)ModelInfo).Serialize(writer, options);
            }
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

        internal static AnomalyDetectionModel DeserializeAnomalyDetectionModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid modelId = default;
            DateTimeOffset createdTime = default;
            DateTimeOffset lastUpdatedTime = default;
            Optional<ModelInfo> modelInfo = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("modelId"u8))
                {
                    modelId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("createdTime"u8))
                {
                    createdTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastUpdatedTime"u8))
                {
                    lastUpdatedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("modelInfo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelInfo = ModelInfo.DeserializeModelInfo(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new AnomalyDetectionModel(modelId, createdTime, lastUpdatedTime, modelInfo.Value, rawData);
        }

        AnomalyDetectionModel IModelJsonSerializable<AnomalyDetectionModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAnomalyDetectionModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AnomalyDetectionModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        AnomalyDetectionModel IModelSerializable<AnomalyDetectionModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeAnomalyDetectionModel(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="AnomalyDetectionModel"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="AnomalyDetectionModel"/> to convert. </param>
        public static implicit operator RequestContent(AnomalyDetectionModel model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="AnomalyDetectionModel"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator AnomalyDetectionModel(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAnomalyDetectionModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
