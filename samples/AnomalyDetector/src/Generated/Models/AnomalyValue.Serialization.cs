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
    public partial class AnomalyValue : IUtf8JsonSerializable, IModelJsonSerializable<AnomalyValue>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AnomalyValue>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AnomalyValue>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("isAnomaly"u8);
            writer.WriteBooleanValue(IsAnomaly);
            writer.WritePropertyName("severity"u8);
            writer.WriteNumberValue(Severity);
            writer.WritePropertyName("score"u8);
            writer.WriteNumberValue(Score);
            if (Optional.IsCollectionDefined(Interpretation))
            {
                writer.WritePropertyName("interpretation"u8);
                writer.WriteStartArray();
                foreach (var item in Interpretation)
                {
                    ((IModelJsonSerializable<AnomalyInterpretation>)item).Serialize(writer, options);
                }
                writer.WriteEndArray();
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

        internal static AnomalyValue DeserializeAnomalyValue(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool isAnomaly = default;
            float severity = default;
            float score = default;
            Optional<IReadOnlyList<AnomalyInterpretation>> interpretation = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isAnomaly"u8))
                {
                    isAnomaly = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("severity"u8))
                {
                    severity = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("score"u8))
                {
                    score = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("interpretation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AnomalyInterpretation> array = new List<AnomalyInterpretation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AnomalyInterpretation.DeserializeAnomalyInterpretation(item));
                    }
                    interpretation = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new AnomalyValue(isAnomaly, severity, score, Optional.ToList(interpretation), rawData);
        }

        AnomalyValue IModelJsonSerializable<AnomalyValue>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAnomalyValue(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AnomalyValue>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        AnomalyValue IModelSerializable<AnomalyValue>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeAnomalyValue(doc.RootElement, options);
        }

        public static implicit operator RequestContent(AnomalyValue model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator AnomalyValue(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAnomalyValue(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
