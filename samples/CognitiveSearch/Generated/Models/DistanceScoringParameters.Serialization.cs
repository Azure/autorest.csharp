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
    public partial class DistanceScoringParameters : IUtf8JsonSerializable, IModelJsonSerializable<DistanceScoringParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DistanceScoringParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DistanceScoringParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("referencePointParameter"u8);
            writer.WriteStringValue(ReferencePointParameter);
            writer.WritePropertyName("boostingDistance"u8);
            writer.WriteNumberValue(BoostingDistance);
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static DistanceScoringParameters DeserializeDistanceScoringParameters(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string referencePointParameter = default;
            double boostingDistance = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("referencePointParameter"u8))
                {
                    referencePointParameter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boostingDistance"u8))
                {
                    boostingDistance = property.Value.GetDouble();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DistanceScoringParameters(referencePointParameter, boostingDistance, serializedAdditionalRawData);
        }

        DistanceScoringParameters IModelJsonSerializable<DistanceScoringParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDistanceScoringParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DistanceScoringParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DistanceScoringParameters IModelSerializable<DistanceScoringParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDistanceScoringParameters(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DistanceScoringParameters"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DistanceScoringParameters"/> to convert. </param>
        public static implicit operator RequestContent(DistanceScoringParameters model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DistanceScoringParameters"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DistanceScoringParameters(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDistanceScoringParameters(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
