// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineSize : IUtf8JsonSerializable, IJsonModel<VirtualMachineSize>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineSize>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineSize>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSize>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineSize)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(NumberOfCores))
            {
                writer.WritePropertyName("numberOfCores"u8);
                writer.WriteNumberValue(NumberOfCores.Value);
            }
            if (Optional.IsDefined(OSDiskSizeInMB))
            {
                writer.WritePropertyName("osDiskSizeInMB"u8);
                writer.WriteNumberValue(OSDiskSizeInMB.Value);
            }
            if (Optional.IsDefined(ResourceDiskSizeInMB))
            {
                writer.WritePropertyName("resourceDiskSizeInMB"u8);
                writer.WriteNumberValue(ResourceDiskSizeInMB.Value);
            }
            if (Optional.IsDefined(MemoryInMB))
            {
                writer.WritePropertyName("memoryInMB"u8);
                writer.WriteNumberValue(MemoryInMB.Value);
            }
            if (Optional.IsDefined(MaxDataDiskCount))
            {
                writer.WritePropertyName("maxDataDiskCount"u8);
                writer.WriteNumberValue(MaxDataDiskCount.Value);
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

        VirtualMachineSize IJsonModel<VirtualMachineSize>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSize>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineSize)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineSize(document.RootElement, options);
        }

        internal static VirtualMachineSize DeserializeVirtualMachineSize(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<int> numberOfCores = default;
            Optional<int> osDiskSizeInMB = default;
            Optional<int> resourceDiskSizeInMB = default;
            Optional<int> memoryInMB = default;
            Optional<int> maxDataDiskCount = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("numberOfCores"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    numberOfCores = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("osDiskSizeInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDiskSizeInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("resourceDiskSizeInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceDiskSizeInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("memoryInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    memoryInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxDataDiskCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxDataDiskCount = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineSize(name.Value, Optional.ToNullable(numberOfCores), Optional.ToNullable(osDiskSizeInMB), Optional.ToNullable(resourceDiskSizeInMB), Optional.ToNullable(memoryInMB), Optional.ToNullable(maxDataDiskCount), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineSize>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSize>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineSize)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineSize IPersistableModel<VirtualMachineSize>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSize>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineSize(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineSize)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineSize>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
