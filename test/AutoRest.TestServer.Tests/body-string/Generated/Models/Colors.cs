// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_string.Models.V100
{
    public readonly partial struct Colors : IEquatable<Colors>
    {
        private readonly string? _value;

        public Colors(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RedColorValue = "red color";
        private const string GreenColorValue = "green-color";
        private const string BlueColorValue = "blue_color";

        public static Colors RedColor { get; } = new Colors(RedColorValue);
        public static Colors GreenColor { get; } = new Colors(GreenColorValue);
        public static Colors BlueColor { get; } = new Colors(BlueColorValue);
        public static bool operator ==(Colors left, Colors right) => left.Equals(right);
        public static bool operator !=(Colors left, Colors right) => !left.Equals(right);
        public static implicit operator Colors(string value) => new Colors(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Colors other && Equals(other);
        public bool Equals(Colors other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
