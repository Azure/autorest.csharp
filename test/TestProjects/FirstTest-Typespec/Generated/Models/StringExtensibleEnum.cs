// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace CadlFirstTest.Models
{
    /// <summary> Extensible enum. </summary>
    public readonly partial struct StringExtensibleEnum : IEquatable<StringExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StringExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StringExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OneValue = "1";
        private const string TwoValue = "2";
        private const string FourValue = "4";

        /// <summary> 1. </summary>
        public static StringExtensibleEnum One { get; } = new StringExtensibleEnum(OneValue);
        /// <summary> 2. </summary>
        public static StringExtensibleEnum Two { get; } = new StringExtensibleEnum(TwoValue);
        /// <summary> 4. </summary>
        public static StringExtensibleEnum Four { get; } = new StringExtensibleEnum(FourValue);
        /// <summary> Determines if two <see cref="StringExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(StringExtensibleEnum left, StringExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StringExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(StringExtensibleEnum left, StringExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StringExtensibleEnum"/>. </summary>
        public static implicit operator StringExtensibleEnum(string value) => new StringExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StringExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StringExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
