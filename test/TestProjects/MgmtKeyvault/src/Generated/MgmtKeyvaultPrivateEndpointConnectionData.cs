// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class representing the MgmtKeyvaultPrivateEndpointConnection data model. </summary>
    public partial class MgmtKeyvaultPrivateEndpointConnectionData : MgmtKeyvaultResourceData
    {
        /// <summary> Initializes a new instance of MgmtKeyvaultPrivateEndpointConnectionData. </summary>
        public MgmtKeyvaultPrivateEndpointConnectionData()
        {
        }

        /// <summary> Initializes a new instance of MgmtKeyvaultPrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        internal MgmtKeyvaultPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, IReadOnlyDictionary<string, string> tags, string etag, SubResource privateEndpoint, MgmtKeyvaultPrivateLinkServiceConnectionState connectionState, MgmtKeyvaultPrivateEndpointConnectionProvisioningState? provisioningState) : base(id, name, resourceType, systemData, location, tags)
        {
            Etag = etag;
            PrivateEndpoint = privateEndpoint;
            ConnectionState = connectionState;
            ProvisioningState = provisioningState;
        }

        /// <summary> Modified whenever there is a change in the state of private endpoint connection. </summary>
        public string Etag { get; set; }
        /// <summary> Properties of the private endpoint object. </summary>
        internal SubResource PrivateEndpoint { get; set; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
        }

        /// <summary> Approval state of the private link connection. </summary>
        public MgmtKeyvaultPrivateLinkServiceConnectionState ConnectionState { get; set; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public MgmtKeyvaultPrivateEndpointConnectionProvisioningState? ProvisioningState { get; set; }
    }
}
