// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> Enum for prop in SendRequest. </summary>
    public readonly partial struct SendRequestProp : IEquatable<SendRequestProp>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SendRequestProp"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SendRequestProp(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "a";
        private const string BValue = "b";
        private const string CValue = "c";

        /// <summary> a. </summary>
        public static SendRequestProp A { get; } = new SendRequestProp(AValue);
        /// <summary> b. </summary>
        public static SendRequestProp B { get; } = new SendRequestProp(BValue);
        /// <summary> c. </summary>
        public static SendRequestProp C { get; } = new SendRequestProp(CValue);
        /// <summary> Determines if two <see cref="SendRequestProp"/> values are the same. </summary>
        public static bool operator ==(SendRequestProp left, SendRequestProp right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SendRequestProp"/> values are not the same. </summary>
        public static bool operator !=(SendRequestProp left, SendRequestProp right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SendRequestProp"/>. </summary>
        public static implicit operator SendRequestProp(string value) => new SendRequestProp(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SendRequestProp other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SendRequestProp other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}