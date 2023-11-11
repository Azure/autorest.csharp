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

namespace FirstTestTypeSpec.Models
{
    public partial class ModelWithRequiredNullableProperties : IUtf8JsonSerializable, IJsonModel<ModelWithRequiredNullableProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithRequiredNullableProperties>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelWithRequiredNullableProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<ModelWithRequiredNullableProperties>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelWithRequiredNullableProperties>)} interface");
            }

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

        ModelWithRequiredNullableProperties IJsonModel<ModelWithRequiredNullableProperties>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredNullableProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement, options);
        }

        internal static ModelWithRequiredNullableProperties DeserializeModelWithRequiredNullableProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? requiredNullablePrimitive = default;
            StringExtensibleEnum? requiredExtensibleEnum = default;
            StringFixedEnum? requiredFixedEnum = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithRequiredNullableProperties(requiredNullablePrimitive, requiredExtensibleEnum, requiredFixedEnum, serializedAdditionalRawData);
        }

        BinaryData IModel<ModelWithRequiredNullableProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredNullableProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelWithRequiredNullableProperties IModel<ModelWithRequiredNullableProperties>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredNullableProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelWithRequiredNullableProperties>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithRequiredNullableProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
