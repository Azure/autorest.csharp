// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Whether network traffic is allowed or denied. </summary>
    public readonly partial struct SecurityRuleAccess : IEquatable<SecurityRuleAccess>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SecurityRuleAccess"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SecurityRuleAccess(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";
        private const string DenyValue = "Deny";

        /// <summary> Allow. </summary>
        public static SecurityRuleAccess Allow { get; } = new SecurityRuleAccess(AllowValue);
        /// <summary> Deny. </summary>
        public static SecurityRuleAccess Deny { get; } = new SecurityRuleAccess(DenyValue);
        /// <summary> Determines if two <see cref="SecurityRuleAccess"/> values are the same. </summary>
        public static bool operator ==(SecurityRuleAccess left, SecurityRuleAccess right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SecurityRuleAccess"/> values are not the same. </summary>
        public static bool operator !=(SecurityRuleAccess left, SecurityRuleAccess right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SecurityRuleAccess"/>. </summary>
        public static implicit operator SecurityRuleAccess(string value) => new SecurityRuleAccess(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecurityRuleAccess other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SecurityRuleAccess other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
