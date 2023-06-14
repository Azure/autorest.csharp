// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The protocol for the outbound rule in load balancer. </summary>
    public readonly partial struct LoadBalancerOutboundRuleProtocol : IEquatable<LoadBalancerOutboundRuleProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LoadBalancerOutboundRuleProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LoadBalancerOutboundRuleProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TcpValue = "Tcp";
        private const string UdpValue = "Udp";
        private const string AllValue = "All";

        /// <summary> Tcp. </summary>
        public static LoadBalancerOutboundRuleProtocol Tcp { get; } = new LoadBalancerOutboundRuleProtocol(TcpValue);
        /// <summary> Udp. </summary>
        public static LoadBalancerOutboundRuleProtocol Udp { get; } = new LoadBalancerOutboundRuleProtocol(UdpValue);
        /// <summary> All. </summary>
        public static LoadBalancerOutboundRuleProtocol All { get; } = new LoadBalancerOutboundRuleProtocol(AllValue);
        /// <summary> Determines if two <see cref="LoadBalancerOutboundRuleProtocol"/> values are the same. </summary>
        public static bool operator ==(LoadBalancerOutboundRuleProtocol left, LoadBalancerOutboundRuleProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LoadBalancerOutboundRuleProtocol"/> values are not the same. </summary>
        public static bool operator !=(LoadBalancerOutboundRuleProtocol left, LoadBalancerOutboundRuleProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LoadBalancerOutboundRuleProtocol"/>. </summary>
        public static implicit operator LoadBalancerOutboundRuleProtocol(string value) => new LoadBalancerOutboundRuleProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LoadBalancerOutboundRuleProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LoadBalancerOutboundRuleProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
