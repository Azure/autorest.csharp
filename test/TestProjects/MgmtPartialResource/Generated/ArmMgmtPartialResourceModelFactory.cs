// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtPartialResource;

namespace MgmtPartialResource.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtPartialResourceModelFactory
    {
        /// <summary> Initializes a new instance of PublicIPAddressData. </summary>
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
        /// <returns> A new <see cref="MgmtPartialResource.PublicIPAddressData"/> instance for mocking. </returns>
        public static PublicIPAddressData PublicIPAddressData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, PublicIPAddressSku sku = null, string etag = null, IEnumerable<string> zones = null, IPAllocationMethod? publicIPAllocationMethod = null, IPVersion? publicIPAddressVersion = null, string ipAddress = null, int? idleTimeoutInMinutes = null, string resourceGuid = null, PublicIPAddressData servicePublicIPAddress = null, PublicIPAddressMigrationPhase? migrationPhase = null, PublicIPAddressData linkedPublicIPAddress = null, DeleteOption? deleteOption = null)
        {
            zones ??= new List<string>();

            return new PublicIPAddressData(id, name, resourceType, systemData, sku, etag, zones?.ToList(), publicIPAllocationMethod, publicIPAddressVersion, ipAddress, idleTimeoutInMinutes, resourceGuid, servicePublicIPAddress, migrationPhase, linkedPublicIPAddress, deleteOption);
        }

        /// <summary> Initializes a new instance of ConfigurationProfileAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the configuration profile assignment. </param>
        /// <returns> A new <see cref="MgmtPartialResource.ConfigurationProfileAssignmentData"/> instance for mocking. </returns>
        public static ConfigurationProfileAssignmentData ConfigurationProfileAssignmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ConfigurationProfileAssignmentProperties properties = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ConfigurationProfileAssignmentData(id, name, resourceType, systemData, tags, location, properties);
        }

        /// <summary> Initializes a new instance of ConfigurationProfileAssignmentProperties. </summary>
        /// <param name="configurationProfile"> The Automanage configurationProfile ARM Resource URI. </param>
        /// <param name="targetId"> The target VM resource URI. </param>
        /// <param name="status"> The status of onboarding, which only appears in the response. </param>
        /// <returns> A new <see cref="Models.ConfigurationProfileAssignmentProperties"/> instance for mocking. </returns>
        public static ConfigurationProfileAssignmentProperties ConfigurationProfileAssignmentProperties(string configurationProfile = null, string targetId = null, string status = null)
        {
            return new ConfigurationProfileAssignmentProperties(configurationProfile, targetId, status);
        }
    }
}
