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

namespace MgmtAcronymMapping.Models
{
    public partial class OSDisk : IUtf8JsonSerializable, IJsonModel<OSDisk>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OSDisk>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<OSDisk>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<OSDisk>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<OSDisk>)} interface");
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
                writer.WriteObjectValue(EncryptionSettings);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Vhd))
            {
                writer.WritePropertyName("vhd"u8);
                writer.WriteObjectValue(Vhd);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue(Image);
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
                writer.WriteObjectValue(DiffDiskSettings);
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
                writer.WriteObjectValue(ManagedDisk);
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

        OSDisk IJsonModel<OSDisk>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OSDisk)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOSDisk(document.RootElement, options);
        }

        internal static OSDisk DeserializeOSDisk(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<OperatingSystemType> osType = default;
            Optional<DiskEncryptionSettings> encryptionSettings = default;
            Optional<string> name = default;
            Optional<VirtualHardDisk> vhd = default;
            Optional<VirtualHardDisk> image = default;
            Optional<CachingType> caching = default;
            Optional<bool> writeAcceleratorEnabled = default;
            Optional<DiffDiskSettings> diffDiskSettings = default;
            DiskCreateOptionType createOption = default;
            Optional<int> diskSizeGB = default;
            Optional<ManagedDiskParameters> managedDisk = default;
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
                    encryptionSettings = DiskEncryptionSettings.DeserializeDiskEncryptionSettings(property.Value);
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
                    vhd = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value);
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
                    diffDiskSettings = DiffDiskSettings.DeserializeDiffDiskSettings(property.Value);
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
                    managedDisk = ManagedDiskParameters.DeserializeManagedDiskParameters(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OSDisk(Optional.ToNullable(osType), encryptionSettings.Value, name.Value, vhd.Value, image.Value, Optional.ToNullable(caching), Optional.ToNullable(writeAcceleratorEnabled), diffDiskSettings.Value, createOption, Optional.ToNullable(diskSizeGB), managedDisk.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<OSDisk>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OSDisk)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        OSDisk IModel<OSDisk>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OSDisk)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOSDisk(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<OSDisk>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
