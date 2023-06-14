// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class WinRMListener : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToSerialString());
            }
            if (Optional.IsDefined(CertificateUri))
            {
                writer.WritePropertyName("certificateUrl"u8);
                writer.WriteStringValue(CertificateUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static WinRMListener DeserializeWinRMListener(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ProtocolType> protocol = default;
            Optional<Uri> certificateUrl = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("protocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protocol = property.Value.GetString().ToProtocolType();
                    continue;
                }
                if (property.NameEquals("certificateUrl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    certificateUrl = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new WinRMListener(Optional.ToNullable(protocol), certificateUrl.Value);
        }
    }
}
