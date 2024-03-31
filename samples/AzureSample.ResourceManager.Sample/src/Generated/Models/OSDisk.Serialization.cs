// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class OSDisk : IUtf8JsonSerializable, IJsonModel<OSDisk>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OSDisk>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OSDisk>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSDisk)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(OSType))
            {
                writer.WritePropertyName("osType"u8);
                writer.WriteStringValue(OSType.Value.ToSerialString());
            }
            if (Optional.IsDefined(EncryptionSettings))
            {
                writer.WritePropertyName("encryptionSettings"u8);
                writer.WriteObjectValue<DiskEncryptionSettings>(EncryptionSettings, options);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Vhd))
            {
                writer.WritePropertyName("vhd"u8);
                writer.WriteObjectValue<VirtualHardDisk>(Vhd, options);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue<VirtualHardDisk>(Image, options);
            }
            if (Optional.IsDefined(Caching))
            {
                writer.WritePropertyName("caching"u8);
                writer.WriteStringValue(Caching.Value.ToSerialString());
            }
            if (Optional.IsDefined(WriteAcceleratorEnabled))
            {
                writer.WritePropertyName("writeAcceleratorEnabled"u8);
                writer.WriteBooleanValue(WriteAcceleratorEnabled.Value);
            }
            if (Optional.IsDefined(DiffDiskSettings))
            {
                writer.WritePropertyName("diffDiskSettings"u8);
                writer.WriteObjectValue<DiffDiskSettings>(DiffDiskSettings, options);
            }
            writer.WritePropertyName("createOption"u8);
            writer.WriteStringValue(CreateOption.ToString());
            if (Optional.IsDefined(DiskSizeGB))
            {
                writer.WritePropertyName("diskSizeGB"u8);
                writer.WriteNumberValue(DiskSizeGB.Value);
            }
            if (Optional.IsDefined(ManagedDisk))
            {
                writer.WritePropertyName("managedDisk"u8);
                writer.WriteObjectValue<ManagedDiskParameters>(ManagedDisk, options);
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

        OSDisk IJsonModel<OSDisk>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSDisk)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOSDisk(document.RootElement, options);
        }

        internal static OSDisk DeserializeOSDisk(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OperatingSystemType? osType = default;
            DiskEncryptionSettings encryptionSettings = default;
            string name = default;
            VirtualHardDisk vhd = default;
            VirtualHardDisk image = default;
            CachingType? caching = default;
            bool? writeAcceleratorEnabled = default;
            DiffDiskSettings diffDiskSettings = default;
            DiskCreateOptionType createOption = default;
            int? diskSizeGB = default;
            ManagedDiskParameters managedDisk = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("osType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osType = property.Value.GetString().ToOperatingSystemType();
                    continue;
                }
                if (property.NameEquals("encryptionSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryptionSettings = DiskEncryptionSettings.DeserializeDiskEncryptionSettings(property.Value, options);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vhd"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vhd = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value, options);
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value, options);
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
                if (property.NameEquals("diffDiskSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diffDiskSettings = DiffDiskSettings.DeserializeDiffDiskSettings(property.Value, options);
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
                    managedDisk = ManagedDiskParameters.DeserializeManagedDiskParameters(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OSDisk(
                osType,
                encryptionSettings,
                name,
                vhd,
                image,
                caching,
                writeAcceleratorEnabled,
                diffDiskSettings,
                createOption,
                diskSizeGB,
                managedDisk,
                serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            if (propertyOverrides != null)
            {
                TransformFlattenedOverrides(bicepOptions, propertyOverrides);
            }

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OSType), out propertyOverride);
            if (Optional.IsDefined(OSType) || hasPropertyOverride)
            {
                builder.Append("  osType: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{OSType.Value.ToSerialString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(EncryptionSettings), out propertyOverride);
            if (Optional.IsDefined(EncryptionSettings) || hasPropertyOverride)
            {
                builder.Append("  encryptionSettings: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, EncryptionSettings, options, 2, false, "  encryptionSettings: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (Optional.IsDefined(Name) || hasPropertyOverride)
            {
                builder.Append("  name: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Name.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Name}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Name}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Vhd), out propertyOverride);
            if (Optional.IsDefined(Vhd) || hasPropertyOverride)
            {
                builder.Append("  vhd: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, Vhd, options, 2, false, "  vhd: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Image), out propertyOverride);
            if (Optional.IsDefined(Image) || hasPropertyOverride)
            {
                builder.Append("  image: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, Image, options, 2, false, "  image: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Caching), out propertyOverride);
            if (Optional.IsDefined(Caching) || hasPropertyOverride)
            {
                builder.Append("  caching: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{Caching.Value.ToSerialString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(WriteAcceleratorEnabled), out propertyOverride);
            if (Optional.IsDefined(WriteAcceleratorEnabled) || hasPropertyOverride)
            {
                builder.Append("  writeAcceleratorEnabled: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var boolValue = WriteAcceleratorEnabled.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DiffDiskSettings), out propertyOverride);
            if (Optional.IsDefined(DiffDiskSettings) || hasPropertyOverride)
            {
                builder.Append("  diffDiskSettings: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, DiffDiskSettings, options, 2, false, "  diffDiskSettings: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(CreateOption), out propertyOverride);
            builder.Append("  createOption: ");
            if (hasPropertyOverride)
            {
                builder.AppendLine($"{propertyOverride}");
            }
            else
            {
                builder.AppendLine($"'{CreateOption.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DiskSizeGB), out propertyOverride);
            if (Optional.IsDefined(DiskSizeGB) || hasPropertyOverride)
            {
                builder.Append("  diskSizeGB: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{DiskSizeGB.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ManagedDisk), out propertyOverride);
            if (Optional.IsDefined(ManagedDisk) || hasPropertyOverride)
            {
                builder.Append("  managedDisk: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, ManagedDisk, options, 2, false, "  managedDisk: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void TransformFlattenedOverrides(BicepModelReaderWriterOptions bicepOptions, IDictionary<string, string> propertyOverrides)
        {
            foreach (var item in propertyOverrides.ToList())
            {
                switch (item.Key)
                {
                    case "VhdUri":
                        Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();
                        propertyDictionary.Add("Uri", item.Value);
                        if (Vhd == null)
                        {
                            Vhd = new VirtualHardDisk();
                        }
                        bicepOptions.PropertyOverrides.Add(Vhd, propertyDictionary);
                        break;
                    case "ImageUri":
                        Dictionary<string, string> propertyDictionary0 = new Dictionary<string, string>();
                        propertyDictionary0.Add("Uri", item.Value);
                        if (Image == null)
                        {
                            Image = new VirtualHardDisk();
                        }
                        bicepOptions.PropertyOverrides.Add(Image, propertyDictionary0);
                        break;
                    default:
                        continue;
                }
            }
        }

        BinaryData IPersistableModel<OSDisk>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(OSDisk)} does not support writing '{options.Format}' format.");
            }
        }

        OSDisk IPersistableModel<OSDisk>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOSDisk(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OSDisk)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OSDisk>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
