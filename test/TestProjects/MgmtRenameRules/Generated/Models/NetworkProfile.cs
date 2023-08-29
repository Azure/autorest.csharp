// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NetworkProfile"/>. </summary>
        public NetworkProfile()
        {
            NetworkInterfaces = new ChangeTrackingList<NetworkInterfaceReference>();
        }

        /// <summary> Initializes a new instance of <see cref="NetworkProfile"/>. </summary>
        /// <param name="networkInterfaces">
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// Serialized Name: NetworkProfile.networkInterfaces
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkProfile(IList<NetworkInterfaceReference> networkInterfaces, Dictionary<string, BinaryData> rawData)
        {
            NetworkInterfaces = networkInterfaces;
            _rawData = rawData;
        }

        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// Serialized Name: NetworkProfile.networkInterfaces
        /// </summary>
        public IList<NetworkInterfaceReference> NetworkInterfaces { get; }
    }
}
