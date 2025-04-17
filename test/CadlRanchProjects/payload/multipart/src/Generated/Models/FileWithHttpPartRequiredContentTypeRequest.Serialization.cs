// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Payload.MultiPart.Models
{
    public partial class FileWithHttpPartRequiredContentTypeRequest : IUtf8JsonSerializable, IJsonModel<FileWithHttpPartRequiredContentTypeRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FileWithHttpPartRequiredContentTypeRequest>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<FileWithHttpPartRequiredContentTypeRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileWithHttpPartRequiredContentTypeRequest)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("profileImage"u8);
            writer.WriteObjectValue(ProfileImage, options);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        FileWithHttpPartRequiredContentTypeRequest IJsonModel<FileWithHttpPartRequiredContentTypeRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileWithHttpPartRequiredContentTypeRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileWithHttpPartRequiredContentTypeRequest(document.RootElement, options);
        }

        internal static FileWithHttpPartRequiredContentTypeRequest DeserializeFileWithHttpPartRequiredContentTypeRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FileRequiredMetaData profileImage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("profileImage"u8))
                {
                    profileImage = FileRequiredMetaData.DeserializeFileRequiredMetaData(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FileWithHttpPartRequiredContentTypeRequest(profileImage, serializedAdditionalRawData);
        }

        private BinaryData SerializeMultipart(ModelReaderWriterOptions options)
        {
            using MultipartFormDataRequestContent content = ToMultipartRequestContent();
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

        internal virtual MultipartFormDataRequestContent ToMultipartRequestContent()
        {
            MultipartFormDataRequestContent content = new MultipartFormDataRequestContent();
            content.Add(ModelReaderWriter.Write<FileRequiredMetaData>(ProfileImage, ModelSerializationExtensions.WireOptions, PayloadMultiPartContext.Default), "profileImage");
            return content;
        }

        BinaryData IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, PayloadMultiPartContext.Default);
                case "MFD":
                    return SerializeMultipart(options);
                default:
                    throw new FormatException($"The model {nameof(FileWithHttpPartRequiredContentTypeRequest)} does not support writing '{options.Format}' format.");
            }
        }

        FileWithHttpPartRequiredContentTypeRequest IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeFileWithHttpPartRequiredContentTypeRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FileWithHttpPartRequiredContentTypeRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FileWithHttpPartRequiredContentTypeRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MFD";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static FileWithHttpPartRequiredContentTypeRequest FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFileWithHttpPartRequiredContentTypeRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
