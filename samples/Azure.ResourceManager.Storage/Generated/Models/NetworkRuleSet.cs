// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Network rule set. </summary>
    public partial class NetworkRuleSet
    {
        /// <summary> Initializes a new instance of NetworkRuleSet. </summary>
        /// <param name="defaultAction"> Specifies the default action of allow or deny when no other rules match. </param>
        public NetworkRuleSet(DefaultAction defaultAction)
        {
            ResourceAccessRules = new ChangeTrackingList<ResourceAccessRule>();
            VirtualNetworkRules = new ChangeTrackingList<VirtualNetworkRule>();
            IpRules = new ChangeTrackingList<IPRule>();
            DefaultAction = defaultAction;
        }

        /// <summary> Initializes a new instance of NetworkRuleSet. </summary>
        /// <param name="bypass"> Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics. </param>
        /// <param name="resourceAccessRules"> Sets the resource access rules. </param>
        /// <param name="virtualNetworkRules"> Sets the virtual network rules. </param>
        /// <param name="ipRules"> Sets the IP ACL rules. </param>
        /// <param name="defaultAction"> Specifies the default action of allow or deny when no other rules match. </param>
        internal NetworkRuleSet(Bypass? bypass, IList<ResourceAccessRule> resourceAccessRules, IList<VirtualNetworkRule> virtualNetworkRules, IList<IPRule> ipRules, DefaultAction defaultAction)
        {
            Bypass = bypass;
            ResourceAccessRules = resourceAccessRules;
            VirtualNetworkRules = virtualNetworkRules;
            IpRules = ipRules;
            DefaultAction = defaultAction;
        }

        /// <summary> Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics. </summary>
        public Bypass? Bypass { get; set; }
        /// <summary> Sets the resource access rules. </summary>
        public IList<ResourceAccessRule> ResourceAccessRules { get; }
        /// <summary> Sets the virtual network rules. </summary>
        public IList<VirtualNetworkRule> VirtualNetworkRules { get; }
        /// <summary> Sets the IP ACL rules. </summary>
        public IList<IPRule> IpRules { get; }
        /// <summary> Specifies the default action of allow or deny when no other rules match. </summary>
        public DefaultAction DefaultAction { get; set; }
    }
}
