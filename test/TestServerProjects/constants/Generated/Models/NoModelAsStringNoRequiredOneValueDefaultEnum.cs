// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The NoModelAsStringNoRequiredOneValueDefaultEnum. </summary>
    internal readonly partial struct NoModelAsStringNoRequiredOneValueDefaultEnum : IEquatable<NoModelAsStringNoRequiredOneValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NoModelAsStringNoRequiredOneValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NoModelAsStringNoRequiredOneValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static NoModelAsStringNoRequiredOneValueDefaultEnum Value1 { get; } = new NoModelAsStringNoRequiredOneValueDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="NoModelAsStringNoRequiredOneValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(NoModelAsStringNoRequiredOneValueDefaultEnum left, NoModelAsStringNoRequiredOneValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NoModelAsStringNoRequiredOneValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(NoModelAsStringNoRequiredOneValueDefaultEnum left, NoModelAsStringNoRequiredOneValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="NoModelAsStringNoRequiredOneValueDefaultEnum"/>. </summary>
        public static implicit operator NoModelAsStringNoRequiredOneValueDefaultEnum(string value) => new NoModelAsStringNoRequiredOneValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NoModelAsStringNoRequiredOneValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NoModelAsStringNoRequiredOneValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
