// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The NoModelAsStringNoRequiredOneValueNoDefaultEnum. </summary>
    internal readonly partial struct NoModelAsStringNoRequiredOneValueNoDefaultEnum : IEquatable<NoModelAsStringNoRequiredOneValueNoDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NoModelAsStringNoRequiredOneValueNoDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NoModelAsStringNoRequiredOneValueNoDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static NoModelAsStringNoRequiredOneValueNoDefaultEnum Value1 { get; } = new NoModelAsStringNoRequiredOneValueNoDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="NoModelAsStringNoRequiredOneValueNoDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(NoModelAsStringNoRequiredOneValueNoDefaultEnum left, NoModelAsStringNoRequiredOneValueNoDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NoModelAsStringNoRequiredOneValueNoDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(NoModelAsStringNoRequiredOneValueNoDefaultEnum left, NoModelAsStringNoRequiredOneValueNoDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NoModelAsStringNoRequiredOneValueNoDefaultEnum"/>. </summary>
        public static implicit operator NoModelAsStringNoRequiredOneValueNoDefaultEnum(string value) => new NoModelAsStringNoRequiredOneValueNoDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NoModelAsStringNoRequiredOneValueNoDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NoModelAsStringNoRequiredOneValueNoDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
