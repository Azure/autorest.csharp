// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Client.Naming.Models
{
    /// <summary> The ClientExtensibleEnum. </summary>
    public readonly partial struct ClientExtensibleEnum : IEquatable<ClientExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ClientExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ClientExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnumValue1Value = "value1";

        /// <summary> value1. </summary>
        public static ClientExtensibleEnum EnumValue1 { get; } = new ClientExtensibleEnum(EnumValue1Value);
        /// <summary> Determines if two <see cref="ClientExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(ClientExtensibleEnum left, ClientExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ClientExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(ClientExtensibleEnum left, ClientExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ClientExtensibleEnum"/>. </summary>
        public static implicit operator ClientExtensibleEnum(string value) => new ClientExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ClientExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ClientExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
