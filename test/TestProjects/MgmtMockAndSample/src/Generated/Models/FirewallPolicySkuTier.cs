// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> Tier of Firewall Policy. </summary>
    public readonly partial struct FirewallPolicySkuTier : IEquatable<FirewallPolicySkuTier>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicySkuTier"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicySkuTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StandardValue = "Standard";
        private const string PremiumValue = "Premium";

        /// <summary> Standard. </summary>
        public static FirewallPolicySkuTier Standard { get; } = new FirewallPolicySkuTier(StandardValue);
        /// <summary> Premium. </summary>
        public static FirewallPolicySkuTier Premium { get; } = new FirewallPolicySkuTier(PremiumValue);
        /// <summary> Determines if two <see cref="FirewallPolicySkuTier"/> values are the same. </summary>
        public static bool operator ==(FirewallPolicySkuTier left, FirewallPolicySkuTier right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirewallPolicySkuTier"/> values are not the same. </summary>
        public static bool operator !=(FirewallPolicySkuTier left, FirewallPolicySkuTier right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicySkuTier"/>. </summary>
        public static implicit operator FirewallPolicySkuTier(string value) => new FirewallPolicySkuTier(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicySkuTier other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirewallPolicySkuTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
