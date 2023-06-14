// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace AppConfiguration.Models
{
    /// <summary> The Get5ItemsItem. </summary>
    public readonly partial struct Get5ItemsItem : IEquatable<Get5ItemsItem>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Get5ItemsItem"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Get5ItemsItem(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NameValue = "name";

        /// <summary> name. </summary>
        public static Get5ItemsItem Name { get; } = new Get5ItemsItem(NameValue);
        /// <summary> Determines if two <see cref="Get5ItemsItem"/> values are the same. </summary>
        public static bool operator ==(Get5ItemsItem left, Get5ItemsItem right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Get5ItemsItem"/> values are not the same. </summary>
        public static bool operator !=(Get5ItemsItem left, Get5ItemsItem right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Get5ItemsItem"/>. </summary>
        public static implicit operator Get5ItemsItem(string value) => new Get5ItemsItem(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Get5ItemsItem other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Get5ItemsItem other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
