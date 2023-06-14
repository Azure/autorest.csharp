// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
    public readonly partial struct StorageSkuName : IEquatable<StorageSkuName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageSkuName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageSkuName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StandardLRSValue = "Standard_LRS";
        private const string StandardGRSValue = "Standard_GRS";
        private const string StandardRagrsValue = "Standard_RAGRS";
        private const string StandardZRSValue = "Standard_ZRS";
        private const string PremiumLRSValue = "Premium_LRS";
        private const string PremiumZRSValue = "Premium_ZRS";
        private const string StandardGzrsValue = "Standard_GZRS";
        private const string StandardRagzrsValue = "Standard_RAGZRS";

        /// <summary> Standard_LRS. </summary>
        public static StorageSkuName StandardLRS { get; } = new StorageSkuName(StandardLRSValue);
        /// <summary> Standard_GRS. </summary>
        public static StorageSkuName StandardGRS { get; } = new StorageSkuName(StandardGRSValue);
        /// <summary> Standard_RAGRS. </summary>
        public static StorageSkuName StandardRagrs { get; } = new StorageSkuName(StandardRagrsValue);
        /// <summary> Standard_ZRS. </summary>
        public static StorageSkuName StandardZRS { get; } = new StorageSkuName(StandardZRSValue);
        /// <summary> Premium_LRS. </summary>
        public static StorageSkuName PremiumLRS { get; } = new StorageSkuName(PremiumLRSValue);
        /// <summary> Premium_ZRS. </summary>
        public static StorageSkuName PremiumZRS { get; } = new StorageSkuName(PremiumZRSValue);
        /// <summary> Standard_GZRS. </summary>
        public static StorageSkuName StandardGzrs { get; } = new StorageSkuName(StandardGzrsValue);
        /// <summary> Standard_RAGZRS. </summary>
        public static StorageSkuName StandardRagzrs { get; } = new StorageSkuName(StandardRagzrsValue);
        /// <summary> Determines if two <see cref="StorageSkuName"/> values are the same. </summary>
        public static bool operator ==(StorageSkuName left, StorageSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageSkuName"/> values are not the same. </summary>
        public static bool operator !=(StorageSkuName left, StorageSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StorageSkuName"/>. </summary>
        public static implicit operator StorageSkuName(string value) => new StorageSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
