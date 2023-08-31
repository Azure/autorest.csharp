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
    public partial class MagnitudeScoringFunction : IUtf8JsonSerializable, IModelJsonSerializable<MagnitudeScoringFunction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MagnitudeScoringFunction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MagnitudeScoringFunction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MagnitudeScoringFunction>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("magnitude"u8);
            ((IModelJsonSerializable<MagnitudeScoringParameters>)Parameters).Serialize(writer, options);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            writer.WritePropertyName("fieldName"u8);
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("boost"u8);
            writer.WriteNumberValue(Boost);
            if (Optional.IsDefined(Interpolation))
            {
                writer.WritePropertyName("interpolation"u8);
                writer.WriteStringValue(Interpolation.Value.ToSerialString());
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

        internal static MagnitudeScoringFunction DeserializeMagnitudeScoringFunction(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MagnitudeScoringParameters magnitude = default;
            string type = default;
            string fieldName = default;
            double boost = default;
            Optional<ScoringFunctionInterpolation> interpolation = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("magnitude"u8))
                {
                    magnitude = MagnitudeScoringParameters.DeserializeMagnitudeScoringParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fieldName"u8))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boost"u8))
                {
                    boost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("interpolation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new MagnitudeScoringFunction(type, fieldName, boost, Optional.ToNullable(interpolation), magnitude, rawData);
        }

        MagnitudeScoringFunction IModelJsonSerializable<MagnitudeScoringFunction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MagnitudeScoringFunction>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMagnitudeScoringFunction(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MagnitudeScoringFunction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MagnitudeScoringFunction>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        MagnitudeScoringFunction IModelSerializable<MagnitudeScoringFunction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<MagnitudeScoringFunction>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeMagnitudeScoringFunction(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="MagnitudeScoringFunction"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="MagnitudeScoringFunction"/> to convert. </param>
        public static implicit operator RequestContent(MagnitudeScoringFunction model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="MagnitudeScoringFunction"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator MagnitudeScoringFunction(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeMagnitudeScoringFunction(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
