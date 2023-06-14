// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the state of virtual network rule. </summary>
    public readonly partial struct State : IEquatable<State>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="State"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public State(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ProvisioningValue = "Provisioning";
        private const string DeprovisioningValue = "Deprovisioning";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string NetworkSourceDeletedValue = "NetworkSourceDeleted";

        /// <summary> Provisioning. </summary>
        public static State Provisioning { get; } = new State(ProvisioningValue);
        /// <summary> Deprovisioning. </summary>
        public static State Deprovisioning { get; } = new State(DeprovisioningValue);
        /// <summary> Succeeded. </summary>
        public static State Succeeded { get; } = new State(SucceededValue);
        /// <summary> Failed. </summary>
        public static State Failed { get; } = new State(FailedValue);
        /// <summary> NetworkSourceDeleted. </summary>
        public static State NetworkSourceDeleted { get; } = new State(NetworkSourceDeletedValue);
        /// <summary> Determines if two <see cref="State"/> values are the same. </summary>
        public static bool operator ==(State left, State right) => left.Equals(right);
        /// <summary> Determines if two <see cref="State"/> values are not the same. </summary>
        public static bool operator !=(State left, State right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="State"/>. </summary>
        public static implicit operator State(string value) => new State(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is State other && Equals(other);
        /// <inheritdoc />
        public bool Equals(State other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
