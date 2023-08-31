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
    public partial class MultivariateLastDetectionOptions : IUtf8JsonSerializable, IModelJsonSerializable<MultivariateLastDetectionOptions>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MultivariateLastDetectionOptions>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MultivariateLastDetectionOptions>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("variables"u8);
            writer.WriteStartArray();
            foreach (var item in Variables)
            {
                ((IModelJsonSerializable<VariableValues>)item).Serialize(writer, options);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("topContributorCount"u8);
            writer.WriteNumberValue(TopContributorCount);
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

        internal static MultivariateLastDetectionOptions DeserializeMultivariateLastDetectionOptions(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<VariableValues> variables = default;
            int topContributorCount = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("variables"u8))
                {
                    List<VariableValues> array = new List<VariableValues>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VariableValues.DeserializeVariableValues(item));
                    }
                    variables = array;
                    continue;
                }
                if (property.NameEquals("topContributorCount"u8))
                {
                    topContributorCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new MultivariateLastDetectionOptions(variables, topContributorCount, rawData);
        }

        MultivariateLastDetectionOptions IModelJsonSerializable<MultivariateLastDetectionOptions>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMultivariateLastDetectionOptions(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MultivariateLastDetectionOptions>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MultivariateLastDetectionOptions IModelSerializable<MultivariateLastDetectionOptions>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMultivariateLastDetectionOptions(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="MultivariateLastDetectionOptions"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="MultivariateLastDetectionOptions"/> to convert. </param>
        public static implicit operator RequestContent(MultivariateLastDetectionOptions model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="MultivariateLastDetectionOptions"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator MultivariateLastDetectionOptions(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMultivariateLastDetectionOptions(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
