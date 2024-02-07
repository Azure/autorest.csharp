// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithAbstractModel : IUtf8JsonSerializable, IJsonModel<ModelWithAbstractModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithAbstractModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelWithAbstractModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithAbstractModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithAbstractModel)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(AbstractModelProperty))
            {
                writer.WritePropertyName("AbstractModelProperty"u8);
                BinaryData data = ModelReaderWriter.Write(AbstractModelProperty, options);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(data);
#else
                using (JsonDocument document = JsonDocument.Parse(data))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        ModelWithAbstractModel IJsonModel<ModelWithAbstractModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithAbstractModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithAbstractModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithAbstractModel(document.RootElement, options);
        }

        internal static ModelWithAbstractModel DeserializeModelWithAbstractModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AbstractModel> abstractModelProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("AbstractModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    abstractModelProperty = AbstractModel.DeserializeAbstractModel(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithAbstractModel(abstractModelProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithAbstractModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithAbstractModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelWithAbstractModel)} does not support '{options.Format}' format.");
            }
        }

        ModelWithAbstractModel IPersistableModel<ModelWithAbstractModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithAbstractModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelWithAbstractModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelWithAbstractModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithAbstractModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
