// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace httpInfrastructure.Models
{
    /// <summary> Simple boolean value true. </summary>
    public readonly partial struct Constant46 : IEquatable<Constant46>
    {
        private readonly bool _value;

        /// <summary> Initializes a new instance of <see cref="Constant46"/>. </summary>
        public Constant46(bool value)
        {
            _value = value;
        }

        private const bool TrueValue = true;

        /// <summary> true. </summary>
        public static Constant46 True { get; } = new Constant46(TrueValue);
        /// <summary> Determines if two <see cref="Constant46"/> values are the same. </summary>
        public static bool operator ==(Constant46 left, Constant46 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Constant46"/> values are not the same. </summary>
        public static bool operator !=(Constant46 left, Constant46 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Constant46"/>. </summary>
        public static implicit operator Constant46(bool value) => new Constant46(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Constant46 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Constant46 other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
