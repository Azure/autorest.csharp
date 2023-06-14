// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace validation.Models
{
    /// <summary> Constant string. </summary>
    public readonly partial struct ProductConstString : IEquatable<ProductConstString>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProductConstString"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProductConstString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConstantValue = "constant";

        /// <summary> constant. </summary>
        public static ProductConstString Constant { get; } = new ProductConstString(ConstantValue);
        /// <summary> Determines if two <see cref="ProductConstString"/> values are the same. </summary>
        public static bool operator ==(ProductConstString left, ProductConstString right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProductConstString"/> values are not the same. </summary>
        public static bool operator !=(ProductConstString left, ProductConstString right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProductConstString"/>. </summary>
        public static implicit operator ProductConstString(string value) => new ProductConstString(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProductConstString other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProductConstString other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
