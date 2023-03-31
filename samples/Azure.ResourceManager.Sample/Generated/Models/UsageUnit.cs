// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// An enum describing the unit of usage measurement.
    /// Serialized Name: UsageUnit
    /// </summary>
    public readonly partial struct UsageUnit : IEquatable<UsageUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UsageUnit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UsageUnit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CountValue = "Count";

        /// <summary>
        /// Count
        /// Serialized Name: UsageUnit.Count
        /// </summary>
        public static UsageUnit Count { get; } = new UsageUnit(CountValue);

        internal string ToSerialString() => _value;

        /// <summary> Determines if two <see cref="UsageUnit"/> values are the same. </summary>
        public static bool operator ==(UsageUnit left, UsageUnit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UsageUnit"/> values are not the same. </summary>
        public static bool operator !=(UsageUnit left, UsageUnit right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="UsageUnit"/>. </summary>
        public static implicit operator UsageUnit(string value) => new UsageUnit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UsageUnit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UsageUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
