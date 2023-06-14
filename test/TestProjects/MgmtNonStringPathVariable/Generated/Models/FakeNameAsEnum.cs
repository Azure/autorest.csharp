// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> The FakeNameAsEnum. </summary>
    public readonly partial struct FakeNameAsEnum : IEquatable<FakeNameAsEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FakeNameAsEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FakeNameAsEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Name1Value = "name1";
        private const string Name2Value = "name2";

        /// <summary> name1. </summary>
        public static FakeNameAsEnum Name1 { get; } = new FakeNameAsEnum(Name1Value);
        /// <summary> name2. </summary>
        public static FakeNameAsEnum Name2 { get; } = new FakeNameAsEnum(Name2Value);
        /// <summary> Determines if two <see cref="FakeNameAsEnum"/> values are the same. </summary>
        public static bool operator ==(FakeNameAsEnum left, FakeNameAsEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FakeNameAsEnum"/> values are not the same. </summary>
        public static bool operator !=(FakeNameAsEnum left, FakeNameAsEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FakeNameAsEnum"/>. </summary>
        public static implicit operator FakeNameAsEnum(string value) => new FakeNameAsEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FakeNameAsEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FakeNameAsEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
