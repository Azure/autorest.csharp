// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MultipleInputFiles.Models
{
    /// <summary> The SourceEnum. </summary>
    internal readonly partial struct SourceEnum : IEquatable<SourceEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SourceEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SourceEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Value1Value = "value1";
        private const string Value2Value = "value2";

        /// <summary> value1. </summary>
        public static SourceEnum Value1 { get; } = new SourceEnum(Value1Value);
        /// <summary> value2. </summary>
        public static SourceEnum Value2 { get; } = new SourceEnum(Value2Value);
        /// <summary> Determines if two <see cref="SourceEnum"/> values are the same. </summary>
        public static bool operator ==(SourceEnum left, SourceEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SourceEnum"/> values are not the same. </summary>
        public static bool operator !=(SourceEnum left, SourceEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SourceEnum"/>. </summary>
        public static implicit operator SourceEnum(string value) => new SourceEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SourceEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SourceEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
