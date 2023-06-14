// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct MgmtReferenceTypesPrivateEndpointServiceConnectionStatus : IEquatable<MgmtReferenceTypesPrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MgmtReferenceTypesPrivateEndpointServiceConnectionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";

        /// <summary> Pending. </summary>
        public static MgmtReferenceTypesPrivateEndpointServiceConnectionStatus Pending { get; } = new MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static MgmtReferenceTypesPrivateEndpointServiceConnectionStatus Approved { get; } = new MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static MgmtReferenceTypesPrivateEndpointServiceConnectionStatus Rejected { get; } = new MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(RejectedValue);
        /// <summary> Determines if two <see cref="MgmtReferenceTypesPrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(MgmtReferenceTypesPrivateEndpointServiceConnectionStatus left, MgmtReferenceTypesPrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MgmtReferenceTypesPrivateEndpointServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(MgmtReferenceTypesPrivateEndpointServiceConnectionStatus left, MgmtReferenceTypesPrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MgmtReferenceTypesPrivateEndpointServiceConnectionStatus"/>. </summary>
        public static implicit operator MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(string value) => new MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MgmtReferenceTypesPrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MgmtReferenceTypesPrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
