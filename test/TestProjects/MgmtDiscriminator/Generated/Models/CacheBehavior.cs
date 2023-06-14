// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Caching behavior for the requests. </summary>
    public readonly partial struct CacheBehavior : IEquatable<CacheBehavior>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CacheBehavior"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CacheBehavior(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BypassCacheValue = "BypassCache";
        private const string OverrideValue = "Override";
        private const string SetIfMissingValue = "SetIfMissing";

        /// <summary> BypassCache. </summary>
        public static CacheBehavior BypassCache { get; } = new CacheBehavior(BypassCacheValue);
        /// <summary> Override. </summary>
        public static CacheBehavior Override { get; } = new CacheBehavior(OverrideValue);
        /// <summary> SetIfMissing. </summary>
        public static CacheBehavior SetIfMissing { get; } = new CacheBehavior(SetIfMissingValue);
        /// <summary> Determines if two <see cref="CacheBehavior"/> values are the same. </summary>
        public static bool operator ==(CacheBehavior left, CacheBehavior right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CacheBehavior"/> values are not the same. </summary>
        public static bool operator !=(CacheBehavior left, CacheBehavior right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CacheBehavior"/>. </summary>
        public static implicit operator CacheBehavior(string value) => new CacheBehavior(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CacheBehavior other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CacheBehavior other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
