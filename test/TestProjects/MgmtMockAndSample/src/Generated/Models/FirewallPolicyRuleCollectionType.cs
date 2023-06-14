// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The type of the rule collection. </summary>
    internal readonly partial struct FirewallPolicyRuleCollectionType : IEquatable<FirewallPolicyRuleCollectionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRuleCollectionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicyRuleCollectionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FirewallPolicyNatRuleCollectionValue = "FirewallPolicyNatRuleCollection";
        private const string FirewallPolicyFilterRuleCollectionValue = "FirewallPolicyFilterRuleCollection";

        /// <summary> FirewallPolicyNatRuleCollection. </summary>
        public static FirewallPolicyRuleCollectionType FirewallPolicyNatRuleCollection { get; } = new FirewallPolicyRuleCollectionType(FirewallPolicyNatRuleCollectionValue);
        /// <summary> FirewallPolicyFilterRuleCollection. </summary>
        public static FirewallPolicyRuleCollectionType FirewallPolicyFilterRuleCollection { get; } = new FirewallPolicyRuleCollectionType(FirewallPolicyFilterRuleCollectionValue);
        /// <summary> Determines if two <see cref="FirewallPolicyRuleCollectionType"/> values are the same. </summary>
        public static bool operator ==(FirewallPolicyRuleCollectionType left, FirewallPolicyRuleCollectionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirewallPolicyRuleCollectionType"/> values are not the same. </summary>
        public static bool operator !=(FirewallPolicyRuleCollectionType left, FirewallPolicyRuleCollectionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyRuleCollectionType"/>. </summary>
        public static implicit operator FirewallPolicyRuleCollectionType(string value) => new FirewallPolicyRuleCollectionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicyRuleCollectionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirewallPolicyRuleCollectionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
