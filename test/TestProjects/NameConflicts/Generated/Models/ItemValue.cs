// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace NameConflicts.Models
{
    /// <summary> The ItemValue. </summary>
    internal readonly partial struct ItemValue : IEquatable<ItemValue>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ItemValue"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ItemValue(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ItemValue1Value = "ItemValue1";
        private const string ItemValue3 = "Item";
        private const string ItemValue2Value = "ItemValue2";

        /// <summary> ItemValue1. </summary>
        public static ItemValue ItemValue1 { get; } = new ItemValue(ItemValue1Value);
        /// <summary> Item. </summary>
        public static ItemValue Item { get; } = new ItemValue(ItemValue3);
        /// <summary> ItemValue2. </summary>
        public static ItemValue ItemValue2 { get; } = new ItemValue(ItemValue2Value);
        /// <summary> Determines if two <see cref="ItemValue"/> values are the same. </summary>
        public static bool operator ==(ItemValue left, ItemValue right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ItemValue"/> values are not the same. </summary>
        public static bool operator !=(ItemValue left, ItemValue right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ItemValue"/>. </summary>
        public static implicit operator ItemValue(string value) => new ItemValue(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ItemValue other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ItemValue other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
