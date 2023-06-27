// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> IP configuration profile child resource. </summary>
    public partial class IPConfigurationProfile : SubResource
    {
        /// <summary> Initializes a new instance of IPConfigurationProfile. </summary>
        public IPConfigurationProfile()
        {
        }

        /// <summary> Initializes a new instance of IPConfigurationProfile. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource. This name can be used to access the resource. </param>
        /// <param name="type"> Sub Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="subnet"> The reference to the subnet resource to create a container network interface ip configuration. </param>
        /// <param name="provisioningState"> The provisioning state of the IP configuration profile resource. </param>
        internal IPConfigurationProfile(string id, string name, string type, string etag, Subnet subnet, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Type = type;
            Etag = etag;
            Subnet = subnet;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> Sub Resource type. </summary>
        public string Type { get; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The reference to the subnet resource to create a container network interface ip configuration. </summary>
        public Subnet Subnet { get; set; }
        /// <summary> The provisioning state of the IP configuration profile resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
