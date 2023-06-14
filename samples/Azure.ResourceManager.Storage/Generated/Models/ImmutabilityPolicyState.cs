// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked. </summary>
    public readonly partial struct ImmutabilityPolicyState : IEquatable<ImmutabilityPolicyState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ImmutabilityPolicyState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ImmutabilityPolicyState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LockedValue = "Locked";
        private const string UnlockedValue = "Unlocked";

        /// <summary> Locked. </summary>
        public static ImmutabilityPolicyState Locked { get; } = new ImmutabilityPolicyState(LockedValue);
        /// <summary> Unlocked. </summary>
        public static ImmutabilityPolicyState Unlocked { get; } = new ImmutabilityPolicyState(UnlockedValue);
        /// <summary> Determines if two <see cref="ImmutabilityPolicyState"/> values are the same. </summary>
        public static bool operator ==(ImmutabilityPolicyState left, ImmutabilityPolicyState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ImmutabilityPolicyState"/> values are not the same. </summary>
        public static bool operator !=(ImmutabilityPolicyState left, ImmutabilityPolicyState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ImmutabilityPolicyState"/>. </summary>
        public static implicit operator ImmutabilityPolicyState(string value) => new ImmutabilityPolicyState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImmutabilityPolicyState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ImmutabilityPolicyState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
