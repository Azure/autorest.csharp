// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The level at which the content needs to be cached. </summary>
    public readonly partial struct CacheType : IEquatable<CacheType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CacheType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CacheType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllValue = "All";

        /// <summary> All. </summary>
        public static CacheType All { get; } = new CacheType(AllValue);
        /// <summary> Determines if two <see cref="CacheType"/> values are the same. </summary>
        public static bool operator ==(CacheType left, CacheType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CacheType"/> values are not the same. </summary>
        public static bool operator !=(CacheType left, CacheType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CacheType"/>. </summary>
        public static implicit operator CacheType(string value) => new CacheType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CacheType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CacheType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
