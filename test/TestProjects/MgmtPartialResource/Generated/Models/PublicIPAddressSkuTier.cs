// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtPartialResource.Models
{
    /// <summary> Tier of a public IP address SKU. </summary>
    public readonly partial struct PublicIPAddressSkuTier : IEquatable<PublicIPAddressSkuTier>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressSkuTier"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PublicIPAddressSkuTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RegionalValue = "Regional";
        private const string GlobalValue = "Global";

        /// <summary> Regional. </summary>
        public static PublicIPAddressSkuTier Regional { get; } = new PublicIPAddressSkuTier(RegionalValue);
        /// <summary> Global. </summary>
        public static PublicIPAddressSkuTier Global { get; } = new PublicIPAddressSkuTier(GlobalValue);
        /// <summary> Determines if two <see cref="PublicIPAddressSkuTier"/> values are the same. </summary>
        public static bool operator ==(PublicIPAddressSkuTier left, PublicIPAddressSkuTier right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PublicIPAddressSkuTier"/> values are not the same. </summary>
        public static bool operator !=(PublicIPAddressSkuTier left, PublicIPAddressSkuTier right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PublicIPAddressSkuTier"/>. </summary>
        public static implicit operator PublicIPAddressSkuTier(string value) => new PublicIPAddressSkuTier(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PublicIPAddressSkuTier other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PublicIPAddressSkuTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
