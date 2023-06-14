// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the sku of an Availability Set. Use 'Aligned' for virtual machines with managed disks and 'Classic' for virtual machines with unmanaged disks. Default value is 'Classic'.
    /// Serialized Name: AvailabilitySetSkuTypes
    /// </summary>
    internal readonly partial struct AvailabilitySetSkuType : IEquatable<AvailabilitySetSkuType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetSkuType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AvailabilitySetSkuType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ClassicValue = "Classic";
        private const string AlignedValue = "Aligned";

        /// <summary>
        /// Classic
        /// Serialized Name: AvailabilitySetSkuTypes.Classic
        /// </summary>
        public static AvailabilitySetSkuType Classic { get; } = new AvailabilitySetSkuType(ClassicValue);
        /// <summary>
        /// Aligned
        /// Serialized Name: AvailabilitySetSkuTypes.Aligned
        /// </summary>
        public static AvailabilitySetSkuType Aligned { get; } = new AvailabilitySetSkuType(AlignedValue);
        /// <summary> Determines if two <see cref="AvailabilitySetSkuType"/> values are the same. </summary>
        public static bool operator ==(AvailabilitySetSkuType left, AvailabilitySetSkuType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AvailabilitySetSkuType"/> values are not the same. </summary>
        public static bool operator !=(AvailabilitySetSkuType left, AvailabilitySetSkuType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AvailabilitySetSkuType"/>. </summary>
        public static implicit operator AvailabilitySetSkuType(string value) => new AvailabilitySetSkuType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AvailabilitySetSkuType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AvailabilitySetSkuType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
