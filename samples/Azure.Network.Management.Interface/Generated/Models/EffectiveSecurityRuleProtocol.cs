// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The network protocol this rule applies to. </summary>
    public readonly partial struct EffectiveSecurityRuleProtocol : IEquatable<EffectiveSecurityRuleProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EffectiveSecurityRuleProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EffectiveSecurityRuleProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TcpValue = "Tcp";
        private const string UdpValue = "Udp";
        private const string AllValue = "All";

        /// <summary> Tcp. </summary>
        public static EffectiveSecurityRuleProtocol Tcp { get; } = new EffectiveSecurityRuleProtocol(TcpValue);
        /// <summary> Udp. </summary>
        public static EffectiveSecurityRuleProtocol Udp { get; } = new EffectiveSecurityRuleProtocol(UdpValue);
        /// <summary> All. </summary>
        public static EffectiveSecurityRuleProtocol All { get; } = new EffectiveSecurityRuleProtocol(AllValue);

        internal string ToSerialString() => _value;

        /// <summary> Determines if two <see cref="EffectiveSecurityRuleProtocol"/> values are the same. </summary>
        public static bool operator ==(EffectiveSecurityRuleProtocol left, EffectiveSecurityRuleProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EffectiveSecurityRuleProtocol"/> values are not the same. </summary>
        public static bool operator !=(EffectiveSecurityRuleProtocol left, EffectiveSecurityRuleProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EffectiveSecurityRuleProtocol"/>. </summary>
        public static implicit operator EffectiveSecurityRuleProtocol(string value) => new EffectiveSecurityRuleProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EffectiveSecurityRuleProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EffectiveSecurityRuleProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
