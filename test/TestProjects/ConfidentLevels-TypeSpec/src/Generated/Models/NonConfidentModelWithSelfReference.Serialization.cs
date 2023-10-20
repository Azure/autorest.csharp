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
    public partial class NonConfidentModelWithSelfReference : IUtf8JsonSerializable, IModelJsonSerializable<NonConfidentModelWithSelfReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NonConfidentModelWithSelfReference>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NonConfidentModelWithSelfReference>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("selfReference"u8);
            writer.WriteStartArray();
            foreach (var item in SelfReference)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
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

        NonConfidentModelWithSelfReference IModelJsonSerializable<NonConfidentModelWithSelfReference>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, options);
        }

        internal static NonConfidentModelWithSelfReference DeserializeNonConfidentModelWithSelfReference(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IList<NonConfidentModelWithSelfReference> selfReference = default;
            BinaryData unionProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("selfReference"u8))
                {
                    List<NonConfidentModelWithSelfReference> array = new List<NonConfidentModelWithSelfReference>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeNonConfidentModelWithSelfReference(item));
                    }
                    selfReference = array;
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
            return new NonConfidentModelWithSelfReference(name, selfReference, unionProperty, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<NonConfidentModelWithSelfReference>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        NonConfidentModelWithSelfReference IModelSerializable<NonConfidentModelWithSelfReference>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static NonConfidentModelWithSelfReference FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeNonConfidentModelWithSelfReference(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
