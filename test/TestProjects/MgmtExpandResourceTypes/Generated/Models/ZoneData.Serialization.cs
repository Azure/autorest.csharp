// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    public partial class ZoneData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag);
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
            if (Optional.IsDefined(ZoneType))
            {
                writer.WritePropertyName("zoneType"u8);
                writer.WriteStringValue(ZoneType.Value.ToSerialString());
            }
            if (Optional.IsDefined(MachineType))
            {
                writer.WritePropertyName("machineType"u8);
                writer.WriteNumberValue((int)MachineType.Value);
            }
            if (Optional.IsDefined(StorageType))
            {
                writer.WritePropertyName("storageType"u8);
                writer.WriteNumberValue((int)StorageType.Value);
            }
            if (Optional.IsDefined(MemoryType))
            {
                writer.WritePropertyName("memoryType"u8);
                writer.WriteNumberValue((long)MemoryType.Value);
            }
            if (Optional.IsCollectionDefined(RegistrationVirtualNetworks))
            {
                writer.WritePropertyName("registrationVirtualNetworks"u8);
                writer.WriteStartArray();
                foreach (var item in RegistrationVirtualNetworks)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ResolutionVirtualNetworks))
            {
                writer.WritePropertyName("resolutionVirtualNetworks"u8);
                writer.WriteStartArray();
                foreach (var item in ResolutionVirtualNetworks)
                {
                    JsonSerializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static ZoneData DeserializeZoneData(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> etag = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<long> maxNumberOfRecordSets = default;
            Optional<long> maxNumberOfRecordsPerRecordSet = default;
            Optional<long> numberOfRecordSets = default;
            Optional<IReadOnlyList<string>> nameServers = default;
            Optional<ZoneType> zoneType = default;
            Optional<MachineType> machineType = default;
            Optional<StorageType> storageType = default;
            Optional<MemoryType> memoryType = default;
            Optional<IList<WritableSubResource>> registrationVirtualNetworks = default;
            Optional<IList<WritableSubResource>> resolutionVirtualNetworks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
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
                        if (property0.NameEquals("maxNumberOfRecordSets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            maxNumberOfRecordSets = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("maxNumberOfRecordsPerRecordSet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            maxNumberOfRecordsPerRecordSet = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("numberOfRecordSets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            numberOfRecordSets = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("nameServers"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            nameServers = array;
                            continue;
                        }
                        if (property0.NameEquals("zoneType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            zoneType = property0.Value.GetString().ToZoneType();
                            continue;
                        }
                        if (property0.NameEquals("machineType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            machineType = property0.Value.GetInt32().ToMachineType();
                            continue;
                        }
                        if (property0.NameEquals("storageType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            storageType = property0.Value.GetInt32().ToStorageType();
                            continue;
                        }
                        if (property0.NameEquals("memoryType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            memoryType = property0.Value.GetInt64().ToMemoryType();
                            continue;
                        }
                        if (property0.NameEquals("registrationVirtualNetworks"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            registrationVirtualNetworks = array;
                            continue;
                        }
                        if (property0.NameEquals("resolutionVirtualNetworks"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            resolutionVirtualNetworks = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ZoneData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, etag.Value, Optional.ToNullable(maxNumberOfRecordSets), Optional.ToNullable(maxNumberOfRecordsPerRecordSet), Optional.ToNullable(numberOfRecordSets), Optional.ToList(nameServers), Optional.ToNullable(zoneType), Optional.ToNullable(machineType), Optional.ToNullable(storageType), Optional.ToNullable(memoryType), Optional.ToList(registrationVirtualNetworks), Optional.ToList(resolutionVirtualNetworks));
        }
    }
}
