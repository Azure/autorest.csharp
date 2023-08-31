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

namespace HlcConstants.Models
{
    public partial class RoundTripModel : IUtf8JsonSerializable, IModelJsonSerializable<RoundTripModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RoundTripModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RoundTripModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(RequiredConstantModel))
            {
                writer.WritePropertyName("requiredConstantModel"u8);
                ((IModelJsonSerializable<ModelWithRequiredConstant>)RequiredConstantModel).Serialize(writer, options);
            }
            if (Optional.IsDefined(OptionalConstantModel))
            {
                writer.WritePropertyName("optionalConstantModel"u8);
                ((IModelJsonSerializable<ModelWithOptionalConstant>)OptionalConstantModel).Serialize(writer, options);
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

        internal static RoundTripModel DeserializeRoundTripModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ModelWithRequiredConstant> requiredConstantModel = default;
            Optional<ModelWithOptionalConstant> optionalConstantModel = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredConstantModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requiredConstantModel = ModelWithRequiredConstant.DeserializeModelWithRequiredConstant(property.Value);
                    continue;
                }
                if (property.NameEquals("optionalConstantModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalConstantModel = ModelWithOptionalConstant.DeserializeModelWithOptionalConstant(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RoundTripModel(requiredConstantModel.Value, optionalConstantModel.Value, rawData);
        }

        RoundTripModel IModelJsonSerializable<RoundTripModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRoundTripModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RoundTripModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RoundTripModel IModelSerializable<RoundTripModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRoundTripModel(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RoundTripModel"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RoundTripModel"/> to convert. </param>
        public static implicit operator RequestContent(RoundTripModel model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RoundTripModel"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RoundTripModel(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRoundTripModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
