// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using MgmtAcronymMapping;

namespace MgmtAcronymMapping.Models
{
    internal partial class HardwareProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(VmSize))
            {
                writer.WritePropertyName("vmSize"u8);
                writer.WriteStringValue(VmSize.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static HardwareProfile DeserializeHardwareProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            VirtualMachineSizeType? vmSize = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vmSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmSize = new VirtualMachineSizeType(property.Value.GetString());
                    continue;
                }
            }
            return new HardwareProfile(vmSize);
        }
    }
}
