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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineInstanceView>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support '{format}' format.");
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
            if (Optional.IsCollectionDefined(Extensions))
            {
                writer.WritePropertyName("extensions"u8);
                writer.WriteStartArray();
                foreach (var item in Extensions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(VmHealth))
            {
                writer.WritePropertyName("vmHealth"u8);
                writer.WriteObjectValue(VmHealth);
            }
            if (Optional.IsDefined(BootDiagnostics))
            {
                writer.WritePropertyName("bootDiagnostics"u8);
                writer.WriteObjectValue(BootDiagnostics);
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
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PatchStatus))
            {
                writer.WritePropertyName("patchStatus"u8);
                writer.WriteObjectValue(PatchStatus);
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

        VirtualMachineInstanceView IJsonModel<VirtualMachineInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support '{format}' format.");
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
            Optional<HyperVGeneration> hyperVGeneration = default;
            Optional<string> rdpThumbPrint = default;
            Optional<VirtualMachineAgentInstanceView> vmAgent = default;
            Optional<MaintenanceRedeployStatus> maintenanceRedeployStatus = default;
            Optional<IReadOnlyList<DiskInstanceView>> disks = default;
            Optional<IReadOnlyList<VirtualMachineExtensionInstanceView>> extensions = default;
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineInstanceView(Optional.ToNullable(platformUpdateDomain), Optional.ToNullable(platformFaultDomain), computerName.Value, osName.Value, osVersion.Value, Optional.ToNullable(hyperVGeneration), rdpThumbPrint.Value, vmAgent.Value, maintenanceRedeployStatus.Value, Optional.ToList(disks), Optional.ToList(extensions), vmHealth.Value, bootDiagnostics.Value, assignedHost.Value, Optional.ToList(statuses), patchStatus.Value, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.ParameterOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ComputerName), out propertyOverride);
            if (Optional.IsDefined(ComputerName) || hasPropertyOverride)
            {
                builder.Append("  computerName: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
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
            if (Optional.IsDefined(OSName) || hasPropertyOverride)
            {
                builder.Append("  osName: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
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
            if (Optional.IsDefined(OSVersion) || hasPropertyOverride)
            {
                builder.Append("  osVersion: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
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
            if (Optional.IsDefined(HyperVGeneration) || hasPropertyOverride)
            {
                builder.Append("  hyperVGeneration: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{HyperVGeneration.Value.ToString()}'");
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
                    AppendChildObject(builder, VmAgent, options, 2, false, "  vmAgent: ");
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
                    AppendChildObject(builder, MaintenanceRedeployStatus, options, 2, false, "  maintenanceRedeployStatus: ");
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
                            AppendChildObject(builder, item, options, 4, true, "  disks: ");
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
                            AppendChildObject(builder, item, options, 4, true, "  extensions: ");
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
                    AppendChildObject(builder, VmHealth, options, 2, false, "  vmHealth: ");
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
                    AppendChildObject(builder, BootDiagnostics, options, 2, false, "  bootDiagnostics: ");
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
                            AppendChildObject(builder, item, options, 4, true, "  statuses: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PatchStatus), out propertyOverride);
            if (Optional.IsDefined(PatchStatus) || hasPropertyOverride)
            {
                builder.Append("  patchStatus: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, PatchStatus, options, 2, false, "  patchStatus: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine, string formattedPropertyName)
        {
            string indent = new string(' ', spaces);
            int emptyObjectLength = 2 + spaces + Environment.NewLine.Length + Environment.NewLine.Length;
            int length = stringBuilder.Length;
            bool inMultilineString = false;

            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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
                    stringBuilder.AppendLine($"{line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
            if (stringBuilder.Length == length + emptyObjectLength)
            {
                stringBuilder.Length = stringBuilder.Length - emptyObjectLength - formattedPropertyName.Length;
            }
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
                    throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support '{options.Format}' format.");
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
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineInstanceView)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
