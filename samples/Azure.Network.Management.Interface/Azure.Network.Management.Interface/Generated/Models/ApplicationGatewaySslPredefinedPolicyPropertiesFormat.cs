// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Properties of ApplicationGatewaySslPredefinedPolicy. </summary>
    public partial class ApplicationGatewaySslPredefinedPolicyPropertiesFormat
    {
        /// <summary> Ssl cipher suites to be enabled in the specified order for application gateway. </summary>
        public IList<ApplicationGatewaySslCipherSuite> CipherSuites { get; set; }
        /// <summary> Minimum version of Ssl protocol to be supported on application gateway. </summary>
        public ApplicationGatewaySslProtocol? MinProtocolVersion { get; set; }
    }
}
