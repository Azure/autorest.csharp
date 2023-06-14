// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the storage account type for the managed disk. Managed OS disk storage account type can only be set when you create the scale set. NOTE: UltraSSD_LRS can only be used with data disks. It cannot be used with OS Disk. Standard_LRS uses Standard HDD. StandardSSD_LRS uses Standard SSD. Premium_LRS uses Premium SSD. UltraSSD_LRS uses Ultra disk. For more information regarding disks supported for Windows Virtual Machines, refer to https://docs.microsoft.com/en-us/azure/virtual-machines/windows/disks-types and, for Linux Virtual Machines, refer to https://docs.microsoft.com/en-us/azure/virtual-machines/linux/disks-types
    /// Serialized Name: StorageAccountTypes
    /// </summary>
    public readonly partial struct StorageAccountType : IEquatable<StorageAccountType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StandardLRSValue = "Standard_LRS";
        private const string PremiumLRSValue = "Premium_LRS";
        private const string StandardSSDLRSValue = "StandardSSD_LRS";
        private const string UltraSSDLRSValue = "UltraSSD_LRS";

        /// <summary>
        /// Standard_LRS
        /// Serialized Name: StorageAccountTypes.Standard_LRS
        /// </summary>
        public static StorageAccountType StandardLRS { get; } = new StorageAccountType(StandardLRSValue);
        /// <summary>
        /// Premium_LRS
        /// Serialized Name: StorageAccountTypes.Premium_LRS
        /// </summary>
        public static StorageAccountType PremiumLRS { get; } = new StorageAccountType(PremiumLRSValue);
        /// <summary>
        /// StandardSSD_LRS
        /// Serialized Name: StorageAccountTypes.StandardSSD_LRS
        /// </summary>
        public static StorageAccountType StandardSSDLRS { get; } = new StorageAccountType(StandardSSDLRSValue);
        /// <summary>
        /// UltraSSD_LRS
        /// Serialized Name: StorageAccountTypes.UltraSSD_LRS
        /// </summary>
        public static StorageAccountType UltraSSDLRS { get; } = new StorageAccountType(UltraSSDLRSValue);
        /// <summary> Determines if two <see cref="StorageAccountType"/> values are the same. </summary>
        public static bool operator ==(StorageAccountType left, StorageAccountType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageAccountType"/> values are not the same. </summary>
        public static bool operator !=(StorageAccountType left, StorageAccountType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StorageAccountType"/>. </summary>
        public static implicit operator StorageAccountType(string value) => new StorageAccountType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageAccountType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
