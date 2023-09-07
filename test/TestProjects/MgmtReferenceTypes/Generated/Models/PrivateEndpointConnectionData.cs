// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The Private Endpoint Connection resource. </summary>
    [TypeReferenceType]
    public partial class PrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="PrivateEndpointConnectionData"/>. </summary>
        [InitializationConstructor]
        public PrivateEndpointConnectionData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpoint"> The resource of private end point. </param>
        /// <param name="connectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        protected PrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, PrivateEndpoint privateEndpoint, MgmtReferenceTypesPrivateLinkServiceConnectionState connectionState, MgmtReferenceTypesPrivateEndpointConnectionProvisioningState? provisioningState, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            PrivateEndpoint = privateEndpoint;
            ConnectionState = connectionState;
            ProvisioningState = provisioningState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The resource of private end point. </summary>
        internal PrivateEndpoint PrivateEndpoint { get; set; }
        /// <summary> The ARM identifier for Private Endpoint. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
        }

        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        public MgmtReferenceTypesPrivateLinkServiceConnectionState ConnectionState { get; set; }
        /// <summary> The provisioning state of the private endpoint connection resource. </summary>
        public MgmtReferenceTypesPrivateEndpointConnectionProvisioningState? ProvisioningState { get; }
    }
}
