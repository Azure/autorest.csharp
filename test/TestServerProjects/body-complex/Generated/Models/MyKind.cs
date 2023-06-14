// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace body_complex.Models
{
    /// <summary> The MyKind. </summary>
    public readonly partial struct MyKind : IEquatable<MyKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MyKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MyKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Kind1Value = "Kind1";

        /// <summary> Kind1. </summary>
        public static MyKind Kind1 { get; } = new MyKind(Kind1Value);
        /// <summary> Determines if two <see cref="MyKind"/> values are the same. </summary>
        public static bool operator ==(MyKind left, MyKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MyKind"/> values are not the same. </summary>
        public static bool operator !=(MyKind left, MyKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MyKind"/>. </summary>
        public static implicit operator MyKind(string value) => new MyKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MyKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MyKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
