// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class Image : IJsonModel<Image>
    {
        void IJsonModel<Image>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Image>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Image)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Url))
            {
                writer.WritePropertyName("url"u8);
                writer.WriteStringValue(Url.AbsoluteUri);
            }
            if (Optional.IsDefined(B64Json))
            {
                writer.WritePropertyName("b64_json"u8);
                writer.WriteBase64StringValue(B64Json.ToArray(), "D");
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

        Image IJsonModel<Image>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Image>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Image)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImage(document.RootElement, options);
        }

        internal static Image DeserializeImage(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri url = default;
            BinaryData b64Json = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("url"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    url = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("b64_json"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    b64Json = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new Image(url, b64Json, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Image>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Image>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(Image)} does not support writing '{options.Format}' format.");
            }
        }

        Image IPersistableModel<Image>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Image>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeImage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Image)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Image>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static Image FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeImage(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
