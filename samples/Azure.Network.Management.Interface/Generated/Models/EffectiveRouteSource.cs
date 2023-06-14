// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Who created the route. </summary>
    public readonly partial struct EffectiveRouteSource : IEquatable<EffectiveRouteSource>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EffectiveRouteSource"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EffectiveRouteSource(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnknownValue = "Unknown";
        private const string UserValue = "User";
        private const string VirtualNetworkGatewayValue = "VirtualNetworkGateway";
        private const string DefaultValue = "Default";

        /// <summary> Unknown. </summary>
        public static EffectiveRouteSource Unknown { get; } = new EffectiveRouteSource(UnknownValue);
        /// <summary> User. </summary>
        public static EffectiveRouteSource User { get; } = new EffectiveRouteSource(UserValue);
        /// <summary> VirtualNetworkGateway. </summary>
        public static EffectiveRouteSource VirtualNetworkGateway { get; } = new EffectiveRouteSource(VirtualNetworkGatewayValue);
        /// <summary> Default. </summary>
        public static EffectiveRouteSource Default { get; } = new EffectiveRouteSource(DefaultValue);
        /// <summary> Determines if two <see cref="EffectiveRouteSource"/> values are the same. </summary>
        public static bool operator ==(EffectiveRouteSource left, EffectiveRouteSource right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EffectiveRouteSource"/> values are not the same. </summary>
        public static bool operator !=(EffectiveRouteSource left, EffectiveRouteSource right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EffectiveRouteSource"/>. </summary>
        public static implicit operator EffectiveRouteSource(string value) => new EffectiveRouteSource(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EffectiveRouteSource other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EffectiveRouteSource other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
