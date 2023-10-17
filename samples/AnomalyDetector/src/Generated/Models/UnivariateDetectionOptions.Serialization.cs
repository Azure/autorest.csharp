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
    public partial class UnivariateDetectionOptions : IUtf8JsonSerializable, IModelJsonSerializable<UnivariateDetectionOptions>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UnivariateDetectionOptions>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UnivariateDetectionOptions>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("series"u8);
            writer.WriteStartArray();
            foreach (var item in Series)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Granularity))
            {
                writer.WritePropertyName("granularity"u8);
                writer.WriteStringValue(Granularity.Value.ToSerialString());
            }
            if (Optional.IsDefined(CustomInterval))
            {
                writer.WritePropertyName("customInterval"u8);
                writer.WriteNumberValue(CustomInterval.Value);
            }
            if (Optional.IsDefined(Period))
            {
                writer.WritePropertyName("period"u8);
                writer.WriteNumberValue(Period.Value);
            }
            if (Optional.IsDefined(MaxAnomalyRatio))
            {
                writer.WritePropertyName("maxAnomalyRatio"u8);
                writer.WriteNumberValue(MaxAnomalyRatio.Value);
            }
            if (Optional.IsDefined(Sensitivity))
            {
                writer.WritePropertyName("sensitivity"u8);
                writer.WriteNumberValue(Sensitivity.Value);
            }
            if (Optional.IsDefined(ImputeMode))
            {
                writer.WritePropertyName("imputeMode"u8);
                writer.WriteStringValue(ImputeMode.Value.ToString());
            }
            if (Optional.IsDefined(ImputeFixedValue))
            {
                writer.WritePropertyName("imputeFixedValue"u8);
                writer.WriteNumberValue(ImputeFixedValue.Value);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        UnivariateDetectionOptions IModelJsonSerializable<UnivariateDetectionOptions>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUnivariateDetectionOptions(document.RootElement, options);
        }

        BinaryData IModelSerializable<UnivariateDetectionOptions>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        UnivariateDetectionOptions IModelSerializable<UnivariateDetectionOptions>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUnivariateDetectionOptions(document.RootElement, options);
        }

        internal static UnivariateDetectionOptions DeserializeUnivariateDetectionOptions(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<TimeSeriesPoint> series = default;
            Optional<TimeGranularity> granularity = default;
            Optional<int> customInterval = default;
            Optional<int> period = default;
            Optional<float> maxAnomalyRatio = default;
            Optional<int> sensitivity = default;
            Optional<ImputeMode> imputeMode = default;
            Optional<float> imputeFixedValue = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            if (options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("series"u8))
                    {
                        List<TimeSeriesPoint> array = new List<TimeSeriesPoint>();
                        foreach (var item in property.Value.EnumerateArray())
                        {
                            array.Add(TimeSeriesPoint.DeserializeTimeSeriesPoint(item));
                        }
                        series = array;
                        continue;
                    }
                    if (property.NameEquals("granularity"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        granularity = property.Value.GetString().ToTimeGranularity();
                        continue;
                    }
                    if (property.NameEquals("customInterval"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        customInterval = property.Value.GetInt32();
                        continue;
                    }
                    if (property.NameEquals("period"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        period = property.Value.GetInt32();
                        continue;
                    }
                    if (property.NameEquals("maxAnomalyRatio"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        maxAnomalyRatio = property.Value.GetSingle();
                        continue;
                    }
                    if (property.NameEquals("sensitivity"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        sensitivity = property.Value.GetInt32();
                        continue;
                    }
                    if (property.NameEquals("imputeMode"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        imputeMode = new ImputeMode(property.Value.GetString());
                        continue;
                    }
                    if (property.NameEquals("imputeFixedValue"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        imputeFixedValue = property.Value.GetSingle();
                        continue;
                    }
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
                serializedAdditionalRawData = additionalPropertiesDictionary;
            }
            return new UnivariateDetectionOptions(series, Optional.ToNullable(granularity), Optional.ToNullable(customInterval), Optional.ToNullable(period), Optional.ToNullable(maxAnomalyRatio), Optional.ToNullable(sensitivity), Optional.ToNullable(imputeMode), Optional.ToNullable(imputeFixedValue), serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static UnivariateDetectionOptions FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnivariateDetectionOptions(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
