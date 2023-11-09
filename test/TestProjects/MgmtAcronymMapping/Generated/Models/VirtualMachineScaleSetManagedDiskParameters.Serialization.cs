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
using Azure.ResourceManager.Resources.Models;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineScaleSetManagedDiskParameters : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetManagedDiskParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetManagedDiskParameters>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<VirtualMachineScaleSetManagedDiskParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<VirtualMachineScaleSetManagedDiskParameters>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<VirtualMachineScaleSetManagedDiskParameters>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(StorageAccountType))
            {
                writer.WritePropertyName("storageAccountType"u8);
                writer.WriteStringValue(StorageAccountType.Value.ToString());
            }
            if (Optional.IsDefined(DiskEncryptionSet))
            {
                writer.WritePropertyName("diskEncryptionSet"u8);
                JsonSerializer.Serialize(writer, DiskEncryptionSet);
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

        VirtualMachineScaleSetManagedDiskParameters IJsonModel<VirtualMachineScaleSetManagedDiskParameters>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetManagedDiskParameters(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetManagedDiskParameters DeserializeVirtualMachineScaleSetManagedDiskParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StorageAccountType> storageAccountType = default;
            Optional<WritableSubResource> diskEncryptionSet = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("storageAccountType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageAccountType = new StorageAccountType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("diskEncryptionSet"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskEncryptionSet = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetManagedDiskParameters(Optional.ToNullable(storageAccountType), diskEncryptionSet, serializedAdditionalRawData);
        }

        BinaryData IModel<VirtualMachineScaleSetManagedDiskParameters>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        VirtualMachineScaleSetManagedDiskParameters IModel<VirtualMachineScaleSetManagedDiskParameters>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetManagedDiskParameters(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<VirtualMachineScaleSetManagedDiskParameters>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
