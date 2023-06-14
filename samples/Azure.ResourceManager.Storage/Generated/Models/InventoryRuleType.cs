// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The valid value is Inventory. </summary>
    public readonly partial struct InventoryRuleType : IEquatable<InventoryRuleType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InventoryRuleType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InventoryRuleType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InventoryValue = "Inventory";

        /// <summary> Inventory. </summary>
        public static InventoryRuleType Inventory { get; } = new InventoryRuleType(InventoryValue);
        /// <summary> Determines if two <see cref="InventoryRuleType"/> values are the same. </summary>
        public static bool operator ==(InventoryRuleType left, InventoryRuleType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InventoryRuleType"/> values are not the same. </summary>
        public static bool operator !=(InventoryRuleType left, InventoryRuleType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InventoryRuleType"/>. </summary>
        public static implicit operator InventoryRuleType(string value) => new InventoryRuleType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InventoryRuleType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InventoryRuleType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
