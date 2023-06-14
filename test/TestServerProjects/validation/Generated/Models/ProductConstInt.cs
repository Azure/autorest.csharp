// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace validation.Models
{
    /// <summary> Constant int. </summary>
    public readonly partial struct ProductConstInt : IEquatable<ProductConstInt>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="ProductConstInt"/>. </summary>
        public ProductConstInt(int value)
        {
            _value = value;
        }

        private const int _0Value = 0;

        /// <summary> 0. </summary>
        public static ProductConstInt _0 { get; } = new ProductConstInt(_0Value);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="ProductConstInt"/> values are the same. </summary>
        public static bool operator ==(ProductConstInt left, ProductConstInt right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProductConstInt"/> values are not the same. </summary>
        public static bool operator !=(ProductConstInt left, ProductConstInt right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProductConstInt"/>. </summary>
        public static implicit operator ProductConstInt(int value) => new ProductConstInt(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProductConstInt other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProductConstInt other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
