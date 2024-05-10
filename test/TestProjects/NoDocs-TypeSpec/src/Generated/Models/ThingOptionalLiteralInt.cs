// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace NoDocsTypeSpec.Models
{
    public readonly partial struct ThingOptionalLiteralInt : IEquatable<ThingOptionalLiteralInt>
    {
        private readonly int _value;

        public ThingOptionalLiteralInt(int value)
        {
            _value = value;
        }

        private const int _456Value = 456;

        public static ThingOptionalLiteralInt _456 { get; } = new ThingOptionalLiteralInt(_456Value);

        internal int ToSerialInt32() => _value;

        public static bool operator ==(ThingOptionalLiteralInt left, ThingOptionalLiteralInt right) => left.Equals(right);
        public static bool operator !=(ThingOptionalLiteralInt left, ThingOptionalLiteralInt right) => !left.Equals(right);
        public static implicit operator ThingOptionalLiteralInt(int value) => new ThingOptionalLiteralInt(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingOptionalLiteralInt other && Equals(other);
        public bool Equals(ThingOptionalLiteralInt other) => Equals(_value, other._value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
