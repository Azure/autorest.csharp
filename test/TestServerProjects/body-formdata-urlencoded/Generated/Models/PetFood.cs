// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace body_formdata_urlencoded.Models
{
    /// <summary> Can take a value of meat, or fish, or plant. </summary>
    public readonly partial struct PetFood : IEquatable<PetFood>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PetFood"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PetFood(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MeatValue = "meat";
        private const string FishValue = "fish";
        private const string PlantValue = "plant";

        /// <summary> meat. </summary>
        public static PetFood Meat { get; } = new PetFood(MeatValue);
        /// <summary> fish. </summary>
        public static PetFood Fish { get; } = new PetFood(FishValue);
        /// <summary> plant. </summary>
        public static PetFood Plant { get; } = new PetFood(PlantValue);
        /// <summary> Determines if two <see cref="PetFood"/> values are the same. </summary>
        public static bool operator ==(PetFood left, PetFood right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PetFood"/> values are not the same. </summary>
        public static bool operator !=(PetFood left, PetFood right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PetFood"/>. </summary>
        public static implicit operator PetFood(string value) => new PetFood(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PetFood other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PetFood other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
