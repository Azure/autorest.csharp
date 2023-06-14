// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Name of a public IP address SKU. </summary>
    public readonly partial struct PublicIPAddressSkuName : IEquatable<PublicIPAddressSkuName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressSkuName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PublicIPAddressSkuName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BasicValue = "Basic";
        private const string StandardValue = "Standard";

        /// <summary> Basic. </summary>
        public static PublicIPAddressSkuName Basic { get; } = new PublicIPAddressSkuName(BasicValue);
        /// <summary> Standard. </summary>
        public static PublicIPAddressSkuName Standard { get; } = new PublicIPAddressSkuName(StandardValue);
        /// <summary> Determines if two <see cref="PublicIPAddressSkuName"/> values are the same. </summary>
        public static bool operator ==(PublicIPAddressSkuName left, PublicIPAddressSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PublicIPAddressSkuName"/> values are not the same. </summary>
        public static bool operator !=(PublicIPAddressSkuName left, PublicIPAddressSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PublicIPAddressSkuName"/>. </summary>
        public static implicit operator PublicIPAddressSkuName(string value) => new PublicIPAddressSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PublicIPAddressSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PublicIPAddressSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
