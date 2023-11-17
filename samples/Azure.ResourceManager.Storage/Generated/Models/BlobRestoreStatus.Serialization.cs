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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobRestoreStatus : IUtf8JsonSerializable, IJsonModel<BlobRestoreStatus>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BlobRestoreStatus>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BlobRestoreStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<BlobRestoreStatus>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<BlobRestoreStatus>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Status))
                {
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(Status.Value.ToString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(FailureReason))
                {
                    writer.WritePropertyName("failureReason"u8);
                    writer.WriteStringValue(FailureReason);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(RestoreId))
                {
                    writer.WritePropertyName("restoreId"u8);
                    writer.WriteStringValue(RestoreId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Parameters))
                {
                    writer.WritePropertyName("parameters"u8);
                    writer.WriteObjectValue(Parameters);
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        BlobRestoreStatus IJsonModel<BlobRestoreStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BlobRestoreStatus)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobRestoreStatus(document.RootElement, options);
        }

        internal static BlobRestoreStatus DeserializeBlobRestoreStatus(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BlobRestoreProgressStatus> status = default;
            Optional<string> failureReason = default;
            Optional<string> restoreId = default;
            Optional<BlobRestoreContent> parameters = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new BlobRestoreProgressStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("failureReason"u8))
                {
                    failureReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("restoreId"u8))
                {
                    restoreId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BlobRestoreContent.DeserializeBlobRestoreContent(property.Value);
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BlobRestoreStatus(Optional.ToNullable(status), failureReason.Value, restoreId.Value, parameters.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BlobRestoreStatus>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BlobRestoreStatus)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        BlobRestoreStatus IPersistableModel<BlobRestoreStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BlobRestoreStatus)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobRestoreStatus(document.RootElement, options);
        }

        string IPersistableModel<BlobRestoreStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
