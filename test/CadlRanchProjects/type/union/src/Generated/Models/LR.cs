// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> The LR. </summary>
    internal readonly partial struct LR : IEquatable<LR>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LR"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LR(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LeftValue = "left";
        private const string RightValue = "right";

        /// <summary> left. </summary>
        public static LR Left { get; } = new LR(LeftValue);
        /// <summary> right. </summary>
        public static LR Right { get; } = new LR(RightValue);
        /// <summary> Determines if two <see cref="LR"/> values are the same. </summary>
        public static bool operator ==(LR left, LR right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LR"/> values are not the same. </summary>
        public static bool operator !=(LR left, LR right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LR"/>. </summary>
        public static implicit operator LR(string value) => new LR(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LR other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LR other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
