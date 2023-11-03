// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    public partial struct OutputAdditionalPropertiesModelStruct : IUtf8JsonSerializable, IJsonModel<OutputAdditionalPropertiesModelStruct>, IJsonModel<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OutputAdditionalPropertiesModelStruct>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<OutputAdditionalPropertiesModelStruct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }

        OutputAdditionalPropertiesModelStruct IJsonModel<OutputAdditionalPropertiesModelStruct>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputAdditionalPropertiesModelStruct(document.RootElement, options);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<OutputAdditionalPropertiesModelStruct>)this).Write(writer, options);

        object IJsonModel<object>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<OutputAdditionalPropertiesModelStruct>)this).Read(ref reader, options);

        internal static OutputAdditionalPropertiesModelStruct DeserializeOutputAdditionalPropertiesModelStruct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            int id = default;
            IReadOnlyDictionary<string, string> additionalProperties = default;
            Dictionary<string, string> additionalPropertiesDictionary = new Dictionary<string, string>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetString());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new OutputAdditionalPropertiesModelStruct(id, additionalProperties);
        }

        BinaryData IModel<OutputAdditionalPropertiesModelStruct>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.Write(this, options);
        }

        OutputAdditionalPropertiesModelStruct IModel<OutputAdditionalPropertiesModelStruct>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOutputAdditionalPropertiesModelStruct(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<OutputAdditionalPropertiesModelStruct>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        BinaryData IModel<object>.Write(ModelReaderWriterOptions options) => ((IModel<OutputAdditionalPropertiesModelStruct>)this).Write(options);

        object IModel<object>.Read(BinaryData data, ModelReaderWriterOptions options) => ((IModel<OutputAdditionalPropertiesModelStruct>)this).Read(data, options);

        ModelReaderWriterFormat IModel<object>.GetWireFormat(ModelReaderWriterOptions options) => ((IModel<OutputAdditionalPropertiesModelStruct>)this).GetWireFormat(options);
    }
}
