// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class DeleteFileResponse : IJsonModel<DeleteFileResponse>
    {
        void IJsonModel<DeleteFileResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteFileResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeleteFileResponse)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("id"))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (!SerializedAdditionalRawData.ContainsKey("object"))
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object);
            }
            if (!SerializedAdditionalRawData.ContainsKey("deleted"))
            {
                writer.WritePropertyName("deleted"u8);
                writer.WriteBooleanValue(Deleted);
            }
            foreach (var item in SerializedAdditionalRawData)
            {
                if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                {
                    continue;
                }
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
            writer.WriteEndObject();
        }

        DeleteFileResponse IJsonModel<DeleteFileResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteFileResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DeleteFileResponse)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeleteFileResponse(document.RootElement, options);
        }

        internal static DeleteFileResponse DeserializeDeleteFileResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            bool deleted = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deleted"u8))
                {
                    deleted = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DeleteFileResponse(id, @object, deleted, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeleteFileResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteFileResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DeleteFileResponse)} does not support writing '{options.Format}' format.");
            }
        }

        DeleteFileResponse IPersistableModel<DeleteFileResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeleteFileResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeleteFileResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DeleteFileResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeleteFileResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static DeleteFileResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDeleteFileResponse(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
