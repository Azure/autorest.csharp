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
    public partial struct InputAdditionalPropertiesModelStruct : IUtf8JsonSerializable, IJsonModel<InputAdditionalPropertiesModelStruct>, IJsonModel<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<InputAdditionalPropertiesModelStruct>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<InputAdditionalPropertiesModelStruct>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<InputAdditionalPropertiesModelStruct>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<InputAdditionalPropertiesModelStruct>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        InputAdditionalPropertiesModelStruct IJsonModel<InputAdditionalPropertiesModelStruct>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(InputAdditionalPropertiesModelStruct)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInputAdditionalPropertiesModelStruct(document.RootElement, options);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<InputAdditionalPropertiesModelStruct>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<InputAdditionalPropertiesModelStruct>)this).Create(ref reader, options);

        internal static InputAdditionalPropertiesModelStruct DeserializeInputAdditionalPropertiesModelStruct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            int id = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new InputAdditionalPropertiesModelStruct(id, additionalProperties);
        }

        BinaryData IPersistableModel<InputAdditionalPropertiesModelStruct>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(InputAdditionalPropertiesModelStruct)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        InputAdditionalPropertiesModelStruct IPersistableModel<InputAdditionalPropertiesModelStruct>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(InputAdditionalPropertiesModelStruct)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeInputAdditionalPropertiesModelStruct(document.RootElement, options);
        }

        string IPersistableModel<InputAdditionalPropertiesModelStruct>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<InputAdditionalPropertiesModelStruct>)this).Write(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<InputAdditionalPropertiesModelStruct>)this).Create(data, options);

        string IPersistableModel<object>.GetWireFormat(ModelReaderWriterOptions options) => ((IPersistableModel<InputAdditionalPropertiesModelStruct>)this).GetWireFormat(options);
    }
}
