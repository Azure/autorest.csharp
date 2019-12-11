// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace extensible_enums_swagger.Models.V20160707
{
    public readonly partial struct IntEnum : IEquatable<IntEnum>
    {
        private readonly string? _value;

        public IntEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string _1Value = "1";
        private const string _2Value = "2";
        private const string _3Value = "3";

        public static IntEnum _1 { get; } = new IntEnum(_1Value);
        public static IntEnum _2 { get; } = new IntEnum(_2Value);
        public static IntEnum _3 { get; } = new IntEnum(_3Value);
        public static bool operator ==(IntEnum left, IntEnum right) => left.Equals(right);
        public static bool operator !=(IntEnum left, IntEnum right) => !left.Equals(right);
        public static implicit operator IntEnum(string value) => new IntEnum(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is IntEnum other && Equals(other);
        public bool Equals(IntEnum other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
