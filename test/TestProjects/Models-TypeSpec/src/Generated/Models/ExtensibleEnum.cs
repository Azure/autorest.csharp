// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace ModelsTypeSpec.Models
{
    /// <summary> Extensible enum. </summary>
    [Obsolete("deprecated for test")]
    public readonly partial struct ExtensibleEnum : IEquatable<ExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OneValue = "1";
        private const string TwoValue = "2";
        private const string FourValue = "4";

        /// <summary> 1. </summary>
        public static ExtensibleEnum One { get; } = new ExtensibleEnum(OneValue);
        /// <summary> 2. </summary>
        public static ExtensibleEnum Two { get; } = new ExtensibleEnum(TwoValue);
        /// <summary> 4. </summary>
        public static ExtensibleEnum Four { get; } = new ExtensibleEnum(FourValue);
        /// <summary> Determines if two <see cref="ExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(ExtensibleEnum left, ExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(ExtensibleEnum left, ExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ExtensibleEnum"/>. </summary>
        public static implicit operator ExtensibleEnum(string value) => new ExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
