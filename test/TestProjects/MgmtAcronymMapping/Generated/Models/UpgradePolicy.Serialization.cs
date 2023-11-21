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
    public partial class UpgradePolicy : IUtf8JsonSerializable, IJsonModel<UpgradePolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UpgradePolicy>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<UpgradePolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(UpgradePolicy)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode"u8);
                writer.WriteStringValue(Mode.Value.ToSerialString());
            }
            if (Optional.IsDefined(RollingUpgradePolicy))
            {
                writer.WritePropertyName("rollingUpgradePolicy"u8);
                writer.WriteObjectValue(RollingUpgradePolicy);
            }
            if (Optional.IsDefined(AutomaticOSUpgradePolicy))
            {
                writer.WritePropertyName("automaticOSUpgradePolicy"u8);
                writer.WriteObjectValue(AutomaticOSUpgradePolicy);
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

        UpgradePolicy IJsonModel<UpgradePolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(UpgradePolicy)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUpgradePolicy(document.RootElement, options);
        }

        internal static UpgradePolicy DeserializeUpgradePolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeMode> mode = default;
            Optional<RollingUpgradePolicy> rollingUpgradePolicy = default;
            Optional<AutomaticOSUpgradePolicy> automaticOSUpgradePolicy = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mode = property.Value.GetString().ToUpgradeMode();
                    continue;
                }
                if (property.NameEquals("rollingUpgradePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollingUpgradePolicy = RollingUpgradePolicy.DeserializeRollingUpgradePolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("automaticOSUpgradePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    automaticOSUpgradePolicy = AutomaticOSUpgradePolicy.DeserializeAutomaticOSUpgradePolicy(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UpgradePolicy(Optional.ToNullable(mode), rollingUpgradePolicy.Value, automaticOSUpgradePolicy.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<UpgradePolicy>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(UpgradePolicy)} does not support '{options.Format}' format.");
            }
        }

        UpgradePolicy IPersistableModel<UpgradePolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpgradePolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUpgradePolicy(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(UpgradePolicy)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<UpgradePolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
