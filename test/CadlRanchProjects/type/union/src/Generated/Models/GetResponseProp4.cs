// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> The GetResponseProp4. </summary>
    public readonly partial struct GetResponseProp4 : IEquatable<GetResponseProp4>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="GetResponseProp4"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public GetResponseProp4(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string CValue = "c";

        /// <summary> b. </summary>
        public static GetResponseProp4 B { get; } = new GetResponseProp4(BValue);
        /// <summary> c. </summary>
        public static GetResponseProp4 C { get; } = new GetResponseProp4(CValue);
        /// <summary> Determines if two <see cref="GetResponseProp4"/> values are the same. </summary>
        public static bool operator ==(GetResponseProp4 left, GetResponseProp4 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="GetResponseProp4"/> values are not the same. </summary>
        public static bool operator !=(GetResponseProp4 left, GetResponseProp4 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="GetResponseProp4"/>. </summary>
        public static implicit operator GetResponseProp4(string value) => new GetResponseProp4(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GetResponseProp4 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(GetResponseProp4 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
