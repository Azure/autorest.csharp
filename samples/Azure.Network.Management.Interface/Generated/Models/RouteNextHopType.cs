// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The type of Azure hop the packet should be sent to. </summary>
    public readonly partial struct RouteNextHopType : IEquatable<RouteNextHopType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RouteNextHopType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RouteNextHopType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string VirtualNetworkGatewayValue = "VirtualNetworkGateway";
        private const string VnetLocalValue = "VnetLocal";
        private const string InternetValue = "Internet";
        private const string VirtualApplianceValue = "VirtualAppliance";
        private const string NoneValue = "None";

        /// <summary> VirtualNetworkGateway. </summary>
        public static RouteNextHopType VirtualNetworkGateway { get; } = new RouteNextHopType(VirtualNetworkGatewayValue);
        /// <summary> VnetLocal. </summary>
        public static RouteNextHopType VnetLocal { get; } = new RouteNextHopType(VnetLocalValue);
        /// <summary> Internet. </summary>
        public static RouteNextHopType Internet { get; } = new RouteNextHopType(InternetValue);
        /// <summary> VirtualAppliance. </summary>
        public static RouteNextHopType VirtualAppliance { get; } = new RouteNextHopType(VirtualApplianceValue);
        /// <summary> None. </summary>
        public static RouteNextHopType None { get; } = new RouteNextHopType(NoneValue);
        /// <summary> Determines if two <see cref="RouteNextHopType"/> values are the same. </summary>
        public static bool operator ==(RouteNextHopType left, RouteNextHopType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RouteNextHopType"/> values are not the same. </summary>
        public static bool operator !=(RouteNextHopType left, RouteNextHopType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RouteNextHopType"/>. </summary>
        public static implicit operator RouteNextHopType(string value) => new RouteNextHopType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RouteNextHopType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RouteNextHopType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
