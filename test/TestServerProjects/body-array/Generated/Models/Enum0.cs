// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_array.Models.V100
{
    public readonly partial struct Enum0 : IEquatable<Enum0>
    {
        private readonly string? _value;

        public Enum0(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Foo1Value = "foo1";
        private const string Foo2Value = "foo2";
        private const string Foo3Value = "foo3";

        public static Enum0 Foo1 { get; } = new Enum0(Foo1Value);
        public static Enum0 Foo2 { get; } = new Enum0(Foo2Value);
        public static Enum0 Foo3 { get; } = new Enum0(Foo3Value);
        public static bool operator ==(Enum0 left, Enum0 right) => left.Equals(right);
        public static bool operator !=(Enum0 left, Enum0 right) => !left.Equals(right);
        public static implicit operator Enum0(string value) => new Enum0(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Enum0 other && Equals(other);
        public bool Equals(Enum0 other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
