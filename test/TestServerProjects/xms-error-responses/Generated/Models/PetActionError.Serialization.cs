// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    public partial class PetActionError : IUtf8JsonSerializable, IJsonModel<PetActionError>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PetActionError>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PetActionError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetActionError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(PetActionError)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
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

        PetActionError IJsonModel<PetActionError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetActionError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(PetActionError)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePetActionError(document.RootElement, options);
        }

        internal static PetActionError DeserializePetActionError(JsonElement element, ModelReaderWriterOptions options = null)
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
                    case "PetHungryOrThirstyError": return PetHungryOrThirstyError.DeserializePetHungryOrThirstyError(element);
                    case "PetSadError": return PetSadError.DeserializePetSadError(element);
                }
            }
            string errorType = default;
            Optional<string> errorMessage = default;
            Optional<string> actionResponse = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PetActionError(actionResponse.Value, serializedAdditionalRawData, errorType, errorMessage.Value);
        }

        BinaryData IPersistableModel<PetActionError>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetActionError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(PetActionError)} does not support '{options.Format}' format.");
            }
        }

        PetActionError IPersistableModel<PetActionError>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetActionError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePetActionError(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(PetActionError)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PetActionError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
