// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredOneValueDefaultOpEnum. </summary>
    public readonly partial struct ModelAsStringRequiredOneValueDefaultOpEnum : IEquatable<ModelAsStringRequiredOneValueDefaultOpEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredOneValueDefaultOpEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringRequiredOneValueDefaultOpEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static ModelAsStringRequiredOneValueDefaultOpEnum Value1 { get; } = new ModelAsStringRequiredOneValueDefaultOpEnum(Value1Value);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredOneValueDefaultOpEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringRequiredOneValueDefaultOpEnum left, ModelAsStringRequiredOneValueDefaultOpEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredOneValueDefaultOpEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringRequiredOneValueDefaultOpEnum left, ModelAsStringRequiredOneValueDefaultOpEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringRequiredOneValueDefaultOpEnum"/>. </summary>
        public static implicit operator ModelAsStringRequiredOneValueDefaultOpEnum(string value) => new ModelAsStringRequiredOneValueDefaultOpEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringRequiredOneValueDefaultOpEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringRequiredOneValueDefaultOpEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
