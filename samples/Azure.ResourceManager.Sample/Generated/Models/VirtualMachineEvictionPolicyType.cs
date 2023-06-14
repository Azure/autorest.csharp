// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the eviction policy for the Azure Spot VM/VMSS
    /// Serialized Name: VirtualMachineEvictionPolicyTypes
    /// </summary>
    public readonly partial struct VirtualMachineEvictionPolicyType : IEquatable<VirtualMachineEvictionPolicyType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineEvictionPolicyType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachineEvictionPolicyType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeallocateValue = "Deallocate";
        private const string DeleteValue = "Delete";

        /// <summary>
        /// Deallocate
        /// Serialized Name: VirtualMachineEvictionPolicyTypes.Deallocate
        /// </summary>
        public static VirtualMachineEvictionPolicyType Deallocate { get; } = new VirtualMachineEvictionPolicyType(DeallocateValue);
        /// <summary>
        /// Delete
        /// Serialized Name: VirtualMachineEvictionPolicyTypes.Delete
        /// </summary>
        public static VirtualMachineEvictionPolicyType Delete { get; } = new VirtualMachineEvictionPolicyType(DeleteValue);
        /// <summary> Determines if two <see cref="VirtualMachineEvictionPolicyType"/> values are the same. </summary>
        public static bool operator ==(VirtualMachineEvictionPolicyType left, VirtualMachineEvictionPolicyType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachineEvictionPolicyType"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachineEvictionPolicyType left, VirtualMachineEvictionPolicyType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachineEvictionPolicyType"/>. </summary>
        public static implicit operator VirtualMachineEvictionPolicyType(string value) => new VirtualMachineEvictionPolicyType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachineEvictionPolicyType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachineEvictionPolicyType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
