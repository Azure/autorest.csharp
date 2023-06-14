// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The current provisioning state. </summary>
    public readonly partial struct MgmtReferenceTypesPrivateEndpointConnectionProvisioningState : IEquatable<MgmtReferenceTypesPrivateEndpointConnectionProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MgmtReferenceTypesPrivateEndpointConnectionProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string CreatingValue = "Creating";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";

        /// <summary> Succeeded. </summary>
        public static MgmtReferenceTypesPrivateEndpointConnectionProvisioningState Succeeded { get; } = new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(SucceededValue);
        /// <summary> Creating. </summary>
        public static MgmtReferenceTypesPrivateEndpointConnectionProvisioningState Creating { get; } = new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(CreatingValue);
        /// <summary> Deleting. </summary>
        public static MgmtReferenceTypesPrivateEndpointConnectionProvisioningState Deleting { get; } = new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(DeletingValue);
        /// <summary> Failed. </summary>
        public static MgmtReferenceTypesPrivateEndpointConnectionProvisioningState Failed { get; } = new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(FailedValue);
        /// <summary> Determines if two <see cref="MgmtReferenceTypesPrivateEndpointConnectionProvisioningState"/> values are the same. </summary>
        public static bool operator ==(MgmtReferenceTypesPrivateEndpointConnectionProvisioningState left, MgmtReferenceTypesPrivateEndpointConnectionProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MgmtReferenceTypesPrivateEndpointConnectionProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(MgmtReferenceTypesPrivateEndpointConnectionProvisioningState left, MgmtReferenceTypesPrivateEndpointConnectionProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MgmtReferenceTypesPrivateEndpointConnectionProvisioningState"/>. </summary>
        public static implicit operator MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(string value) => new MgmtReferenceTypesPrivateEndpointConnectionProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MgmtReferenceTypesPrivateEndpointConnectionProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MgmtReferenceTypesPrivateEndpointConnectionProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
