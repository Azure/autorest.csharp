// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The current state of the service.
    /// Serialized Name: OrchestrationServiceState
    /// </summary>
    public readonly partial struct OrchestrationServiceState : IEquatable<OrchestrationServiceState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OrchestrationServiceState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OrchestrationServiceState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotRunningValue = "NotRunning";
        private const string RunningValue = "Running";
        private const string SuspendedValue = "Suspended";

        /// <summary>
        /// NotRunning
        /// Serialized Name: OrchestrationServiceState.NotRunning
        /// </summary>
        public static OrchestrationServiceState NotRunning { get; } = new OrchestrationServiceState(NotRunningValue);
        /// <summary>
        /// Running
        /// Serialized Name: OrchestrationServiceState.Running
        /// </summary>
        public static OrchestrationServiceState Running { get; } = new OrchestrationServiceState(RunningValue);
        /// <summary>
        /// Suspended
        /// Serialized Name: OrchestrationServiceState.Suspended
        /// </summary>
        public static OrchestrationServiceState Suspended { get; } = new OrchestrationServiceState(SuspendedValue);
        /// <summary> Determines if two <see cref="OrchestrationServiceState"/> values are the same. </summary>
        public static bool operator ==(OrchestrationServiceState left, OrchestrationServiceState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OrchestrationServiceState"/> values are not the same. </summary>
        public static bool operator !=(OrchestrationServiceState left, OrchestrationServiceState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="OrchestrationServiceState"/>. </summary>
        public static implicit operator OrchestrationServiceState(string value) => new OrchestrationServiceState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OrchestrationServiceState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OrchestrationServiceState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
