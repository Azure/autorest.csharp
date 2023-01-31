// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace AnomalyDetector.Models
{
    public readonly partial struct APIVersion : IEquatable<APIVersion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="APIVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public APIVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string V11Value = "v1.1";

        /// <summary> v1.1. </summary>
        public static APIVersion V11 { get; } = new APIVersion(V11Value);
        /// <summary> Determines if two <see cref="APIVersion"/> values are the same. </summary>
        public static bool operator ==(APIVersion left, APIVersion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="APIVersion"/> values are not the same. </summary>
        public static bool operator !=(APIVersion left, APIVersion right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="APIVersion"/>. </summary>
        public static implicit operator APIVersion(string value) => new APIVersion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is APIVersion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(APIVersion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
