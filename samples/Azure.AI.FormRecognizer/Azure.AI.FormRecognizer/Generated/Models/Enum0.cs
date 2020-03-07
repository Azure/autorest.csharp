// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The Enum0. </summary>
    public readonly partial struct Enum0 : IEquatable<Enum0>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
        public Enum0(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FullValue = "full";
        private const string SummaryValue = "summary";

        /// <summary> full. </summary>
        public static Enum0 Full { get; } = new Enum0(FullValue);
        /// <summary> summary. </summary>
        public static Enum0 Summary { get; } = new Enum0(SummaryValue);
        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
        public static bool operator ==(Enum0 left, Enum0 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum0"/> values are not the same. </summary>
        public static bool operator !=(Enum0 left, Enum0 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum0"/>. </summary>
        public static implicit operator Enum0(string value) => new Enum0(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Enum0 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum0 other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
