// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Management.Models
{
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct PrivateEndpointServiceConnectionStatus : IEquatable<PrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="PrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public PrivateEndpointServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";

        /// <summary> Pending. </summary>
        public static PrivateEndpointServiceConnectionStatus Pending { get; } = new PrivateEndpointServiceConnectionStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static PrivateEndpointServiceConnectionStatus Approved { get; } = new PrivateEndpointServiceConnectionStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static PrivateEndpointServiceConnectionStatus Rejected { get; } = new PrivateEndpointServiceConnectionStatus(RejectedValue);
        /// <summary> Determines if two <see cref="PrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(PrivateEndpointServiceConnectionStatus left, PrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PrivateEndpointServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(PrivateEndpointServiceConnectionStatus left, PrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PrivateEndpointServiceConnectionStatus"/>. </summary>
        public static implicit operator PrivateEndpointServiceConnectionStatus(string value) => new PrivateEndpointServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
