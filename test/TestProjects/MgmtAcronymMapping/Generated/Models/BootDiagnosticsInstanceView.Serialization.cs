// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class BootDiagnosticsInstanceView : IUtf8JsonSerializable, IModelJsonSerializable<BootDiagnosticsInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BootDiagnosticsInstanceView>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BootDiagnosticsInstanceView>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ConsoleScreenshotBlobUri))
            {
                writer.WritePropertyName("consoleScreenshotBlobUri"u8);
                writer.WriteStringValue(ConsoleScreenshotBlobUri.AbsoluteUri);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SerialConsoleLogBlobUri))
            {
                writer.WritePropertyName("serialConsoleLogBlobUri"u8);
                writer.WriteStringValue(SerialConsoleLogBlobUri.AbsoluteUri);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteObjectValue(Status);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        BootDiagnosticsInstanceView IModelJsonSerializable<BootDiagnosticsInstanceView>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBootDiagnosticsInstanceView(document.RootElement, options);
        }

        internal static BootDiagnosticsInstanceView DeserializeBootDiagnosticsInstanceView(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BootDiagnosticsInstanceView(consoleScreenshotBlobUri.Value, serialConsoleLogBlobUri.Value, status.Value, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<BootDiagnosticsInstanceView>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BootDiagnosticsInstanceView IModelSerializable<BootDiagnosticsInstanceView>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBootDiagnosticsInstanceView(document.RootElement, options);
        }
    }
}
