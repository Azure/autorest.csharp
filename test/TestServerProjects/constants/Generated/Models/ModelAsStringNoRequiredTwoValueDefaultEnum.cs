// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredTwoValueDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringNoRequiredTwoValueDefaultEnum : IEquatable<ModelAsStringNoRequiredTwoValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredTwoValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredTwoValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredTwoValueDefaultEnum Value1 { get; } = new ModelAsStringNoRequiredTwoValueDefaultEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringNoRequiredTwoValueDefaultEnum Value2 { get; } = new ModelAsStringNoRequiredTwoValueDefaultEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredTwoValueDefaultEnum left, ModelAsStringNoRequiredTwoValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredTwoValueDefaultEnum left, ModelAsStringNoRequiredTwoValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringNoRequiredTwoValueDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredTwoValueDefaultEnum(string value) => new ModelAsStringNoRequiredTwoValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredTwoValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredTwoValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
