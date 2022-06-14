// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtSignalR.Models;

namespace MgmtSignalR
{
    /// <summary> A class representing the MgmtSignalRPrivateEndpointConnection data model. </summary>
    public partial class MgmtSignalRPrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Initializes a new instance of MgmtSignalRPrivateEndpointConnectionData. </summary>
        public MgmtSignalRPrivateEndpointConnectionData()
        {
        }

        /// <summary> Initializes a new instance of MgmtSignalRPrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="privateEndpoint"> Private endpoint associated with the private endpoint connection. </param>
        /// <param name="connectionState"> Connection state. </param>
        internal MgmtSignalRPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ProvisioningState? provisioningState, WritableSubResource privateEndpoint, MgmtSignalRPrivateLinkServiceConnectionState connectionState) : base(id, name, resourceType, systemData)
        {
            ProvisioningState = provisioningState;
            PrivateEndpoint = privateEndpoint;
            ConnectionState = connectionState;
        }

        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> Private endpoint associated with the private endpoint connection. </summary>
        internal WritableSubResource PrivateEndpoint { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
            set
            {
                if (PrivateEndpoint is null)
                    PrivateEndpoint = new WritableSubResource();
                PrivateEndpoint.Id = value;
            }
        }

        /// <summary> Connection state. </summary>
        public MgmtSignalRPrivateLinkServiceConnectionState ConnectionState { get; set; }
    }
}
