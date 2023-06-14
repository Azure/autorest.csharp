// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The Enum4. </summary>
    public readonly partial struct Enum4 : IEquatable<Enum4>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Enum4"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Enum4(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ServiceValue = "service";

        /// <summary> service. </summary>
        public static Enum4 Service { get; } = new Enum4(ServiceValue);
        /// <summary> Determines if two <see cref="Enum4"/> values are the same. </summary>
        public static bool operator ==(Enum4 left, Enum4 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum4"/> values are not the same. </summary>
        public static bool operator !=(Enum4 left, Enum4 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum4"/>. </summary>
        public static implicit operator Enum4(string value) => new Enum4(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Enum4 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum4 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
