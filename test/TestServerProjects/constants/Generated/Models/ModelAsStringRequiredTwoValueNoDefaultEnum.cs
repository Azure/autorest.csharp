// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueNoDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringRequiredTwoValueNoDefaultEnum : IEquatable<ModelAsStringRequiredTwoValueNoDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueNoDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringRequiredTwoValueNoDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringRequiredTwoValueNoDefaultEnum Value1 { get; } = new ModelAsStringRequiredTwoValueNoDefaultEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringRequiredTwoValueNoDefaultEnum Value2 { get; } = new ModelAsStringRequiredTwoValueNoDefaultEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueNoDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringRequiredTwoValueNoDefaultEnum left, ModelAsStringRequiredTwoValueNoDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueNoDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringRequiredTwoValueNoDefaultEnum left, ModelAsStringRequiredTwoValueNoDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringRequiredTwoValueNoDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringRequiredTwoValueNoDefaultEnum(string value) => new ModelAsStringRequiredTwoValueNoDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringRequiredTwoValueNoDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringRequiredTwoValueNoDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
