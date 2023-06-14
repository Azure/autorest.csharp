// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtPropertyChooser.Models;

namespace MgmtPropertyChooser
{
    public partial class VirtualMachineData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan"u8);
                JsonSerializer.Serialize(writer, Plan);
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                JsonSerializer.Serialize(writer, Identity);
            }
            if (Optional.IsDefined(IdentityWithRenamedProperty))
            {
                writer.WritePropertyName("identityWithRenamedProperty"u8);
                writer.WriteObjectValue(IdentityWithRenamedProperty);
            }
            if (Optional.IsDefined(IdentityWithDifferentPropertyType))
            {
                writer.WritePropertyName("identityWithDifferentPropertyType"u8);
                writer.WriteObjectValue(IdentityWithDifferentPropertyType);
            }
            if (Optional.IsDefined(IdentityWithNoUserIdentity))
            {
                writer.WritePropertyName("identityWithNoUserIdentity"u8);
                JsonSerializer.Serialize(writer, IdentityWithNoUserIdentity);
            }
            if (Optional.IsDefined(IdentityWithNoSystemIdentity))
            {
                writer.WritePropertyName("identityWithNoSystemIdentity"u8);
                writer.WriteObjectValue(IdentityWithNoSystemIdentity);
            }
            if (Optional.IsDefined(IdentityV3))
            {
                writer.WritePropertyName("identityV3"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, IdentityV3, serializeOptions);
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
            if (Optional.IsDefined(FakeSubResource))
            {
                writer.WritePropertyName("fakeSubResource"u8);
                JsonSerializer.Serialize(writer, FakeSubResource);
            }
            if (Optional.IsDefined(FakeWritableSubResource))
            {
                writer.WritePropertyName("fakeWritableSubResource"u8);
                JsonSerializer.Serialize(writer, FakeWritableSubResource);
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
            writer.WriteEndObject();
        }

        internal static VirtualMachineData DeserializeVirtualMachineData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ArmPlan> plan = default;
            Optional<IReadOnlyList<VirtualMachineExtension>> resources = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<IdentityWithRenamedProperty> identityWithRenamedProperty = default;
            Optional<IdentityWithDifferentPropertyType> identityWithDifferentPropertyType = default;
            Optional<ManagedServiceIdentity> identityWithNoUserIdentity = default;
            Optional<IdentityWithNoSystemIdentity> identityWithNoSystemIdentity = default;
            Optional<ManagedServiceIdentity> identityV3 = default;
            Optional<IList<string>> zones = default;
            Optional<IReadOnlyList<MgmtPropertyChooserResourceData>> fakeResources = default;
            Optional<SubResource> fakeSubResource = default;
            Optional<WritableSubResource> fakeWritableSubResource = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> provisioningState = default;
            Optional<string> licenseType = default;
            Optional<string> vmId = default;
            Optional<string> extensionsTimeBudget = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("plan"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    plan = JsonSerializer.Deserialize<ArmPlan>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("resources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineExtension> array = new List<VirtualMachineExtension>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtension.DeserializeVirtualMachineExtension(item));
                    }
                    resources = array;
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
                if (property.NameEquals("identityWithRenamedProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identityWithRenamedProperty = IdentityWithRenamedProperty.DeserializeIdentityWithRenamedProperty(property.Value);
                    continue;
                }
                if (property.NameEquals("identityWithDifferentPropertyType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identityWithDifferentPropertyType = IdentityWithDifferentPropertyType.DeserializeIdentityWithDifferentPropertyType(property.Value);
                    continue;
                }
                if (property.NameEquals("identityWithNoUserIdentity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identityWithNoUserIdentity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("identityWithNoSystemIdentity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identityWithNoSystemIdentity = IdentityWithNoSystemIdentity.DeserializeIdentityWithNoSystemIdentity(property.Value);
                    continue;
                }
                if (property.NameEquals("identityV3"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                    identityV3 = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
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
                if (property.NameEquals("fakeResources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MgmtPropertyChooserResourceData> array = new List<MgmtPropertyChooserResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MgmtPropertyChooserResourceData.DeserializeMgmtPropertyChooserResourceData(item));
                    }
                    fakeResources = array;
                    continue;
                }
                if (property.NameEquals("fakeSubResource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fakeSubResource = JsonSerializer.Deserialize<SubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("fakeWritableSubResource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fakeWritableSubResource = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
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
            }
            return new VirtualMachineData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, plan, Optional.ToList(resources), identity, identityWithRenamedProperty.Value, identityWithDifferentPropertyType.Value, identityWithNoUserIdentity, identityWithNoSystemIdentity.Value, identityV3, Optional.ToList(zones), Optional.ToList(fakeResources), fakeSubResource, fakeWritableSubResource, provisioningState.Value, licenseType.Value, vmId.Value, extensionsTimeBudget.Value);
        }
    }
}
