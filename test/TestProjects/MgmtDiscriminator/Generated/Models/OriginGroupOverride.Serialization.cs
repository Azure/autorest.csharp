// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtDiscriminator.Models
{
    public partial class OriginGroupOverride : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(OriginGroup))
            {
                writer.WritePropertyName("originGroup"u8);
                JsonSerializer.Serialize(writer, OriginGroup);
            }
            if (Optional.IsDefined(ForwardingProtocol))
            {
                writer.WritePropertyName("forwardingProtocol"u8);
                writer.WriteStringValue(ForwardingProtocol.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static OriginGroupOverride DeserializeOriginGroupOverride(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<WritableSubResource> originGroup = default;
            Optional<ForwardingProtocol> forwardingProtocol = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("originGroup"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    originGroup = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("forwardingProtocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    forwardingProtocol = new ForwardingProtocol(property.Value.GetString());
                    continue;
                }
            }
            return new OriginGroupOverride(originGroup, Optional.ToNullable(forwardingProtocol));
        }
    }
}
