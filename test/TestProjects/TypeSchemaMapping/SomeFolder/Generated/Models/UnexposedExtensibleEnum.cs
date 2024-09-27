// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace TypeSchemaMapping.Models
{
    /// <summary> More Letters. </summary>
    internal readonly partial struct UnexposedExtensibleEnum : IEquatable<UnexposedExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UnexposedExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UnexposedExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "A";
        private const string BValue = "B";
        private const string CValue = "C";

        /// <summary> A. </summary>
        public static UnexposedExtensibleEnum A { get; } = new UnexposedExtensibleEnum(AValue);
        /// <summary> B. </summary>
        public static UnexposedExtensibleEnum B { get; } = new UnexposedExtensibleEnum(BValue);
        /// <summary> C. </summary>
        public static UnexposedExtensibleEnum C { get; } = new UnexposedExtensibleEnum(CValue);
        /// <summary> Determines if two <see cref="UnexposedExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(UnexposedExtensibleEnum left, UnexposedExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UnexposedExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(UnexposedExtensibleEnum left, UnexposedExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UnexposedExtensibleEnum"/>. </summary>
        public static implicit operator UnexposedExtensibleEnum(string value) => new UnexposedExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UnexposedExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UnexposedExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
