// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtSingletonResource.Models
{
    /// <summary> The BrakeName. </summary>
    public readonly partial struct BrakeName : IEquatable<BrakeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BrakeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BrakeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "default";

        /// <summary> default. </summary>
        public static BrakeName Default { get; } = new BrakeName(DefaultValue);
        /// <summary> Determines if two <see cref="BrakeName"/> values are the same. </summary>
        public static bool operator ==(BrakeName left, BrakeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BrakeName"/> values are not the same. </summary>
        public static bool operator !=(BrakeName left, BrakeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="BrakeName"/>. </summary>
        public static implicit operator BrakeName(string value) => new BrakeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BrakeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BrakeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
