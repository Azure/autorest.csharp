// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The current provisioning state. </summary>
    public readonly partial struct StoragePrivateEndpointConnectionProvisioningState : IEquatable<StoragePrivateEndpointConnectionProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StoragePrivateEndpointConnectionProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StoragePrivateEndpointConnectionProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string CreatingValue = "Creating";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";

        /// <summary> Succeeded. </summary>
        public static StoragePrivateEndpointConnectionProvisioningState Succeeded { get; } = new StoragePrivateEndpointConnectionProvisioningState(SucceededValue);
        /// <summary> Creating. </summary>
        public static StoragePrivateEndpointConnectionProvisioningState Creating { get; } = new StoragePrivateEndpointConnectionProvisioningState(CreatingValue);
        /// <summary> Deleting. </summary>
        public static StoragePrivateEndpointConnectionProvisioningState Deleting { get; } = new StoragePrivateEndpointConnectionProvisioningState(DeletingValue);
        /// <summary> Failed. </summary>
        public static StoragePrivateEndpointConnectionProvisioningState Failed { get; } = new StoragePrivateEndpointConnectionProvisioningState(FailedValue);
        /// <summary> Determines if two <see cref="StoragePrivateEndpointConnectionProvisioningState"/> values are the same. </summary>
        public static bool operator ==(StoragePrivateEndpointConnectionProvisioningState left, StoragePrivateEndpointConnectionProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StoragePrivateEndpointConnectionProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(StoragePrivateEndpointConnectionProvisioningState left, StoragePrivateEndpointConnectionProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StoragePrivateEndpointConnectionProvisioningState"/>. </summary>
        public static implicit operator StoragePrivateEndpointConnectionProvisioningState(string value) => new StoragePrivateEndpointConnectionProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StoragePrivateEndpointConnectionProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StoragePrivateEndpointConnectionProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
