// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Settings properties for Active Directory (AD). </summary>
    public partial class ActiveDirectoryProperties
    {
        /// <summary> Initializes a new instance of ActiveDirectoryProperties. </summary>
        internal ActiveDirectoryProperties()
        {
        }

        /// <summary> Initializes a new instance of ActiveDirectoryProperties. </summary>
        /// <param name="domainName"> Specifies the primary domain that the AD DNS server is authoritative for. </param>
        /// <param name="netBiosDomainName"> Specifies the NetBIOS domain name. </param>
        /// <param name="forestName"> Specifies the Active Directory forest to get. </param>
        /// <param name="domainGuid"> Specifies the domain GUID. </param>
        /// <param name="domainSid"> Specifies the security identifier (SID). </param>
        /// <param name="azureStorageSid"> Specifies the security identifier (SID) for Azure Storage. </param>
        internal ActiveDirectoryProperties(string domainName, string netBiosDomainName, string forestName, string domainGuid, string domainSid, string azureStorageSid)
        {
            DomainName = domainName;
            NetBiosDomainName = netBiosDomainName;
            ForestName = forestName;
            DomainGuid = domainGuid;
            DomainSid = domainSid;
            AzureStorageSid = azureStorageSid;
        }

        /// <summary> Specifies the primary domain that the AD DNS server is authoritative for. </summary>
        public string DomainName { get; set; }
        /// <summary> Specifies the NetBIOS domain name. </summary>
        public string NetBiosDomainName { get; set; }
        /// <summary> Specifies the Active Directory forest to get. </summary>
        public string ForestName { get; set; }
        /// <summary> Specifies the domain GUID. </summary>
        public string DomainGuid { get; set; }
        /// <summary> Specifies the security identifier (SID). </summary>
        public string DomainSid { get; set; }
        /// <summary> Specifies the security identifier (SID) for Azure Storage. </summary>
        public string AzureStorageSid { get; set; }
    }
}
