// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(IdleTimeoutInMinutes))
            {
                writer.WritePropertyName("idleTimeoutInMinutes"u8);
                writer.WriteNumberValue(IdleTimeoutInMinutes.Value);
            }
            if (Optional.IsDefined(DnsSettings))
            {
                writer.WritePropertyName("dnsSettings"u8);
                writer.WriteObjectValue(DnsSettings);
            }
            if (Optional.IsCollectionDefined(IPTags))
            {
                writer.WritePropertyName("ipTags"u8);
                writer.WriteStartArray();
                foreach (var item in IPTags)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PublicIPPrefix))
            {
                writer.WritePropertyName("publicIPPrefix"u8);
                JsonSerializer.Serialize(writer, PublicIPPrefix);
            }
            if (Optional.IsDefined(PublicIPAddressVersion))
            {
                writer.WritePropertyName("publicIPAddressVersion"u8);
                writer.WriteStringValue(PublicIPAddressVersion.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetPublicIPAddressConfiguration DeserializeVirtualMachineScaleSetPublicIPAddressConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<int> idleTimeoutInMinutes = default;
            Optional<VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings> dnsSettings = default;
            Optional<IList<VirtualMachineScaleSetIPTag>> ipTags = default;
            Optional<WritableSubResource> publicIPPrefix = default;
            Optional<IPVersion> publicIPAddressVersion = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
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
                        if (property0.NameEquals("idleTimeoutInMinutes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            idleTimeoutInMinutes = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("dnsSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            dnsSettings = VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings.DeserializeVirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("ipTags"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<VirtualMachineScaleSetIPTag> array = new List<VirtualMachineScaleSetIPTag>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(VirtualMachineScaleSetIPTag.DeserializeVirtualMachineScaleSetIPTag(item));
                            }
                            ipTags = array;
                            continue;
                        }
                        if (property0.NameEquals("publicIPPrefix"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPPrefix = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("publicIPAddressVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPAddressVersion = new IPVersion(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new VirtualMachineScaleSetPublicIPAddressConfiguration(name, Optional.ToNullable(idleTimeoutInMinutes), dnsSettings.Value, Optional.ToList(ipTags), publicIPPrefix, Optional.ToNullable(publicIPAddressVersion));
        }
    }
}
