// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Effective Route. </summary>
    public partial class EffectiveRoute
    {
        /// <summary> Initializes a new instance of EffectiveRoute. </summary>
        internal EffectiveRoute()
        {
            AddressPrefix = new ChangeTrackingList<string>();
            NextHopIpAddress = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of EffectiveRoute. </summary>
        /// <param name="name"> The name of the user defined route. This is optional. </param>
        /// <param name="disableBgpRoutePropagation"> If true, on-premises routes are not propagated to the network interfaces in the subnet. </param>
        /// <param name="source"> Who created the route. </param>
        /// <param name="state"> The value of effective route. </param>
        /// <param name="addressPrefix"> The address prefixes of the effective routes in CIDR notation. </param>
        /// <param name="nextHopIpAddress"> The IP address of the next hop of the effective route. </param>
        /// <param name="nextHopType"> The type of Azure hop the packet should be sent to. </param>
        internal EffectiveRoute(string name, bool? disableBgpRoutePropagation, EffectiveRouteSource? source, EffectiveRouteState? state, IReadOnlyList<string> addressPrefix, IReadOnlyList<string> nextHopIpAddress, RouteNextHopType? nextHopType)
        {
            Name = name;
            DisableBgpRoutePropagation = disableBgpRoutePropagation;
            Source = source;
            State = state;
            AddressPrefix = addressPrefix;
            NextHopIpAddress = nextHopIpAddress;
            NextHopType = nextHopType;
        }

        /// <summary> The name of the user defined route. This is optional. </summary>
        public string Name { get; }
        /// <summary> If true, on-premises routes are not propagated to the network interfaces in the subnet. </summary>
        public bool? DisableBgpRoutePropagation { get; }
        /// <summary> Who created the route. </summary>
        public EffectiveRouteSource? Source { get; }
        /// <summary> The value of effective route. </summary>
        public EffectiveRouteState? State { get; }
        /// <summary> The address prefixes of the effective routes in CIDR notation. </summary>
        public IReadOnlyList<string> AddressPrefix { get; }
        /// <summary> The IP address of the next hop of the effective route. </summary>
        public IReadOnlyList<string> NextHopIpAddress { get; }
        /// <summary> The type of Azure hop the packet should be sent to. </summary>
        public RouteNextHopType? NextHopType { get; }
    }
}
