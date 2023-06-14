// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtLRO.Models
{
    public partial class FakeProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PlatformUpdateDomainCount))
            {
                writer.WritePropertyName("platformUpdateDomainCount"u8);
                writer.WriteNumberValue(PlatformUpdateDomainCount.Value);
            }
            if (Optional.IsDefined(PlatformFaultDomainCount))
            {
                writer.WritePropertyName("platformFaultDomainCount"u8);
                writer.WriteNumberValue(PlatformFaultDomainCount.Value);
            }
            writer.WriteEndObject();
        }

        internal static FakeProperties DeserializeFakeProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> platformUpdateDomainCount = default;
            Optional<int> platformFaultDomainCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformUpdateDomainCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomainCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformFaultDomainCount = property.Value.GetInt32();
                    continue;
                }
            }
            return new FakeProperties(Optional.ToNullable(platformUpdateDomainCount), Optional.ToNullable(platformFaultDomainCount));
        }
    }
}
