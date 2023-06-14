// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredOneValueNoDefaultOpEnum. </summary>
    public readonly partial struct ModelAsStringNoRequiredOneValueNoDefaultOpEnum : IEquatable<ModelAsStringNoRequiredOneValueNoDefaultOpEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueNoDefaultOpEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredOneValueNoDefaultOpEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredOneValueNoDefaultOpEnum Value1 { get; } = new ModelAsStringNoRequiredOneValueNoDefaultOpEnum(Value1Value);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueNoDefaultOpEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredOneValueNoDefaultOpEnum left, ModelAsStringNoRequiredOneValueNoDefaultOpEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredOneValueNoDefaultOpEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredOneValueNoDefaultOpEnum left, ModelAsStringNoRequiredOneValueNoDefaultOpEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringNoRequiredOneValueNoDefaultOpEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredOneValueNoDefaultOpEnum(string value) => new ModelAsStringNoRequiredOneValueNoDefaultOpEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredOneValueNoDefaultOpEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredOneValueNoDefaultOpEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
