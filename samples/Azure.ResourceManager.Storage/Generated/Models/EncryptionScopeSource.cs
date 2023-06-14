// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </summary>
    public readonly partial struct EncryptionScopeSource : IEquatable<EncryptionScopeSource>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EncryptionScopeSource"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EncryptionScopeSource(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftStorageValue = "Microsoft.Storage";
        private const string MicrosoftKeyVaultValue = "Microsoft.KeyVault";

        /// <summary> Microsoft.Storage. </summary>
        public static EncryptionScopeSource MicrosoftStorage { get; } = new EncryptionScopeSource(MicrosoftStorageValue);
        /// <summary> Microsoft.KeyVault. </summary>
        public static EncryptionScopeSource MicrosoftKeyVault { get; } = new EncryptionScopeSource(MicrosoftKeyVaultValue);
        /// <summary> Determines if two <see cref="EncryptionScopeSource"/> values are the same. </summary>
        public static bool operator ==(EncryptionScopeSource left, EncryptionScopeSource right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EncryptionScopeSource"/> values are not the same. </summary>
        public static bool operator !=(EncryptionScopeSource left, EncryptionScopeSource right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EncryptionScopeSource"/>. </summary>
        public static implicit operator EncryptionScopeSource(string value) => new EncryptionScopeSource(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EncryptionScopeSource other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EncryptionScopeSource other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
