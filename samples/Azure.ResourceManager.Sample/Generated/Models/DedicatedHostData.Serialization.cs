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
    public partial class DedicatedHostData : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("sku"u8);
            writer.WriteObjectValue(Sku);
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
                if (Optional.IsDefined(PlatformFaultDomain))
                {
                    writer.WritePropertyName("platformFaultDomain"u8);
                    writer.WriteNumberValue(PlatformFaultDomain.Value);
                }
                if (Optional.IsDefined(AutoReplaceOnFailure))
                {
                    writer.WritePropertyName("autoReplaceOnFailure"u8);
                    writer.WriteBooleanValue(AutoReplaceOnFailure.Value);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(HostId))
                {
                    writer.WritePropertyName("hostId"u8);
                    writer.WriteStringValue(HostId);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(VirtualMachines))
                {
                    writer.WritePropertyName("virtualMachines"u8);
                    writer.WriteStartArray();
                    foreach (var item in VirtualMachines)
                    {
                        JsonSerializer.Serialize(writer, item);
                    }
                    writer.WriteEndArray();
                }
                if (Optional.IsDefined(LicenseType))
                {
                    writer.WritePropertyName("licenseType"u8);
                    writer.WriteStringValue(LicenseType.Value.ToSerialString());
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ProvisioningOn))
                {
                    writer.WritePropertyName("provisioningTime"u8);
                    writer.WriteStringValue(ProvisioningOn.Value, "O");
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState);
                }
                if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(InstanceView))
                {
                    writer.WritePropertyName("instanceView"u8);
                    writer.WriteObjectValue(InstanceView);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        DedicatedHostData IModelJsonSerializable<DedicatedHostData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostData(document.RootElement, options);
        }

        BinaryData IModelSerializable<DedicatedHostData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostData IModelSerializable<DedicatedHostData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDedicatedHostData(document.RootElement, options);
        }

        internal static DedicatedHostData DeserializeDedicatedHostData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SampleSku sku = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<int> platformFaultDomain = default;
            Optional<bool> autoReplaceOnFailure = default;
            Optional<string> hostId = default;
            Optional<IReadOnlyList<Resources.Models.SubResource>> virtualMachines = default;
            Optional<DedicatedHostLicenseType> licenseType = default;
            Optional<DateTimeOffset> provisioningTime = default;
            Optional<string> provisioningState = default;
            Optional<DedicatedHostInstanceView> instanceView = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sku"u8))
                {
                    sku = SampleSku.DeserializeSampleSku(property.Value);
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
                        if (property0.NameEquals("platformFaultDomain"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            platformFaultDomain = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("autoReplaceOnFailure"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            autoReplaceOnFailure = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hostId"u8))
                        {
                            hostId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("virtualMachines"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Resources.Models.SubResource> array = new List<Resources.Models.SubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<Resources.Models.SubResource>(item.GetRawText()));
                            }
                            virtualMachines = array;
                            continue;
                        }
                        if (property0.NameEquals("licenseType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            licenseType = property0.Value.GetString().ToDedicatedHostLicenseType();
                            continue;
                        }
                        if (property0.NameEquals("provisioningTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningTime = property0.Value.GetDateTimeOffset("O");
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
                            instanceView = DedicatedHostInstanceView.DeserializeDedicatedHostInstanceView(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new DedicatedHostData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, sku, Optional.ToNullable(platformFaultDomain), Optional.ToNullable(autoReplaceOnFailure), hostId.Value, Optional.ToList(virtualMachines), Optional.ToNullable(licenseType), Optional.ToNullable(provisioningTime), provisioningState.Value, instanceView.Value);
        }
    }
}
