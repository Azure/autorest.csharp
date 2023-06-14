// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Algorithm to use for URL signing. </summary>
    public readonly partial struct Algorithm : IEquatable<Algorithm>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Algorithm"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Algorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SHA256Value = "SHA256";

        /// <summary> SHA256. </summary>
        public static Algorithm SHA256 { get; } = new Algorithm(SHA256Value);
        /// <summary> Determines if two <see cref="Algorithm"/> values are the same. </summary>
        public static bool operator ==(Algorithm left, Algorithm right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Algorithm"/> values are not the same. </summary>
        public static bool operator !=(Algorithm left, Algorithm right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Algorithm"/>. </summary>
        public static implicit operator Algorithm(string value) => new Algorithm(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Algorithm other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Algorithm other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
