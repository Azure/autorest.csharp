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

namespace HlcConstants.Models
{
    public partial class ModelWithRequiredConstant : IUtf8JsonSerializable, IJsonModel<ModelWithRequiredConstant>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithRequiredConstant>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelWithRequiredConstant>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<ModelWithRequiredConstant>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelWithRequiredConstant>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredStringConstant"u8);
            writer.WriteStringValue(RequiredStringConstant.ToString());
            writer.WritePropertyName("requiredIntConstant"u8);
            writer.WriteNumberValue(RequiredIntConstant.ToSerialInt32());
            writer.WritePropertyName("requiredBooleanConstant"u8);
            writer.WriteBooleanValue(RequiredBooleanConstant);
            writer.WritePropertyName("requiredFloatConstant"u8);
            writer.WriteNumberValue(RequiredFloatConstant.ToSerialSingle());
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

        ModelWithRequiredConstant IJsonModel<ModelWithRequiredConstant>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredConstant)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithRequiredConstant(document.RootElement, options);
        }

        internal static ModelWithRequiredConstant DeserializeModelWithRequiredConstant(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StringConstant requiredStringConstant = default;
            IntConstant requiredIntConstant = default;
            bool requiredBooleanConstant = default;
            FloatConstant requiredFloatConstant = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredStringConstant"u8))
                {
                    requiredStringConstant = new StringConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredIntConstant"u8))
                {
                    requiredIntConstant = new IntConstant(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("requiredBooleanConstant"u8))
                {
                    requiredBooleanConstant = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredFloatConstant"u8))
                {
                    requiredFloatConstant = new FloatConstant(property.Value.GetSingle());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithRequiredConstant(requiredStringConstant, requiredIntConstant, requiredBooleanConstant, requiredFloatConstant, serializedAdditionalRawData);
        }

        BinaryData IModel<ModelWithRequiredConstant>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredConstant)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelWithRequiredConstant IModel<ModelWithRequiredConstant>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithRequiredConstant)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithRequiredConstant(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelWithRequiredConstant>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
