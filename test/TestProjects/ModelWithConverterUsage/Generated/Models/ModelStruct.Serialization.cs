// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(ModelStructConverter))]
    public partial struct ModelStruct : IUtf8JsonSerializable, IJsonModel<ModelStruct>, IJsonModel<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelStruct>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelStruct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("Model_Property"u8);
                writer.WriteStringValue(ModelProperty);
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

        ModelStruct IJsonModel<ModelStruct>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelStruct)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelStruct(document.RootElement, options);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ModelStruct>)this).Write(writer, options);

        object IJsonModel<object>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ModelStruct>)this).Read(ref reader, options);

        internal static ModelStruct DeserializeModelStruct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            Optional<string> modelProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Model_Property"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelStruct(modelProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<ModelStruct>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelStruct)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelStruct IModel<ModelStruct>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelStruct)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelStruct(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelStruct>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        BinaryData IModel<object>.Write(ModelReaderWriterOptions options) => ((IModel<ModelStruct>)this).Write(options);

        object IModel<object>.Read(BinaryData data, ModelReaderWriterOptions options) => ((IModel<ModelStruct>)this).Read(data, options);

        ModelReaderWriterFormat IModel<object>.GetWireFormat(ModelReaderWriterOptions options) => ((IModel<ModelStruct>)this).GetWireFormat(options);

        internal partial class ModelStructConverter : JsonConverter<ModelStruct>
        {
            public override void Write(Utf8JsonWriter writer, ModelStruct model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ModelStruct Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeModelStruct(document.RootElement);
            }
        }
    }
}
