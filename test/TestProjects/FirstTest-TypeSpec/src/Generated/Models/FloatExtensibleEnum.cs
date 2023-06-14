// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace FirstTestTypeSpec.Models
{
    /// <summary> Float based extensible enum. </summary>
    public readonly partial struct FloatExtensibleEnum : IEquatable<FloatExtensibleEnum>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="FloatExtensibleEnum"/>. </summary>
        public FloatExtensibleEnum(int value)
        {
            _value = value;
        }

        private const int OneValue = 1;
        private const int TwoValue = 2;
        private const int FourValue = 4;

        /// <summary> 1. </summary>
        public static FloatExtensibleEnum One { get; } = new FloatExtensibleEnum(OneValue);
        /// <summary> 2. </summary>
        public static FloatExtensibleEnum Two { get; } = new FloatExtensibleEnum(TwoValue);
        /// <summary> 4. </summary>
        public static FloatExtensibleEnum Four { get; } = new FloatExtensibleEnum(FourValue);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="FloatExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(FloatExtensibleEnum left, FloatExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FloatExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(FloatExtensibleEnum left, FloatExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FloatExtensibleEnum"/>. </summary>
        public static implicit operator FloatExtensibleEnum(int value) => new FloatExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FloatExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FloatExtensibleEnum other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
