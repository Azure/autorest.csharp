// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    public partial class VirtualMachineScaleSetVmData : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineScaleSetVmData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineScaleSetVmData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineScaleSetVmData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(InstanceId))
            {
                writer.WritePropertyName("instanceId"u8);
                writer.WriteStringValue(InstanceId);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteObjectValue(Sku);
            }
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan"u8);
                writer.WriteObjectValue(Plan);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(Resources))
            {
                writer.WritePropertyName("resources"u8);
                writer.WriteStartArray();
                foreach (var item in Resources)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(Zones))
            {
                writer.WritePropertyName("zones"u8);
                writer.WriteStartArray();
                foreach (var item in Zones)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(SystemData))
            {
                writer.WritePropertyName("systemData"u8);
                JsonSerializer.Serialize(writer, SystemData);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(LatestModelApplied))
                {
                    writer.WritePropertyName("latestModelApplied"u8);
                    writer.WriteBooleanValue(LatestModelApplied.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(VmId))
                {
                    writer.WritePropertyName("vmId"u8);
                    writer.WriteStringValue(VmId);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(InstanceView))
                {
                    writer.WritePropertyName("instanceView"u8);
                    writer.WriteObjectValue(InstanceView);
                }
                if (Optional.IsDefined(HardwareProfile))
                {
                    writer.WritePropertyName("hardwareProfile"u8);
                    writer.WriteObjectValue(HardwareProfile);
                }
                if (Optional.IsDefined(StorageProfile))
                {
                    writer.WritePropertyName("storageProfile"u8);
                    writer.WriteObjectValue(StorageProfile);
                }
                if (Optional.IsDefined(AdditionalCapabilities))
                {
                    writer.WritePropertyName("additionalCapabilities"u8);
                    writer.WriteObjectValue(AdditionalCapabilities);
                }
                if (Optional.IsDefined(OSProfile))
                {
                    writer.WritePropertyName("osProfile"u8);
                    writer.WriteObjectValue(OSProfile);
                }
                if (Optional.IsDefined(SecurityProfile))
                {
                    writer.WritePropertyName("securityProfile"u8);
                    writer.WriteObjectValue(SecurityProfile);
                }
                if (Optional.IsDefined(NetworkProfile))
                {
                    writer.WritePropertyName("networkProfile"u8);
                    writer.WriteObjectValue(NetworkProfile);
                }
                if (Optional.IsDefined(NetworkProfileConfiguration))
                {
                    writer.WritePropertyName("networkProfileConfiguration"u8);
                    writer.WriteObjectValue(NetworkProfileConfiguration);
                }
                if (Optional.IsDefined(DiagnosticsProfile))
                {
                    writer.WritePropertyName("diagnosticsProfile"u8);
                    writer.WriteObjectValue(DiagnosticsProfile);
                }
                if (Optional.IsDefined(AvailabilitySet))
                {
                    writer.WritePropertyName("availabilitySet"u8);
                    JsonSerializer.Serialize(writer, AvailabilitySet);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState);
                }
                if (Optional.IsDefined(LicenseType))
                {
                    writer.WritePropertyName("licenseType"u8);
                    writer.WriteStringValue(LicenseType);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ModelDefinitionApplied))
                {
                    writer.WritePropertyName("modelDefinitionApplied"u8);
                    writer.WriteStringValue(ModelDefinitionApplied);
                }
                if (Optional.IsDefined(ProtectionPolicy))
                {
                    writer.WritePropertyName("protectionPolicy"u8);
                    writer.WriteObjectValue(ProtectionPolicy);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        VirtualMachineScaleSetVmData IModelJsonSerializable<VirtualMachineScaleSetVmData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetVmData(document.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineScaleSetVmData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineScaleSetVmData IModelSerializable<VirtualMachineScaleSetVmData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetVmData(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetVmData DeserializeVirtualMachineScaleSetVmData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> instanceId = default;
            Optional<SampleSku> sku = default;
            Optional<SamplePlan> plan = default;
            Optional<IReadOnlyList<VirtualMachineExtensionData>> resources = default;
            Optional<IReadOnlyList<string>> zones = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<bool> latestModelApplied = default;
            Optional<string> vmId = default;
            Optional<VirtualMachineScaleSetVmInstanceView> instanceView = default;
            Optional<HardwareProfile> hardwareProfile = default;
            Optional<StorageProfile> storageProfile = default;
            Optional<AdditionalCapabilities> additionalCapabilities = default;
            Optional<OSProfile> osProfile = default;
            Optional<SecurityProfile> securityProfile = default;
            Optional<NetworkProfile> networkProfile = default;
            Optional<VirtualMachineScaleSetVmNetworkProfileConfiguration> networkProfileConfiguration = default;
            Optional<DiagnosticsProfile> diagnosticsProfile = default;
            Optional<WritableSubResource> availabilitySet = default;
            Optional<string> provisioningState = default;
            Optional<string> licenseType = default;
            Optional<string> modelDefinitionApplied = default;
            Optional<VirtualMachineScaleSetVmProtectionPolicy> protectionPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("instanceId"u8))
                {
                    instanceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = SampleSku.DeserializeSampleSku(property.Value);
                    continue;
                }
                if (property.NameEquals("plan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    plan = SamplePlan.DeserializeSamplePlan(property.Value);
                    continue;
                }
                if (property.NameEquals("resources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineExtensionData> array = new List<VirtualMachineExtensionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(item));
                    }
                    resources = array;
                    continue;
                }
                if (property.NameEquals("zones"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    zones = array;
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
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("latestModelApplied"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            latestModelApplied = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("vmId"u8))
                        {
                            vmId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceView"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            instanceView = VirtualMachineScaleSetVmInstanceView.DeserializeVirtualMachineScaleSetVmInstanceView(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("hardwareProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hardwareProfile = HardwareProfile.DeserializeHardwareProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("storageProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            storageProfile = StorageProfile.DeserializeStorageProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("additionalCapabilities"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            additionalCapabilities = AdditionalCapabilities.DeserializeAdditionalCapabilities(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("osProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            osProfile = OSProfile.DeserializeOSProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("securityProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            securityProfile = SecurityProfile.DeserializeSecurityProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("networkProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkProfile = NetworkProfile.DeserializeNetworkProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("networkProfileConfiguration"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkProfileConfiguration = VirtualMachineScaleSetVmNetworkProfileConfiguration.DeserializeVirtualMachineScaleSetVmNetworkProfileConfiguration(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("diagnosticsProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            diagnosticsProfile = DiagnosticsProfile.DeserializeDiagnosticsProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("availabilitySet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            availabilitySet = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("licenseType"u8))
                        {
                            licenseType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("modelDefinitionApplied"u8))
                        {
                            modelDefinitionApplied = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("protectionPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protectionPolicy = VirtualMachineScaleSetVmProtectionPolicy.DeserializeVirtualMachineScaleSetVmProtectionPolicy(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new VirtualMachineScaleSetVmData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, instanceId.Value, sku.Value, plan.Value, Optional.ToList(resources), Optional.ToList(zones), Optional.ToNullable(latestModelApplied), vmId.Value, instanceView.Value, hardwareProfile.Value, storageProfile.Value, additionalCapabilities.Value, osProfile.Value, securityProfile.Value, networkProfile.Value, networkProfileConfiguration.Value, diagnosticsProfile.Value, availabilitySet, provisioningState.Value, licenseType.Value, modelDefinitionApplied.Value, protectionPolicy.Value);
        }
    }
}
