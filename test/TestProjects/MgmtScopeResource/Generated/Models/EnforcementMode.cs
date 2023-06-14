// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtScopeResource.Models
{
    /// <summary> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </summary>
    public readonly partial struct EnforcementMode : IEquatable<EnforcementMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EnforcementMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EnforcementMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "Default";
        private const string DoNotEnforceValue = "DoNotEnforce";

        /// <summary> The policy effect is enforced during resource creation or update. </summary>
        public static EnforcementMode Default { get; } = new EnforcementMode(DefaultValue);
        /// <summary> The policy effect is not enforced during resource creation or update. </summary>
        public static EnforcementMode DoNotEnforce { get; } = new EnforcementMode(DoNotEnforceValue);
        /// <summary> Determines if two <see cref="EnforcementMode"/> values are the same. </summary>
        public static bool operator ==(EnforcementMode left, EnforcementMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EnforcementMode"/> values are not the same. </summary>
        public static bool operator !=(EnforcementMode left, EnforcementMode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EnforcementMode"/>. </summary>
        public static implicit operator EnforcementMode(string value) => new EnforcementMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnforcementMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EnforcementMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
