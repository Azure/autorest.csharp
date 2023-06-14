// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Details the service to which the subnet is delegated. </summary>
    public partial class Delegation : SubResource
    {
        /// <summary> Initializes a new instance of Delegation. </summary>
        public Delegation()
        {
            Actions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of Delegation. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a subnet. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="serviceName"> The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers). </param>
        /// <param name="actions"> The actions permitted to the service upon delegation. </param>
        /// <param name="provisioningState"> The provisioning state of the service delegation resource. </param>
        internal Delegation(string id, string name, string etag, string serviceName, IReadOnlyList<string> actions, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            ServiceName = serviceName;
            Actions = actions;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within a subnet. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers). </summary>
        public string ServiceName { get; set; }
        /// <summary> The actions permitted to the service upon delegation. </summary>
        public IReadOnlyList<string> Actions { get; }
        /// <summary> The provisioning state of the service delegation resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
