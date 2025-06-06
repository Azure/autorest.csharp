// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetUpdateVmProfile : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetUpdateVmProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetUpdateVmProfile>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineScaleSetUpdateVmProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetUpdateVmProfile)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(OSProfile))
            {
                writer.WritePropertyName("osProfile"u8);
                writer.WriteObjectValue(OSProfile, options);
            }
            if (Optional.IsDefined(StorageProfile))
            {
                writer.WritePropertyName("storageProfile"u8);
                writer.WriteObjectValue(StorageProfile, options);
            }
            if (Optional.IsDefined(NetworkProfile))
            {
                writer.WritePropertyName("networkProfile"u8);
                writer.WriteObjectValue(NetworkProfile, options);
            }
            if (Optional.IsDefined(SecurityProfile))
            {
                writer.WritePropertyName("securityProfile"u8);
                writer.WriteObjectValue(SecurityProfile, options);
            }
            if (Optional.IsDefined(DiagnosticsProfile))
            {
                writer.WritePropertyName("diagnosticsProfile"u8);
                writer.WriteObjectValue(DiagnosticsProfile, options);
            }
            if (Optional.IsDefined(ExtensionProfile))
            {
                writer.WritePropertyName("extensionProfile"u8);
                writer.WriteObjectValue(ExtensionProfile, options);
            }
            if (Optional.IsDefined(LicenseType))
            {
                writer.WritePropertyName("licenseType"u8);
                writer.WriteStringValue(LicenseType);
            }
            if (Optional.IsDefined(BillingProfile))
            {
                writer.WritePropertyName("billingProfile"u8);
                writer.WriteObjectValue(BillingProfile, options);
            }
            if (Optional.IsDefined(ScheduledEventsProfile))
            {
                writer.WritePropertyName("scheduledEventsProfile"u8);
                writer.WriteObjectValue(ScheduledEventsProfile, options);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        VirtualMachineScaleSetUpdateVmProfile IJsonModel<VirtualMachineScaleSetUpdateVmProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetUpdateVmProfile)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetUpdateVmProfile(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetUpdateVmProfile DeserializeVirtualMachineScaleSetUpdateVmProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            VirtualMachineScaleSetUpdateOSProfile osProfile = default;
            VirtualMachineScaleSetUpdateStorageProfile storageProfile = default;
            VirtualMachineScaleSetUpdateNetworkProfile networkProfile = default;
            SecurityProfile securityProfile = default;
            DiagnosticsProfile diagnosticsProfile = default;
            VirtualMachineScaleSetExtensionProfile extensionProfile = default;
            string licenseType = default;
            BillingProfile billingProfile = default;
            ScheduledEventsProfile scheduledEventsProfile = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("osProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osProfile = VirtualMachineScaleSetUpdateOSProfile.DeserializeVirtualMachineScaleSetUpdateOSProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("storageProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageProfile = VirtualMachineScaleSetUpdateStorageProfile.DeserializeVirtualMachineScaleSetUpdateStorageProfile(property.Value, options);
                    continue;
                }
                if (property.NameEquals("networkProfile"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkProfile = VirtualMachineScaleSetUpdateNetworkProfile.DeserializeVirtualMachineScaleSetUpdateNetworkProfile(property.Value, options);
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
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineScaleSetUpdateVmProfile(
                osProfile,
                storageProfile,
                networkProfile,
                securityProfile,
                diagnosticsProfile,
                extensionProfile,
                licenseType,
                billingProfile,
                scheduledEventsProfile,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureSampleResourceManagerSampleContext.Default);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetUpdateVmProfile)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetUpdateVmProfile IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeVirtualMachineScaleSetUpdateVmProfile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetUpdateVmProfile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetUpdateVmProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
