// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace body_string.Models
{
    /// <summary> Referenced Color Constant Description. </summary>
    public readonly partial struct ColorConstant : IEquatable<ColorConstant>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ColorConstant"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ColorConstant(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string GreenColorValue = "green-color";

        /// <summary> green-color. </summary>
        public static ColorConstant GreenColor { get; } = new ColorConstant(GreenColorValue);
        /// <summary> Determines if two <see cref="ColorConstant"/> values are the same. </summary>
        public static bool operator ==(ColorConstant left, ColorConstant right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ColorConstant"/> values are not the same. </summary>
        public static bool operator !=(ColorConstant left, ColorConstant right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ColorConstant"/>. </summary>
        public static implicit operator ColorConstant(string value) => new ColorConstant(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ColorConstant other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ColorConstant other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
