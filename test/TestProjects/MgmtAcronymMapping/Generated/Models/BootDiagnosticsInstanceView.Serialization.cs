// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class BootDiagnosticsInstanceView : IUtf8JsonSerializable, IJsonModel<BootDiagnosticsInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BootDiagnosticsInstanceView>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<BootDiagnosticsInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<BootDiagnosticsInstanceView>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<BootDiagnosticsInstanceView>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ConsoleScreenshotBlobUri))
                {
                    writer.WritePropertyName("consoleScreenshotBlobUri"u8);
                    writer.WriteStringValue(ConsoleScreenshotBlobUri.AbsoluteUri);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(SerialConsoleLogBlobUri))
                {
                    writer.WritePropertyName("serialConsoleLogBlobUri"u8);
                    writer.WriteStringValue(SerialConsoleLogBlobUri.AbsoluteUri);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Status))
                {
                    writer.WritePropertyName("status"u8);
                    writer.WriteObjectValue(Status);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        BootDiagnosticsInstanceView IJsonModel<BootDiagnosticsInstanceView>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BootDiagnosticsInstanceView)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBootDiagnosticsInstanceView(document.RootElement, options);
        }

        internal static BootDiagnosticsInstanceView DeserializeBootDiagnosticsInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> consoleScreenshotBlobUri = default;
            Optional<Uri> serialConsoleLogBlobUri = default;
            Optional<InstanceViewStatus> status = default;
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
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = InstanceViewStatus.DeserializeInstanceViewStatus(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BootDiagnosticsInstanceView(consoleScreenshotBlobUri.Value, serialConsoleLogBlobUri.Value, status.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<BootDiagnosticsInstanceView>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BootDiagnosticsInstanceView)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        BootDiagnosticsInstanceView IModel<BootDiagnosticsInstanceView>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BootDiagnosticsInstanceView)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBootDiagnosticsInstanceView(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<BootDiagnosticsInstanceView>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
