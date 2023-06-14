// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased. </summary>
    public readonly partial struct LeaseDuration : IEquatable<LeaseDuration>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LeaseDuration"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LeaseDuration(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InfiniteValue = "Infinite";
        private const string FixedValue = "Fixed";

        /// <summary> Infinite. </summary>
        public static LeaseDuration Infinite { get; } = new LeaseDuration(InfiniteValue);
        /// <summary> Fixed. </summary>
        public static LeaseDuration Fixed { get; } = new LeaseDuration(FixedValue);
        /// <summary> Determines if two <see cref="LeaseDuration"/> values are the same. </summary>
        public static bool operator ==(LeaseDuration left, LeaseDuration right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LeaseDuration"/> values are not the same. </summary>
        public static bool operator !=(LeaseDuration left, LeaseDuration right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LeaseDuration"/>. </summary>
        public static implicit operator LeaseDuration(string value) => new LeaseDuration(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LeaseDuration other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LeaseDuration other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
