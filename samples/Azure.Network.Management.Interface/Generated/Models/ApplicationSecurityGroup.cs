// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> An application security group in a resource group. </summary>
    public partial class ApplicationSecurityGroup : Resource
    {
        /// <summary> Initializes a new instance of <see cref="ApplicationSecurityGroup"/>. </summary>
        public ApplicationSecurityGroup()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ApplicationSecurityGroup"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="resourceGuid"> The resource GUID property of the application security group resource. It uniquely identifies a resource, even if the user changes its name or migrate the resource across subscriptions or resource groups. </param>
        /// <param name="provisioningState"> The provisioning state of the application security group resource. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ApplicationSecurityGroup(string id, string name, string type, string location, IDictionary<string, string> tags, string etag, string resourceGuid, ProvisioningState? provisioningState, Dictionary<string, BinaryData> rawData) : base(id, name, type, location, tags, rawData)
        {
            Etag = etag;
            ResourceGuid = resourceGuid;
            ProvisioningState = provisioningState;
        }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The resource GUID property of the application security group resource. It uniquely identifies a resource, even if the user changes its name or migrate the resource across subscriptions or resource groups. </summary>
        public string ResourceGuid { get; }
        /// <summary> The provisioning state of the application security group resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
