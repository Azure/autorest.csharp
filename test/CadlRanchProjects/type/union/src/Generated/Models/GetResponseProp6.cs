// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Type.Union.Models
{
    /// <summary> The GetResponseProp6. </summary>
    public readonly partial struct GetResponseProp6 : IEquatable<GetResponseProp6>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="GetResponseProp6"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public GetResponseProp6(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string CValue = "c";

        /// <summary> b. </summary>
        public static GetResponseProp6 B { get; } = new GetResponseProp6(BValue);
        /// <summary> c. </summary>
        public static GetResponseProp6 C { get; } = new GetResponseProp6(CValue);
        /// <summary> Determines if two <see cref="GetResponseProp6"/> values are the same. </summary>
        public static bool operator ==(GetResponseProp6 left, GetResponseProp6 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="GetResponseProp6"/> values are not the same. </summary>
        public static bool operator !=(GetResponseProp6 left, GetResponseProp6 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="GetResponseProp6"/>. </summary>
        public static implicit operator GetResponseProp6(string value) => new GetResponseProp6(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GetResponseProp6 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(GetResponseProp6 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
