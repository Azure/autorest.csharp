// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace PetStore.Models
{
    /// <summary> Extensible enum Values for pet kind. </summary>
    public readonly partial struct PetKind : IEquatable<PetKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PetKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PetKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DogValue = "dog";
        private const string CatValue = "cat";

        /// <summary> dog. </summary>
        public static PetKind Dog { get; } = new PetKind(DogValue);
        /// <summary> cat. </summary>
        public static PetKind Cat { get; } = new PetKind(CatValue);
        /// <summary> Determines if two <see cref="PetKind"/> values are the same. </summary>
        public static bool operator ==(PetKind left, PetKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PetKind"/> values are not the same. </summary>
        public static bool operator !=(PetKind left, PetKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PetKind"/>. </summary>
        public static implicit operator PetKind(string value) => new PetKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PetKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PetKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
