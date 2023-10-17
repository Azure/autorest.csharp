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
    public partial class Dog : IUtf8JsonSerializable, IModelJsonSerializable<Dog>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Dog>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Dog>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("woof"u8);
            writer.WriteStringValue(Woof);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        Dog IModelJsonSerializable<Dog>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDog(document.RootElement, options);
        }

        BinaryData IModelSerializable<Dog>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        Dog IModelSerializable<Dog>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDog(document.RootElement, options);
        }

        internal static Dog DeserializeDog(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string woof = default;
            string kind = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            if (options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("woof"u8))
                    {
                        woof = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("kind"u8))
                    {
                        kind = property.Value.GetString();
                        continue;
                    }
                    if (property.NameEquals("name"u8))
                    {
                        name = property.Value.GetString();
                        continue;
                    }
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
                serializedAdditionalRawData = additionalPropertiesDictionary;
            }
            return new Dog(kind, name, serializedAdditionalRawData, woof);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new Dog FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDog(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
