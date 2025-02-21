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
    public partial class VirtualMachineInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineInstanceView>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(PlatformUpdateDomain))
            {
                writer.WritePropertyName("platformUpdateDomain"u8);
                writer.WriteNumberValue(PlatformUpdateDomain.Value);
            }
            if (Optional.IsDefined(PlatformFaultDomain))
            {
                writer.WritePropertyName("platformFaultDomain"u8);
                writer.WriteNumberValue(PlatformFaultDomain.Value);
            }
            if (Optional.IsDefined(ComputerName))
            {
                writer.WritePropertyName("computerName"u8);
                writer.WriteStringValue(ComputerName);
            }
            if (Optional.IsDefined(OSName))
            {
                writer.WritePropertyName("osName"u8);
                writer.WriteStringValue(OSName);
            }
            if (Optional.IsDefined(OSVersion))
            {
                writer.WritePropertyName("osVersion"u8);
                writer.WriteStringValue(OSVersion);
            }
            if (Optional.IsDefined(HyperVGeneration))
            {
                writer.WritePropertyName("hyperVGeneration"u8);
                writer.WriteStringValue(HyperVGeneration.Value.ToString());
            }
            if (Optional.IsDefined(RdpThumbPrint))
            {
                writer.WritePropertyName("rdpThumbPrint"u8);
                writer.WriteStringValue(RdpThumbPrint);
            }
            if (Optional.IsDefined(VmAgent))
            {
                writer.WritePropertyName("vmAgent"u8);
                writer.WriteObjectValue(VmAgent, options);
            }
            if (Optional.IsDefined(MaintenanceRedeployStatus))
            {
                writer.WritePropertyName("maintenanceRedeployStatus"u8);
                writer.WriteObjectValue(MaintenanceRedeployStatus, options);
            }
            if (Optional.IsCollectionDefined(Disks))
            {
                writer.WritePropertyName("disks"u8);
                writer.WriteStartArray();
                foreach (var item in Disks)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Extensions))
            {
                writer.WritePropertyName("extensions"u8);
                writer.WriteStartArray();
                foreach (var item in Extensions)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(VmHealth))
            {
                writer.WritePropertyName("vmHealth"u8);
                writer.WriteObjectValue(VmHealth, options);
            }
            if (Optional.IsDefined(BootDiagnostics))
            {
                writer.WritePropertyName("bootDiagnostics"u8);
                writer.WriteObjectValue(BootDiagnostics, options);
            }
            if (options.Format != "W" && Optional.IsDefined(AssignedHost))
            {
                writer.WritePropertyName("assignedHost"u8);
                writer.WriteStringValue(AssignedHost);
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PatchStatus))
            {
                writer.WritePropertyName("patchStatus"u8);
                writer.WriteObjectValue(PatchStatus, options);
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

        VirtualMachineInstanceView IJsonModel<VirtualMachineInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineInstanceView DeserializeVirtualMachineInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? platformUpdateDomain = default;
            int? platformFaultDomain = default;
            string computerName = default;
            string osName = default;
            string osVersion = default;
            HyperVGeneration? hyperVGeneration = default;
            string rdpThumbPrint = default;
            VirtualMachineAgentInstanceView vmAgent = default;
            MaintenanceRedeployStatus maintenanceRedeployStatus = default;
            IReadOnlyList<DiskInstanceView> disks = default;
            IReadOnlyList<VirtualMachineExtensionInstanceView> extensions = default;
            VirtualMachineHealthStatus vmHealth = default;
            BootDiagnosticsInstanceView bootDiagnostics = default;
            string assignedHost = default;
            IReadOnlyList<InstanceViewStatus> statuses = default;
            VirtualMachinePatchStatus patchStatus = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomain"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformUpdateDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomain"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformFaultDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("computerName"u8))
                {
                    computerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osName"u8))
                {
                    osName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osVersion"u8))
                {
                    osVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hyperVGeneration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperVGeneration = new HyperVGeneration(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("rdpThumbPrint"u8))
                {
                    rdpThumbPrint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vmAgent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmAgent = VirtualMachineAgentInstanceView.DeserializeVirtualMachineAgentInstanceView(property.Value, options);
                    continue;
                }
                if (property.NameEquals("maintenanceRedeployStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceRedeployStatus = MaintenanceRedeployStatus.DeserializeMaintenanceRedeployStatus(property.Value, options);
                    continue;
                }
                if (property.NameEquals("disks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DiskInstanceView> array = new List<DiskInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DiskInstanceView.DeserializeDiskInstanceView(item, options));
                    }
                    disks = array;
                    continue;
                }
                if (property.NameEquals("extensions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineExtensionInstanceView> array = new List<VirtualMachineExtensionInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtensionInstanceView.DeserializeVirtualMachineExtensionInstanceView(item, options));
                    }
                    extensions = array;
                    continue;
                }
                if (property.NameEquals("vmHealth"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmHealth = VirtualMachineHealthStatus.DeserializeVirtualMachineHealthStatus(property.Value, options);
                    continue;
                }
                if (property.NameEquals("bootDiagnostics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bootDiagnostics = BootDiagnosticsInstanceView.DeserializeBootDiagnosticsInstanceView(property.Value, options);
                    continue;
                }
                if (property.NameEquals("assignedHost"u8))
                {
                    assignedHost = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item, options));
                    }
                    statuses = array;
                    continue;
                }
                if (property.NameEquals("patchStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    patchStatus = VirtualMachinePatchStatus.DeserializeVirtualMachinePatchStatus(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineInstanceView(
                platformUpdateDomain,
                platformFaultDomain,
                computerName,
                osName,
                osVersion,
                hyperVGeneration,
                rdpThumbPrint,
                vmAgent,
                maintenanceRedeployStatus,
                disks ?? new ChangeTrackingList<DiskInstanceView>(),
                extensions ?? new ChangeTrackingList<VirtualMachineExtensionInstanceView>(),
                vmHealth,
                bootDiagnostics,
                assignedHost,
                statuses ?? new ChangeTrackingList<InstanceViewStatus>(),
                patchStatus,
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

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PlatformUpdateDomain), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  platformUpdateDomain: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PlatformUpdateDomain))
                {
                    builder.Append("  platformUpdateDomain: ");
                    builder.AppendLine($"{PlatformUpdateDomain.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PlatformFaultDomain), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  platformFaultDomain: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PlatformFaultDomain))
                {
                    builder.Append("  platformFaultDomain: ");
                    builder.AppendLine($"{PlatformFaultDomain.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ComputerName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  computerName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ComputerName))
                {
                    builder.Append("  computerName: ");
                    if (ComputerName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ComputerName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ComputerName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OSName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  osName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(OSName))
                {
                    builder.Append("  osName: ");
                    if (OSName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{OSName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{OSName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OSVersion), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  osVersion: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(OSVersion))
                {
                    builder.Append("  osVersion: ");
                    if (OSVersion.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{OSVersion}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{OSVersion}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(HyperVGeneration), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  hyperVGeneration: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(HyperVGeneration))
                {
                    builder.Append("  hyperVGeneration: ");
                    builder.AppendLine($"'{HyperVGeneration.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RdpThumbPrint), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  rdpThumbPrint: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RdpThumbPrint))
                {
                    builder.Append("  rdpThumbPrint: ");
                    if (RdpThumbPrint.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{RdpThumbPrint}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{RdpThumbPrint}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(VmAgent), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  vmAgent: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(VmAgent))
                {
                    builder.Append("  vmAgent: ");
                    BicepSerializationHelpers.AppendChildObject(builder, VmAgent, options, 2, false, "  vmAgent: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MaintenanceRedeployStatus), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  maintenanceRedeployStatus: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(MaintenanceRedeployStatus))
                {
                    builder.Append("  maintenanceRedeployStatus: ");
                    BicepSerializationHelpers.AppendChildObject(builder, MaintenanceRedeployStatus, options, 2, false, "  maintenanceRedeployStatus: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Disks), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  disks: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Disks))
                {
                    if (Disks.Any())
                    {
                        builder.Append("  disks: ");
                        builder.AppendLine("[");
                        foreach (var item in Disks)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  disks: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Extensions), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  extensions: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Extensions))
                {
                    if (Extensions.Any())
                    {
                        builder.Append("  extensions: ");
                        builder.AppendLine("[");
                        foreach (var item in Extensions)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  extensions: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("VmHealthStatus", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  vmHealth: ");
                builder.AppendLine("{");
                builder.Append("    status: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("  }");
            }
            else
            {
                if (Optional.IsDefined(VmHealth))
                {
                    builder.Append("  vmHealth: ");
                    BicepSerializationHelpers.AppendChildObject(builder, VmHealth, options, 2, false, "  vmHealth: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(BootDiagnostics), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  bootDiagnostics: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(BootDiagnostics))
                {
                    builder.Append("  bootDiagnostics: ");
                    BicepSerializationHelpers.AppendChildObject(builder, BootDiagnostics, options, 2, false, "  bootDiagnostics: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(AssignedHost), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  assignedHost: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(AssignedHost))
                {
                    builder.Append("  assignedHost: ");
                    if (AssignedHost.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{AssignedHost}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{AssignedHost}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Statuses), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  statuses: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Statuses))
                {
                    if (Statuses.Any())
                    {
                        builder.Append("  statuses: ");
                        builder.AppendLine("[");
                        foreach (var item in Statuses)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  statuses: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PatchStatus), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  patchStatus: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PatchStatus))
                {
                    builder.Append("  patchStatus: ");
                    BicepSerializationHelpers.AppendChildObject(builder, PatchStatus, options, 2, false, "  patchStatus: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<VirtualMachineInstanceView>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineInstanceView IPersistableModel<VirtualMachineInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeVirtualMachineInstanceView(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
