// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The CacheExpirationActionParametersTypeName. </summary>
    public readonly partial struct CacheExpirationActionParametersTypeName : IEquatable<CacheExpirationActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CacheExpirationActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CacheExpirationActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleCacheExpirationActionParametersValue = "DeliveryRuleCacheExpirationActionParameters";

        /// <summary> DeliveryRuleCacheExpirationActionParameters. </summary>
        public static CacheExpirationActionParametersTypeName DeliveryRuleCacheExpirationActionParameters { get; } = new CacheExpirationActionParametersTypeName(DeliveryRuleCacheExpirationActionParametersValue);
        /// <summary> Determines if two <see cref="CacheExpirationActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(CacheExpirationActionParametersTypeName left, CacheExpirationActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CacheExpirationActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(CacheExpirationActionParametersTypeName left, CacheExpirationActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CacheExpirationActionParametersTypeName"/>. </summary>
        public static implicit operator CacheExpirationActionParametersTypeName(string value) => new CacheExpirationActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CacheExpirationActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CacheExpirationActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
