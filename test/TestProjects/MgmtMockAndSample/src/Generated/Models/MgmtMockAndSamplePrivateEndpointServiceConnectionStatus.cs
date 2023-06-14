// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct MgmtMockAndSamplePrivateEndpointServiceConnectionStatus : IEquatable<MgmtMockAndSamplePrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointServiceConnectionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";
        private const string DisconnectedValue = "Disconnected";

        /// <summary> Pending. </summary>
        public static MgmtMockAndSamplePrivateEndpointServiceConnectionStatus Pending { get; } = new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(PendingValue);
        /// <summary> Approved. </summary>
        public static MgmtMockAndSamplePrivateEndpointServiceConnectionStatus Approved { get; } = new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(ApprovedValue);
        /// <summary> Rejected. </summary>
        public static MgmtMockAndSamplePrivateEndpointServiceConnectionStatus Rejected { get; } = new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(RejectedValue);
        /// <summary> Disconnected. </summary>
        public static MgmtMockAndSamplePrivateEndpointServiceConnectionStatus Disconnected { get; } = new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(DisconnectedValue);
        /// <summary> Determines if two <see cref="MgmtMockAndSamplePrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(MgmtMockAndSamplePrivateEndpointServiceConnectionStatus left, MgmtMockAndSamplePrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MgmtMockAndSamplePrivateEndpointServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(MgmtMockAndSamplePrivateEndpointServiceConnectionStatus left, MgmtMockAndSamplePrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MgmtMockAndSamplePrivateEndpointServiceConnectionStatus"/>. </summary>
        public static implicit operator MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(string value) => new MgmtMockAndSamplePrivateEndpointServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MgmtMockAndSamplePrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MgmtMockAndSamplePrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
