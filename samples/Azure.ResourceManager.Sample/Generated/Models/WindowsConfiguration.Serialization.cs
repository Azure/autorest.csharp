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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class WindowsConfiguration : IUtf8JsonSerializable, IJsonModel<WindowsConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WindowsConfiguration>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<WindowsConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ProvisionVmAgent))
            {
                writer.WritePropertyName("provisionVMAgent"u8);
                writer.WriteBooleanValue(ProvisionVmAgent.Value);
            }
            if (Optional.IsDefined(EnableAutomaticUpdates))
            {
                writer.WritePropertyName("enableAutomaticUpdates"u8);
                writer.WriteBooleanValue(EnableAutomaticUpdates.Value);
            }
            if (Optional.IsDefined(TimeZone))
            {
                writer.WritePropertyName("timeZone"u8);
                writer.WriteStringValue(TimeZone);
            }
            if (Optional.IsCollectionDefined(AdditionalUnattendContent))
            {
                writer.WritePropertyName("additionalUnattendContent"u8);
                writer.WriteStartArray();
                foreach (var item in AdditionalUnattendContent)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PatchSettings))
            {
                writer.WritePropertyName("patchSettings"u8);
                writer.WriteObjectValue(PatchSettings);
            }
            if (Optional.IsDefined(WinRM))
            {
                writer.WritePropertyName("winRM"u8);
                writer.WriteObjectValue(WinRM);
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

        WindowsConfiguration IJsonModel<WindowsConfiguration>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWindowsConfiguration(document.RootElement, options);
        }

        internal static WindowsConfiguration DeserializeWindowsConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> provisionVmAgent = default;
            Optional<bool> enableAutomaticUpdates = default;
            Optional<string> timeZone = default;
            Optional<IList<AdditionalUnattendContent>> additionalUnattendContent = default;
            Optional<PatchSettings> patchSettings = default;
            Optional<WinRMConfiguration> winRM = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisionVMAgent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisionVmAgent = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enableAutomaticUpdates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutomaticUpdates = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("timeZone"u8))
                {
                    timeZone = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalUnattendContent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AdditionalUnattendContent> array = new List<AdditionalUnattendContent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Models.AdditionalUnattendContent.DeserializeAdditionalUnattendContent(item));
                    }
                    additionalUnattendContent = array;
                    continue;
                }
                if (property.NameEquals("patchSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    patchSettings = PatchSettings.DeserializePatchSettings(property.Value);
                    continue;
                }
                if (property.NameEquals("winRM"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    winRM = WinRMConfiguration.DeserializeWinRMConfiguration(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WindowsConfiguration(Optional.ToNullable(provisionVmAgent), Optional.ToNullable(enableAutomaticUpdates), timeZone.Value, Optional.ToList(additionalUnattendContent), patchSettings.Value, winRM.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<WindowsConfiguration>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        WindowsConfiguration IModel<WindowsConfiguration>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWindowsConfiguration(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<WindowsConfiguration>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
