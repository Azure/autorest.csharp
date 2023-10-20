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

namespace ConfidentLevelsInTsp.Models
{
    public partial class IndirectSelfReferenceModel : IUtf8JsonSerializable, IModelJsonSerializable<IndirectSelfReferenceModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<IndirectSelfReferenceModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<IndirectSelfReferenceModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("something"u8);
            writer.WriteStringValue(Something);
            if (Optional.IsDefined(Reference))
            {
                writer.WritePropertyName("reference"u8);
                writer.WriteObjectValue(Reference);
            }
            writer.WritePropertyName("unionProperty"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(UnionProperty);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(UnionProperty.ToString()).RootElement);
#endif
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

        IndirectSelfReferenceModel IModelJsonSerializable<IndirectSelfReferenceModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIndirectSelfReferenceModel(document.RootElement, options);
        }

        internal static IndirectSelfReferenceModel DeserializeIndirectSelfReferenceModel(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string something = default;
            Optional<NonConfidentModelWithSelfReference> reference = default;
            BinaryData unionProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("something"u8))
                {
                    something = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reference = NonConfidentModelWithSelfReference.DeserializeNonConfidentModelWithSelfReference(property.Value);
                    continue;
                }
                if (property.NameEquals("unionProperty"u8))
                {
                    unionProperty = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new IndirectSelfReferenceModel(something, reference.Value, unionProperty, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<IndirectSelfReferenceModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        IndirectSelfReferenceModel IModelSerializable<IndirectSelfReferenceModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeIndirectSelfReferenceModel(document.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IndirectSelfReferenceModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIndirectSelfReferenceModel(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
