// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace extensible_enums_swagger.Models.V20160707
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct IntEnum : IEquatable<IntEnum>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="IntEnum"/> values are the same. </summary>
        public IntEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string _1Value = "1";
        private const string _2Value = "2";
        private const string _3Value = "3";

        /// <summary> one. </summary>
        public static IntEnum _1 { get; } = new IntEnum(_1Value);
        /// <summary> two. </summary>
        public static IntEnum _2 { get; } = new IntEnum(_2Value);
        /// <summary> three. </summary>
        public static IntEnum _3 { get; } = new IntEnum(_3Value);
        /// <summary> Determines if two <see cref="IntEnum"/> values are the same. </summary>
        public static bool operator ==(IntEnum left, IntEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IntEnum"/> values are not the same. </summary>
        public static bool operator !=(IntEnum left, IntEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <cref="IntEnum"/>. </summary>
        public static implicit operator IntEnum(string value) => new IntEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is IntEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IntEnum other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
