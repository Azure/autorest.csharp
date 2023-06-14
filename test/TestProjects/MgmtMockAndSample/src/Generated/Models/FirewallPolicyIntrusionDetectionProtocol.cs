// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> Possible intrusion detection bypass traffic protocols. </summary>
    public readonly partial struct FirewallPolicyIntrusionDetectionProtocol : IEquatable<FirewallPolicyIntrusionDetectionProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIntrusionDetectionProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicyIntrusionDetectionProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TCPValue = "TCP";
        private const string UDPValue = "UDP";
        private const string IcmpValue = "ICMP";
        private const string ANYValue = "ANY";

        /// <summary> TCP. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol TCP { get; } = new FirewallPolicyIntrusionDetectionProtocol(TCPValue);
        /// <summary> UDP. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol UDP { get; } = new FirewallPolicyIntrusionDetectionProtocol(UDPValue);
        /// <summary> ICMP. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol Icmp { get; } = new FirewallPolicyIntrusionDetectionProtocol(IcmpValue);
        /// <summary> ANY. </summary>
        public static FirewallPolicyIntrusionDetectionProtocol ANY { get; } = new FirewallPolicyIntrusionDetectionProtocol(ANYValue);
        /// <summary> Determines if two <see cref="FirewallPolicyIntrusionDetectionProtocol"/> values are the same. </summary>
        public static bool operator ==(FirewallPolicyIntrusionDetectionProtocol left, FirewallPolicyIntrusionDetectionProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirewallPolicyIntrusionDetectionProtocol"/> values are not the same. </summary>
        public static bool operator !=(FirewallPolicyIntrusionDetectionProtocol left, FirewallPolicyIntrusionDetectionProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyIntrusionDetectionProtocol"/>. </summary>
        public static implicit operator FirewallPolicyIntrusionDetectionProtocol(string value) => new FirewallPolicyIntrusionDetectionProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicyIntrusionDetectionProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirewallPolicyIntrusionDetectionProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
