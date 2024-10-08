// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueDefaultEnum. </summary>
    internal readonly partial struct ModelAsStringRequiredTwoValueDefaultEnum : IEquatable<ModelAsStringRequiredTwoValueDefaultEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefaultEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringRequiredTwoValueDefaultEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringRequiredTwoValueDefaultEnum Value1 { get; } = new ModelAsStringRequiredTwoValueDefaultEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringRequiredTwoValueDefaultEnum Value2 { get; } = new ModelAsStringRequiredTwoValueDefaultEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueDefaultEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringRequiredTwoValueDefaultEnum left, ModelAsStringRequiredTwoValueDefaultEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueDefaultEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringRequiredTwoValueDefaultEnum left, ModelAsStringRequiredTwoValueDefaultEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ModelAsStringRequiredTwoValueDefaultEnum"/>. </summary>
        public static implicit operator ModelAsStringRequiredTwoValueDefaultEnum(string value) => new ModelAsStringRequiredTwoValueDefaultEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringRequiredTwoValueDefaultEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringRequiredTwoValueDefaultEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
