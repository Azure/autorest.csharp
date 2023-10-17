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

namespace Encode.Duration.Models
{
    public partial class ISO8601DurationProperty : IUtf8JsonSerializable, IModelJsonSerializable<ISO8601DurationProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ISO8601DurationProperty>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ISO8601DurationProperty>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value, "P");
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

        ISO8601DurationProperty IModelJsonSerializable<ISO8601DurationProperty>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeISO8601DurationProperty(document.RootElement, options);
        }

        BinaryData IModelSerializable<ISO8601DurationProperty>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ISO8601DurationProperty IModelSerializable<ISO8601DurationProperty>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeISO8601DurationProperty(document.RootElement, options);
        }

        internal static ISO8601DurationProperty DeserializeISO8601DurationProperty(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            TimeSpan value = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            if (options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("value"u8))
                    {
                        value = property.Value.GetTimeSpan("P");
                        continue;
                    }
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
                serializedAdditionalRawData = additionalPropertiesDictionary;
            }
            return new ISO8601DurationProperty(value, serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ISO8601DurationProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeISO8601DurationProperty(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
