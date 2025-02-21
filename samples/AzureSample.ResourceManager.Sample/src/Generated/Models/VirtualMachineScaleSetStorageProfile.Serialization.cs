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
    public partial class VirtualMachineScaleSetStorageProfile : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetStorageProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetStorageProfile>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineScaleSetStorageProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetStorageProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetStorageProfile)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(ImageReference))
            {
                writer.WritePropertyName("imageReference"u8);
                writer.WriteObjectValue(ImageReference, options);
            }
            if (Optional.IsDefined(OSDisk))
            {
                writer.WritePropertyName("osDisk"u8);
                writer.WriteObjectValue(OSDisk, options);
            }
            if (Optional.IsCollectionDefined(DataDisks))
            {
                writer.WritePropertyName("dataDisks"u8);
                writer.WriteStartArray();
                foreach (var item in DataDisks)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        VirtualMachineScaleSetStorageProfile IJsonModel<VirtualMachineScaleSetStorageProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetStorageProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetStorageProfile)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetStorageProfile(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetStorageProfile DeserializeVirtualMachineScaleSetStorageProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ImageReference imageReference = default;
            VirtualMachineScaleSetOSDisk osDisk = default;
            IList<VirtualMachineScaleSetDataDisk> dataDisks = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("imageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageReference = ImageReference.DeserializeImageReference(property.Value, options);
                    continue;
                }
                if (property.NameEquals("osDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDisk = VirtualMachineScaleSetOSDisk.DeserializeVirtualMachineScaleSetOSDisk(property.Value, options);
                    continue;
                }
                if (property.NameEquals("dataDisks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetDataDisk> array = new List<VirtualMachineScaleSetDataDisk>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetDataDisk.DeserializeVirtualMachineScaleSetDataDisk(item, options));
                    }
                    dataDisks = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineScaleSetStorageProfile(imageReference, osDisk, dataDisks ?? new ChangeTrackingList<VirtualMachineScaleSetDataDisk>(), serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ImageReference), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  imageReference: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ImageReference))
                {
                    builder.Append("  imageReference: ");
                    BicepSerializationHelpers.AppendChildObject(builder, ImageReference, options, 2, false, "  imageReference: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OSDisk), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  osDisk: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(OSDisk))
                {
                    builder.Append("  osDisk: ");
                    BicepSerializationHelpers.AppendChildObject(builder, OSDisk, options, 2, false, "  osDisk: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DataDisks), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  dataDisks: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(DataDisks))
                {
                    if (DataDisks.Any())
                    {
                        builder.Append("  dataDisks: ");
                        builder.AppendLine("[");
                        foreach (var item in DataDisks)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  dataDisks: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetStorageProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetStorageProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetStorageProfile)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetStorageProfile IPersistableModel<VirtualMachineScaleSetStorageProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetStorageProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeVirtualMachineScaleSetStorageProfile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetStorageProfile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetStorageProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
