// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU Family of the managed HSM Pool. </summary>
    public readonly partial struct ManagedHsmSkuFamily : IEquatable<ManagedHsmSkuFamily>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ManagedHsmSkuFamily"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ManagedHsmSkuFamily(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "B";

        /// <summary> B. </summary>
        public static ManagedHsmSkuFamily B { get; } = new ManagedHsmSkuFamily(BValue);
        /// <summary> Determines if two <see cref="ManagedHsmSkuFamily"/> values are the same. </summary>
        public static bool operator ==(ManagedHsmSkuFamily left, ManagedHsmSkuFamily right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ManagedHsmSkuFamily"/> values are not the same. </summary>
        public static bool operator !=(ManagedHsmSkuFamily left, ManagedHsmSkuFamily right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ManagedHsmSkuFamily"/>. </summary>
        public static implicit operator ManagedHsmSkuFamily(string value) => new ManagedHsmSkuFamily(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManagedHsmSkuFamily other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ManagedHsmSkuFamily other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
