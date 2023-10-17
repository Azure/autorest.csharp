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

namespace _Type.Property.ValueTypes.Models
{
    public partial class EnumProperty : IUtf8JsonSerializable, IModelJsonSerializable<EnumProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<EnumProperty>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<EnumProperty>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("property"u8);
            writer.WriteStringValue(Property.ToSerialString());
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

        EnumProperty IModelJsonSerializable<EnumProperty>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEnumProperty(document.RootElement, options);
        }

        BinaryData IModelSerializable<EnumProperty>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        EnumProperty IModelSerializable<EnumProperty>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEnumProperty(document.RootElement, options);
        }

        internal static EnumProperty DeserializeEnumProperty(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FixedInnerEnum property = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            if (options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property0 in element.EnumerateObject())
                {
                    if (property0.NameEquals("property"u8))
                    {
                        property = property0.Value.GetString().ToFixedInnerEnum();
                        continue;
                    }
                    additionalPropertiesDictionary.Add(property0.Name, BinaryData.FromString(property0.Value.GetRawText()));
                }
                serializedAdditionalRawData = additionalPropertiesDictionary;
            }
            return new EnumProperty(property, serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static EnumProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeEnumProperty(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
