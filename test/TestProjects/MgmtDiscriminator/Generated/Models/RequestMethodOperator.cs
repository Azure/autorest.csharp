// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Describes operator to be matched. </summary>
    public readonly partial struct RequestMethodOperator : IEquatable<RequestMethodOperator>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestMethodOperator"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestMethodOperator(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EqualValue = "Equal";

        /// <summary> Equal. </summary>
        public static RequestMethodOperator Equal { get; } = new RequestMethodOperator(EqualValue);
        /// <summary> Determines if two <see cref="RequestMethodOperator"/> values are the same. </summary>
        public static bool operator ==(RequestMethodOperator left, RequestMethodOperator right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestMethodOperator"/> values are not the same. </summary>
        public static bool operator !=(RequestMethodOperator left, RequestMethodOperator right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RequestMethodOperator"/>. </summary>
        public static implicit operator RequestMethodOperator(string value) => new RequestMethodOperator(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestMethodOperator other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestMethodOperator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
