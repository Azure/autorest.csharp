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
    public partial class UnivariateChangePointDetectionOptions : IUtf8JsonSerializable, IModelJsonSerializable<UnivariateChangePointDetectionOptions>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UnivariateChangePointDetectionOptions>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UnivariateChangePointDetectionOptions>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("series"u8);
            writer.WriteStartArray();
            foreach (var item in Series)
            {
                ((IModelJsonSerializable<TimeSeriesPoint>)item).Serialize(writer, options);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("granularity"u8);
            writer.WriteStringValue(Granularity.ToSerialString());
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
            if (Optional.IsDefined(StableTrendWindow))
            {
                writer.WritePropertyName("stableTrendWindow"u8);
                writer.WriteNumberValue(StableTrendWindow.Value);
            }
            if (Optional.IsDefined(Threshold))
            {
                writer.WritePropertyName("threshold"u8);
                writer.WriteNumberValue(Threshold.Value);
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

        internal static UnivariateChangePointDetectionOptions DeserializeUnivariateChangePointDetectionOptions(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<TimeSeriesPoint> series = default;
            TimeGranularity granularity = default;
            Optional<int> customInterval = default;
            Optional<int> period = default;
            Optional<int> stableTrendWindow = default;
            Optional<float> threshold = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("stableTrendWindow"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    stableTrendWindow = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("threshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    threshold = property.Value.GetSingle();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UnivariateChangePointDetectionOptions(series, granularity, Optional.ToNullable(customInterval), Optional.ToNullable(period), Optional.ToNullable(stableTrendWindow), Optional.ToNullable(threshold), rawData);
        }

        UnivariateChangePointDetectionOptions IModelJsonSerializable<UnivariateChangePointDetectionOptions>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUnivariateChangePointDetectionOptions(doc.RootElement, options);
        }

        BinaryData IModelSerializable<UnivariateChangePointDetectionOptions>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        UnivariateChangePointDetectionOptions IModelSerializable<UnivariateChangePointDetectionOptions>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeUnivariateChangePointDetectionOptions(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="UnivariateChangePointDetectionOptions"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="UnivariateChangePointDetectionOptions"/> to convert. </param>
        public static implicit operator RequestContent(UnivariateChangePointDetectionOptions model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="UnivariateChangePointDetectionOptions"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator UnivariateChangePointDetectionOptions(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeUnivariateChangePointDetectionOptions(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
