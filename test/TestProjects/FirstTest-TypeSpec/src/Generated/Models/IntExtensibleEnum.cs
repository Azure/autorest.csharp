// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace FirstTestTypeSpec.Models
{
    /// <summary> Int based extensible enum. </summary>
    public readonly partial struct IntExtensibleEnum : IEquatable<IntExtensibleEnum>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="IntExtensibleEnum"/>. </summary>
        public IntExtensibleEnum(int value)
        {
            _value = value;
        }

        private const int OneValue = 1;
        private const int TwoValue = 2;
        private const int FourValue = 4;

        /// <summary> 1. </summary>
        public static IntExtensibleEnum One { get; } = new IntExtensibleEnum(OneValue);
        /// <summary> 2. </summary>
        public static IntExtensibleEnum Two { get; } = new IntExtensibleEnum(TwoValue);
        /// <summary> 4. </summary>
        public static IntExtensibleEnum Four { get; } = new IntExtensibleEnum(FourValue);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="IntExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(IntExtensibleEnum left, IntExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IntExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(IntExtensibleEnum left, IntExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IntExtensibleEnum"/>. </summary>
        public static implicit operator IntExtensibleEnum(int value) => new IntExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IntExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IntExtensibleEnum other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
