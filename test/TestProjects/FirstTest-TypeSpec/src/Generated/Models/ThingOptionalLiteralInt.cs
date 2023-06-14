// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The Thing_optionalLiteralInt. </summary>
    public readonly partial struct ThingOptionalLiteralInt : IEquatable<ThingOptionalLiteralInt>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="ThingOptionalLiteralInt"/>. </summary>
        public ThingOptionalLiteralInt(int value)
        {
            _value = value;
        }

        private const int _456Value = 456;

        /// <summary> 456. </summary>
        public static ThingOptionalLiteralInt _456 { get; } = new ThingOptionalLiteralInt(_456Value);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="ThingOptionalLiteralInt"/> values are the same. </summary>
        public static bool operator ==(ThingOptionalLiteralInt left, ThingOptionalLiteralInt right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThingOptionalLiteralInt"/> values are not the same. </summary>
        public static bool operator !=(ThingOptionalLiteralInt left, ThingOptionalLiteralInt right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ThingOptionalLiteralInt"/>. </summary>
        public static implicit operator ThingOptionalLiteralInt(int value) => new ThingOptionalLiteralInt(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingOptionalLiteralInt other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThingOptionalLiteralInt other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
