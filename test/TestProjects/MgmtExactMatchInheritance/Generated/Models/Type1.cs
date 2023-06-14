// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The Type1. </summary>
    public readonly partial struct Type1 : IEquatable<Type1>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Type1"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Type1(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftFooBarValue = "Microsoft.Foo/bar";

        /// <summary> Microsoft.Foo/bar. </summary>
        public static Type1 MicrosoftFooBar { get; } = new Type1(MicrosoftFooBarValue);
        /// <summary> Determines if two <see cref="Type1"/> values are the same. </summary>
        public static bool operator ==(Type1 left, Type1 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Type1"/> values are not the same. </summary>
        public static bool operator !=(Type1 left, Type1 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Type1"/>. </summary>
        public static implicit operator Type1(string value) => new Type1(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Type1 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Type1 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
