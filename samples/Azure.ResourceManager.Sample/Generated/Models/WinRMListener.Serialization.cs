// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class WinRMListener : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol");
                writer.WriteStringValue(Protocol.Value.ToSerialString());
            }
            if (Optional.IsDefined(CertificateUrl))
            {
                writer.WritePropertyName("certificateUrl");
                writer.WriteStringValue(CertificateUrl);
            }
            writer.WriteEndObject();
        }

        internal static WinRMListener DeserializeWinRMListener(JsonElement element)
        {
            Optional<ProtocolTypes> protocol = default;
            Optional<string> certificateUrl = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("protocol"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    protocol = property.Value.GetString().ToProtocolTypes();
                    continue;
                }
                if (property.NameEquals("certificateUrl"))
                {
                    certificateUrl = property.Value.GetString();
                    continue;
                }
            }
            return new WinRMListener(Optional.ToNullable(protocol), certificateUrl.Value);
        }
    }
}
