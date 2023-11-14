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

namespace MgmtPartialResource.Models
{
    public partial class ConfigurationProfileAssignmentProperties : IUtf8JsonSerializable, IJsonModel<ConfigurationProfileAssignmentProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ConfigurationProfileAssignmentProperties>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<ConfigurationProfileAssignmentProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<ConfigurationProfileAssignmentProperties>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ConfigurationProfileAssignmentProperties>)} interface");
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
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Status))
                {
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(Status);
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

        ConfigurationProfileAssignmentProperties IJsonModel<ConfigurationProfileAssignmentProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConfigurationProfileAssignmentProperties(document.RootElement, options);
        }

        internal static ConfigurationProfileAssignmentProperties DeserializeConfigurationProfileAssignmentProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ConfigurationProfileAssignmentProperties(configurationProfile.Value, targetId.Value, status.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ConfigurationProfileAssignmentProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ConfigurationProfileAssignmentProperties IPersistableModel<ConfigurationProfileAssignmentProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ConfigurationProfileAssignmentProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeConfigurationProfileAssignmentProperties(document.RootElement, options);
        }

        string IPersistableModel<ConfigurationProfileAssignmentProperties>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
