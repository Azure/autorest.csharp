// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> PrivateLinkConnection properties for the network interface. </summary>
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties"/>. </summary>
        internal NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties()
        {
            Fqdns = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties"/>. </summary>
        /// <param name="groupId"> The group ID for current private link connection. </param>
        /// <param name="requiredMemberName"> The required member name for current private link connection. </param>
        /// <param name="fqdns"> List of FQDNs for current private link connection. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(string groupId, string requiredMemberName, IReadOnlyList<string> fqdns, Dictionary<string, BinaryData> rawData)
        {
            GroupId = groupId;
            RequiredMemberName = requiredMemberName;
            Fqdns = fqdns;
            _rawData = rawData;
        }

        /// <summary> The group ID for current private link connection. </summary>
        public string GroupId { get; }
        /// <summary> The required member name for current private link connection. </summary>
        public string RequiredMemberName { get; }
        /// <summary> List of FQDNs for current private link connection. </summary>
        public IReadOnlyList<string> Fqdns { get; }
    }
}
