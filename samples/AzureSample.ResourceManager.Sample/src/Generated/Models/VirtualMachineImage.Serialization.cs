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
    public partial class VirtualMachineImage : IUtf8JsonSerializable, IJsonModel<VirtualMachineImage>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineImage>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineImage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineImage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineImage)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan"u8);
                writer.WriteObjectValue(Plan, options);
            }
            if (Optional.IsDefined(OSDiskImage))
            {
                writer.WritePropertyName("osDiskImage"u8);
                writer.WriteObjectValue(OSDiskImage, options);
            }
            if (Optional.IsCollectionDefined(DataDiskImages))
            {
                writer.WritePropertyName("dataDiskImages"u8);
                writer.WriteStartArray();
                foreach (var item in DataDiskImages)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AutomaticOSUpgradeProperties))
            {
                writer.WritePropertyName("automaticOSUpgradeProperties"u8);
                writer.WriteObjectValue(AutomaticOSUpgradeProperties, options);
            }
            if (Optional.IsDefined(HyperVGeneration))
            {
                writer.WritePropertyName("hyperVGeneration"u8);
                writer.WriteStringValue(HyperVGeneration.Value.ToString());
            }
            if (Optional.IsDefined(Disallowed))
            {
                writer.WritePropertyName("disallowed"u8);
                writer.WriteObjectValue(Disallowed, options);
            }
            writer.WriteEndObject();
        }

        VirtualMachineImage IJsonModel<VirtualMachineImage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineImage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineImage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineImage(document.RootElement, options);
        }

        internal static VirtualMachineImage DeserializeVirtualMachineImage(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            AzureLocation location = default;
            IDictionary<string, string> tags = default;
            string id = default;
            PurchasePlan plan = default;
            OSDiskImage osDiskImage = default;
            IList<DataDiskImage> dataDiskImages = default;
            AutomaticOSUpgradeProperties automaticOSUpgradeProperties = default;
            HyperVGeneration? hyperVGeneration = default;
            DisallowedConfiguration disallowed = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("plan"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            plan = PurchasePlan.DeserializePurchasePlan(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("osDiskImage"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            osDiskImage = OSDiskImage.DeserializeOSDiskImage(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("dataDiskImages"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DataDiskImage> array = new List<DataDiskImage>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DataDiskImage.DeserializeDataDiskImage(item, options));
                            }
                            dataDiskImages = array;
                            continue;
                        }
                        if (property0.NameEquals("automaticOSUpgradeProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            automaticOSUpgradeProperties = AutomaticOSUpgradeProperties.DeserializeAutomaticOSUpgradeProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("hyperVGeneration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hyperVGeneration = new HyperVGeneration(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("disallowed"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            disallowed = DisallowedConfiguration.DeserializeDisallowedConfiguration(property0.Value, options);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineImage(
                id,
                serializedAdditionalRawData,
                name,
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                plan,
                osDiskImage,
                dataDiskImages ?? new ChangeTrackingList<DataDiskImage>(),
                automaticOSUpgradeProperties,
                hyperVGeneration,
                disallowed);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  name: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Name))
                {
                    builder.Append("  name: ");
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Location), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  location: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                builder.Append("  location: ");
                builder.AppendLine($"'{Location.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Tags), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  tags: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Tags))
                {
                    if (Tags.Any())
                    {
                        builder.Append("  tags: ");
                        builder.AppendLine("{");
                        foreach (var item in Tags)
                        {
                            builder.Append($"    '{item.Key}': ");
                            if (item.Value == null)
                            {
                                builder.Append("null");
                                continue;
                            }
                            if (item.Value.Contains(Environment.NewLine))
                            {
                                builder.AppendLine("'''");
                                builder.AppendLine($"{item.Value}'''");
                            }
                            else
                            {
                                builder.AppendLine($"'{item.Value}'");
                            }
                        }
                        builder.AppendLine("  }");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Id), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  id: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Id))
                {
                    builder.Append("  id: ");
                    if (Id.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Id}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Id}'");
                    }
                }
            }

            builder.Append("  properties:");
            builder.AppendLine(" {");
            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Plan), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    plan: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Plan))
                {
                    builder.Append("    plan: ");
                    BicepSerializationHelpers.AppendChildObject(builder, Plan, options, 4, false, "    plan: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("OSDiskImageOperatingSystem", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    osDiskImage: ");
                builder.AppendLine("{");
                builder.AppendLine("      osDiskImage: {");
                builder.Append("        operatingSystem: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("      }");
                builder.AppendLine("    }");
            }
            else
            {
                if (Optional.IsDefined(OSDiskImage))
                {
                    builder.Append("    osDiskImage: ");
                    BicepSerializationHelpers.AppendChildObject(builder, OSDiskImage, options, 4, false, "    osDiskImage: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DataDiskImages), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    dataDiskImages: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(DataDiskImages))
                {
                    if (DataDiskImages.Any())
                    {
                        builder.Append("    dataDiskImages: ");
                        builder.AppendLine("[");
                        foreach (var item in DataDiskImages)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 6, true, "    dataDiskImages: ");
                        }
                        builder.AppendLine("    ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("AutomaticOSUpgradeSupported", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    automaticOSUpgradeProperties: ");
                builder.AppendLine("{");
                builder.AppendLine("      automaticOSUpgradeProperties: {");
                builder.Append("        automaticOSUpgradeSupported: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("      }");
                builder.AppendLine("    }");
            }
            else
            {
                if (Optional.IsDefined(AutomaticOSUpgradeProperties))
                {
                    builder.Append("    automaticOSUpgradeProperties: ");
                    BicepSerializationHelpers.AppendChildObject(builder, AutomaticOSUpgradeProperties, options, 4, false, "    automaticOSUpgradeProperties: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(HyperVGeneration), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    hyperVGeneration: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(HyperVGeneration))
                {
                    builder.Append("    hyperVGeneration: ");
                    builder.AppendLine($"'{HyperVGeneration.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("DisallowedVmDiskType", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    disallowed: ");
                builder.AppendLine("{");
                builder.AppendLine("      disallowed: {");
                builder.Append("        vmDiskType: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("      }");
                builder.AppendLine("    }");
            }
            else
            {
                if (Optional.IsDefined(Disallowed))
                {
                    builder.Append("    disallowed: ");
                    BicepSerializationHelpers.AppendChildObject(builder, Disallowed, options, 4, false, "    disallowed: ");
                }
            }

            builder.AppendLine("  }");
            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<VirtualMachineImage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineImage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureSampleResourceManagerSampleContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineImage)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineImage IPersistableModel<VirtualMachineImage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineImage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeVirtualMachineImage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineImage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineImage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
