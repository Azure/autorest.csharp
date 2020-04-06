// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> IP address version. </summary>
    public readonly partial struct IPVersion : IEquatable<IPVersion>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="IPVersion"/> values are the same. </summary>
        public IPVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IPv4Value = "IPv4";
        private const string IPv6Value = "IPv6";

        /// <summary> IPv4. </summary>
        public static IPVersion IPv4 { get; } = new IPVersion(IPv4Value);
        /// <summary> IPv6. </summary>
        public static IPVersion IPv6 { get; } = new IPVersion(IPv6Value);
        /// <summary> Determines if two <see cref="IPVersion"/> values are the same. </summary>
        public static bool operator ==(IPVersion left, IPVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IPVersion"/> values are not the same. </summary>
        public static bool operator !=(IPVersion left, IPVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IPVersion"/>. </summary>
        public static implicit operator IPVersion(string value) => new IPVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IPVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IPVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
