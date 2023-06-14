// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </summary>
    public readonly partial struct EncryptionScopeState : IEquatable<EncryptionScopeState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EncryptionScopeState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EncryptionScopeState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Enabled. </summary>
        public static EncryptionScopeState Enabled { get; } = new EncryptionScopeState(EnabledValue);
        /// <summary> Disabled. </summary>
        public static EncryptionScopeState Disabled { get; } = new EncryptionScopeState(DisabledValue);
        /// <summary> Determines if two <see cref="EncryptionScopeState"/> values are the same. </summary>
        public static bool operator ==(EncryptionScopeState left, EncryptionScopeState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EncryptionScopeState"/> values are not the same. </summary>
        public static bool operator !=(EncryptionScopeState left, EncryptionScopeState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EncryptionScopeState"/>. </summary>
        public static implicit operator EncryptionScopeState(string value) => new EncryptionScopeState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EncryptionScopeState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EncryptionScopeState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
