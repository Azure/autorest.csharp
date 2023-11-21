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
    public partial class RollingUpgradeProgressInfo : IUtf8JsonSerializable, IJsonModel<RollingUpgradeProgressInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RollingUpgradeProgressInfo>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RollingUpgradeProgressInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (Optional.IsDefined(SuccessfulInstanceCount))
                {
                    writer.WritePropertyName("successfulInstanceCount"u8);
                    writer.WriteNumberValue(SuccessfulInstanceCount.Value);
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(FailedInstanceCount))
                {
                    writer.WritePropertyName("failedInstanceCount"u8);
                    writer.WriteNumberValue(FailedInstanceCount.Value);
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(InProgressInstanceCount))
                {
                    writer.WritePropertyName("inProgressInstanceCount"u8);
                    writer.WriteNumberValue(InProgressInstanceCount.Value);
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(PendingInstanceCount))
                {
                    writer.WritePropertyName("pendingInstanceCount"u8);
                    writer.WriteNumberValue(PendingInstanceCount.Value);
                }
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

        RollingUpgradeProgressInfo IJsonModel<RollingUpgradeProgressInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
        }

        internal static RollingUpgradeProgressInfo DeserializeRollingUpgradeProgressInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfulInstanceCount = default;
            Optional<int> failedInstanceCount = default;
            Optional<int> inProgressInstanceCount = default;
            Optional<int> pendingInstanceCount = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfulInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfulInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("inProgressInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inProgressInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("pendingInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pendingInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RollingUpgradeProgressInfo(Optional.ToNullable(successfulInstanceCount), Optional.ToNullable(failedInstanceCount), Optional.ToNullable(inProgressInstanceCount), Optional.ToNullable(pendingInstanceCount), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RollingUpgradeProgressInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{options.Format}' format.");
            }
        }

        RollingUpgradeProgressInfo IPersistableModel<RollingUpgradeProgressInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RollingUpgradeProgressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRollingUpgradeProgressInfo(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(RollingUpgradeProgressInfo)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RollingUpgradeProgressInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
