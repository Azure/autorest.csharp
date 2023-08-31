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
    public partial class MultivariateDetectionResult : IUtf8JsonSerializable, IModelJsonSerializable<MultivariateDetectionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MultivariateDetectionResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MultivariateDetectionResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("summary"u8);
            ((IModelJsonSerializable<MultivariateBatchDetectionResultSummary>)Summary).Serialize(writer, options);
            writer.WritePropertyName("results"u8);
            writer.WriteStartArray();
            foreach (var item in Results)
            {
                ((IModelJsonSerializable<AnomalyState>)item).Serialize(writer, options);
            }
            writer.WriteEndArray();
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

        internal static MultivariateDetectionResult DeserializeMultivariateDetectionResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid resultId = default;
            MultivariateBatchDetectionResultSummary summary = default;
            IReadOnlyList<AnomalyState> results = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resultId"u8))
                {
                    resultId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("summary"u8))
                {
                    summary = MultivariateBatchDetectionResultSummary.DeserializeMultivariateBatchDetectionResultSummary(property.Value);
                    continue;
                }
                if (property.NameEquals("results"u8))
                {
                    List<AnomalyState> array = new List<AnomalyState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AnomalyState.DeserializeAnomalyState(item));
                    }
                    results = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new MultivariateDetectionResult(resultId, summary, results, rawData);
        }

        MultivariateDetectionResult IModelJsonSerializable<MultivariateDetectionResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMultivariateDetectionResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MultivariateDetectionResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MultivariateDetectionResult IModelSerializable<MultivariateDetectionResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMultivariateDetectionResult(doc.RootElement, options);
        }

        public static implicit operator RequestContent(MultivariateDetectionResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator MultivariateDetectionResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMultivariateDetectionResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
