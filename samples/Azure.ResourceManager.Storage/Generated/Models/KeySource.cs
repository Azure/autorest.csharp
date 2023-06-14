// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault. </summary>
    public readonly partial struct KeySource : IEquatable<KeySource>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KeySource"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KeySource(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftStorageValue = "Microsoft.Storage";
        private const string MicrosoftKeyvaultValue = "Microsoft.Keyvault";

        /// <summary> Microsoft.Storage. </summary>
        public static KeySource MicrosoftStorage { get; } = new KeySource(MicrosoftStorageValue);
        /// <summary> Microsoft.Keyvault. </summary>
        public static KeySource MicrosoftKeyvault { get; } = new KeySource(MicrosoftKeyvaultValue);
        /// <summary> Determines if two <see cref="KeySource"/> values are the same. </summary>
        public static bool operator ==(KeySource left, KeySource right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KeySource"/> values are not the same. </summary>
        public static bool operator !=(KeySource left, KeySource right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="KeySource"/>. </summary>
        public static implicit operator KeySource(string value) => new KeySource(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeySource other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KeySource other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
