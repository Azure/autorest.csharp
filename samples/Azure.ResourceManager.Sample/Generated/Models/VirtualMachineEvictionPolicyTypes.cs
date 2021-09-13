// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Specifies the eviction policy for the Azure Spot VM/VMSS. </summary>
    public readonly partial struct VirtualMachineEvictionPolicyTypes : IEquatable<VirtualMachineEvictionPolicyTypes>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of VirtualMachineEvictionPolicyTypes. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachineEvictionPolicyTypes(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeallocateValue = "Deallocate";
        private const string DeleteValue = "Delete";

        /// <summary> Deallocate. </summary>
        public static VirtualMachineEvictionPolicyTypes Deallocate { get; } = new VirtualMachineEvictionPolicyTypes(DeallocateValue);
        /// <summary> Delete. </summary>
        public static VirtualMachineEvictionPolicyTypes Delete { get; } = new VirtualMachineEvictionPolicyTypes(DeleteValue);
        /// <summary> Determines if two <see cref="VirtualMachineEvictionPolicyTypes"/> values are the same. </summary>
        public static bool operator ==(VirtualMachineEvictionPolicyTypes left, VirtualMachineEvictionPolicyTypes right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachineEvictionPolicyTypes"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachineEvictionPolicyTypes left, VirtualMachineEvictionPolicyTypes right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachineEvictionPolicyTypes"/>. </summary>
        public static implicit operator VirtualMachineEvictionPolicyTypes(string value) => new VirtualMachineEvictionPolicyTypes(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachineEvictionPolicyTypes other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachineEvictionPolicyTypes other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
