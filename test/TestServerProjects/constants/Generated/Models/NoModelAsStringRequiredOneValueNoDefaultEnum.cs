// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredOneValueNoDefaultEnum. </summary>
    internal readonly partial struct NoModelAsStringRequiredOneValueNoDefaultEnum : IEquatable<NoModelAsStringRequiredOneValueNoDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NoModelAsStringRequiredOneValueNoDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NoModelAsStringRequiredOneValueNoDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static NoModelAsStringRequiredOneValueNoDefaultEnum Value1 { get; } = new NoModelAsStringRequiredOneValueNoDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="NoModelAsStringRequiredOneValueNoDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(NoModelAsStringRequiredOneValueNoDefaultEnum left, NoModelAsStringRequiredOneValueNoDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NoModelAsStringRequiredOneValueNoDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(NoModelAsStringRequiredOneValueNoDefaultEnum left, NoModelAsStringRequiredOneValueNoDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="NoModelAsStringRequiredOneValueNoDefaultEnum"/>. </summary>
        public static implicit operator NoModelAsStringRequiredOneValueNoDefaultEnum(string value) => new NoModelAsStringRequiredOneValueNoDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NoModelAsStringRequiredOneValueNoDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NoModelAsStringRequiredOneValueNoDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
