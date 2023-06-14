// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The Thing_requiredLiteralFloat. </summary>
    public readonly partial struct ThingRequiredLiteralFloat : IEquatable<ThingRequiredLiteralFloat>
    {
        private readonly float _value;

        /// <summary> Initializes a new instance of <see cref="ThingRequiredLiteralFloat"/>. </summary>
        public ThingRequiredLiteralFloat(float value)
        {
            _value = value;
        }

        private const float _123Value = 1.23F;

        /// <summary> 1.23. </summary>
        public static ThingRequiredLiteralFloat _123 { get; } = new ThingRequiredLiteralFloat(_123Value);

        internal float ToSerialSingle() => _value;

        /// <summary> Determines if two <see cref="ThingRequiredLiteralFloat"/> values are the same. </summary>
        public static bool operator ==(ThingRequiredLiteralFloat left, ThingRequiredLiteralFloat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThingRequiredLiteralFloat"/> values are not the same. </summary>
        public static bool operator !=(ThingRequiredLiteralFloat left, ThingRequiredLiteralFloat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ThingRequiredLiteralFloat"/>. </summary>
        public static implicit operator ThingRequiredLiteralFloat(float value) => new ThingRequiredLiteralFloat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingRequiredLiteralFloat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThingRequiredLiteralFloat other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
