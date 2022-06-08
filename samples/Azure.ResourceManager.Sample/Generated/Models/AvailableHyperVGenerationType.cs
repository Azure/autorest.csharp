// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Specifies the HyperVGeneration Type associated with a resource. </summary>
    public readonly partial struct AvailableHyperVGenerationType : IEquatable<AvailableHyperVGenerationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AvailableHyperVGenerationType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AvailableHyperVGenerationType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string V1Value = "V1";
        private const string V2Value = "V2";

        /// <summary> V1. </summary>
        public static AvailableHyperVGenerationType V1 { get; } = new AvailableHyperVGenerationType(V1Value);
        /// <summary> V2. </summary>
        public static AvailableHyperVGenerationType V2 { get; } = new AvailableHyperVGenerationType(V2Value);
        /// <summary> Determines if two <see cref="AvailableHyperVGenerationType"/> values are the same. </summary>
        public static bool operator ==(AvailableHyperVGenerationType left, AvailableHyperVGenerationType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AvailableHyperVGenerationType"/> values are not the same. </summary>
        public static bool operator !=(AvailableHyperVGenerationType left, AvailableHyperVGenerationType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AvailableHyperVGenerationType"/>. </summary>
        public static implicit operator AvailableHyperVGenerationType(string value) => new AvailableHyperVGenerationType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AvailableHyperVGenerationType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AvailableHyperVGenerationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
