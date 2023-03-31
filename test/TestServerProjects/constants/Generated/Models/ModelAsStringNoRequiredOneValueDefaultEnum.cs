// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredOneValueDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringNoRequiredOneValueDefaultEnum : IEquatable<ModelAsStringNoRequiredOneValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredOneValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredOneValueDefaultEnum Value1 { get; } = new ModelAsStringNoRequiredOneValueDefaultEnum(Value1Value);

        internal string ToSerialString() => _value;

        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredOneValueDefaultEnum left, ModelAsStringNoRequiredOneValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredOneValueDefaultEnum left, ModelAsStringNoRequiredOneValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringNoRequiredOneValueDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredOneValueDefaultEnum(string value) => new ModelAsStringNoRequiredOneValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredOneValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredOneValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
