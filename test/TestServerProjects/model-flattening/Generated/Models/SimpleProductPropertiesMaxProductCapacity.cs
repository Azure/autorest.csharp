// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace model_flattening.Models
{
    /// <summary> Capacity of product. For example, 4 people. </summary>
    public readonly partial struct SimpleProductPropertiesMaxProductCapacity : IEquatable<SimpleProductPropertiesMaxProductCapacity>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SimpleProductPropertiesMaxProductCapacity"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SimpleProductPropertiesMaxProductCapacity(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LargeValue = "Large";

        /// <summary> Large. </summary>
        public static SimpleProductPropertiesMaxProductCapacity Large { get; } = new SimpleProductPropertiesMaxProductCapacity(LargeValue);
        /// <summary> Determines if two <see cref="SimpleProductPropertiesMaxProductCapacity"/> values are the same. </summary>
        public static bool operator ==(SimpleProductPropertiesMaxProductCapacity left, SimpleProductPropertiesMaxProductCapacity right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SimpleProductPropertiesMaxProductCapacity"/> values are not the same. </summary>
        public static bool operator !=(SimpleProductPropertiesMaxProductCapacity left, SimpleProductPropertiesMaxProductCapacity right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SimpleProductPropertiesMaxProductCapacity"/>. </summary>
        public static implicit operator SimpleProductPropertiesMaxProductCapacity(string value) => new SimpleProductPropertiesMaxProductCapacity(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SimpleProductPropertiesMaxProductCapacity other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SimpleProductPropertiesMaxProductCapacity other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
