// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the priority for a standalone virtual machine or the virtual machines in the scale set. &lt;br&gt;&lt;br&gt; 'Low' enum will be deprecated in the future, please use 'Spot' as the enum to deploy Azure Spot VM/VMSS.
    /// Serialized Name: VirtualMachinePriorityTypes
    /// </summary>
    public readonly partial struct VirtualMachinePriorityType : IEquatable<VirtualMachinePriorityType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VirtualMachinePriorityType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachinePriorityType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RegularValue = "Regular";
        private const string LowValue = "Low";
        private const string SpotValue = "Spot";

        /// <summary>
        /// Regular
        /// Serialized Name: VirtualMachinePriorityTypes.Regular
        /// </summary>
        public static VirtualMachinePriorityType Regular { get; } = new VirtualMachinePriorityType(RegularValue);
        /// <summary>
        /// Low
        /// Serialized Name: VirtualMachinePriorityTypes.Low
        /// </summary>
        public static VirtualMachinePriorityType Low { get; } = new VirtualMachinePriorityType(LowValue);
        /// <summary>
        /// Spot
        /// Serialized Name: VirtualMachinePriorityTypes.Spot
        /// </summary>
        public static VirtualMachinePriorityType Spot { get; } = new VirtualMachinePriorityType(SpotValue);
        /// <summary> Determines if two <see cref="VirtualMachinePriorityType"/> values are the same. </summary>
        public static bool operator ==(VirtualMachinePriorityType left, VirtualMachinePriorityType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachinePriorityType"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachinePriorityType left, VirtualMachinePriorityType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachinePriorityType"/>. </summary>
        public static implicit operator VirtualMachinePriorityType(string value) => new VirtualMachinePriorityType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachinePriorityType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachinePriorityType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
