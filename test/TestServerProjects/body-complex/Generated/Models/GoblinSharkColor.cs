// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_complex.Models.V20160229
{
    public readonly partial struct GoblinSharkColor : IEquatable<GoblinSharkColor>
    {
        private readonly string? _value;

        public GoblinSharkColor(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PinkValue = "pink";
        private const string GrayValue = "gray";
        private const string BrownValue = "brown";

        public static GoblinSharkColor Pink { get; } = new GoblinSharkColor(PinkValue);
        public static GoblinSharkColor Gray { get; } = new GoblinSharkColor(GrayValue);
        public static GoblinSharkColor Brown { get; } = new GoblinSharkColor(BrownValue);
        public static bool operator ==(GoblinSharkColor left, GoblinSharkColor right) => left.Equals(right);
        public static bool operator !=(GoblinSharkColor left, GoblinSharkColor right) => !left.Equals(right);
        public static implicit operator GoblinSharkColor(string value) => new GoblinSharkColor(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is GoblinSharkColor other && Equals(other);
        public bool Equals(GoblinSharkColor other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
