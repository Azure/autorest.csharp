// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend. </summary>
    public readonly partial struct ImmutabilityPolicyUpdateType : IEquatable<ImmutabilityPolicyUpdateType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ImmutabilityPolicyUpdateType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ImmutabilityPolicyUpdateType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PutValue = "put";
        private const string LockValue = "lock";
        private const string ExtendValue = "extend";

        /// <summary> put. </summary>
        public static ImmutabilityPolicyUpdateType Put { get; } = new ImmutabilityPolicyUpdateType(PutValue);
        /// <summary> lock. </summary>
        public static ImmutabilityPolicyUpdateType Lock { get; } = new ImmutabilityPolicyUpdateType(LockValue);
        /// <summary> extend. </summary>
        public static ImmutabilityPolicyUpdateType Extend { get; } = new ImmutabilityPolicyUpdateType(ExtendValue);
        /// <summary> Determines if two <see cref="ImmutabilityPolicyUpdateType"/> values are the same. </summary>
        public static bool operator ==(ImmutabilityPolicyUpdateType left, ImmutabilityPolicyUpdateType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ImmutabilityPolicyUpdateType"/> values are not the same. </summary>
        public static bool operator !=(ImmutabilityPolicyUpdateType left, ImmutabilityPolicyUpdateType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ImmutabilityPolicyUpdateType"/>. </summary>
        public static implicit operator ImmutabilityPolicyUpdateType(string value) => new ImmutabilityPolicyUpdateType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImmutabilityPolicyUpdateType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ImmutabilityPolicyUpdateType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
