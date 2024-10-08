// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredTwoValueDefaultOpEnum. </summary>
    public readonly partial struct ModelAsStringNoRequiredTwoValueDefaultOpEnum : IEquatable<ModelAsStringNoRequiredTwoValueDefaultOpEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredTwoValueDefaultOpEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ModelAsStringNoRequiredTwoValueDefaultOpEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static ModelAsStringNoRequiredTwoValueDefaultOpEnum Value1 { get; } = new ModelAsStringNoRequiredTwoValueDefaultOpEnum(Value1Value);
        /// <summary> value2. </summary>
        public static ModelAsStringNoRequiredTwoValueDefaultOpEnum Value2 { get; } = new ModelAsStringNoRequiredTwoValueDefaultOpEnum(Value2Value);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueDefaultOpEnum"/> values are the same. </summary>
        public static bool operator ==(ModelAsStringNoRequiredTwoValueDefaultOpEnum left, ModelAsStringNoRequiredTwoValueDefaultOpEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ModelAsStringNoRequiredTwoValueDefaultOpEnum"/> values are not the same. </summary>
        public static bool operator !=(ModelAsStringNoRequiredTwoValueDefaultOpEnum left, ModelAsStringNoRequiredTwoValueDefaultOpEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ModelAsStringNoRequiredTwoValueDefaultOpEnum"/>. </summary>
        public static implicit operator ModelAsStringNoRequiredTwoValueDefaultOpEnum(string value) => new ModelAsStringNoRequiredTwoValueDefaultOpEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ModelAsStringNoRequiredTwoValueDefaultOpEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ModelAsStringNoRequiredTwoValueDefaultOpEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
