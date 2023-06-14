// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredOneValueDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringRequiredOneValueDefaultEnum : IEquatable<ModelAsStringRequiredOneValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredOneValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringRequiredOneValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static ModelAsStringRequiredOneValueDefaultEnum Value1 { get; } = new ModelAsStringRequiredOneValueDefaultEnum(Value1Value);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredOneValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringRequiredOneValueDefaultEnum left, ModelAsStringRequiredOneValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredOneValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringRequiredOneValueDefaultEnum left, ModelAsStringRequiredOneValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringRequiredOneValueDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringRequiredOneValueDefaultEnum(string value) => new ModelAsStringRequiredOneValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringRequiredOneValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringRequiredOneValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
