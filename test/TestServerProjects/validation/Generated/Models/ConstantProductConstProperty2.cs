// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace validation.Models
{
    /// <summary> Constant string2. </summary>
    public readonly partial struct ConstantProductConstProperty2 : IEquatable<ConstantProductConstProperty2>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConstantProductConstProperty2"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ConstantProductConstProperty2(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Constant2Value = "constant2";

        /// <summary> constant2. </summary>
        public static ConstantProductConstProperty2 Constant2 { get; } = new ConstantProductConstProperty2(Constant2Value);
        /// <summary> Determines if two <see cref="ConstantProductConstProperty2"/> values are the same. </summary>
        public static bool operator ==(ConstantProductConstProperty2 left, ConstantProductConstProperty2 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConstantProductConstProperty2"/> values are not the same. </summary>
        public static bool operator !=(ConstantProductConstProperty2 left, ConstantProductConstProperty2 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConstantProductConstProperty2"/>. </summary>
        public static implicit operator ConstantProductConstProperty2(string value) => new ConstantProductConstProperty2(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConstantProductConstProperty2 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConstantProductConstProperty2 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
