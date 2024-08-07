// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace NoDocsTypeSpec.Models
{
    public readonly partial struct ThingRequiredLiteralFloat : IEquatable<ThingRequiredLiteralFloat>
    {
        private readonly float _value;

        public ThingRequiredLiteralFloat(float value)
        {
            _value = value;
        }

        private const float _123Value = 1.23F;

        public static ThingRequiredLiteralFloat _123 { get; } = new ThingRequiredLiteralFloat(_123Value);

        internal float ToSerialSingle() => _value;

        public static bool operator ==(ThingRequiredLiteralFloat left, ThingRequiredLiteralFloat right) => left.Equals(right);
        public static bool operator !=(ThingRequiredLiteralFloat left, ThingRequiredLiteralFloat right) => !left.Equals(right);
        public static implicit operator ThingRequiredLiteralFloat(float value) => new ThingRequiredLiteralFloat(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingRequiredLiteralFloat other && Equals(other);
        public bool Equals(ThingRequiredLiteralFloat other) => Equals(_value, other._value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
