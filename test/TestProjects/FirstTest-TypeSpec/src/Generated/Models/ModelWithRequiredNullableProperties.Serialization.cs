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

namespace FirstTestTypeSpec.Models
{
    internal partial class ModelWithRequiredNullableProperties : IUtf8JsonSerializable, IModelJsonSerializable<ModelWithRequiredNullableProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelWithRequiredNullableProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelWithRequiredNullableProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (RequiredNullablePrimitive != null)
            {
                writer.WritePropertyName("requiredNullablePrimitive"u8);
                writer.WriteNumberValue(RequiredNullablePrimitive.Value);
            }
            else
            {
                writer.WriteNull("requiredNullablePrimitive");
            }
            if (RequiredExtensibleEnum != null)
            {
                writer.WritePropertyName("requiredExtensibleEnum"u8);
                writer.WriteStringValue(RequiredExtensibleEnum.Value.ToString());
            }
            else
            {
                writer.WriteNull("requiredExtensibleEnum");
            }
            if (RequiredFixedEnum != null)
            {
                writer.WritePropertyName("requiredFixedEnum"u8);
                writer.WriteStringValue(RequiredFixedEnum.Value.ToSerialString());
            }
            else
            {
                writer.WriteNull("requiredFixedEnum");
            }
            foreach (var item in _serializedAdditionalRawData)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
            }
            writer.WriteEndObject();
        }

        ModelWithRequiredNullableProperties IModelJsonSerializable<ModelWithRequiredNullableProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithRequiredNullableProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelWithRequiredNullableProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ModelWithRequiredNullableProperties IModelSerializable<ModelWithRequiredNullableProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement, options);
        }

        internal static ModelWithRequiredNullableProperties DeserializeModelWithRequiredNullableProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? requiredNullablePrimitive = default;
            StringExtensibleEnum? requiredExtensibleEnum = default;
            StringFixedEnum? requiredFixedEnum = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredNullablePrimitive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullablePrimitive = null;
                        continue;
                    }
                    requiredNullablePrimitive = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredExtensibleEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredExtensibleEnum = null;
                        continue;
                    }
                    requiredExtensibleEnum = new StringExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredFixedEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredFixedEnum = null;
                        continue;
                    }
                    requiredFixedEnum = property.Value.GetString().ToStringFixedEnum();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithRequiredNullableProperties(requiredNullablePrimitive, requiredExtensibleEnum, requiredFixedEnum);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithRequiredNullableProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
