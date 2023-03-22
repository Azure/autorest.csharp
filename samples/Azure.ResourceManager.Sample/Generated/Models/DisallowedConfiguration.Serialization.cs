// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DisallowedConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(VmDiskType))
            {
                writer.WritePropertyName("vmDiskType"u8);
                writer.WriteStringValue(VmDiskType.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static DisallowedConfiguration DeserializeDisallowedConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<VmDiskType> vmDiskType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vmDiskType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    vmDiskType = new VmDiskType(property.Value.GetString());
                    continue;
                }
            }
            return new DisallowedConfiguration(Optional.ToNullable(vmDiskType));
        }
    }
}
