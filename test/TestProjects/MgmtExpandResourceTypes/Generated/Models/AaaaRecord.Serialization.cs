// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    public partial class AaaaRecord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Ipv6Address))
            {
                writer.WritePropertyName("ipv6Address"u8);
                writer.WriteStringValue(Ipv6Address);
            }
            writer.WriteEndObject();
        }

        internal static AaaaRecord DeserializeAaaaRecord(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> ipv6Address = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ipv6Address"u8))
                {
                    ipv6Address = property.Value.GetString();
                    continue;
                }
            }
            return new AaaaRecord(ipv6Address.Value);
        }
    }
}
