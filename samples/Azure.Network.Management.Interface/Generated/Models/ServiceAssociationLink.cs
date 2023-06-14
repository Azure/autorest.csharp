// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> ServiceAssociationLink resource. </summary>
    public partial class ServiceAssociationLink : SubResource
    {
        /// <summary> Initializes a new instance of ServiceAssociationLink. </summary>
        public ServiceAssociationLink()
        {
            Locations = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of ServiceAssociationLink. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="linkedResourceType"> Resource type of the linked resource. </param>
        /// <param name="link"> Link to the external resource. </param>
        /// <param name="provisioningState"> The provisioning state of the service association link resource. </param>
        /// <param name="allowDelete"> If true, the resource can be deleted. </param>
        /// <param name="locations"> A list of locations. </param>
        internal ServiceAssociationLink(string id, string name, string etag, string type, string linkedResourceType, string link, ProvisioningState? provisioningState, bool? allowDelete, IList<string> locations) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            LinkedResourceType = linkedResourceType;
            Link = link;
            ProvisioningState = provisioningState;
            AllowDelete = allowDelete;
            Locations = locations;
        }

        /// <summary> Name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Resource type. </summary>
        public string Type { get; }
        /// <summary> Resource type of the linked resource. </summary>
        public string LinkedResourceType { get; set; }
        /// <summary> Link to the external resource. </summary>
        public string Link { get; set; }
        /// <summary> The provisioning state of the service association link resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> If true, the resource can be deleted. </summary>
        public bool? AllowDelete { get; set; }
        /// <summary> A list of locations. </summary>
        public IList<string> Locations { get; }
    }
}
