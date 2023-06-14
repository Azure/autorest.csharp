// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The action type of a rule. </summary>
    public readonly partial struct FirewallPolicyFilterRuleCollectionActionType : IEquatable<FirewallPolicyFilterRuleCollectionActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyFilterRuleCollectionActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicyFilterRuleCollectionActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";
        private const string DenyValue = "Deny";

        /// <summary> Allow. </summary>
        public static FirewallPolicyFilterRuleCollectionActionType Allow { get; } = new FirewallPolicyFilterRuleCollectionActionType(AllowValue);
        /// <summary> Deny. </summary>
        public static FirewallPolicyFilterRuleCollectionActionType Deny { get; } = new FirewallPolicyFilterRuleCollectionActionType(DenyValue);
        /// <summary> Determines if two <see cref="FirewallPolicyFilterRuleCollectionActionType"/> values are the same. </summary>
        public static bool operator ==(FirewallPolicyFilterRuleCollectionActionType left, FirewallPolicyFilterRuleCollectionActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirewallPolicyFilterRuleCollectionActionType"/> values are not the same. </summary>
        public static bool operator !=(FirewallPolicyFilterRuleCollectionActionType left, FirewallPolicyFilterRuleCollectionActionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyFilterRuleCollectionActionType"/>. </summary>
        public static implicit operator FirewallPolicyFilterRuleCollectionActionType(string value) => new FirewallPolicyFilterRuleCollectionActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicyFilterRuleCollectionActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirewallPolicyFilterRuleCollectionActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
