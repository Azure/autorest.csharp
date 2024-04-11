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

namespace xms_error_responses.Models
{
    public partial class PetSadError : IUtf8JsonSerializable, IJsonModel<PetSadError>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PetSadError>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PetSadError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetSadError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PetSadError)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Reason))
            {
                writer.WritePropertyName("reason"u8);
                writer.WriteStringValue(Reason);
            }
            writer.WritePropertyName("errorType"u8);
            writer.WriteStringValue(ErrorType);
            if (Optional.IsDefined(ErrorMessage))
            {
                writer.WritePropertyName("errorMessage"u8);
                writer.WriteStringValue(ErrorMessage);
            }
            if (Optional.IsDefined(ActionResponse))
            {
                writer.WritePropertyName("actionResponse"u8);
                writer.WriteStringValue(ActionResponse);
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

        PetSadError IJsonModel<PetSadError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetSadError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PetSadError)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePetSadError(document.RootElement, options);
        }

        internal static PetSadError DeserializePetSadError(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("errorType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "PetHungryOrThirstyError": return PetHungryOrThirstyError.DeserializePetHungryOrThirstyError(element, options);
                }
            }
            string reason = default;
            string errorType = "PetSadError";
            string errorMessage = default;
            string actionResponse = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("reason"u8))
                {
                    reason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorType"u8))
                {
                    errorType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionResponse"u8))
                {
                    actionResponse = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new PetSadError(actionResponse, serializedAdditionalRawData, errorType, errorMessage, reason);
        }

        BinaryData IPersistableModel<PetSadError>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetSadError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(PetSadError)} does not support writing '{options.Format}' format.");
            }
        }

        PetSadError IPersistableModel<PetSadError>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetSadError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePetSadError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PetSadError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PetSadError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new PetSadError FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializePetSadError(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
