// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The Thing_optionalLiteralString. </summary>
    public readonly partial struct ThingOptionalLiteralString : IEquatable<ThingOptionalLiteralString>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ThingOptionalLiteralString"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ThingOptionalLiteralString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RejectValue = "reject";

        /// <summary> reject. </summary>
        public static ThingOptionalLiteralString Reject { get; } = new ThingOptionalLiteralString(RejectValue);
        /// <summary> Determines if two <see cref="ThingOptionalLiteralString"/> values are the same. </summary>
        public static bool operator ==(ThingOptionalLiteralString left, ThingOptionalLiteralString right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThingOptionalLiteralString"/> values are not the same. </summary>
        public static bool operator !=(ThingOptionalLiteralString left, ThingOptionalLiteralString right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ThingOptionalLiteralString"/>. </summary>
        public static implicit operator ThingOptionalLiteralString(string value) => new ThingOptionalLiteralString(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingOptionalLiteralString other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThingOptionalLiteralString other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
