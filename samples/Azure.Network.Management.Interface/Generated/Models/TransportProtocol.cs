// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The transport protocol for the endpoint. </summary>
    public readonly partial struct TransportProtocol : IEquatable<TransportProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TransportProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TransportProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UdpValue = "Udp";
        private const string TcpValue = "Tcp";
        private const string AllValue = "All";

        /// <summary> Udp. </summary>
        public static TransportProtocol Udp { get; } = new TransportProtocol(UdpValue);
        /// <summary> Tcp. </summary>
        public static TransportProtocol Tcp { get; } = new TransportProtocol(TcpValue);
        /// <summary> All. </summary>
        public static TransportProtocol All { get; } = new TransportProtocol(AllValue);
        /// <summary> Determines if two <see cref="TransportProtocol"/> values are the same. </summary>
        public static bool operator ==(TransportProtocol left, TransportProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TransportProtocol"/> values are not the same. </summary>
        public static bool operator !=(TransportProtocol left, TransportProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TransportProtocol"/>. </summary>
        public static implicit operator TransportProtocol(string value) => new TransportProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TransportProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TransportProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
