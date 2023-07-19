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
    public partial class MultivariateDetectionResult : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("summary"u8);
            writer.WriteObjectValue(Summary);
            writer.WritePropertyName("results"u8);
            writer.WriteStartArray();
            foreach (var item in Results)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeMultivariateDetectionResult(doc.RootElement, options);
        }

        internal static MultivariateDetectionResult DeserializeMultivariateDetectionResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid resultId = default;
            MultivariateBatchDetectionResultSummary summary = default;
            IReadOnlyList<AnomalyState> results = default;
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
            }
            return new MultivariateDetectionResult(resultId, summary, results);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMultivariateDetectionResult(doc.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultivariateDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMultivariateDetectionResult(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
