// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Specifies the HyperVGeneration Type associated with a resource. </summary>
    public readonly partial struct HyperVGenerationType : IEquatable<HyperVGenerationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of HyperVGenerationType. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HyperVGenerationType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string V1Value = "V1";
        private const string V2Value = "V2";

        /// <summary> V1. </summary>
        public static HyperVGenerationType V1 { get; } = new HyperVGenerationType(V1Value);
        /// <summary> V2. </summary>
        public static HyperVGenerationType V2 { get; } = new HyperVGenerationType(V2Value);
        /// <summary> Determines if two <see cref="HyperVGenerationType"/> values are the same. </summary>
        public static bool operator ==(HyperVGenerationType left, HyperVGenerationType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HyperVGenerationType"/> values are not the same. </summary>
        public static bool operator !=(HyperVGenerationType left, HyperVGenerationType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="HyperVGenerationType"/>. </summary>
        public static implicit operator HyperVGenerationType(string value) => new HyperVGenerationType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HyperVGenerationType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HyperVGenerationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
