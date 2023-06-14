// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> SKU of a load balancer. </summary>
    public partial class LoadBalancerSku
    {
        /// <summary> Initializes a new instance of LoadBalancerSku. </summary>
        public LoadBalancerSku()
        {
        }

        /// <summary> Initializes a new instance of LoadBalancerSku. </summary>
        /// <param name="name"> Name of a load balancer SKU. </param>
        internal LoadBalancerSku(LoadBalancerSkuName? name)
        {
            Name = name;
        }

        /// <summary> Name of a load balancer SKU. </summary>
        public LoadBalancerSkuName? Name { get; set; }
    }
}
