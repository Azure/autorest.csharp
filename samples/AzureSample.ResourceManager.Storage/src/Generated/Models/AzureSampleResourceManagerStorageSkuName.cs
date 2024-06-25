// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace AzureSample.ResourceManager.Storage.Models
{
    /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
    public readonly partial struct AzureSampleResourceManagerStorageSkuName : IEquatable<AzureSampleResourceManagerStorageSkuName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AzureSampleResourceManagerStorageSkuName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AzureSampleResourceManagerStorageSkuName(string value)
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
        public static AzureSampleResourceManagerStorageSkuName StandardLRS { get; } = new AzureSampleResourceManagerStorageSkuName(StandardLRSValue);
        /// <summary> Standard_GRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName StandardGRS { get; } = new AzureSampleResourceManagerStorageSkuName(StandardGRSValue);
        /// <summary> Standard_RAGRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName StandardRagrs { get; } = new AzureSampleResourceManagerStorageSkuName(StandardRagrsValue);
        /// <summary> Standard_ZRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName StandardZRS { get; } = new AzureSampleResourceManagerStorageSkuName(StandardZRSValue);
        /// <summary> Premium_LRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName PremiumLRS { get; } = new AzureSampleResourceManagerStorageSkuName(PremiumLRSValue);
        /// <summary> Premium_ZRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName PremiumZRS { get; } = new AzureSampleResourceManagerStorageSkuName(PremiumZRSValue);
        /// <summary> Standard_GZRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName StandardGzrs { get; } = new AzureSampleResourceManagerStorageSkuName(StandardGzrsValue);
        /// <summary> Standard_RAGZRS. </summary>
        public static AzureSampleResourceManagerStorageSkuName StandardRagzrs { get; } = new AzureSampleResourceManagerStorageSkuName(StandardRagzrsValue);
        /// <summary> Determines if two <see cref="AzureSampleResourceManagerStorageSkuName"/> values are the same. </summary>
        public static bool operator ==(AzureSampleResourceManagerStorageSkuName left, AzureSampleResourceManagerStorageSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AzureSampleResourceManagerStorageSkuName"/> values are not the same. </summary>
        public static bool operator !=(AzureSampleResourceManagerStorageSkuName left, AzureSampleResourceManagerStorageSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AzureSampleResourceManagerStorageSkuName"/>. </summary>
        public static implicit operator AzureSampleResourceManagerStorageSkuName(string value) => new AzureSampleResourceManagerStorageSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AzureSampleResourceManagerStorageSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AzureSampleResourceManagerStorageSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
