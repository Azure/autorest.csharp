// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the network interfaces of the virtual machine.
    /// Serialized Name: NetworkProfile
    /// </summary>
    internal partial class NetworkProfile
    {
        /// <summary> Initializes a new instance of NetworkProfile. </summary>
        public NetworkProfile()
        {
            NetworkInterfaces = new ChangeTrackingList<NetworkInterfaceReference>();
        }

        /// <summary> Initializes a new instance of NetworkProfile. </summary>
        /// <param name="networkInterfaces">
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// Serialized Name: NetworkProfile.networkInterfaces
        /// </param>
        internal NetworkProfile(IList<NetworkInterfaceReference> networkInterfaces)
        {
            NetworkInterfaces = networkInterfaces;
        }

        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// Serialized Name: NetworkProfile.networkInterfaces
        /// </summary>
        public IList<NetworkInterfaceReference> NetworkInterfaces { get; }
    }
}
