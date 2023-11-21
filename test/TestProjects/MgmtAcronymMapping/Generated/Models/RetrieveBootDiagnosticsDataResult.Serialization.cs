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

namespace MgmtAcronymMapping.Models
{
    public partial class RetrieveBootDiagnosticsDataResult : IUtf8JsonSerializable, IJsonModel<RetrieveBootDiagnosticsDataResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RetrieveBootDiagnosticsDataResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RetrieveBootDiagnosticsDataResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RetrieveBootDiagnosticsDataResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RetrieveBootDiagnosticsDataResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(ConsoleScreenshotBlobUri))
            {
                writer.WritePropertyName("consoleScreenshotBlobUri"u8);
                writer.WriteStringValue(ConsoleScreenshotBlobUri.AbsoluteUri);
            }
            if (options.Format != "W" && Optional.IsDefined(SerialConsoleLogBlobUri))
            {
                writer.WritePropertyName("serialConsoleLogBlobUri"u8);
                writer.WriteStringValue(SerialConsoleLogBlobUri.AbsoluteUri);
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

        RetrieveBootDiagnosticsDataResult IJsonModel<RetrieveBootDiagnosticsDataResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RetrieveBootDiagnosticsDataResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RetrieveBootDiagnosticsDataResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRetrieveBootDiagnosticsDataResult(document.RootElement, options);
        }

        internal static RetrieveBootDiagnosticsDataResult DeserializeRetrieveBootDiagnosticsDataResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> consoleScreenshotBlobUri = default;
            Optional<Uri> serialConsoleLogBlobUri = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("consoleScreenshotBlobUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    consoleScreenshotBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serialConsoleLogBlobUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serialConsoleLogBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RetrieveBootDiagnosticsDataResult(consoleScreenshotBlobUri.Value, serialConsoleLogBlobUri.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RetrieveBootDiagnosticsDataResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RetrieveBootDiagnosticsDataResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(RetrieveBootDiagnosticsDataResult)} does not support '{options.Format}' format.");
            }
        }

        RetrieveBootDiagnosticsDataResult IPersistableModel<RetrieveBootDiagnosticsDataResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RetrieveBootDiagnosticsDataResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRetrieveBootDiagnosticsDataResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(RetrieveBootDiagnosticsDataResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RetrieveBootDiagnosticsDataResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
