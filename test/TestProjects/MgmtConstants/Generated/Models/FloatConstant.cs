// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace MgmtConstants.Models
{
    /// <summary> A constant based on float. </summary>
    public readonly partial struct FloatConstant : IEquatable<FloatConstant>
    {
        private readonly float _value;

        /// <summary> Initializes a new instance of <see cref="FloatConstant"/>. </summary>
        public FloatConstant(float value)
        {
            _value = value;
        }

        private const float _314Value = 3.14F;

        /// <summary> 3.14. </summary>
        public static FloatConstant _314 { get; } = new FloatConstant(_314Value);

        internal float ToSerialSingle() => _value;

        /// <summary> Determines if two <see cref="FloatConstant"/> values are the same. </summary>
        public static bool operator ==(FloatConstant left, FloatConstant right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FloatConstant"/> values are not the same. </summary>
        public static bool operator !=(FloatConstant left, FloatConstant right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FloatConstant"/>. </summary>
        public static implicit operator FloatConstant(float value) => new FloatConstant(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FloatConstant other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FloatConstant other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
