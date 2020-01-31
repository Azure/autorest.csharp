// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace AnotherCustomNamespace
{
    /// <summary> Fruit. </summary>
    internal readonly partial struct CustomFruitEnum : IEquatable<CustomFruitEnum>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="CustomFruitEnum"/> values are the same. </summary>
        public CustomFruitEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AppleValue = "apple";
        private const string PearValue = "pear";

        /// <summary> apple. </summary>
        public static CustomFruitEnum Apple { get; } = new CustomFruitEnum(AppleValue);
        /// <summary> pear. </summary>
        public static CustomFruitEnum Pear { get; } = new CustomFruitEnum(PearValue);
        /// <summary> Determines if two <see cref="CustomFruitEnum"/> values are the same. </summary>
        public static bool operator ==(CustomFruitEnum left, CustomFruitEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CustomFruitEnum"/> values are not the same. </summary>
        public static bool operator !=(CustomFruitEnum left, CustomFruitEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CustomFruitEnum"/>. </summary>
        public static implicit operator CustomFruitEnum(string value) => new CustomFruitEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CustomFruitEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CustomFruitEnum other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
