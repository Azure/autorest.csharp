// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> DNS Proxy Settings in Firewall Policy. </summary>
    public partial class DnsSettings
    {
        /// <summary> Initializes a new instance of DnsSettings. </summary>
        public DnsSettings()
        {
            Servers = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of DnsSettings. </summary>
        /// <param name="servers"> List of Custom DNS Servers. </param>
        /// <param name="enableProxy"> Enable DNS Proxy on Firewalls attached to the Firewall Policy. </param>
        /// <param name="requireProxyForNetworkRules"> FQDNs in Network Rules are supported when set to true. </param>
        internal DnsSettings(IList<string> servers, bool? enableProxy, bool? requireProxyForNetworkRules)
        {
            Servers = servers;
            EnableProxy = enableProxy;
            RequireProxyForNetworkRules = requireProxyForNetworkRules;
        }

        /// <summary> List of Custom DNS Servers. </summary>
        public IList<string> Servers { get; }
        /// <summary> Enable DNS Proxy on Firewalls attached to the Firewall Policy. </summary>
        public bool? EnableProxy { get; set; }
        /// <summary> FQDNs in Network Rules are supported when set to true. </summary>
        public bool? RequireProxyForNetworkRules { get; set; }
    }
}
