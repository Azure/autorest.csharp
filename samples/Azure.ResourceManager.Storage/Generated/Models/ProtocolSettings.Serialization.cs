// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class ProtocolSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Smb))
            {
                writer.WritePropertyName("smb"u8);
                writer.WriteObjectValue(Smb);
            }
            writer.WriteEndObject();
        }

        internal static ProtocolSettings DeserializeProtocolSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SmbSetting> smb = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("smb"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    smb = SmbSetting.DeserializeSmbSetting(property.Value);
                    continue;
                }
            }
            return new ProtocolSettings(smb.Value);
        }
    }
}
