// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The VirtualMachineScaleSetScaleInRule.
    /// Serialized Name: VirtualMachineScaleSetScaleInRules
    /// </summary>
    public readonly partial struct VirtualMachineScaleSetScaleInRule : IEquatable<VirtualMachineScaleSetScaleInRule>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetScaleInRule"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachineScaleSetScaleInRule(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "Default";
        private const string OldestVmValue = "OldestVM";
        private const string NewestVmValue = "NewestVM";

        /// <summary>
        /// Default
        /// Serialized Name: VirtualMachineScaleSetScaleInRules.Default
        /// </summary>
        public static VirtualMachineScaleSetScaleInRule Default { get; } = new VirtualMachineScaleSetScaleInRule(DefaultValue);
        /// <summary>
        /// OldestVM
        /// Serialized Name: VirtualMachineScaleSetScaleInRules.OldestVM
        /// </summary>
        public static VirtualMachineScaleSetScaleInRule OldestVm { get; } = new VirtualMachineScaleSetScaleInRule(OldestVmValue);
        /// <summary>
        /// NewestVM
        /// Serialized Name: VirtualMachineScaleSetScaleInRules.NewestVM
        /// </summary>
        public static VirtualMachineScaleSetScaleInRule NewestVm { get; } = new VirtualMachineScaleSetScaleInRule(NewestVmValue);
        /// <summary> Determines if two <see cref="VirtualMachineScaleSetScaleInRule"/> values are the same. </summary>
        public static bool operator ==(VirtualMachineScaleSetScaleInRule left, VirtualMachineScaleSetScaleInRule right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachineScaleSetScaleInRule"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachineScaleSetScaleInRule left, VirtualMachineScaleSetScaleInRule right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachineScaleSetScaleInRule"/>. </summary>
        public static implicit operator VirtualMachineScaleSetScaleInRule(string value) => new VirtualMachineScaleSetScaleInRule(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachineScaleSetScaleInRule other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachineScaleSetScaleInRule other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
