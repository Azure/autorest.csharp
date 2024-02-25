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
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetDataDisk : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetDataDisk>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetDataDisk>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineScaleSetDataDisk>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetDataDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetDataDisk)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WritePropertyName("lun"u8);
            writer.WriteNumberValue(Lun);
            if (Caching.HasValue)
            {
                writer.WritePropertyName("caching"u8);
                writer.WriteStringValue(Caching.Value.ToSerialString());
            }
            if (WriteAcceleratorEnabled.HasValue)
            {
                writer.WritePropertyName("writeAcceleratorEnabled"u8);
                writer.WriteBooleanValue(WriteAcceleratorEnabled.Value);
            }
            writer.WritePropertyName("createOption"u8);
            writer.WriteStringValue(CreateOption.ToString());
            if (DiskSizeGB.HasValue)
            {
                writer.WritePropertyName("diskSizeGB"u8);
                writer.WriteNumberValue(DiskSizeGB.Value);
            }
            if (ManagedDisk != null)
            {
                writer.WritePropertyName("managedDisk"u8);
                writer.WriteObjectValue(ManagedDisk);
            }
            if (DiskIopsReadWrite.HasValue)
            {
                writer.WritePropertyName("diskIOPSReadWrite"u8);
                writer.WriteNumberValue(DiskIopsReadWrite.Value);
            }
            if (DiskMBpsReadWrite.HasValue)
            {
                writer.WritePropertyName("diskMBpsReadWrite"u8);
                writer.WriteNumberValue(DiskMBpsReadWrite.Value);
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

        VirtualMachineScaleSetDataDisk IJsonModel<VirtualMachineScaleSetDataDisk>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetDataDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetDataDisk)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetDataDisk(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetDataDisk DeserializeVirtualMachineScaleSetDataDisk(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            int lun = default;
            Optional<CachingType> caching = default;
            Optional<bool> writeAcceleratorEnabled = default;
            DiskCreateOptionType createOption = default;
            Optional<int> diskSizeGB = default;
            Optional<VirtualMachineScaleSetManagedDiskParameters> managedDisk = default;
            Optional<long> diskIOPSReadWrite = default;
            Optional<long> diskMBpsReadWrite = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lun"u8))
                {
                    lun = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("caching"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    caching = property.Value.GetString().ToCachingType();
                    continue;
                }
                if (property.NameEquals("writeAcceleratorEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    writeAcceleratorEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("createOption"u8))
                {
                    createOption = new DiskCreateOptionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("diskSizeGB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskSizeGB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("managedDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    managedDisk = VirtualMachineScaleSetManagedDiskParameters.DeserializeVirtualMachineScaleSetManagedDiskParameters(property.Value, options);
                    continue;
                }
                if (property.NameEquals("diskIOPSReadWrite"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskIOPSReadWrite = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("diskMBpsReadWrite"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskMBpsReadWrite = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetDataDisk(name.Value, lun, Optional.ToNullable(caching), Optional.ToNullable(writeAcceleratorEnabled), createOption, Optional.ToNullable(diskSizeGB), managedDisk.Value, Optional.ToNullable(diskIOPSReadWrite), Optional.ToNullable(diskMBpsReadWrite), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Name != null)
            {
                builder.Append("  name:");
                if (Name.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{Name}'''");
                }
                else
                {
                    builder.AppendLine($" '{Name}'");
                }
            }

            builder.Append("  lun:");
            builder.AppendLine($" {Lun}");

            if (Caching.HasValue)
            {
                builder.Append("  caching:");
                builder.AppendLine($" '{Caching.Value.ToSerialString()}'");
            }

            if (WriteAcceleratorEnabled.HasValue)
            {
                builder.Append("  writeAcceleratorEnabled:");
                var boolValue = WriteAcceleratorEnabled.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
            }

            builder.Append("  createOption:");
            builder.AppendLine($" '{CreateOption.ToString()}'");

            if (DiskSizeGB.HasValue)
            {
                builder.Append("  diskSizeGB:");
                builder.AppendLine($" {DiskSizeGB.Value}");
            }

            if (ManagedDisk != null)
            {
                builder.Append("  managedDisk:");
                AppendChildObject(builder, ManagedDisk, options, 2, false);
            }

            if (DiskIopsReadWrite.HasValue)
            {
                builder.Append("  diskIOPSReadWrite:");
                builder.AppendLine($" '{DiskIopsReadWrite.Value.ToString()}'");
            }

            if (DiskMBpsReadWrite.HasValue)
            {
                builder.Append("  diskMBpsReadWrite:");
                builder.AppendLine($" '{DiskMBpsReadWrite.Value.ToString()}'");
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine)
        {
            string indent = new string(' ', spaces);
            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool inMultilineString = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (inMultilineString)
                {
                    if (line.Contains("'''"))
                    {
                        inMultilineString = false;
                    }
                    stringBuilder.AppendLine(line);
                    continue;
                }
                if (line.Contains("'''"))
                {
                    inMultilineString = true;
                    stringBuilder.AppendLine($"{indent}{line}");
                    continue;
                }
                if (i == 0 && !indentFirstLine)
                {
                    stringBuilder.AppendLine($" {line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetDataDisk>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetDataDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetDataDisk)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetDataDisk IPersistableModel<VirtualMachineScaleSetDataDisk>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetDataDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineScaleSetDataDisk(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetDataDisk)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetDataDisk>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
