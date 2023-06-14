// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The minimum tls version. </summary>
    public readonly partial struct MinimumTlsVersion : IEquatable<MinimumTlsVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MinimumTlsVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MinimumTlsVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Tls1_0Value = "TLS1_0";
        private const string Tls1_1Value = "TLS1_1";
        private const string Tls1_2Value = "TLS1_2";
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
