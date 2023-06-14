// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property. </summary>
    public readonly partial struct MinimumTlsVersion : IEquatable<MinimumTlsVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MinimumTlsVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MinimumTlsVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TLS10Value = "TLS1_0";
        private const string TLS11Value = "TLS1_1";
        private const string TLS12Value = "TLS1_2";

        /// <summary> TLS1_0. </summary>
        public static MinimumTlsVersion TLS10 { get; } = new MinimumTlsVersion(TLS10Value);
        /// <summary> TLS1_1. </summary>
        public static MinimumTlsVersion TLS11 { get; } = new MinimumTlsVersion(TLS11Value);
        /// <summary> TLS1_2. </summary>
        public static MinimumTlsVersion TLS12 { get; } = new MinimumTlsVersion(TLS12Value);
        /// <summary> Determines if two <see cref="MinimumTlsVersion"/> values are the same. </summary>
        public static bool operator ==(MinimumTlsVersion left, MinimumTlsVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MinimumTlsVersion"/> values are not the same. </summary>
        public static bool operator !=(MinimumTlsVersion left, MinimumTlsVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MinimumTlsVersion"/>. </summary>
        public static implicit operator MinimumTlsVersion(string value) => new MinimumTlsVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MinimumTlsVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MinimumTlsVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
