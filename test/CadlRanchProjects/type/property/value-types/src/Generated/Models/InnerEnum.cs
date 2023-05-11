// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Enum that will be used as a property for model EnumProperty. Non-extensible. </summary>
    public readonly partial struct InnerEnum : IEquatable<InnerEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InnerEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InnerEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ValueOneValue = "ValueOne";
        private const string ValueTwoValue = "ValueTwo";

        /// <summary> First value. </summary>
        public static InnerEnum ValueOne { get; } = new InnerEnum(ValueOneValue);
        /// <summary> Second value. </summary>
        public static InnerEnum ValueTwo { get; } = new InnerEnum(ValueTwoValue);
        /// <summary> Determines if two <see cref="InnerEnum"/> values are the same. </summary>
        public static bool operator ==(InnerEnum left, InnerEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InnerEnum"/> values are not the same. </summary>
        public static bool operator !=(InnerEnum left, InnerEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InnerEnum"/>. </summary>
        public static implicit operator InnerEnum(string value) => new InnerEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InnerEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InnerEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
