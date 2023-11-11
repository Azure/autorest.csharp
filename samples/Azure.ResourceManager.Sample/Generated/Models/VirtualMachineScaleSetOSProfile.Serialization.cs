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
    public partial class VirtualMachineScaleSetOSProfile : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetOSProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetOSProfile>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<VirtualMachineScaleSetOSProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<VirtualMachineScaleSetOSProfile>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<VirtualMachineScaleSetOSProfile>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ComputerNamePrefix))
            {
                writer.WritePropertyName("computerNamePrefix"u8);
                writer.WriteStringValue(ComputerNamePrefix);
            }
            if (Optional.IsDefined(AdminUsername))
            {
                writer.WritePropertyName("adminUsername"u8);
                writer.WriteStringValue(AdminUsername);
            }
            if (Optional.IsDefined(AdminPassword))
            {
                writer.WritePropertyName("adminPassword"u8);
                writer.WriteStringValue(AdminPassword);
            }
            if (Optional.IsDefined(CustomData))
            {
                writer.WritePropertyName("customData"u8);
                writer.WriteStringValue(CustomData);
            }
            if (Optional.IsDefined(WindowsConfiguration))
            {
                writer.WritePropertyName("windowsConfiguration"u8);
                writer.WriteObjectValue(WindowsConfiguration);
            }
            if (Optional.IsDefined(LinuxConfiguration))
            {
                writer.WritePropertyName("linuxConfiguration"u8);
                writer.WriteObjectValue(LinuxConfiguration);
            }
            if (Optional.IsCollectionDefined(Secrets))
            {
                writer.WritePropertyName("secrets"u8);
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

        VirtualMachineScaleSetOSProfile IJsonModel<VirtualMachineScaleSetOSProfile>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetOSProfile)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetOSProfile(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetOSProfile DeserializeVirtualMachineScaleSetOSProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> computerNamePrefix = default;
            Optional<string> adminUsername = default;
            Optional<string> adminPassword = default;
            Optional<string> customData = default;
            Optional<WindowsConfiguration> windowsConfiguration = default;
            Optional<LinuxConfiguration> linuxConfiguration = default;
            Optional<IList<VaultSecretGroup>> secrets = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computerNamePrefix"u8))
                {
                    computerNamePrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminUsername"u8))
                {
                    adminUsername = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminPassword"u8))
                {
                    adminPassword = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customData"u8))
                {
                    customData = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("windowsConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    windowsConfiguration = WindowsConfiguration.DeserializeWindowsConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("linuxConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    linuxConfiguration = LinuxConfiguration.DeserializeLinuxConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("secrets"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultSecretGroup> array = new List<VaultSecretGroup>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultSecretGroup.DeserializeVaultSecretGroup(item));
                    }
                    secrets = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetOSProfile(computerNamePrefix.Value, adminUsername.Value, adminPassword.Value, customData.Value, windowsConfiguration.Value, linuxConfiguration.Value, Optional.ToList(secrets), serializedAdditionalRawData);
        }

        BinaryData IModel<VirtualMachineScaleSetOSProfile>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetOSProfile)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        VirtualMachineScaleSetOSProfile IModel<VirtualMachineScaleSetOSProfile>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetOSProfile)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetOSProfile(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<VirtualMachineScaleSetOSProfile>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
