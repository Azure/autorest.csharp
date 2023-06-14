// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    internal partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("domainNameLabel"u8);
            writer.WriteStringValue(DomainNameLabel);
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DeserializeVirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string domainNameLabel = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainNameLabel"u8))
                {
                    domainNameLabel = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(domainNameLabel);
        }
    }
}
