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
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetVmProfile : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetVmProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetVmProfile>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineScaleSetVmProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmProfile)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(OSProfile))
            {
                writer.WritePropertyName("osProfile"u8);
                writer.WriteObjectValue(OSProfile);
            }
            if (Optional.IsDefined(StorageProfile))
            {
                writer.WritePropertyName("storageProfile"u8);
                writer.WriteObjectValue(StorageProfile);
            }
            if (Optional.IsDefined(NetworkProfile))
            {
                writer.WritePropertyName("networkProfile"u8);
                writer.WriteObjectValue(NetworkProfile);
            }
            if (Optional.IsDefined(SecurityProfile))
            {
                writer.WritePropertyName("securityProfile"u8);
                writer.WriteObjectValue(SecurityProfile);
            }
            if (Optional.IsDefined(DiagnosticsProfile))
            {
                writer.WritePropertyName("diagnosticsProfile"u8);
                writer.WriteObjectValue(DiagnosticsProfile);
            }
            if (Optional.IsDefined(ExtensionProfile))
            {
                writer.WritePropertyName("extensionProfile"u8);
                writer.WriteObjectValue(ExtensionProfile);
            }
            if (Optional.IsDefined(LicenseType))
            {
                writer.WritePropertyName("licenseType"u8);
                writer.WriteStringValue(LicenseType);
            }
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteStringValue(Priority.Value.ToString());
            }
            if (Optional.IsDefined(EvictionPolicy))
            {
                writer.WritePropertyName("evictionPolicy"u8);
                writer.WriteStringValue(EvictionPolicy.Value.ToString());
            }
            if (Optional.IsDefined(BillingProfile))
            {
                writer.WritePropertyName("billingProfile"u8);
                writer.WriteObjectValue(BillingProfile);
            }
            if (Optional.IsDefined(ScheduledEventsProfile))
            {
                writer.WritePropertyName("scheduledEventsProfile"u8);
                writer.WriteObjectValue(ScheduledEventsProfile);
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

        VirtualMachineScaleSetVmProfile IJsonModel<VirtualMachineScaleSetVmProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmProfile)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetVmProfile(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetVmProfile DeserializeVirtualMachineScaleSetVmProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<VirtualMachineScaleSetOSProfile> osProfile = default;
            Optional<VirtualMachineScaleSetStorageProfile> storageProfile = default;
            Optional<VirtualMachineScaleSetNetworkProfile> networkProfile = default;
            Optional<SecurityProfile> securityProfile = default;
            Optional<DiagnosticsProfile> diagnosticsProfile = default;
            Optional<VirtualMachineScaleSetExtensionProfile> extensionProfile = default;
            Optional<string> licenseType = default;
            Optional<VirtualMachinePriorityType> priority = default;
            Optional<VirtualMachineEvictionPolicyType> evictionPolicy = default;
            Optional<BillingProfile> billingProfile = default;
            Optional<ScheduledEventsProfile> scheduledEventsProfile = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("osProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osProfile = VirtualMachineScaleSetOSProfile.DeserializeVirtualMachineScaleSetOSProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("storageProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageProfile = VirtualMachineScaleSetStorageProfile.DeserializeVirtualMachineScaleSetStorageProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("networkProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkProfile = VirtualMachineScaleSetNetworkProfile.DeserializeVirtualMachineScaleSetNetworkProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("securityProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    securityProfile = SecurityProfile.DeserializeSecurityProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("diagnosticsProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diagnosticsProfile = DiagnosticsProfile.DeserializeDiagnosticsProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("extensionProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    extensionProfile = VirtualMachineScaleSetExtensionProfile.DeserializeVirtualMachineScaleSetExtensionProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("licenseType"u8))
                {
                    licenseType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    priority = new VirtualMachinePriorityType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("evictionPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    evictionPolicy = new VirtualMachineEvictionPolicyType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("billingProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    billingProfile = BillingProfile.DeserializeBillingProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("scheduledEventsProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    scheduledEventsProfile = ScheduledEventsProfile.DeserializeScheduledEventsProfile(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetVmProfile(osProfile.Value, storageProfile.Value, networkProfile.Value, securityProfile.Value, diagnosticsProfile.Value, extensionProfile.Value, licenseType.Value, Optional.ToNullable(priority), Optional.ToNullable(evictionPolicy), billingProfile.Value, scheduledEventsProfile.Value, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OSProfile), out propertyOverride);
            if (Optional.IsDefined(OSProfile) || hasPropertyOverride)
            {
                builder.Append("  osProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, OSProfile, options, 2, false, "  osProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(StorageProfile), out propertyOverride);
            if (Optional.IsDefined(StorageProfile) || hasPropertyOverride)
            {
                builder.Append("  storageProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, StorageProfile, options, 2, false, "  storageProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(NetworkProfile), out propertyOverride);
            if (Optional.IsDefined(NetworkProfile) || hasPropertyOverride)
            {
                builder.Append("  networkProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, NetworkProfile, options, 2, false, "  networkProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SecurityProfile), out propertyOverride);
            if (Optional.IsDefined(SecurityProfile) || hasPropertyOverride)
            {
                builder.Append("  securityProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, SecurityProfile, options, 2, false, "  securityProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DiagnosticsProfile), out propertyOverride);
            if (Optional.IsDefined(DiagnosticsProfile) || hasPropertyOverride)
            {
                builder.Append("  diagnosticsProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, DiagnosticsProfile, options, 2, false, "  diagnosticsProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ExtensionProfile), out propertyOverride);
            if (Optional.IsDefined(ExtensionProfile) || hasPropertyOverride)
            {
                builder.Append("  extensionProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, ExtensionProfile, options, 2, false, "  extensionProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LicenseType), out propertyOverride);
            if (Optional.IsDefined(LicenseType) || hasPropertyOverride)
            {
                builder.Append("  licenseType: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (LicenseType.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{LicenseType}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{LicenseType}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Priority), out propertyOverride);
            if (Optional.IsDefined(Priority) || hasPropertyOverride)
            {
                builder.Append("  priority: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{Priority.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(EvictionPolicy), out propertyOverride);
            if (Optional.IsDefined(EvictionPolicy) || hasPropertyOverride)
            {
                builder.Append("  evictionPolicy: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{EvictionPolicy.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(BillingProfile), out propertyOverride);
            if (Optional.IsDefined(BillingProfile) || hasPropertyOverride)
            {
                builder.Append("  billingProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, BillingProfile, options, 2, false, "  billingProfile: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ScheduledEventsProfile), out propertyOverride);
            if (Optional.IsDefined(ScheduledEventsProfile) || hasPropertyOverride)
            {
                builder.Append("  scheduledEventsProfile: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    AppendChildObject(builder, ScheduledEventsProfile, options, 2, false, "  scheduledEventsProfile: ");
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

        BinaryData IPersistableModel<VirtualMachineScaleSetVmProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmProfile)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetVmProfile IPersistableModel<VirtualMachineScaleSetVmProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetVmProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineScaleSetVmProfile(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetVmProfile)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetVmProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
