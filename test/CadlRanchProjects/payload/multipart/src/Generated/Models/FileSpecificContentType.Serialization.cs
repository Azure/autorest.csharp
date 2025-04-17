// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Payload.MultiPart.Models
{
    public partial class FileSpecificContentType : IUtf8JsonSerializable, IJsonModel<FileSpecificContentType>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FileSpecificContentType>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<FileSpecificContentType>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileSpecificContentType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileSpecificContentType)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
        }

        FileSpecificContentType IJsonModel<FileSpecificContentType>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileSpecificContentType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileSpecificContentType)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileSpecificContentType(document.RootElement, options);
        }

        internal static FileSpecificContentType DeserializeFileSpecificContentType(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string contentType = default;
            string filename = default;
            BinaryData contents = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("contentType"u8))
                {
                    contentType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filename"u8))
                {
                    filename = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("contents"u8))
                {
                    contents = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FileSpecificContentType(contentType, filename, contents, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FileSpecificContentType>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileSpecificContentType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, PayloadMultiPartContext.Default);
                default:
                    throw new FormatException($"The model {nameof(FileSpecificContentType)} does not support writing '{options.Format}' format.");
            }
        }

        FileSpecificContentType IPersistableModel<FileSpecificContentType>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileSpecificContentType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeFileSpecificContentType(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FileSpecificContentType)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FileSpecificContentType>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new FileSpecificContentType FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFileSpecificContentType(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
