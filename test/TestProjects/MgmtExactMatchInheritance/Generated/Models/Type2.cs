// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The Type2. </summary>
    public readonly partial struct Type2 : IEquatable<Type2>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Type2"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Type2(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FooValue = "foo";

        /// <summary> foo. </summary>
        public static Type2 Foo { get; } = new Type2(FooValue);
        /// <summary> Determines if two <see cref="Type2"/> values are the same. </summary>
        public static bool operator ==(Type2 left, Type2 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Type2"/> values are not the same. </summary>
        public static bool operator !=(Type2 left, Type2 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Type2"/>. </summary>
        public static implicit operator Type2(string value) => new Type2(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Type2 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Type2 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
