// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace CustomizationsInCadl.Models
{
    /// <summary> Extensible enum. </summary>
    public readonly partial struct EnumToBeMadeExtensible : IEquatable<EnumToBeMadeExtensible>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EnumToBeMadeExtensible"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EnumToBeMadeExtensible(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ExOneValue = "1";
        private const string ExTwoValue = "2";
        private const string ExThreeValue = "3";

        /// <summary> 1. </summary>
        public static EnumToBeMadeExtensible ExOne { get; } = new EnumToBeMadeExtensible(ExOneValue);
        /// <summary> 2. </summary>
        public static EnumToBeMadeExtensible ExTwo { get; } = new EnumToBeMadeExtensible(ExTwoValue);
        /// <summary> 3. </summary>
        public static EnumToBeMadeExtensible ExThree { get; } = new EnumToBeMadeExtensible(ExThreeValue);
        /// <summary> Determines if two <see cref="EnumToBeMadeExtensible"/> values are the same. </summary>
        public static bool operator ==(EnumToBeMadeExtensible left, EnumToBeMadeExtensible right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EnumToBeMadeExtensible"/> values are not the same. </summary>
        public static bool operator !=(EnumToBeMadeExtensible left, EnumToBeMadeExtensible right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EnumToBeMadeExtensible"/>. </summary>
        public static implicit operator EnumToBeMadeExtensible(string value) => new EnumToBeMadeExtensible(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnumToBeMadeExtensible other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EnumToBeMadeExtensible other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
