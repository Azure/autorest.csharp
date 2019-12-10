// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_complex.Models.V20160229
{
    public readonly partial struct CMYKColors : IEquatable<CMYKColors>
    {
        private readonly string? _value;

        public CMYKColors(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CyanValue = "cyan";
        private const string MagentaValue = "Magenta";
        private const string YELLOWValue = "YELLOW";
        private const string BlacKValue = "blacK";

        public static CMYKColors Cyan { get; } = new CMYKColors(CyanValue);
        public static CMYKColors Magenta { get; } = new CMYKColors(MagentaValue);
        public static CMYKColors YELLOW { get; } = new CMYKColors(YELLOWValue);
        public static CMYKColors BlacK { get; } = new CMYKColors(BlacKValue);
        public static bool operator ==(CMYKColors left, CMYKColors right) => left.Equals(right);
        public static bool operator !=(CMYKColors left, CMYKColors right) => !left.Equals(right);
        public static implicit operator CMYKColors(string value) => new CMYKColors(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is CMYKColors other && Equals(other);
        public bool Equals(CMYKColors other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
