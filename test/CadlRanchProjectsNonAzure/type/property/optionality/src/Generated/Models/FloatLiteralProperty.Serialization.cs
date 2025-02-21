// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.Optionality.Models
{
    public partial class FloatLiteralProperty : IJsonModel<FloatLiteralProperty>
    {
        void IJsonModel<FloatLiteralProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FloatLiteralProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FloatLiteralProperty)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Property))
            {
                writer.WritePropertyName("property"u8);
                writer.WriteNumberValue(Property.Value.ToSerialSingle());
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        FloatLiteralProperty IJsonModel<FloatLiteralProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FloatLiteralProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FloatLiteralProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFloatLiteralProperty(document.RootElement, options);
        }

        internal static FloatLiteralProperty DeserializeFloatLiteralProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FloatLiteralPropertyProperty? property = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property0 in element.EnumerateObject())
            {
                if (property0.NameEquals("property"u8))
                {
                    if (property0.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    property = new FloatLiteralPropertyProperty(property0.Value.GetSingle());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property0.Name, BinaryData.FromString(property0.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FloatLiteralProperty(property, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FloatLiteralProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FloatLiteralProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FloatLiteralProperty)} does not support writing '{options.Format}' format.");
            }
        }

        FloatLiteralProperty IPersistableModel<FloatLiteralProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FloatLiteralProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeFloatLiteralProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FloatLiteralProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FloatLiteralProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FloatLiteralProperty FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeFloatLiteralProperty(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
