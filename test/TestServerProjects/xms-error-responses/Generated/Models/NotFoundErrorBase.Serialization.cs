// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace xms_error_responses.Models
{
    [PersistableModelProxy(typeof(UnknownNotFoundErrorBase))]
    internal partial class NotFoundErrorBase : IUtf8JsonSerializable, IJsonModel<NotFoundErrorBase>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NotFoundErrorBase>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<NotFoundErrorBase>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NotFoundErrorBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NotFoundErrorBase)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Reason))
            {
                writer.WritePropertyName("reason"u8);
                writer.WriteStringValue(Reason);
            }
            writer.WritePropertyName("whatNotFound"u8);
            writer.WriteStringValue(WhatNotFound);
        }

        NotFoundErrorBase IJsonModel<NotFoundErrorBase>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NotFoundErrorBase>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NotFoundErrorBase)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNotFoundErrorBase(document.RootElement, options);
        }

        internal static NotFoundErrorBase DeserializeNotFoundErrorBase(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("whatNotFound", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AnimalNotFound": return AnimalNotFound.DeserializeAnimalNotFound(element, options);
                    case "InvalidResourceLink": return LinkNotFound.DeserializeLinkNotFound(element, options);
                }
            }
            return UnknownNotFoundErrorBase.DeserializeUnknownNotFoundErrorBase(element, options);
        }

        BinaryData IPersistableModel<NotFoundErrorBase>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NotFoundErrorBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(NotFoundErrorBase)} does not support writing '{options.Format}' format.");
            }
        }

        NotFoundErrorBase IPersistableModel<NotFoundErrorBase>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NotFoundErrorBase>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeNotFoundErrorBase(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NotFoundErrorBase)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<NotFoundErrorBase>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new NotFoundErrorBase FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeNotFoundErrorBase(document.RootElement);
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
