// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The status of the secondary location. </summary>
    public readonly partial struct GeoReplicationStatusType : IEquatable<GeoReplicationStatusType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="GeoReplicationStatusType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public GeoReplicationStatusType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LiveValue = "live";
        private const string BootstrapValue = "bootstrap";
        private const string UnavailableValue = "unavailable";

        /// <summary> live. </summary>
        public static GeoReplicationStatusType Live { get; } = new GeoReplicationStatusType(LiveValue);
        /// <summary> bootstrap. </summary>
        public static GeoReplicationStatusType Bootstrap { get; } = new GeoReplicationStatusType(BootstrapValue);
        /// <summary> unavailable. </summary>
        public static GeoReplicationStatusType Unavailable { get; } = new GeoReplicationStatusType(UnavailableValue);
        /// <summary> Determines if two <see cref="GeoReplicationStatusType"/> values are the same. </summary>
        public static bool operator ==(GeoReplicationStatusType left, GeoReplicationStatusType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="GeoReplicationStatusType"/> values are not the same. </summary>
        public static bool operator !=(GeoReplicationStatusType left, GeoReplicationStatusType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="GeoReplicationStatusType"/>. </summary>
        public static implicit operator GeoReplicationStatusType(string value) => new GeoReplicationStatusType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GeoReplicationStatusType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(GeoReplicationStatusType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
