// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class UnivariateEntireDetectionResult : IUtf8JsonSerializable, IJsonModel<UnivariateEntireDetectionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UnivariateEntireDetectionResult>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<UnivariateEntireDetectionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<UnivariateEntireDetectionResult>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<UnivariateEntireDetectionResult>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("period"u8);
            writer.WriteNumberValue(Period);
            writer.WritePropertyName("expectedValues"u8);
            writer.WriteStartArray();
            foreach (var item in ExpectedValues)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("upperMargins"u8);
            writer.WriteStartArray();
            foreach (var item in UpperMargins)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("lowerMargins"u8);
            writer.WriteStartArray();
            foreach (var item in LowerMargins)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("isAnomaly"u8);
            writer.WriteStartArray();
            foreach (var item in IsAnomaly)
            {
                writer.WriteBooleanValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("isNegativeAnomaly"u8);
            writer.WriteStartArray();
            foreach (var item in IsNegativeAnomaly)
            {
                writer.WriteBooleanValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("isPositiveAnomaly"u8);
            writer.WriteStartArray();
            foreach (var item in IsPositiveAnomaly)
            {
                writer.WriteBooleanValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(Severity))
            {
                writer.WritePropertyName("severity"u8);
                writer.WriteStartArray();
                foreach (var item in Severity)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        UnivariateEntireDetectionResult IJsonModel<UnivariateEntireDetectionResult>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UnivariateEntireDetectionResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUnivariateEntireDetectionResult(document.RootElement, options);
        }

        internal static UnivariateEntireDetectionResult DeserializeUnivariateEntireDetectionResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int period = default;
            IReadOnlyList<float> expectedValues = default;
            IReadOnlyList<float> upperMargins = default;
            IReadOnlyList<float> lowerMargins = default;
            IReadOnlyList<bool> isAnomaly = default;
            IReadOnlyList<bool> isNegativeAnomaly = default;
            IReadOnlyList<bool> isPositiveAnomaly = default;
            Optional<IReadOnlyList<float>> severity = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("period"u8))
                {
                    period = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("expectedValues"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    expectedValues = array;
                    continue;
                }
                if (property.NameEquals("upperMargins"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    upperMargins = array;
                    continue;
                }
                if (property.NameEquals("lowerMargins"u8))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    lowerMargins = array;
                    continue;
                }
                if (property.NameEquals("isAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isAnomaly = array;
                    continue;
                }
                if (property.NameEquals("isNegativeAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isNegativeAnomaly = array;
                    continue;
                }
                if (property.NameEquals("isPositiveAnomaly"u8))
                {
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isPositiveAnomaly = array;
                    continue;
                }
                if (property.NameEquals("severity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    severity = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UnivariateEntireDetectionResult(period, expectedValues, upperMargins, lowerMargins, isAnomaly, isNegativeAnomaly, isPositiveAnomaly, Optional.ToList(severity), serializedAdditionalRawData);
        }

        BinaryData IModel<UnivariateEntireDetectionResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UnivariateEntireDetectionResult)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        UnivariateEntireDetectionResult IModel<UnivariateEntireDetectionResult>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(UnivariateEntireDetectionResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUnivariateEntireDetectionResult(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<UnivariateEntireDetectionResult>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static UnivariateEntireDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnivariateEntireDetectionResult(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
