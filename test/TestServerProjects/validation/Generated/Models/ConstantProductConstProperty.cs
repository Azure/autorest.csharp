// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace validation.Models
{
    /// <summary> Constant string. </summary>
    public readonly partial struct ConstantProductConstProperty : IEquatable<ConstantProductConstProperty>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConstantProductConstProperty"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ConstantProductConstProperty(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConstantValue = "constant";

        /// <summary> constant. </summary>
        public static ConstantProductConstProperty Constant { get; } = new ConstantProductConstProperty(ConstantValue);
        /// <summary> Determines if two <see cref="ConstantProductConstProperty"/> values are the same. </summary>
        public static bool operator ==(ConstantProductConstProperty left, ConstantProductConstProperty right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConstantProductConstProperty"/> values are not the same. </summary>
        public static bool operator !=(ConstantProductConstProperty left, ConstantProductConstProperty right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ConstantProductConstProperty"/>. </summary>
        public static implicit operator ConstantProductConstProperty(string value) => new ConstantProductConstProperty(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConstantProductConstProperty other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConstantProductConstProperty other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
