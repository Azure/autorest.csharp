// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> The StringLiteralProperty_property. </summary>
    public readonly partial struct StringLiteralPropertyProperty : IEquatable<StringLiteralPropertyProperty>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StringLiteralPropertyProperty"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StringLiteralPropertyProperty(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HelloValue = "hello";

        /// <summary> hello. </summary>
        public static StringLiteralPropertyProperty Hello { get; } = new StringLiteralPropertyProperty(HelloValue);
        /// <summary> Determines if two <see cref="StringLiteralPropertyProperty"/> values are the same. </summary>
        public static bool operator ==(StringLiteralPropertyProperty left, StringLiteralPropertyProperty right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StringLiteralPropertyProperty"/> values are not the same. </summary>
        public static bool operator !=(StringLiteralPropertyProperty left, StringLiteralPropertyProperty right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StringLiteralPropertyProperty"/>. </summary>
        public static implicit operator StringLiteralPropertyProperty(string value) => new StringLiteralPropertyProperty(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StringLiteralPropertyProperty other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StringLiteralPropertyProperty other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
