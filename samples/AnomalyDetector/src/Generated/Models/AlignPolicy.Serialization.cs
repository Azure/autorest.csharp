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
    public partial class AlignPolicy : IUtf8JsonSerializable, IModelJsonSerializable<AlignPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AlignPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AlignPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(AlignMode))
            {
                writer.WritePropertyName("alignMode"u8);
                writer.WriteStringValue(AlignMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(FillNAMethod))
            {
                writer.WritePropertyName("fillNAMethod"u8);
                writer.WriteStringValue(FillNAMethod.Value.ToString());
            }
            if (Optional.IsDefined(PaddingValue))
            {
                writer.WritePropertyName("paddingValue"u8);
                writer.WriteNumberValue(PaddingValue.Value);
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

        AlignPolicy IModelJsonSerializable<AlignPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAlignPolicy(document.RootElement, options);
        }

        BinaryData IModelSerializable<AlignPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        AlignPolicy IModelSerializable<AlignPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAlignPolicy(document.RootElement, options);
        }

        internal static AlignPolicy DeserializeAlignPolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AlignMode> alignMode = default;
            Optional<FillNAMethod> fillNAMethod = default;
            Optional<float> paddingValue = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("alignMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    alignMode = property.Value.GetString().ToAlignMode();
                    continue;
                }
                if (property.NameEquals("fillNAMethod"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fillNAMethod = new FillNAMethod(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("paddingValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    paddingValue = property.Value.GetSingle();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AlignPolicy(Optional.ToNullable(alignMode), Optional.ToNullable(fillNAMethod), Optional.ToNullable(paddingValue), serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AlignPolicy FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAlignPolicy(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
