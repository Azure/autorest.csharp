// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    public partial class ProximityPlacementGroupData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ExtendedLocation))
            {
                writer.WritePropertyName("extendedLocation"u8);
                JsonSerializer.Serialize(writer, ExtendedLocation);
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
            if (Optional.IsDefined(ProximityPlacementGroupType))
            {
                writer.WritePropertyName("proximityPlacementGroupType"u8);
                writer.WriteStringValue(ProximityPlacementGroupType.Value.ToString());
            }
            if (Optional.IsDefined(ColocationStatus))
            {
                writer.WritePropertyName("colocationStatus"u8);
                writer.WriteObjectValue(ColocationStatus);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ProximityPlacementGroupData DeserializeProximityPlacementGroupData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ExtendedLocation> extendedLocation = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<ProximityPlacementGroupType> proximityPlacementGroupType = default;
            Optional<IReadOnlyList<SubResourceWithColocationStatus>> virtualMachines = default;
            Optional<IReadOnlyList<SubResourceWithColocationStatus>> virtualMachineScaleSets = default;
            Optional<IReadOnlyList<SubResourceWithColocationStatus>> availabilitySets = default;
            Optional<InstanceViewStatus> colocationStatus = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("extendedLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    extendedLocation = JsonSerializer.Deserialize<ExtendedLocation>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                        property.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("proximityPlacementGroupType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            proximityPlacementGroupType = new ProximityPlacementGroupType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("virtualMachines"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SubResourceWithColocationStatus> array = new List<SubResourceWithColocationStatus>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SubResourceWithColocationStatus.DeserializeSubResourceWithColocationStatus(item));
                            }
                            virtualMachines = array;
                            continue;
                        }
                        if (property0.NameEquals("virtualMachineScaleSets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SubResourceWithColocationStatus> array = new List<SubResourceWithColocationStatus>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SubResourceWithColocationStatus.DeserializeSubResourceWithColocationStatus(item));
                            }
                            virtualMachineScaleSets = array;
                            continue;
                        }
                        if (property0.NameEquals("availabilitySets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SubResourceWithColocationStatus> array = new List<SubResourceWithColocationStatus>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SubResourceWithColocationStatus.DeserializeSubResourceWithColocationStatus(item));
                            }
                            availabilitySets = array;
                            continue;
                        }
                        if (property0.NameEquals("colocationStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            colocationStatus = InstanceViewStatus.DeserializeInstanceViewStatus(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ProximityPlacementGroupData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, extendedLocation, Optional.ToNullable(proximityPlacementGroupType), Optional.ToList(virtualMachines), Optional.ToList(virtualMachineScaleSets), Optional.ToList(availabilitySets), colocationStatus.Value);
        }
    }
}
