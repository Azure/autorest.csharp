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
    public partial class VirtualMachineScaleSetVmInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetVmInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetVmInstanceView>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineScaleSetVmInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmInstanceView)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
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
            if (options.Format != "W" && Optional.IsDefined(AssignedHost))
            {
                writer.WritePropertyName("assignedHost"u8);
                writer.WriteStringValue(AssignedHost);
            }
            if (Optional.IsDefined(PlacementGroupId))
            {
                writer.WritePropertyName("placementGroupId"u8);
                writer.WriteStringValue(PlacementGroupId);
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

        VirtualMachineScaleSetVmInstanceView IJsonModel<VirtualMachineScaleSetVmInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmInstanceView)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetVmInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetVmInstanceView DeserializeVirtualMachineScaleSetVmInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? platformUpdateDomain = default;
            int? platformFaultDomain = default;
            string rdpThumbPrint = default;
            VirtualMachineAgentInstanceView vmAgent = default;
            MaintenanceRedeployStatus maintenanceRedeployStatus = default;
            IReadOnlyList<DiskInstanceView> disks = default;
            IReadOnlyList<VirtualMachineExtensionInstanceView> extensions = default;
            VirtualMachineHealthStatus vmHealth = default;
            BootDiagnosticsInstanceView bootDiagnostics = default;
            IReadOnlyList<InstanceViewStatus> statuses = default;
            string assignedHost = default;
            string placementGroupId = default;
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
                if (property.NameEquals("assignedHost"u8))
                {
                    assignedHost = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("placementGroupId"u8))
                {
                    placementGroupId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineScaleSetVmInstanceView(
                platformUpdateDomain,
                platformFaultDomain,
                rdpThumbPrint,
                vmAgent,
                maintenanceRedeployStatus,
                disks ?? new ChangeTrackingList<DiskInstanceView>(),
                extensions ?? new ChangeTrackingList<VirtualMachineExtensionInstanceView>(),
                vmHealth,
                bootDiagnostics,
                statuses ?? new ChangeTrackingList<InstanceViewStatus>(),
                assignedHost,
                placementGroupId,
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PlatformUpdateDomain), out propertyOverride);
            if (Optional.IsDefined(PlatformUpdateDomain) || hasPropertyOverride)
            {
                builder.Append("  platformUpdateDomain: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{PlatformUpdateDomain.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PlatformFaultDomain), out propertyOverride);
            if (Optional.IsDefined(PlatformFaultDomain) || hasPropertyOverride)
            {
                builder.Append("  platformFaultDomain: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"{PlatformFaultDomain.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RdpThumbPrint), out propertyOverride);
            if (Optional.IsDefined(RdpThumbPrint) || hasPropertyOverride)
            {
                builder.Append("  rdpThumbPrint: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
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
            if (Optional.IsDefined(VmAgent) || hasPropertyOverride)
            {
                builder.Append("  vmAgent: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, VmAgent, options, 2, false, "  vmAgent: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MaintenanceRedeployStatus), out propertyOverride);
            if (Optional.IsDefined(MaintenanceRedeployStatus) || hasPropertyOverride)
            {
                builder.Append("  maintenanceRedeployStatus: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, MaintenanceRedeployStatus, options, 2, false, "  maintenanceRedeployStatus: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Disks), out propertyOverride);
            if (Optional.IsCollectionDefined(Disks) || hasPropertyOverride)
            {
                if (Disks.Any() || hasPropertyOverride)
                {
                    builder.Append("  disks: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
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
            if (Optional.IsCollectionDefined(Extensions) || hasPropertyOverride)
            {
                if (Extensions.Any() || hasPropertyOverride)
                {
                    builder.Append("  extensions: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in Extensions)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  extensions: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(VmHealth), out propertyOverride);
            if (Optional.IsDefined(VmHealth) || hasPropertyOverride)
            {
                builder.Append("  vmHealth: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, VmHealth, options, 2, false, "  vmHealth: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(BootDiagnostics), out propertyOverride);
            if (Optional.IsDefined(BootDiagnostics) || hasPropertyOverride)
            {
                builder.Append("  bootDiagnostics: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, BootDiagnostics, options, 2, false, "  bootDiagnostics: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Statuses), out propertyOverride);
            if (Optional.IsCollectionDefined(Statuses) || hasPropertyOverride)
            {
                if (Statuses.Any() || hasPropertyOverride)
                {
                    builder.Append("  statuses: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in Statuses)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  statuses: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(AssignedHost), out propertyOverride);
            if (Optional.IsDefined(AssignedHost) || hasPropertyOverride)
            {
                builder.Append("  assignedHost: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PlacementGroupId), out propertyOverride);
            if (Optional.IsDefined(PlacementGroupId) || hasPropertyOverride)
            {
                builder.Append("  placementGroupId: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (PlacementGroupId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{PlacementGroupId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{PlacementGroupId}'");
                    }
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
                    case "VmHealthStatus":
                        Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();
                        propertyDictionary.Add("Status", item.Value);
                        bicepOptions.PropertyOverrides.Add(VmHealth, propertyDictionary);
                        break;
                    default:
                        continue;
                }
            }
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetVmInstanceView>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmInstanceView)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetVmInstanceView IPersistableModel<VirtualMachineScaleSetVmInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineScaleSetVmInstanceView(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmInstanceView)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetVmInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
