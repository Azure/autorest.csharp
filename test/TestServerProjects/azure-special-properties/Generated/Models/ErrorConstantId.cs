// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace azure_special_properties.Models
{
    /// <summary> The ErrorConstantId. </summary>
    internal readonly partial struct ErrorConstantId : IEquatable<ErrorConstantId>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="ErrorConstantId"/>. </summary>
        public ErrorConstantId(int value)
        {
            _value = value;
        }

        private const int _1Value = 1;

        /// <summary> 1. </summary>
        public static ErrorConstantId _1 { get; } = new ErrorConstantId(_1Value);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="ErrorConstantId"/> values are the same. </summary>
        public static bool operator ==(ErrorConstantId left, ErrorConstantId right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ErrorConstantId"/> values are not the same. </summary>
        public static bool operator !=(ErrorConstantId left, ErrorConstantId right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ErrorConstantId"/>. </summary>
        public static implicit operator ErrorConstantId(int value) => new ErrorConstantId(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ErrorConstantId other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ErrorConstantId other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
