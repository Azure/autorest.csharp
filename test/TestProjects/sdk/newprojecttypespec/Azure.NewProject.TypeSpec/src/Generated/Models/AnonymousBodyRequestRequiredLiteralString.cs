// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.NewProject.TypeSpec.Models
{
    /// <summary> The AnonymousBodyRequest_requiredLiteralString. </summary>
    public readonly partial struct AnonymousBodyRequestRequiredLiteralString : IEquatable<AnonymousBodyRequestRequiredLiteralString>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnonymousBodyRequestRequiredLiteralString"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnonymousBodyRequestRequiredLiteralString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AcceptValue = "accept";

        /// <summary> accept. </summary>
        public static AnonymousBodyRequestRequiredLiteralString Accept { get; } = new AnonymousBodyRequestRequiredLiteralString(AcceptValue);
        /// <summary> Determines if two <see cref="AnonymousBodyRequestRequiredLiteralString"/> values are the same. </summary>
        public static bool operator ==(AnonymousBodyRequestRequiredLiteralString left, AnonymousBodyRequestRequiredLiteralString right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnonymousBodyRequestRequiredLiteralString"/> values are not the same. </summary>
        public static bool operator !=(AnonymousBodyRequestRequiredLiteralString left, AnonymousBodyRequestRequiredLiteralString right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnonymousBodyRequestRequiredLiteralString"/>. </summary>
        public static implicit operator AnonymousBodyRequestRequiredLiteralString(string value) => new AnonymousBodyRequestRequiredLiteralString(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnonymousBodyRequestRequiredLiteralString other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnonymousBodyRequestRequiredLiteralString other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
