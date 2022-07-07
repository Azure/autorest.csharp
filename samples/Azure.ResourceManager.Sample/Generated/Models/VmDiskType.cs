// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// VM disk types which are disallowed.
    /// Serialized Name: VmDiskTypes
    /// </summary>
    public readonly partial struct VmDiskType : IEquatable<VmDiskType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VmDiskType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VmDiskType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string UnmanagedValue = "Unmanaged";

        /// <summary>
        /// None
        /// Serialized Name: VmDiskTypes.None
        /// </summary>
        public static VmDiskType None { get; } = new VmDiskType(NoneValue);
        /// <summary>
        /// Unmanaged
        /// Serialized Name: VmDiskTypes.Unmanaged
        /// </summary>
        public static VmDiskType Unmanaged { get; } = new VmDiskType(UnmanagedValue);
        /// <summary> Determines if two <see cref="VmDiskType"/> values are the same. </summary>
        public static bool operator ==(VmDiskType left, VmDiskType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VmDiskType"/> values are not the same. </summary>
        public static bool operator !=(VmDiskType left, VmDiskType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VmDiskType"/>. </summary>
        public static implicit operator VmDiskType(string value) => new VmDiskType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VmDiskType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VmDiskType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
