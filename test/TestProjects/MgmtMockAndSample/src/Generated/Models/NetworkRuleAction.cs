// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated. </summary>
    public readonly partial struct NetworkRuleAction : IEquatable<NetworkRuleAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetworkRuleAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NetworkRuleAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";
        private const string DenyValue = "Deny";

        /// <summary> Allow. </summary>
        public static NetworkRuleAction Allow { get; } = new NetworkRuleAction(AllowValue);
        /// <summary> Deny. </summary>
        public static NetworkRuleAction Deny { get; } = new NetworkRuleAction(DenyValue);
        /// <summary> Determines if two <see cref="NetworkRuleAction"/> values are the same. </summary>
        public static bool operator ==(NetworkRuleAction left, NetworkRuleAction right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NetworkRuleAction"/> values are not the same. </summary>
        public static bool operator !=(NetworkRuleAction left, NetworkRuleAction right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NetworkRuleAction"/>. </summary>
        public static implicit operator NetworkRuleAction(string value) => new NetworkRuleAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NetworkRuleAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NetworkRuleAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
