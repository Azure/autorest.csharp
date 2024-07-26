// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The AnonymousBodyRequest_requiredLiteralFloat. </summary>
    public readonly partial struct AnonymousBodyRequestRequiredLiteralFloat : IEquatable<AnonymousBodyRequestRequiredLiteralFloat>
    {
        private readonly float _value;

        /// <summary> Initializes a new instance of <see cref="AnonymousBodyRequestRequiredLiteralFloat"/>. </summary>
        public AnonymousBodyRequestRequiredLiteralFloat(float value)
        {
            _value = value;
        }

        private const float _123Value = 1.23F;

        /// <summary> 1.23. </summary>
        public static AnonymousBodyRequestRequiredLiteralFloat _123 { get; } = new AnonymousBodyRequestRequiredLiteralFloat(_123Value);

        internal float ToSerialSingle() => _value;

        /// <summary> Determines if two <see cref="AnonymousBodyRequestRequiredLiteralFloat"/> values are the same. </summary>
        public static bool operator ==(AnonymousBodyRequestRequiredLiteralFloat left, AnonymousBodyRequestRequiredLiteralFloat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnonymousBodyRequestRequiredLiteralFloat"/> values are not the same. </summary>
        public static bool operator !=(AnonymousBodyRequestRequiredLiteralFloat left, AnonymousBodyRequestRequiredLiteralFloat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnonymousBodyRequestRequiredLiteralFloat"/>. </summary>
        public static implicit operator AnonymousBodyRequestRequiredLiteralFloat(float value) => new AnonymousBodyRequestRequiredLiteralFloat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnonymousBodyRequestRequiredLiteralFloat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnonymousBodyRequestRequiredLiteralFloat other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
