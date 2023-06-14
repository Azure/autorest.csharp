// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Inheritance.Models
{
    /// <summary> The BaseClassWithEntensibleEnumDiscriminatorEnum. </summary>
    public readonly partial struct BaseClassWithEntensibleEnumDiscriminatorEnum : IEquatable<BaseClassWithEntensibleEnumDiscriminatorEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BaseClassWithEntensibleEnumDiscriminatorEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BaseClassWithEntensibleEnumDiscriminatorEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DerivedValue = "derived";
        private const string OtherValue = "other";

        /// <summary> derived. </summary>
        public static BaseClassWithEntensibleEnumDiscriminatorEnum Derived { get; } = new BaseClassWithEntensibleEnumDiscriminatorEnum(DerivedValue);
        /// <summary> other. </summary>
        public static BaseClassWithEntensibleEnumDiscriminatorEnum Other { get; } = new BaseClassWithEntensibleEnumDiscriminatorEnum(OtherValue);
        /// <summary> Determines if two <see cref="BaseClassWithEntensibleEnumDiscriminatorEnum"/> values are the same. </summary>
        public static bool operator ==(BaseClassWithEntensibleEnumDiscriminatorEnum left, BaseClassWithEntensibleEnumDiscriminatorEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BaseClassWithEntensibleEnumDiscriminatorEnum"/> values are not the same. </summary>
        public static bool operator !=(BaseClassWithEntensibleEnumDiscriminatorEnum left, BaseClassWithEntensibleEnumDiscriminatorEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="BaseClassWithEntensibleEnumDiscriminatorEnum"/>. </summary>
        public static implicit operator BaseClassWithEntensibleEnumDiscriminatorEnum(string value) => new BaseClassWithEntensibleEnumDiscriminatorEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BaseClassWithEntensibleEnumDiscriminatorEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BaseClassWithEntensibleEnumDiscriminatorEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
