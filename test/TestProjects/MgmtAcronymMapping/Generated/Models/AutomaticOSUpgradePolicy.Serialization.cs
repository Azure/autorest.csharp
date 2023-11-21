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
    public partial class AutomaticOSUpgradePolicy : IUtf8JsonSerializable, IJsonModel<AutomaticOSUpgradePolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AutomaticOSUpgradePolicy>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<AutomaticOSUpgradePolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticOSUpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(AutomaticOSUpgradePolicy)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(EnableAutomaticOSUpgrade))
            {
                writer.WritePropertyName("enableAutomaticOSUpgrade"u8);
                writer.WriteBooleanValue(EnableAutomaticOSUpgrade.Value);
            }
            if (Optional.IsDefined(DisableAutomaticRollback))
            {
                writer.WritePropertyName("disableAutomaticRollback"u8);
                writer.WriteBooleanValue(DisableAutomaticRollback.Value);
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

        AutomaticOSUpgradePolicy IJsonModel<AutomaticOSUpgradePolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticOSUpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(AutomaticOSUpgradePolicy)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAutomaticOSUpgradePolicy(document.RootElement, options);
        }

        internal static AutomaticOSUpgradePolicy DeserializeAutomaticOSUpgradePolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> enableAutomaticOSUpgrade = default;
            Optional<bool> disableAutomaticRollback = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enableAutomaticOSUpgrade"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutomaticOSUpgrade = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("disableAutomaticRollback"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    disableAutomaticRollback = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AutomaticOSUpgradePolicy(Optional.ToNullable(enableAutomaticOSUpgrade), Optional.ToNullable(disableAutomaticRollback), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AutomaticOSUpgradePolicy>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticOSUpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(AutomaticOSUpgradePolicy)} does not support '{options.Format}' format.");
            }
        }

        AutomaticOSUpgradePolicy IPersistableModel<AutomaticOSUpgradePolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticOSUpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAutomaticOSUpgradePolicy(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(AutomaticOSUpgradePolicy)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<AutomaticOSUpgradePolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
