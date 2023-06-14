// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> A set of rules governing the network accessibility of a managed hsm pool. </summary>
    public partial class MhsmNetworkRuleSet
    {
        /// <summary> Initializes a new instance of MhsmNetworkRuleSet. </summary>
        public MhsmNetworkRuleSet()
        {
            IpRules = new ChangeTrackingList<MhsmipRule>();
            VirtualNetworkRules = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> Initializes a new instance of MhsmNetworkRuleSet. </summary>
        /// <param name="bypass"> Tells what traffic can bypass network rules. This can be 'AzureServices' or 'None'.  If not specified the default is 'AzureServices'. </param>
        /// <param name="defaultAction"> The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated. </param>
        /// <param name="ipRules"> The list of IP address rules. </param>
        /// <param name="virtualNetworkRules"> The list of virtual network rules. </param>
        internal MhsmNetworkRuleSet(NetworkRuleBypassOption? bypass, NetworkRuleAction? defaultAction, IList<MhsmipRule> ipRules, IList<WritableSubResource> virtualNetworkRules)
        {
            Bypass = bypass;
            DefaultAction = defaultAction;
            IpRules = ipRules;
            VirtualNetworkRules = virtualNetworkRules;
        }

        /// <summary> Tells what traffic can bypass network rules. This can be 'AzureServices' or 'None'.  If not specified the default is 'AzureServices'. </summary>
        public NetworkRuleBypassOption? Bypass { get; set; }
        /// <summary> The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated. </summary>
        public NetworkRuleAction? DefaultAction { get; set; }
        /// <summary> The list of IP address rules. </summary>
        public IList<MhsmipRule> IpRules { get; }
        /// <summary> The list of virtual network rules. </summary>
        public IList<WritableSubResource> VirtualNetworkRules { get; }
    }
}
