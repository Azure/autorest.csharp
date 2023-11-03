// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace CustomizationsInTsp.Models
{
    public partial class ModelToAddAdditionalSerializableProperty : IUtf8JsonSerializable, IJsonModel<ModelToAddAdditionalSerializableProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelToAddAdditionalSerializableProperty>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelToAddAdditionalSerializableProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            WriteRequiredIntValue(writer);
            if (Optional.IsDefined(AdditionalSerializableProperty))
            {
                writer.WritePropertyName("additionalSerializableProperty"u8);
                writer.WriteNumberValue(AdditionalSerializableProperty);
            }
            if (Optional.IsDefined(AdditionalNullableSerializableProperty))
            {
                if (AdditionalNullableSerializableProperty != null)
                {
                    writer.WritePropertyName("additionalNullableSerializableProperty"u8);
                    writer.WriteNumberValue(AdditionalNullableSerializableProperty.Value);
                }
                else
                {
                    writer.WriteNull("additionalNullableSerializableProperty");
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        ModelToAddAdditionalSerializableProperty IJsonModel<ModelToAddAdditionalSerializableProperty>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement, options);
        }

        internal static ModelToAddAdditionalSerializableProperty DeserializeModelToAddAdditionalSerializableProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            Optional<int> additionalSerializableProperty = default;
            Optional<int?> additionalNullableSerializableProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    DeserializeRequiredIntValue(property, ref requiredInt);
                    continue;
                }
                if (property.NameEquals("additionalSerializableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    additionalSerializableProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("additionalNullableSerializableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        additionalNullableSerializableProperty = null;
                        continue;
                    }
                    additionalNullableSerializableProperty = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelToAddAdditionalSerializableProperty(requiredInt, additionalSerializableProperty, Optional.ToNullable(additionalNullableSerializableProperty), serializedAdditionalRawData);
        }

        BinaryData IModel<ModelToAddAdditionalSerializableProperty>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelToAddAdditionalSerializableProperty IModel<ModelToAddAdditionalSerializableProperty>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelToAddAdditionalSerializableProperty>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelToAddAdditionalSerializableProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelToAddAdditionalSerializableProperty(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
