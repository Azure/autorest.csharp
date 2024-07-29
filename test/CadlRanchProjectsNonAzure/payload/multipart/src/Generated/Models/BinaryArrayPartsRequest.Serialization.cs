// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Payload.MultiPart.Models
{
    public partial class BinaryArrayPartsRequest : IJsonModel<BinaryArrayPartsRequest>
    {
        void IJsonModel<BinaryArrayPartsRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("pictures"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(global::System.BinaryData.FromStream(Pictures));
#else
            using (JsonDocument document = JsonDocument.Parse(BinaryData.FromStream(Pictures)))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
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

        BinaryArrayPartsRequest IJsonModel<BinaryArrayPartsRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBinaryArrayPartsRequest(document.RootElement, options);
        }

        internal static BinaryArrayPartsRequest DeserializeBinaryArrayPartsRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            Stream pictures = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pictures"u8))
                {
                    pictures = BinaryData.FromString(property.Value.GetRawText()).ToStream();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BinaryArrayPartsRequest(id, pictures, serializedAdditionalRawData);
        }

        private BinaryData SerializeMultipart(ModelReaderWriterOptions options)
        {
            using MultipartFormDataBinaryContent content = ToMultipartBinaryBody();
            using MemoryStream stream = new MemoryStream();
            content.WriteTo(stream);
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        internal virtual MultipartFormDataBinaryContent ToMultipartBinaryBody()
        {
            MultipartFormDataBinaryContent content = new MultipartFormDataBinaryContent();
            content.Add(Id, "id");
            content.Add(Pictures, "pictures", "pictures", "application/octet-stream");
            return content;
        }

        BinaryData IPersistableModel<BinaryArrayPartsRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "MFD":
                    return SerializeMultipart(options);
                default:
                    throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support writing '{options.Format}' format.");
            }
        }

        BinaryArrayPartsRequest IPersistableModel<BinaryArrayPartsRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BinaryArrayPartsRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeBinaryArrayPartsRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BinaryArrayPartsRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BinaryArrayPartsRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MFD";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static BinaryArrayPartsRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBinaryArrayPartsRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
