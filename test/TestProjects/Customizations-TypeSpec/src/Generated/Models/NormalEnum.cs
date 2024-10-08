// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace CustomizationsInTsp.Models
{
    /// <summary> A normal enum. </summary>
    public readonly partial struct NormalEnum : IEquatable<NormalEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NormalEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NormalEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "a";
        private const string BValue = "b";

        /// <summary> a. </summary>
        public static NormalEnum A { get; } = new NormalEnum(AValue);
        /// <summary> b. </summary>
        public static NormalEnum B { get; } = new NormalEnum(BValue);
        /// <summary> Determines if two <see cref="NormalEnum"/> values are the same. </summary>
        public static bool operator ==(NormalEnum left, NormalEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NormalEnum"/> values are not the same. </summary>
        public static bool operator !=(NormalEnum left, NormalEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="NormalEnum"/>. </summary>
        public static implicit operator NormalEnum(string value) => new NormalEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NormalEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NormalEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
