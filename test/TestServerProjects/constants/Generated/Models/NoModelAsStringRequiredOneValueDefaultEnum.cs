// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredOneValueDefaultEnum. </summary>
    internal readonly partial struct NoModelAsStringRequiredOneValueDefaultEnum : IEquatable<NoModelAsStringRequiredOneValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NoModelAsStringRequiredOneValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NoModelAsStringRequiredOneValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static NoModelAsStringRequiredOneValueDefaultEnum Value1 { get; } = new NoModelAsStringRequiredOneValueDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="NoModelAsStringRequiredOneValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(NoModelAsStringRequiredOneValueDefaultEnum left, NoModelAsStringRequiredOneValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NoModelAsStringRequiredOneValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(NoModelAsStringRequiredOneValueDefaultEnum left, NoModelAsStringRequiredOneValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="NoModelAsStringRequiredOneValueDefaultEnum"/>. </summary>
        public static implicit operator NoModelAsStringRequiredOneValueDefaultEnum(string value) => new NoModelAsStringRequiredOneValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NoModelAsStringRequiredOneValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NoModelAsStringRequiredOneValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
