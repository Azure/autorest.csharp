// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachinePatch : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachinePatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachinePatch>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachinePatch>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachinePatch>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan"u8);
                ((IModelJsonSerializable<MgmtRenameRulesPlan>)Plan).Serialize(writer, options);
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                JsonSerializer.Serialize(writer, Identity);
            }
            if (Optional.IsCollectionDefined(Zones))
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
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(HardwareProfile))
            {
                writer.WritePropertyName("hardwareProfile"u8);
                ((IModelJsonSerializable<HardwareProfile>)HardwareProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(StorageProfile))
            {
                writer.WritePropertyName("storageProfile"u8);
                ((IModelJsonSerializable<StorageProfile>)StorageProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(AdditionalCapabilities))
            {
                writer.WritePropertyName("additionalCapabilities"u8);
                ((IModelJsonSerializable<AdditionalCapabilities>)AdditionalCapabilities).Serialize(writer, options);
            }
            if (Optional.IsDefined(OSProfile))
            {
                writer.WritePropertyName("osProfile"u8);
                ((IModelJsonSerializable<OSProfile>)OSProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(NetworkProfile))
            {
                writer.WritePropertyName("networkProfile"u8);
                ((IModelJsonSerializable<NetworkProfile>)NetworkProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(SecurityProfile))
            {
                writer.WritePropertyName("securityProfile"u8);
                ((IModelJsonSerializable<SecurityProfile>)SecurityProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(DiagnosticsProfile))
            {
                writer.WritePropertyName("diagnosticsProfile"u8);
                ((IModelJsonSerializable<DiagnosticsProfile>)DiagnosticsProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(AvailabilitySet))
            {
                writer.WritePropertyName("availabilitySet"u8);
                JsonSerializer.Serialize(writer, AvailabilitySet);
            }
            if (Optional.IsDefined(VirtualMachineScaleSet))
            {
                writer.WritePropertyName("virtualMachineScaleSet"u8);
                JsonSerializer.Serialize(writer, VirtualMachineScaleSet);
            }
            if (Optional.IsDefined(ProximityPlacementGroup))
            {
                writer.WritePropertyName("proximityPlacementGroup"u8);
                JsonSerializer.Serialize(writer, ProximityPlacementGroup);
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
                ((IModelJsonSerializable<BillingProfile>)BillingProfile).Serialize(writer, options);
            }
            if (Optional.IsDefined(Host))
            {
                writer.WritePropertyName("host"u8);
                JsonSerializer.Serialize(writer, Host);
            }
            if (Optional.IsDefined(HostGroup))
            {
                writer.WritePropertyName("hostGroup"u8);
                JsonSerializer.Serialize(writer, HostGroup);
            }
            if (Optional.IsDefined(LicenseType))
            {
                writer.WritePropertyName("licenseType"u8);
                writer.WriteStringValue(LicenseType);
            }
            if (Optional.IsDefined(ExtensionsTimeBudget))
            {
                writer.WritePropertyName("extensionsTimeBudget"u8);
                writer.WriteStringValue(ExtensionsTimeBudget);
            }
            writer.WriteEndObject();
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachinePatch DeserializeVirtualMachinePatch(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<MgmtRenameRulesPlan> plan = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<IList<string>> zones = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<HardwareProfile> hardwareProfile = default;
            Optional<StorageProfile> storageProfile = default;
            Optional<AdditionalCapabilities> additionalCapabilities = default;
            Optional<OSProfile> osProfile = default;
            Optional<NetworkProfile> networkProfile = default;
            Optional<SecurityProfile> securityProfile = default;
            Optional<DiagnosticsProfile> diagnosticsProfile = default;
            Optional<WritableSubResource> availabilitySet = default;
            Optional<WritableSubResource> virtualMachineScaleSet = default;
            Optional<WritableSubResource> proximityPlacementGroup = default;
            Optional<VirtualMachinePriorityType> priority = default;
            Optional<VirtualMachineEvictionPolicyType> evictionPolicy = default;
            Optional<BillingProfile> billingProfile = default;
            Optional<WritableSubResource> host = default;
            Optional<WritableSubResource> hostGroup = default;
            Optional<string> provisioningState = default;
            Optional<VirtualMachineInstanceView> instanceView = default;
            Optional<string> licenseType = default;
            Optional<string> vmId = default;
            Optional<string> extensionsTimeBudget = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("plan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    plan = MgmtRenameRulesPlan.DeserializeMgmtRenameRulesPlan(property.Value);
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText());
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
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
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
                        if (property0.NameEquals("networkProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkProfile = NetworkProfile.DeserializeNetworkProfile(property0.Value);
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
                        if (property0.NameEquals("virtualMachineScaleSet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            virtualMachineScaleSet = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("proximityPlacementGroup"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            proximityPlacementGroup = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("priority"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            priority = new VirtualMachinePriorityType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("evictionPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            evictionPolicy = new VirtualMachineEvictionPolicyType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("billingProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            billingProfile = BillingProfile.DeserializeBillingProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("host"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            host = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("hostGroup"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hostGroup = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceView"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            instanceView = VirtualMachineInstanceView.DeserializeVirtualMachineInstanceView(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("licenseType"u8))
                        {
                            licenseType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("vmId"u8))
                        {
                            vmId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("extensionsTimeBudget"u8))
                        {
                            extensionsTimeBudget = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachinePatch(Optional.ToDictionary(tags), plan.Value, identity, Optional.ToList(zones), hardwareProfile.Value, storageProfile.Value, additionalCapabilities.Value, osProfile.Value, networkProfile.Value, securityProfile.Value, diagnosticsProfile.Value, availabilitySet, virtualMachineScaleSet, proximityPlacementGroup, Optional.ToNullable(priority), Optional.ToNullable(evictionPolicy), billingProfile.Value, host, hostGroup, provisioningState.Value, instanceView.Value, licenseType.Value, vmId.Value, extensionsTimeBudget.Value, rawData);
        }

        VirtualMachinePatch IModelJsonSerializable<VirtualMachinePatch>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachinePatch>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachinePatch(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachinePatch>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachinePatch>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachinePatch IModelSerializable<VirtualMachinePatch>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachinePatch>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachinePatch(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VirtualMachinePatch"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VirtualMachinePatch"/> to convert. </param>
        public static implicit operator RequestContent(VirtualMachinePatch model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VirtualMachinePatch"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VirtualMachinePatch(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachinePatch(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
