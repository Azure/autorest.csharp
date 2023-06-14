// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMockAndSample
{
    public partial class VirtualMachineExtensionImageData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(OperatingSystem))
            {
                writer.WritePropertyName("operatingSystem"u8);
                writer.WriteStringValue(OperatingSystem);
            }
            if (Optional.IsDefined(ComputeRole))
            {
                writer.WritePropertyName("computeRole"u8);
                writer.WriteStringValue(ComputeRole);
            }
            if (Optional.IsDefined(HandlerSchema))
            {
                writer.WritePropertyName("handlerSchema"u8);
                writer.WriteStringValue(HandlerSchema);
            }
            if (Optional.IsDefined(VmScaleSetEnabled))
            {
                writer.WritePropertyName("vmScaleSetEnabled"u8);
                writer.WriteBooleanValue(VmScaleSetEnabled.Value);
            }
            if (Optional.IsDefined(SupportsMultipleExtensions))
            {
                writer.WritePropertyName("supportsMultipleExtensions"u8);
                writer.WriteBooleanValue(SupportsMultipleExtensions.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static VirtualMachineExtensionImageData DeserializeVirtualMachineExtensionImageData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AzureLocation> location = default;
            Optional<IReadOnlyDictionary<string, string>> tags = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> operatingSystem = default;
            Optional<string> computeRole = default;
            Optional<string> handlerSchema = default;
            Optional<bool> vmScaleSetEnabled = default;
            Optional<bool> supportsMultipleExtensions = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
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
                        if (property0.NameEquals("operatingSystem"u8))
                        {
                            operatingSystem = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("computeRole"u8))
                        {
                            computeRole = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("handlerSchema"u8))
                        {
                            handlerSchema = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("vmScaleSetEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            vmScaleSetEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("supportsMultipleExtensions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            supportsMultipleExtensions = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new VirtualMachineExtensionImageData(id, name, type, systemData.Value, operatingSystem.Value, computeRole.Value, handlerSchema.Value, Optional.ToNullable(vmScaleSetEnabled), Optional.ToNullable(supportsMultipleExtensions), Optional.ToNullable(location), Optional.ToDictionary(tags));
        }
    }
}
