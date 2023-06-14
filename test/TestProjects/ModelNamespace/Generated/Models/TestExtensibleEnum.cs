// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace ModelNamespace
{
    /// <summary> More Letters. </summary>
    internal readonly partial struct TestExtensibleEnum : IEquatable<TestExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TestExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TestExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "A";
        private const string BValue = "B";
        private const string CValue = "C";

        /// <summary> A. </summary>
        public static TestExtensibleEnum A { get; } = new TestExtensibleEnum(AValue);
        /// <summary> B. </summary>
        public static TestExtensibleEnum B { get; } = new TestExtensibleEnum(BValue);
        /// <summary> C. </summary>
        public static TestExtensibleEnum C { get; } = new TestExtensibleEnum(CValue);
        /// <summary> Determines if two <see cref="TestExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(TestExtensibleEnum left, TestExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TestExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(TestExtensibleEnum left, TestExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TestExtensibleEnum"/>. </summary>
        public static implicit operator TestExtensibleEnum(string value) => new TestExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TestExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TestExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
