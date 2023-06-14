// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace HlcConstants.Models
{
    /// <summary> A constant based on string, the only allowable value is default. </summary>
    public readonly partial struct StringConstant : IEquatable<StringConstant>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StringConstant"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StringConstant(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "default";

        /// <summary> default. </summary>
        public static StringConstant Default { get; } = new StringConstant(DefaultValue);
        /// <summary> Determines if two <see cref="StringConstant"/> values are the same. </summary>
        public static bool operator ==(StringConstant left, StringConstant right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StringConstant"/> values are not the same. </summary>
        public static bool operator !=(StringConstant left, StringConstant right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StringConstant"/>. </summary>
        public static implicit operator StringConstant(string value) => new StringConstant(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StringConstant other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StringConstant other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
