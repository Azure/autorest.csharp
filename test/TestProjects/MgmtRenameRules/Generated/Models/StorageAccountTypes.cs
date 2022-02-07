// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary> Specifies the storage account type for the managed disk. Managed OS disk storage account type can only be set when you create the scale set. NOTE: UltraSSD_LRS can only be used with data disks. It cannot be used with OS Disk. Standard_LRS uses Standard HDD. StandardSSD_LRS uses Standard SSD. Premium_LRS uses Premium SSD. UltraSSD_LRS uses Ultra disk. For more information regarding disks supported for Windows Virtual Machines, refer to https://docs.microsoft.com/en-us/azure/virtual-machines/windows/disks-types and, for Linux Virtual Machines, refer to https://docs.microsoft.com/en-us/azure/virtual-machines/linux/disks-types. </summary>
    public readonly partial struct StorageAccountTypes : IEquatable<StorageAccountTypes>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountTypes"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountTypes(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StandardLRSValue = "Standard_LRS";
        private const string PremiumLRSValue = "Premium_LRS";
        private const string StandardSSDLRSValue = "StandardSSD_LRS";
        private const string UltraSSDLRSValue = "UltraSSD_LRS";

        /// <summary> Standard_LRS. </summary>
        public static StorageAccountTypes StandardLRS { get; } = new StorageAccountTypes(StandardLRSValue);
        /// <summary> Premium_LRS. </summary>
        public static StorageAccountTypes PremiumLRS { get; } = new StorageAccountTypes(PremiumLRSValue);
        /// <summary> StandardSSD_LRS. </summary>
        public static StorageAccountTypes StandardSSDLRS { get; } = new StorageAccountTypes(StandardSSDLRSValue);
        /// <summary> UltraSSD_LRS. </summary>
        public static StorageAccountTypes UltraSSDLRS { get; } = new StorageAccountTypes(UltraSSDLRSValue);
        /// <summary> Determines if two <see cref="StorageAccountTypes"/> values are the same. </summary>
        public static bool operator ==(StorageAccountTypes left, StorageAccountTypes right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageAccountTypes"/> values are not the same. </summary>
        public static bool operator !=(StorageAccountTypes left, StorageAccountTypes right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StorageAccountTypes"/>. </summary>
        public static implicit operator StorageAccountTypes(string value) => new StorageAccountTypes(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountTypes other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageAccountTypes other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
