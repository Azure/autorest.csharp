// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueDefaultOpEnum. </summary>
    public readonly partial struct ModelAsStringRequiredTwoValueDefaultOpEnum : IEquatable<ModelAsStringRequiredTwoValueDefaultOpEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefaultOpEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringRequiredTwoValueDefaultOpEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringRequiredTwoValueDefaultOpEnum Value1 { get; } = new ModelAsStringRequiredTwoValueDefaultOpEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringRequiredTwoValueDefaultOpEnum Value2 { get; } = new ModelAsStringRequiredTwoValueDefaultOpEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueDefaultOpEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringRequiredTwoValueDefaultOpEnum left, ModelAsStringRequiredTwoValueDefaultOpEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringRequiredTwoValueDefaultOpEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringRequiredTwoValueDefaultOpEnum left, ModelAsStringRequiredTwoValueDefaultOpEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ModelAsStringRequiredTwoValueDefaultOpEnum"/>. </summary>
        public static implicit operator ModelAsStringRequiredTwoValueDefaultOpEnum(string value) => new ModelAsStringRequiredTwoValueDefaultOpEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringRequiredTwoValueDefaultOpEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringRequiredTwoValueDefaultOpEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
