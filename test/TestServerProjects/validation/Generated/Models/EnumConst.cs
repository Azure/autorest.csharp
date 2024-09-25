// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace validation.Models
{
    /// <summary> Constant string as Enum. </summary>
    public readonly partial struct EnumConst : IEquatable<EnumConst>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EnumConst"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EnumConst(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConstantStringAsEnumValue = "constant_string_as_enum";

        /// <summary> constant_string_as_enum. </summary>
        public static EnumConst ConstantStringAsEnum { get; } = new EnumConst(ConstantStringAsEnumValue);
        /// <summary> Determines if two <see cref="EnumConst"/> values are the same. </summary>
        public static bool operator ==(EnumConst left, EnumConst right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EnumConst"/> values are not the same. </summary>
        public static bool operator !=(EnumConst left, EnumConst right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EnumConst"/>. </summary>
        public static implicit operator EnumConst(string value) => new EnumConst(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnumConst other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EnumConst other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
