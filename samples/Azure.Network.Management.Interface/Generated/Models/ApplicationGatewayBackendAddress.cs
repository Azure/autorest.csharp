// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Backend address of an application gateway. </summary>
    public partial class ApplicationGatewayBackendAddress
    {
        /// <summary> Initializes a new instance of ApplicationGatewayBackendAddress. </summary>
        public ApplicationGatewayBackendAddress()
        {
        }

        /// <summary> Initializes a new instance of ApplicationGatewayBackendAddress. </summary>
        /// <param name="fqdn"> Fully qualified domain name (FQDN). </param>
        /// <param name="ipAddress"> IP address. </param>
        internal ApplicationGatewayBackendAddress(string fqdn, string ipAddress)
        {
            Fqdn = fqdn;
            IpAddress = ipAddress;
        }

        /// <summary> Fully qualified domain name (FQDN). </summary>
        public string Fqdn { get; set; }
        /// <summary> IP address. </summary>
        public string IpAddress { get; set; }
    }
}
