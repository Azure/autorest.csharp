// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class SmbSetting : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Multichannel))
            {
                writer.WritePropertyName("multichannel"u8);
                writer.WriteObjectValue(Multichannel);
            }
            if (Optional.IsDefined(Versions))
            {
                writer.WritePropertyName("versions"u8);
                writer.WriteStringValue(Versions);
            }
            if (Optional.IsDefined(AuthenticationMethods))
            {
                writer.WritePropertyName("authenticationMethods"u8);
                writer.WriteStringValue(AuthenticationMethods);
            }
            if (Optional.IsDefined(KerberosTicketEncryption))
            {
                writer.WritePropertyName("kerberosTicketEncryption"u8);
                writer.WriteStringValue(KerberosTicketEncryption);
            }
            if (Optional.IsDefined(ChannelEncryption))
            {
                writer.WritePropertyName("channelEncryption"u8);
                writer.WriteStringValue(ChannelEncryption);
            }
            writer.WriteEndObject();
        }

        internal static SmbSetting DeserializeSmbSetting(JsonElement element)
        {
            Optional<Multichannel> multichannel = default;
            Optional<string> versions = default;
            Optional<string> authenticationMethods = default;
            Optional<string> kerberosTicketEncryption = default;
            Optional<string> channelEncryption = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("multichannel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    multichannel = Multichannel.DeserializeMultichannel(property.Value);
                    continue;
                }
                if (property.NameEquals("versions"u8))
                {
                    versions = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("authenticationMethods"u8))
                {
                    authenticationMethods = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kerberosTicketEncryption"u8))
                {
                    kerberosTicketEncryption = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("channelEncryption"u8))
                {
                    channelEncryption = property.Value.GetString();
                    continue;
                }
            }
            return new SmbSetting(multichannel.Value, versions.Value, authenticationMethods.Value, kerberosTicketEncryption.Value, channelEncryption.Value);
        }
    }
}
