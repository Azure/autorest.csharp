// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Describes what transforms are applied before matching. </summary>
    public readonly partial struct Transform : IEquatable<Transform>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Transform"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Transform(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LowercaseValue = "Lowercase";
        private const string UppercaseValue = "Uppercase";
        private const string TrimValue = "Trim";
        private const string UrlDecodeValue = "UrlDecode";
        private const string UrlEncodeValue = "UrlEncode";
        private const string RemoveNullsValue = "RemoveNulls";

        /// <summary> Lowercase. </summary>
        public static Transform Lowercase { get; } = new Transform(LowercaseValue);
        /// <summary> Uppercase. </summary>
        public static Transform Uppercase { get; } = new Transform(UppercaseValue);
        /// <summary> Trim. </summary>
        public static Transform Trim { get; } = new Transform(TrimValue);
        /// <summary> UrlDecode. </summary>
        public static Transform UrlDecode { get; } = new Transform(UrlDecodeValue);
        /// <summary> UrlEncode. </summary>
        public static Transform UrlEncode { get; } = new Transform(UrlEncodeValue);
        /// <summary> RemoveNulls. </summary>
        public static Transform RemoveNulls { get; } = new Transform(RemoveNullsValue);
        /// <summary> Determines if two <see cref="Transform"/> values are the same. </summary>
        public static bool operator ==(Transform left, Transform right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Transform"/> values are not the same. </summary>
        public static bool operator !=(Transform left, Transform right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Transform"/>. </summary>
        public static implicit operator Transform(string value) => new Transform(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Transform other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Transform other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
