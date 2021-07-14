// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace MgmtPropertyChooser
{
    public partial class VirtualMachineData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Plan))
            {
                writer.WritePropertyName("plan");
                writer.WriteObjectValue(Plan);
            }
            if (Optional.IsDefined(ResourceIdentity))
            {
                writer.WritePropertyName("identity");
                JsonSerializer.Serialize(writer, ResourceIdentity);
            }
            if (Optional.IsDefined(IdentityWithRenamedProperty))
            {
                writer.WritePropertyName("identityWithRenamedProperty");
                writer.WriteObjectValue(IdentityWithRenamedProperty);
            }
            if (Optional.IsDefined(IdentityWithDifferentPropertyType))
            {
                writer.WritePropertyName("identityWithDifferentPropertyType");
                writer.WriteObjectValue(IdentityWithDifferentPropertyType);
            }
            if (Optional.IsDefined(IdentityWithNoUserIdentity))
            {
                writer.WritePropertyName("identityWithNoUserIdentity");
                writer.WriteObjectValue(IdentityWithNoUserIdentity);
            }
            if (Optional.IsDefined(IdentityWithNoSystemIdentity))
            {
                writer.WritePropertyName("identityWithNoSystemIdentity");
                writer.WriteObjectValue(IdentityWithNoSystemIdentity);
            }
            if (Optional.IsCollectionDefined(Zones))
            {
                writer.WritePropertyName("zones");
                writer.WriteStartArray();
                foreach (var item in Zones)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("tags");
            writer.WriteStartObject();
            foreach (var item in Tags)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(LicenseType))
            {
                writer.WritePropertyName("licenseType");
                writer.WriteStringValue(LicenseType);
            }
            if (Optional.IsDefined(ExtensionsTimeBudget))
            {
                writer.WritePropertyName("extensionsTimeBudget");
                writer.WriteStringValue(ExtensionsTimeBudget);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static VirtualMachineData DeserializeVirtualMachineData(JsonElement element)
        {
            Optional<Plan> plan = default;
            Optional<IReadOnlyList<VirtualMachineExtension>> resources = default;
            Optional<ResourceIdentity> identity = default;
            Optional<IdentityWithRenamedProperty> identityWithRenamedProperty = default;
            Optional<IdentityWithDifferentPropertyType> identityWithDifferentPropertyType = default;
            Optional<IdentityWithNoUserIdentity> identityWithNoUserIdentity = default;
            Optional<IdentityWithNoSystemIdentity> identityWithNoSystemIdentity = default;
            Optional<IList<string>> zones = default;
            IDictionary<string, string> tags = default;
            Location location = default;
            ResourceGroupResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<string> provisioningState = default;
            Optional<string> licenseType = default;
            Optional<string> vmId = default;
            Optional<string> extensionsTimeBudget = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("plan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    plan = Plan.DeserializePlan(property.Value);
                    continue;
                }
                if (property.NameEquals("resources"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("identity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identity = JsonSerializer.Deserialize<ResourceIdentity>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("identityWithRenamedProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identityWithRenamedProperty = IdentityWithRenamedProperty.DeserializeIdentityWithRenamedProperty(property.Value);
                    continue;
                }
                if (property.NameEquals("identityWithDifferentPropertyType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identityWithDifferentPropertyType = IdentityWithDifferentPropertyType.DeserializeIdentityWithDifferentPropertyType(property.Value);
                    continue;
                }
                if (property.NameEquals("identityWithNoUserIdentity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identityWithNoUserIdentity = IdentityWithNoUserIdentity.DeserializeIdentityWithNoUserIdentity(property.Value);
                    continue;
                }
                if (property.NameEquals("identityWithNoSystemIdentity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identityWithNoSystemIdentity = IdentityWithNoSystemIdentity.DeserializeIdentityWithNoSystemIdentity(property.Value);
                    continue;
                }
                if (property.NameEquals("zones"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("tags"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("provisioningState"))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("licenseType"))
                        {
                            licenseType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("vmId"))
                        {
                            vmId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("extensionsTimeBudget"))
                        {
                            extensionsTimeBudget = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new VirtualMachineData(id, name, type, location, tags, plan.Value, Optional.ToList(resources), identity, identityWithRenamedProperty.Value, identityWithDifferentPropertyType.Value, identityWithNoUserIdentity.Value, identityWithNoSystemIdentity.Value, Optional.ToList(zones), provisioningState.Value, licenseType.Value, vmId.Value, extensionsTimeBudget.Value);
        }
    }
}
