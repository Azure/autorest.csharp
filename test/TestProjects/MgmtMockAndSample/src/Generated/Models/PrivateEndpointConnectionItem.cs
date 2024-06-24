// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> Private endpoint connection item. </summary>
    public partial class PrivateEndpointConnectionItem
    {
        /// <summary> Initializes a new instance of <see cref="PrivateEndpointConnectionItem"/>. </summary>
        internal PrivateEndpointConnectionItem()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateEndpointConnectionItem"/>. </summary>
        /// <param name="id"> Id of private endpoint connection. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        internal PrivateEndpointConnectionItem(string id, string etag, Azure.ResourceManager.Resources.Models.SubResource privateEndpoint, MgmtMockAndSamplePrivateLinkServiceConnectionState connectionState, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState)
        {
            Id = id;
            ETag = etag;
            PrivateEndpoint = privateEndpoint;
            ConnectionState = connectionState;
            ProvisioningState = provisioningState;
        }

        /// <summary> Id of private endpoint connection. </summary>
        public string Id { get; }
        /// <summary> Modified whenever there is a change in the state of private endpoint connection. </summary>
        public string ETag { get; }
        /// <summary> Properties of the private endpoint object. </summary>
        internal Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint?.Id;
        }

        /// <summary> Approval state of the private link connection. </summary>
        public MgmtMockAndSamplePrivateLinkServiceConnectionState ConnectionState { get; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? ProvisioningState { get; }
    }
}
