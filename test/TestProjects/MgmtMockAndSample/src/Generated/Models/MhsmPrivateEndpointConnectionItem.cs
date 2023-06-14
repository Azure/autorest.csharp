// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> Private endpoint connection item. </summary>
    public partial class MhsmPrivateEndpointConnectionItem
    {
        /// <summary> Initializes a new instance of MhsmPrivateEndpointConnectionItem. </summary>
        internal MhsmPrivateEndpointConnectionItem()
        {
        }

        /// <summary> Initializes a new instance of MhsmPrivateEndpointConnectionItem. </summary>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        internal MhsmPrivateEndpointConnectionItem(Azure.ResourceManager.Resources.Models.SubResource privateEndpoint, MhsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState)
        {
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            ProvisioningState = provisioningState;
        }

        /// <summary> Properties of the private endpoint object. </summary>
        internal Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint?.Id;
        }

        /// <summary> Approval state of the private link connection. </summary>
        public MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? ProvisioningState { get; }
    }
}
