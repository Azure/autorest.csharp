// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace MgmtConstants.Models
{
    /// <summary> A constant based on integer. </summary>
    public readonly partial struct IntConstant : IEquatable<IntConstant>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="IntConstant"/>. </summary>
        public IntConstant(int value)
        {
            _value = value;
        }

        private const int _0Value = 0;

        /// <summary> 0. </summary>
        public static IntConstant _0 { get; } = new IntConstant(_0Value);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="IntConstant"/> values are the same. </summary>
        public static bool operator ==(IntConstant left, IntConstant right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IntConstant"/> values are not the same. </summary>
        public static bool operator !=(IntConstant left, IntConstant right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IntConstant"/>. </summary>
        public static implicit operator IntConstant(int value) => new IntConstant(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IntConstant other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IntConstant other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
