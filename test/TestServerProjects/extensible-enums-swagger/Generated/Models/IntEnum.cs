// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace extensible_enums_swagger.Models
{
    /// <summary> The IntEnum. </summary>
    public readonly partial struct IntEnum : IEquatable<IntEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="IntEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public IntEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OneValue = "1";
        private const string TwoValue = "2";
        private const string ThreeValue = "3";

        /// <summary> This is a really long comment to see what wrapping looks like. This comment is really long and it should wrap for readability. Please wrap. This should wrap. </summary>
        public static IntEnum One { get; } = new IntEnum(OneValue);
        /// <summary> two. </summary>
        public static IntEnum Two { get; } = new IntEnum(TwoValue);
        /// <summary> three. </summary>
        public static IntEnum Three { get; } = new IntEnum(ThreeValue);
        /// <summary> Determines if two <see cref="IntEnum"/> values are the same. </summary>
        public static bool operator ==(IntEnum left, IntEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IntEnum"/> values are not the same. </summary>
        public static bool operator !=(IntEnum left, IntEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IntEnum"/>. </summary>
        public static implicit operator IntEnum(string value) => new IntEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IntEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IntEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
