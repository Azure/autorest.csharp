// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_complex.Models.V20160229
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct CMYKColors : IEquatable<CMYKColors>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="CMYKColors"/> values are the same. </summary>
        public CMYKColors(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CyanValue = "cyan";
        private const string MagentaValue = "Magenta";
        private const string YELLOWValue = "YELLOW";
        private const string BlacKValue = "blacK";

        /// <summary> cyan. </summary>
        public static CMYKColors Cyan { get; } = new CMYKColors(CyanValue);
        /// <summary> Magenta. </summary>
        public static CMYKColors Magenta { get; } = new CMYKColors(MagentaValue);
        /// <summary> YELLOW. </summary>
        public static CMYKColors YELLOW { get; } = new CMYKColors(YELLOWValue);
        /// <summary> blacK. </summary>
        public static CMYKColors BlacK { get; } = new CMYKColors(BlacKValue);
        /// <summary> Determines if two <see cref="CMYKColors"/> values are the same. </summary>
        public static bool operator ==(CMYKColors left, CMYKColors right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CMYKColors"/> values are not the same. </summary>
        public static bool operator !=(CMYKColors left, CMYKColors right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CMYKColors"/>. </summary>
        public static implicit operator CMYKColors(string value) => new CMYKColors(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is CMYKColors other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CMYKColors other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
