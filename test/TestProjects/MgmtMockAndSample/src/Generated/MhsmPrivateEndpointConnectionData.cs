// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the MhsmPrivateEndpointConnection data model.
    /// Private endpoint connection resource.
    /// </summary>
    public partial class MhsmPrivateEndpointConnectionData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MhsmPrivateEndpointConnectionData"/>. </summary>
        /// <param name="location"> The location. </param>
        public MhsmPrivateEndpointConnectionData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MhsmPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MhsmPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string etag, Azure.ResourceManager.Resources.Models.SubResource privateEndpoint, MhsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState, ManagedHsmSku sku, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Etag = etag;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            ProvisioningState = provisioningState;
            Sku = sku;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MhsmPrivateEndpointConnectionData"/> for deserialization. </summary>
        internal MhsmPrivateEndpointConnectionData()
        {
        }

        /// <summary> Modified whenever there is a change in the state of private endpoint connection. </summary>
        public string Etag { get; set; }
        /// <summary> Properties of the private endpoint object. </summary>
        internal Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get; set; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
        }

        /// <summary> Approval state of the private link connection. </summary>
        public MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? ProvisioningState { get; set; }
        /// <summary> SKU details. </summary>
        public ManagedHsmSku Sku { get; set; }
    }
}
