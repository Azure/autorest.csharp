// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The BlobInventoryPolicyName. </summary>
    public readonly partial struct BlobInventoryPolicyName : IEquatable<BlobInventoryPolicyName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BlobInventoryPolicyName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BlobInventoryPolicyName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "default";

        /// <summary> default. </summary>
        public static BlobInventoryPolicyName Default { get; } = new BlobInventoryPolicyName(DefaultValue);
        /// <summary> Determines if two <see cref="BlobInventoryPolicyName"/> values are the same. </summary>
        public static bool operator ==(BlobInventoryPolicyName left, BlobInventoryPolicyName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BlobInventoryPolicyName"/> values are not the same. </summary>
        public static bool operator !=(BlobInventoryPolicyName left, BlobInventoryPolicyName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="BlobInventoryPolicyName"/>. </summary>
        public static implicit operator BlobInventoryPolicyName(string value) => new BlobInventoryPolicyName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlobInventoryPolicyName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BlobInventoryPolicyName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
