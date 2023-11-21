// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CognitiveServicesAccount : IUtf8JsonSerializable, IJsonModel<CognitiveServicesAccount>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CognitiveServicesAccount>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CognitiveServicesAccount>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CognitiveServicesAccount>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CognitiveServicesAccount)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        CognitiveServicesAccount IJsonModel<CognitiveServicesAccount>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CognitiveServicesAccount>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CognitiveServicesAccount)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCognitiveServicesAccount(document.RootElement, options);
        }

        internal static CognitiveServicesAccount DeserializeCognitiveServicesAccount(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.CognitiveServicesByKey": return CognitiveServicesAccountKey.DeserializeCognitiveServicesAccountKey(element);
                    case "#Microsoft.Azure.Search.DefaultCognitiveServices": return DefaultCognitiveServicesAccount.DeserializeDefaultCognitiveServicesAccount(element);
                }
            }
            return UnknownCognitiveServicesAccount.DeserializeUnknownCognitiveServicesAccount(element);
        }

        BinaryData IPersistableModel<CognitiveServicesAccount>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CognitiveServicesAccount>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(CognitiveServicesAccount)} does not support '{options.Format}' format.");
            }
        }

        CognitiveServicesAccount IPersistableModel<CognitiveServicesAccount>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CognitiveServicesAccount>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCognitiveServicesAccount(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(CognitiveServicesAccount)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CognitiveServicesAccount>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
