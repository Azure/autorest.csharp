// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineInstanceView>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineInstanceView)} does not support '{format}' format.");
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
                writer.WriteObjectValue(VmAgent);
            }
            if (Optional.IsDefined(MaintenanceRedeployStatus))
            {
                writer.WritePropertyName("maintenanceRedeployStatus"u8);
                writer.WriteObjectValue(MaintenanceRedeployStatus);
            }
            if (Optional.IsCollectionDefined(Disks))
            {
                writer.WritePropertyName("disks"u8);
                writer.WriteStartArray();
                foreach (var item in Disks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(VmHealth))
                {
                    writer.WritePropertyName("vmHealth"u8);
                    writer.WriteObjectValue(VmHealth);
                }
            }
            if (Optional.IsDefined(BootDiagnostics))
            {
                writer.WritePropertyName("bootDiagnostics"u8);
                writer.WriteObjectValue(BootDiagnostics);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(AssignedHost))
                {
                    writer.WritePropertyName("assignedHost"u8);
                    writer.WriteStringValue(AssignedHost);
                }
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PatchStatus))
            {
                writer.WritePropertyName("patchStatus"u8);
                writer.WriteObjectValue(PatchStatus);
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        VirtualMachineInstanceView IJsonModel<VirtualMachineInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineInstanceView)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineInstanceView DeserializeVirtualMachineInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> platformUpdateDomain = default;
            Optional<int> platformFaultDomain = default;
            Optional<string> computerName = default;
            Optional<string> osName = default;
            Optional<string> osVersion = default;
            Optional<HyperVGenerationType> hyperVGeneration = default;
            Optional<string> rdpThumbPrint = default;
            Optional<VirtualMachineAgentInstanceView> vmAgent = default;
            Optional<MaintenanceRedeployStatus> maintenanceRedeployStatus = default;
            Optional<IReadOnlyList<DiskInstanceView>> disks = default;
            Optional<VirtualMachineHealthStatus> vmHealth = default;
            Optional<BootDiagnosticsInstanceView> bootDiagnostics = default;
            Optional<string> assignedHost = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            Optional<VirtualMachinePatchStatus> patchStatus = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    hyperVGeneration = new HyperVGenerationType(property.Value.GetString());
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
                    vmAgent = VirtualMachineAgentInstanceView.DeserializeVirtualMachineAgentInstanceView(property.Value);
                    continue;
                }
                if (property.NameEquals("maintenanceRedeployStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceRedeployStatus = MaintenanceRedeployStatus.DeserializeMaintenanceRedeployStatus(property.Value);
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
                        array.Add(DiskInstanceView.DeserializeDiskInstanceView(item));
                    }
                    disks = array;
                    continue;
                }
                if (property.NameEquals("vmHealth"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmHealth = VirtualMachineHealthStatus.DeserializeVirtualMachineHealthStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("bootDiagnostics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bootDiagnostics = BootDiagnosticsInstanceView.DeserializeBootDiagnosticsInstanceView(property.Value);
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
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
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
                    patchStatus = VirtualMachinePatchStatus.DeserializeVirtualMachinePatchStatus(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineInstanceView(Optional.ToNullable(platformUpdateDomain), Optional.ToNullable(platformFaultDomain), computerName.Value, osName.Value, osVersion.Value, Optional.ToNullable(hyperVGeneration), rdpThumbPrint.Value, vmAgent.Value, maintenanceRedeployStatus.Value, Optional.ToList(disks), vmHealth.Value, bootDiagnostics.Value, assignedHost.Value, Optional.ToList(statuses), patchStatus.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineInstanceView>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineInstanceView)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineInstanceView IPersistableModel<VirtualMachineInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineInstanceView(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineInstanceView)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
