// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredOneValueNoDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringNoRequiredOneValueNoDefaultEnum : IEquatable<ModelAsStringNoRequiredOneValueNoDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueNoDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredOneValueNoDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredOneValueNoDefaultEnum Value1 { get; } = new ModelAsStringNoRequiredOneValueNoDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueNoDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredOneValueNoDefaultEnum left, ModelAsStringNoRequiredOneValueNoDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueNoDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredOneValueNoDefaultEnum left, ModelAsStringNoRequiredOneValueNoDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringNoRequiredOneValueNoDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredOneValueNoDefaultEnum(string value) => new ModelAsStringNoRequiredOneValueNoDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredOneValueNoDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredOneValueNoDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
