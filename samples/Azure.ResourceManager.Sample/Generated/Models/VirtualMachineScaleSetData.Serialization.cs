// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    public partial class VirtualMachineScaleSetData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteObjectValue(Sku);
            }
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan"u8);
                writer.WriteObjectValue(Plan);
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
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(UpgradePolicy))
            {
                writer.WritePropertyName("upgradePolicy"u8);
                writer.WriteObjectValue(UpgradePolicy);
            }
            if (Optional.IsDefined(AutomaticRepairsPolicy))
            {
                writer.WritePropertyName("automaticRepairsPolicy"u8);
                writer.WriteObjectValue(AutomaticRepairsPolicy);
            }
            if (Optional.IsDefined(VirtualMachineProfile))
            {
                writer.WritePropertyName("virtualMachineProfile"u8);
                writer.WriteObjectValue(VirtualMachineProfile);
            }
            if (Optional.IsDefined(Overprovision))
            {
                writer.WritePropertyName("overprovision"u8);
                writer.WriteBooleanValue(Overprovision.Value);
            }
            if (Optional.IsDefined(DoNotRunExtensionsOnOverprovisionedVMs))
            {
                writer.WritePropertyName("doNotRunExtensionsOnOverprovisionedVMs"u8);
                writer.WriteBooleanValue(DoNotRunExtensionsOnOverprovisionedVMs.Value);
            }
            if (Optional.IsDefined(SinglePlacementGroup))
            {
                writer.WritePropertyName("singlePlacementGroup"u8);
                writer.WriteBooleanValue(SinglePlacementGroup.Value);
            }
            if (Optional.IsDefined(ZoneBalance))
            {
                writer.WritePropertyName("zoneBalance"u8);
                writer.WriteBooleanValue(ZoneBalance.Value);
            }
            if (Optional.IsDefined(PlatformFaultDomainCount))
            {
                writer.WritePropertyName("platformFaultDomainCount"u8);
                writer.WriteNumberValue(PlatformFaultDomainCount.Value);
            }
            if (Optional.IsDefined(ProximityPlacementGroup))
            {
                writer.WritePropertyName("proximityPlacementGroup"u8);
                JsonSerializer.Serialize(writer, ProximityPlacementGroup);
            }
            if (Optional.IsDefined(HostGroup))
            {
                writer.WritePropertyName("hostGroup"u8);
                JsonSerializer.Serialize(writer, HostGroup);
            }
            if (Optional.IsDefined(AdditionalCapabilities))
            {
                writer.WritePropertyName("additionalCapabilities"u8);
                writer.WriteObjectValue(AdditionalCapabilities);
            }
            if (Optional.IsDefined(ScaleInPolicy))
            {
                writer.WritePropertyName("scaleInPolicy"u8);
                writer.WriteObjectValue(ScaleInPolicy);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetData DeserializeVirtualMachineScaleSetData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SampleSku> sku = default;
            Optional<SamplePlan> plan = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<IList<string>> zones = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<UpgradePolicy> upgradePolicy = default;
            Optional<AutomaticRepairsPolicy> automaticRepairsPolicy = default;
            Optional<VirtualMachineScaleSetVMProfile> virtualMachineProfile = default;
            Optional<string> provisioningState = default;
            Optional<bool> overprovision = default;
            Optional<bool> doNotRunExtensionsOnOverprovisionedVMs = default;
            Optional<string> uniqueId = default;
            Optional<bool> singlePlacementGroup = default;
            Optional<bool> zoneBalance = default;
            Optional<int> platformFaultDomainCount = default;
            Optional<WritableSubResource> proximityPlacementGroup = default;
            Optional<WritableSubResource> hostGroup = default;
            Optional<AdditionalCapabilities> additionalCapabilities = default;
            Optional<ScaleInPolicy> scaleInPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
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
                        if (property0.NameEquals("upgradePolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            upgradePolicy = UpgradePolicy.DeserializeUpgradePolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("automaticRepairsPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            automaticRepairsPolicy = AutomaticRepairsPolicy.DeserializeAutomaticRepairsPolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("virtualMachineProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            virtualMachineProfile = VirtualMachineScaleSetVMProfile.DeserializeVirtualMachineScaleSetVMProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("overprovision"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            overprovision = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("doNotRunExtensionsOnOverprovisionedVMs"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            doNotRunExtensionsOnOverprovisionedVMs = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("uniqueId"u8))
                        {
                            uniqueId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("singlePlacementGroup"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            singlePlacementGroup = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("zoneBalance"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            zoneBalance = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("platformFaultDomainCount"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            platformFaultDomainCount = property0.Value.GetInt32();
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
                        if (property0.NameEquals("hostGroup"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            hostGroup = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
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
                        if (property0.NameEquals("scaleInPolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            scaleInPolicy = ScaleInPolicy.DeserializeScaleInPolicy(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new VirtualMachineScaleSetData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, sku.Value, plan.Value, identity, Optional.ToList(zones), upgradePolicy.Value, automaticRepairsPolicy.Value, virtualMachineProfile.Value, provisioningState.Value, Optional.ToNullable(overprovision), Optional.ToNullable(doNotRunExtensionsOnOverprovisionedVMs), uniqueId.Value, Optional.ToNullable(singlePlacementGroup), Optional.ToNullable(zoneBalance), Optional.ToNullable(platformFaultDomainCount), proximityPlacementGroup, hostGroup, additionalCapabilities.Value, scaleInPolicy.Value);
        }
    }
}
