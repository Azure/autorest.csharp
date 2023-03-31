// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The current provisioning state. </summary>
    public readonly partial struct MgmtMockAndSamplePrivateEndpointConnectionProvisioningState : IEquatable<MgmtMockAndSamplePrivateEndpointConnectionProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointConnectionProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string CreatingValue = "Creating";
        private const string UpdatingValue = "Updating";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";
        private const string DisconnectedValue = "Disconnected";

        /// <summary> Succeeded. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Succeeded { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(SucceededValue);
        /// <summary> Creating. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Creating { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(CreatingValue);
        /// <summary> Updating. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Updating { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(UpdatingValue);
        /// <summary> Deleting. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Deleting { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(DeletingValue);
        /// <summary> Failed. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Failed { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(FailedValue);
        /// <summary> Disconnected. </summary>
        public static MgmtMockAndSamplePrivateEndpointConnectionProvisioningState Disconnected { get; } = new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(DisconnectedValue);

        internal string ToSerialString() => _value;

        /// <summary> Determines if two <see cref="MgmtMockAndSamplePrivateEndpointConnectionProvisioningState"/> values are the same. </summary>
        public static bool operator ==(MgmtMockAndSamplePrivateEndpointConnectionProvisioningState left, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MgmtMockAndSamplePrivateEndpointConnectionProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(MgmtMockAndSamplePrivateEndpointConnectionProvisioningState left, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MgmtMockAndSamplePrivateEndpointConnectionProvisioningState"/>. </summary>
        public static implicit operator MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(string value) => new MgmtMockAndSamplePrivateEndpointConnectionProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MgmtMockAndSamplePrivateEndpointConnectionProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MgmtMockAndSamplePrivateEndpointConnectionProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
