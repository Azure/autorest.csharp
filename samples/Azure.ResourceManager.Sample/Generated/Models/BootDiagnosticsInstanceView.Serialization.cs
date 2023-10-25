// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class BootDiagnosticsInstanceView : IUtf8JsonSerializable, IJsonModel<BootDiagnosticsInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BootDiagnosticsInstanceView>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<BootDiagnosticsInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(ConsoleScreenshotBlobUri))
            {
                writer.WritePropertyName("consoleScreenshotBlobUri"u8);
                writer.WriteStringValue(ConsoleScreenshotBlobUri.AbsoluteUri);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(SerialConsoleLogBlobUri))
            {
                writer.WritePropertyName("serialConsoleLogBlobUri"u8);
                writer.WriteStringValue(SerialConsoleLogBlobUri.AbsoluteUri);
            }
            if (options.Format == ModelReaderWriterFormat.Json && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteObjectValue(Status);
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
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }

        BootDiagnosticsInstanceView IModel<BootDiagnosticsInstanceView>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBootDiagnosticsInstanceView(document.RootElement, options);
        }
    }
}
