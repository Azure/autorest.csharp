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

namespace Azure.AI.FormRecognizer.Models
{
    public partial class Model : IUtf8JsonSerializable, IModelJsonSerializable<Model>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Model>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Model>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("modelInfo"u8);
            ((IModelJsonSerializable<ModelInfo>)ModelInfo).Serialize(writer, options);
            if (Optional.IsDefined(Keys))
            {
                writer.WritePropertyName("keys"u8);
                ((IModelJsonSerializable<KeysResult>)Keys).Serialize(writer, options);
            }
            if (Optional.IsDefined(TrainResult))
            {
                writer.WritePropertyName("trainResult"u8);
                ((IModelJsonSerializable<TrainResult>)TrainResult).Serialize(writer, options);
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

        internal static Model DeserializeModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ModelInfo modelInfo = default;
            Optional<KeysResult> keys = default;
            Optional<TrainResult> trainResult = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("modelInfo"u8))
                {
                    modelInfo = ModelInfo.DeserializeModelInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("keys"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keys = KeysResult.DeserializeKeysResult(property.Value);
                    continue;
                }
                if (property.NameEquals("trainResult"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    trainResult = TrainResult.DeserializeTrainResult(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Model(modelInfo, keys.Value, trainResult.Value, rawData);
        }

        Model IModelJsonSerializable<Model>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Model>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Model IModelSerializable<Model>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeModel(doc.RootElement, options);
        }

        public static implicit operator RequestContent(Model model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator Model(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
