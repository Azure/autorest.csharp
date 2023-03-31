// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The name of the service.
    /// Serialized Name: OrchestrationServiceNames
    /// </summary>
    public readonly partial struct OrchestrationServiceName : IEquatable<OrchestrationServiceName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OrchestrationServiceName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OrchestrationServiceName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AutomaticRepairsValue = "AutomaticRepairs";

        /// <summary>
        /// AutomaticRepairs
        /// Serialized Name: OrchestrationServiceNames.AutomaticRepairs
        /// </summary>
        public static OrchestrationServiceName AutomaticRepairs { get; } = new OrchestrationServiceName(AutomaticRepairsValue);

        internal string ToSerialString() => _value;

        /// <summary> Determines if two <see cref="OrchestrationServiceName"/> values are the same. </summary>
        public static bool operator ==(OrchestrationServiceName left, OrchestrationServiceName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OrchestrationServiceName"/> values are not the same. </summary>
        public static bool operator !=(OrchestrationServiceName left, OrchestrationServiceName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OrchestrationServiceName"/>. </summary>
        public static implicit operator OrchestrationServiceName(string value) => new OrchestrationServiceName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OrchestrationServiceName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OrchestrationServiceName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
