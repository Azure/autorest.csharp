// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> Enum for prop in SendRequest2. </summary>
    public readonly partial struct SendRequest2Prop : IEquatable<SendRequest2Prop>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SendRequest2Prop"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SendRequest2Prop(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string CValue = "c";

        /// <summary> b. </summary>
        public static SendRequest2Prop B { get; } = new SendRequest2Prop(BValue);
        /// <summary> c. </summary>
        public static SendRequest2Prop C { get; } = new SendRequest2Prop(CValue);
        /// <summary> Determines if two <see cref="SendRequest2Prop"/> values are the same. </summary>
        public static bool operator ==(SendRequest2Prop left, SendRequest2Prop right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SendRequest2Prop"/> values are not the same. </summary>
        public static bool operator !=(SendRequest2Prop left, SendRequest2Prop right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SendRequest2Prop"/>. </summary>
        public static implicit operator SendRequest2Prop(string value) => new SendRequest2Prop(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SendRequest2Prop other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SendRequest2Prop other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
