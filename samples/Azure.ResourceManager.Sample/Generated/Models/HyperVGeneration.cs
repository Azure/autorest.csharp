// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the HyperVGeneration Type
    /// Serialized Name: HyperVGenerationTypes
    /// </summary>
    public readonly partial struct HyperVGeneration : IEquatable<HyperVGeneration>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HyperVGeneration"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HyperVGeneration(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string V1Value = "V1";
        private const string V2Value = "V2";

        /// <summary>
        /// V1
        /// Serialized Name: HyperVGenerationTypes.V1
        /// </summary>
        public static HyperVGeneration V1 { get; } = new HyperVGeneration(V1Value);
        /// <summary>
        /// V2
        /// Serialized Name: HyperVGenerationTypes.V2
        /// </summary>
        public static HyperVGeneration V2 { get; } = new HyperVGeneration(V2Value);
        /// <summary> Determines if two <see cref="HyperVGeneration"/> values are the same. </summary>
        public static bool operator ==(HyperVGeneration left, HyperVGeneration right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HyperVGeneration"/> values are not the same. </summary>
        public static bool operator !=(HyperVGeneration left, HyperVGeneration right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="HyperVGeneration"/>. </summary>
        public static implicit operator HyperVGeneration(string value) => new HyperVGeneration(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HyperVGeneration other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HyperVGeneration other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
