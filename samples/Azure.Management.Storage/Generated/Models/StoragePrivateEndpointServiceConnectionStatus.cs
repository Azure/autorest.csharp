// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Management.Storage.Models
{
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct StoragePrivateEndpointServiceConnectionStatus : IEquatable<StoragePrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StoragePrivateEndpointServiceConnectionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StoragePrivateEndpointServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";

        /// <summary> Pending. </summary>
        public static StoragePrivateEndpointServiceConnectionStatus Pending { get; } = new StoragePrivateEndpointServiceConnectionStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static StoragePrivateEndpointServiceConnectionStatus Approved { get; } = new StoragePrivateEndpointServiceConnectionStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static StoragePrivateEndpointServiceConnectionStatus Rejected { get; } = new StoragePrivateEndpointServiceConnectionStatus(RejectedValue);
        /// <summary> Determines if two <see cref="StoragePrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(StoragePrivateEndpointServiceConnectionStatus left, StoragePrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StoragePrivateEndpointServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(StoragePrivateEndpointServiceConnectionStatus left, StoragePrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StoragePrivateEndpointServiceConnectionStatus"/>. </summary>
        public static implicit operator StoragePrivateEndpointServiceConnectionStatus(string value) => new StoragePrivateEndpointServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StoragePrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StoragePrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
