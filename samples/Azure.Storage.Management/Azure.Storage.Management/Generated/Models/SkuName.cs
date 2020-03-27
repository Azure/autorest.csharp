// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Management.Models
{
    /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
    public readonly partial struct SkuName : IEquatable<SkuName>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="SkuName"/> values are the same. </summary>
        public SkuName(string value)
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
        public static SkuName StandardLRS { get; } = new SkuName(StandardLRSValue);
        /// <summary> Standard_GRS. </summary>
        public static SkuName StandardGRS { get; } = new SkuName(StandardGRSValue);
        /// <summary> Standard_RAGRS. </summary>
        public static SkuName StandardRagrs { get; } = new SkuName(StandardRagrsValue);
        /// <summary> Standard_ZRS. </summary>
        public static SkuName StandardZRS { get; } = new SkuName(StandardZRSValue);
        /// <summary> Premium_LRS. </summary>
        public static SkuName PremiumLRS { get; } = new SkuName(PremiumLRSValue);
        /// <summary> Premium_ZRS. </summary>
        public static SkuName PremiumZRS { get; } = new SkuName(PremiumZRSValue);
        /// <summary> Standard_GZRS. </summary>
        public static SkuName StandardGzrs { get; } = new SkuName(StandardGzrsValue);
        /// <summary> Standard_RAGZRS. </summary>
        public static SkuName StandardRagzrs { get; } = new SkuName(StandardRagzrsValue);
        /// <summary> Determines if two <see cref="SkuName"/> values are the same. </summary>
        public static bool operator ==(SkuName left, SkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SkuName"/> values are not the same. </summary>
        public static bool operator !=(SkuName left, SkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SkuName"/>. </summary>
        public static implicit operator SkuName(string value) => new SkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SkuName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
