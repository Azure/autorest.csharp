// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetManagedDiskParameters : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetManagedDiskParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetManagedDiskParameters>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineScaleSetManagedDiskParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support writing '{format}' format.");
            }

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
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        VirtualMachineScaleSetManagedDiskParameters IJsonModel<VirtualMachineScaleSetManagedDiskParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetManagedDiskParameters(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetManagedDiskParameters DeserializeVirtualMachineScaleSetManagedDiskParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StorageAccountType? storageAccountType = default;
            WritableSubResource diskEncryptionSet = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineScaleSetManagedDiskParameters(storageAccountType, diskEncryptionSet, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(StorageAccountType), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  storageAccountType: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(StorageAccountType))
                {
                    builder.Append("  storageAccountType: ");
                    builder.AppendLine($"'{StorageAccountType.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("DiskEncryptionSetId", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  diskEncryptionSet: ");
                builder.AppendLine("{");
                builder.Append("    id: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("  }");
            }
            else
            {
                if (Optional.IsDefined(DiskEncryptionSet))
                {
                    builder.Append("  diskEncryptionSet: ");
                    BicepSerializationHelpers.AppendChildObject(builder, DiskEncryptionSet, options, 2, false, "  diskEncryptionSet: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureSampleResourceManagerSampleContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetManagedDiskParameters IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeVirtualMachineScaleSetManagedDiskParameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetManagedDiskParameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetManagedDiskParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
