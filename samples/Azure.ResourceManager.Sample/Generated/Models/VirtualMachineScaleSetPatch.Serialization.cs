// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetPatch : IUtf8JsonSerializable
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
            if (Optional.IsDefined(ProximityPlacementGroup))
            {
                writer.WritePropertyName("proximityPlacementGroup"u8);
                JsonSerializer.Serialize(writer, ProximityPlacementGroup);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
