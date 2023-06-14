// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the reboot requirements of the patch.
    /// Serialized Name: SoftwareUpdateRebootBehavior
    /// </summary>
    public readonly partial struct SoftwareUpdateRebootBehavior : IEquatable<SoftwareUpdateRebootBehavior>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SoftwareUpdateRebootBehavior"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SoftwareUpdateRebootBehavior(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NeverRebootsValue = "NeverReboots";
        private const string AlwaysRequiresRebootValue = "AlwaysRequiresReboot";
        private const string CanRequestRebootValue = "CanRequestReboot";

        /// <summary>
        /// NeverReboots
        /// Serialized Name: SoftwareUpdateRebootBehavior.NeverReboots
        /// </summary>
        public static SoftwareUpdateRebootBehavior NeverReboots { get; } = new SoftwareUpdateRebootBehavior(NeverRebootsValue);
        /// <summary>
        /// AlwaysRequiresReboot
        /// Serialized Name: SoftwareUpdateRebootBehavior.AlwaysRequiresReboot
        /// </summary>
        public static SoftwareUpdateRebootBehavior AlwaysRequiresReboot { get; } = new SoftwareUpdateRebootBehavior(AlwaysRequiresRebootValue);
        /// <summary>
        /// CanRequestReboot
        /// Serialized Name: SoftwareUpdateRebootBehavior.CanRequestReboot
        /// </summary>
        public static SoftwareUpdateRebootBehavior CanRequestReboot { get; } = new SoftwareUpdateRebootBehavior(CanRequestRebootValue);
        /// <summary> Determines if two <see cref="SoftwareUpdateRebootBehavior"/> values are the same. </summary>
        public static bool operator ==(SoftwareUpdateRebootBehavior left, SoftwareUpdateRebootBehavior right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SoftwareUpdateRebootBehavior"/> values are not the same. </summary>
        public static bool operator !=(SoftwareUpdateRebootBehavior left, SoftwareUpdateRebootBehavior right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SoftwareUpdateRebootBehavior"/>. </summary>
        public static implicit operator SoftwareUpdateRebootBehavior(string value) => new SoftwareUpdateRebootBehavior(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SoftwareUpdateRebootBehavior other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SoftwareUpdateRebootBehavior other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
