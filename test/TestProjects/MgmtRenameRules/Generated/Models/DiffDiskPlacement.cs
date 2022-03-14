// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary> Specifies the ephemeral disk placement for operating system disk. This property can be used by user in the request to choose the location i.e, cache disk or resource disk space for Ephemeral OS disk provisioning. For more information on Ephemeral OS disk size requirements, please refer Ephemeral OS disk size requirements for Windows VM at https://docs.microsoft.com/en-us/azure/virtual-machines/windows/ephemeral-os-disks#size-requirements and Linux VM at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/ephemeral-os-disks#size-requirements. </summary>
    public readonly partial struct DiffDiskPlacement : IEquatable<DiffDiskPlacement>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DiffDiskPlacement"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DiffDiskPlacement(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CacheDiskValue = "CacheDisk";
        private const string ResourceDiskValue = "ResourceDisk";

        /// <summary> CacheDisk. </summary>
        public static DiffDiskPlacement CacheDisk { get; } = new DiffDiskPlacement(CacheDiskValue);
        /// <summary> ResourceDisk. </summary>
        public static DiffDiskPlacement ResourceDisk { get; } = new DiffDiskPlacement(ResourceDiskValue);
        /// <summary> Determines if two <see cref="DiffDiskPlacement"/> values are the same. </summary>
        public static bool operator ==(DiffDiskPlacement left, DiffDiskPlacement right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DiffDiskPlacement"/> values are not the same. </summary>
        public static bool operator !=(DiffDiskPlacement left, DiffDiskPlacement right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DiffDiskPlacement"/>. </summary>
        public static implicit operator DiffDiskPlacement(string value) => new DiffDiskPlacement(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DiffDiskPlacement other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DiffDiskPlacement other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
