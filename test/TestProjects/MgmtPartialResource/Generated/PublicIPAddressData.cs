// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtPartialResource.Models;

namespace MgmtPartialResource
{
    /// <summary>
    /// A class representing the PublicIPAddress data model.
    /// Public IP address resource.
    /// </summary>
    public partial class PublicIPAddressData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressData"/>. </summary>
        public PublicIPAddressData()
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The public IP address SKU. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="zones"> A list of availability zones denoting the IP allocated for the resource needs to come from. </param>
        /// <param name="publicIPAllocationMethod"> The public IP address allocation method. </param>
        /// <param name="publicIPAddressVersion"> The public IP address version. </param>
        /// <param name="ipAddress"> The IP address associated with the public IP address resource. </param>
        /// <param name="idleTimeoutInMinutes"> The idle timeout of the public IP address. </param>
        /// <param name="resourceGuid"> The resource GUID property of the public IP address resource. </param>
        /// <param name="servicePublicIPAddress"> The service public IP address of the public IP address resource. </param>
        /// <param name="migrationPhase"> Migration phase of Public IP Address. </param>
        /// <param name="linkedPublicIPAddress"> The linked public IP address of the public IP address resource. </param>
        /// <param name="deleteOption"> Specify what happens to the public IP address when the VM using it is deleted. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PublicIPAddressData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PublicIPAddressSku sku, string etag, IList<string> zones, IPAllocationMethod? publicIPAllocationMethod, IPVersion? publicIPAddressVersion, string ipAddress, int? idleTimeoutInMinutes, string resourceGuid, PublicIPAddressData servicePublicIPAddress, PublicIPAddressMigrationPhase? migrationPhase, PublicIPAddressData linkedPublicIPAddress, DeleteOption? deleteOption, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            Sku = sku;
            Etag = etag;
            Zones = zones;
            PublicIPAllocationMethod = publicIPAllocationMethod;
            PublicIPAddressVersion = publicIPAddressVersion;
            IpAddress = ipAddress;
            IdleTimeoutInMinutes = idleTimeoutInMinutes;
            ResourceGuid = resourceGuid;
            ServicePublicIPAddress = servicePublicIPAddress;
            MigrationPhase = migrationPhase;
            LinkedPublicIPAddress = linkedPublicIPAddress;
            DeleteOption = deleteOption;
            _rawData = rawData;
        }

        /// <summary> The public IP address SKU. </summary>
        public PublicIPAddressSku Sku { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> A list of availability zones denoting the IP allocated for the resource needs to come from. </summary>
        public IList<string> Zones { get; }
        /// <summary> The public IP address allocation method. </summary>
        public IPAllocationMethod? PublicIPAllocationMethod { get; set; }
        /// <summary> The public IP address version. </summary>
        public IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary> The IP address associated with the public IP address resource. </summary>
        public string IpAddress { get; set; }
        /// <summary> The idle timeout of the public IP address. </summary>
        public int? IdleTimeoutInMinutes { get; set; }
        /// <summary> The resource GUID property of the public IP address resource. </summary>
        public string ResourceGuid { get; }
        /// <summary> The service public IP address of the public IP address resource. </summary>
        public PublicIPAddressData ServicePublicIPAddress { get; set; }
        /// <summary> Migration phase of Public IP Address. </summary>
        public PublicIPAddressMigrationPhase? MigrationPhase { get; set; }
        /// <summary> The linked public IP address of the public IP address resource. </summary>
        public PublicIPAddressData LinkedPublicIPAddress { get; set; }
        /// <summary> Specify what happens to the public IP address when the VM using it is deleted. </summary>
        public DeleteOption? DeleteOption { get; set; }
    }
}
