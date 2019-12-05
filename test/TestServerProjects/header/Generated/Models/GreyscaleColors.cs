// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace header.Models.V100
{
    public readonly partial struct GreyscaleColors : IEquatable<GreyscaleColors>
    {
        private readonly string? _value;

        public GreyscaleColors(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string WhiteValue = "White";
        private const string BlackValue = "black";
        private const string GREYValue = "GREY";

        public static GreyscaleColors White { get; } = new GreyscaleColors(WhiteValue);
        public static GreyscaleColors Black { get; } = new GreyscaleColors(BlackValue);
        public static GreyscaleColors GREY { get; } = new GreyscaleColors(GREYValue);
        public static bool operator ==(GreyscaleColors left, GreyscaleColors right) => left.Equals(right);
        public static bool operator !=(GreyscaleColors left, GreyscaleColors right) => !left.Equals(right);
        public static implicit operator GreyscaleColors(string value) => new GreyscaleColors(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is GreyscaleColors other && Equals(other);
        public bool Equals(GreyscaleColors other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
