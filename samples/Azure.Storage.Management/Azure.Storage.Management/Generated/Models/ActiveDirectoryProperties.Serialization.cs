// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class ActiveDirectoryProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("domainName");
            writer.WriteStringValue(DomainName);
            writer.WritePropertyName("netBiosDomainName");
            writer.WriteStringValue(NetBiosDomainName);
            writer.WritePropertyName("forestName");
            writer.WriteStringValue(ForestName);
            writer.WritePropertyName("domainGuid");
            writer.WriteStringValue(DomainGuid);
            writer.WritePropertyName("domainSid");
            writer.WriteStringValue(DomainSid);
            writer.WritePropertyName("azureStorageSid");
            writer.WriteStringValue(AzureStorageSid);
            writer.WriteEndObject();
        }

        internal static ActiveDirectoryProperties DeserializeActiveDirectoryProperties(JsonElement element)
        {
            string domainName = default;
            string netBiosDomainName = default;
            string forestName = default;
            string domainGuid = default;
            string domainSid = default;
            string azureStorageSid = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainName"))
                {
                    domainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("netBiosDomainName"))
                {
                    netBiosDomainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("forestName"))
                {
                    forestName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainGuid"))
                {
                    domainGuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainSid"))
                {
                    domainSid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("azureStorageSid"))
                {
                    azureStorageSid = property.Value.GetString();
                    continue;
                }
            }
            return new ActiveDirectoryProperties(domainName, netBiosDomainName, forestName, domainGuid, domainSid, azureStorageSid);
        }
    }
}
