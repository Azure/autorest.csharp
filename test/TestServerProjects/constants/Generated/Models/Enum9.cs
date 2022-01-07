// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace Constants.Models
{
    /// <summary> The Enum9. </summary>
    public readonly partial struct Enum9 : IEquatable<Enum9>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="Enum9"/>. </summary>
        public Enum9(int value)
        {
            _value = value;
        }

        private const int OneHundredValue = 100;

        /// <summary> 100. </summary>
        public static Enum9 OneHundred { get; } = new Enum9(OneHundredValue);
        /// <summary> Determines if two <see cref="Enum9"/> values are the same. </summary>
        public static bool operator ==(Enum9 left, Enum9 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum9"/> values are not the same. </summary>
        public static bool operator !=(Enum9 left, Enum9 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum9"/>. </summary>
        public static implicit operator Enum9(int value) => new Enum9(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Enum9 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum9 other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
