// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class OSDiskImage : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("operatingSystem"u8);
            writer.WriteStringValue(OperatingSystem.ToSerialString());
            writer.WriteEndObject();
        }

        internal static OSDiskImage DeserializeOSDiskImage(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OperatingSystemType operatingSystem = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("operatingSystem"u8))
                {
                    operatingSystem = property.Value.GetString().ToOperatingSystemType();
                    continue;
                }
            }
            return new OSDiskImage(operatingSystem);
        }
    }
}
