// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the MgmtMockAndSamplePrivateEndpointConnection data model.
    /// Private endpoint connection resource.
    /// </summary>
    public partial class MgmtMockAndSamplePrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointConnectionData"/>. </summary>
        public MgmtMockAndSamplePrivateEndpointConnectionData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="eTag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        internal MgmtMockAndSamplePrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? eTag, Azure.ResourceManager.Resources.Models.SubResource privateEndpoint, MgmtMockAndSamplePrivateLinkServiceConnectionState connectionState, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState, AzureLocation? location, IReadOnlyDictionary<string, string> tags) : base(id, name, resourceType, systemData)
        {
            ETag = eTag;
            PrivateEndpoint = privateEndpoint;
            ConnectionState = connectionState;
            ProvisioningState = provisioningState;
            Location = location;
            Tags = tags;
        }

        /// <summary> Modified whenever there is a change in the state of private endpoint connection. </summary>
        public ETag? ETag { get; set; }
        /// <summary> Properties of the private endpoint object. </summary>
        internal Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get; set; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
        }

        /// <summary> Approval state of the private link connection. </summary>
        public MgmtMockAndSamplePrivateLinkServiceConnectionState ConnectionState { get; set; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? ProvisioningState { get; set; }
        /// <summary> Azure location of the key vault resource. </summary>
        public AzureLocation? Location { get; }
        /// <summary> Tags assigned to the key vault resource. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
