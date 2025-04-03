// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> The GetResponseProp1. </summary>
    public readonly partial struct GetResponseProp1 : IEquatable<GetResponseProp1>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="GetResponseProp1"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public GetResponseProp1(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string CValue = "c";

        /// <summary> b. </summary>
        public static GetResponseProp1 B { get; } = new GetResponseProp1(BValue);
        /// <summary> c. </summary>
        public static GetResponseProp1 C { get; } = new GetResponseProp1(CValue);
        /// <summary> Determines if two <see cref="GetResponseProp1"/> values are the same. </summary>
        public static bool operator ==(GetResponseProp1 left, GetResponseProp1 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="GetResponseProp1"/> values are not the same. </summary>
        public static bool operator !=(GetResponseProp1 left, GetResponseProp1 right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="GetResponseProp1"/>. </summary>
        public static implicit operator GetResponseProp1(string value) => new GetResponseProp1(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GetResponseProp1 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(GetResponseProp1 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
