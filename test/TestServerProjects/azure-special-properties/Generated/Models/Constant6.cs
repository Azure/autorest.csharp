// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace azure_special_properties.Models
{
    /// <summary> The Constant6. </summary>
    public readonly partial struct Constant6 : IEquatable<Constant6>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="Constant6"/>. </summary>
        public Constant6(int value)
        {
            _value = value;
        }

        private const int _0Value = 0;

        /// <summary> 0. </summary>
        public static Constant6 _0 { get; } = new Constant6(_0Value);
        /// <summary> Determines if two <see cref="Constant6"/> values are the same. </summary>
        public static bool operator ==(Constant6 left, Constant6 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Constant6"/> values are not the same. </summary>
        public static bool operator !=(Constant6 left, Constant6 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Constant6"/>. </summary>
        public static implicit operator Constant6(int value) => new Constant6(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Constant6 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Constant6 other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
