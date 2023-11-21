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

namespace MgmtPartialResource.Models
{
    public partial class ConfigurationProfileAssignmentProperties : IUtf8JsonSerializable, IJsonModel<ConfigurationProfileAssignmentProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ConfigurationProfileAssignmentProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ConfigurationProfileAssignmentProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConfigurationProfileAssignmentProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ConfigurationProfile))
            {
                writer.WritePropertyName("configurationProfile"u8);
                writer.WriteStringValue(ConfigurationProfile);
            }
            if (Optional.IsDefined(TargetId))
            {
                writer.WritePropertyName("targetId"u8);
                writer.WriteStringValue(TargetId);
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(Status))
                {
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(Status);
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

        ConfigurationProfileAssignmentProperties IJsonModel<ConfigurationProfileAssignmentProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConfigurationProfileAssignmentProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConfigurationProfileAssignmentProperties(document.RootElement, options);
        }

        internal static ConfigurationProfileAssignmentProperties DeserializeConfigurationProfileAssignmentProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> configurationProfile = default;
            Optional<string> targetId = default;
            Optional<string> status = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("configurationProfile"u8))
                {
                    configurationProfile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetId"u8))
                {
                    targetId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ConfigurationProfileAssignmentProperties(configurationProfile.Value, targetId.Value, status.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ConfigurationProfileAssignmentProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConfigurationProfileAssignmentProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{options.Format}' format.");
            }
        }

        ConfigurationProfileAssignmentProperties IPersistableModel<ConfigurationProfileAssignmentProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConfigurationProfileAssignmentProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeConfigurationProfileAssignmentProperties(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConfigurationProfileAssignmentProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
