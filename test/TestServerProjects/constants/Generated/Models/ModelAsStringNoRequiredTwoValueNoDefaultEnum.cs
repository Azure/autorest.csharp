// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredTwoValueNoDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringNoRequiredTwoValueNoDefaultEnum : IEquatable<ModelAsStringNoRequiredTwoValueNoDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredTwoValueNoDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredTwoValueNoDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredTwoValueNoDefaultEnum Value1 { get; } = new ModelAsStringNoRequiredTwoValueNoDefaultEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringNoRequiredTwoValueNoDefaultEnum Value2 { get; } = new ModelAsStringNoRequiredTwoValueNoDefaultEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueNoDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredTwoValueNoDefaultEnum left, ModelAsStringNoRequiredTwoValueNoDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueNoDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredTwoValueNoDefaultEnum left, ModelAsStringNoRequiredTwoValueNoDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringNoRequiredTwoValueNoDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredTwoValueNoDefaultEnum(string value) => new ModelAsStringNoRequiredTwoValueNoDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredTwoValueNoDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredTwoValueNoDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
