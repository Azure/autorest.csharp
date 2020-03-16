// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> PrivateLinkConnection properties for the network interface. </summary>
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties
    {
        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties. </summary>
        public NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties()
        {
        }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties. </summary>
        /// <param name="groupId"> The group ID for current private link connection. </param>
        /// <param name="requiredMemberName"> The required member name for current private link connection. </param>
        /// <param name="fqdns"> List of FQDNs for current private link connection. </param>
        internal NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(string groupId, string requiredMemberName, IList<string> fqdns)
        {
            GroupId = groupId;
            RequiredMemberName = requiredMemberName;
            Fqdns = fqdns;
        }

        /// <summary> The group ID for current private link connection. </summary>
        public string GroupId { get; internal set; }
        /// <summary> The required member name for current private link connection. </summary>
        public string RequiredMemberName { get; internal set; }
        /// <summary> List of FQDNs for current private link connection. </summary>
        public IList<string> Fqdns { get; internal set; }
    }
}
