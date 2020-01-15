// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_array.Models.V100
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct Enum0 : IEquatable<Enum0>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
        public Enum0(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Foo1Value = "foo1";
        private const string Foo2Value = "foo2";
        private const string Foo3Value = "foo3";

        /// <summary> foo1. </summary>
        public static Enum0 Foo1 { get; } = new Enum0(Foo1Value);
        /// <summary> foo2. </summary>
        public static Enum0 Foo2 { get; } = new Enum0(Foo2Value);
        /// <summary> foo3. </summary>
        public static Enum0 Foo3 { get; } = new Enum0(Foo3Value);
        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
        public static bool operator ==(Enum0 left, Enum0 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum0"/> values are not the same. </summary>
        public static bool operator !=(Enum0 left, Enum0 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum0"/>. </summary>
        public static implicit operator Enum0(string value) => new Enum0(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Enum0 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum0 other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
