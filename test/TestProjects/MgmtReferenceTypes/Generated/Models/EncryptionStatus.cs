// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> Indicates whether or not the encryption is enabled for container registry. </summary>
    public readonly partial struct EncryptionStatus : IEquatable<EncryptionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EncryptionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EncryptionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "enabled";
        private const string DisabledValue = "disabled";

        /// <summary> enabled. </summary>
        public static EncryptionStatus Enabled { get; } = new EncryptionStatus(EnabledValue);
        /// <summary> disabled. </summary>
        public static EncryptionStatus Disabled { get; } = new EncryptionStatus(DisabledValue);
        /// <summary> Determines if two <see cref="EncryptionStatus"/> values are the same. </summary>
        public static bool operator ==(EncryptionStatus left, EncryptionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EncryptionStatus"/> values are not the same. </summary>
        public static bool operator !=(EncryptionStatus left, EncryptionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EncryptionStatus"/>. </summary>
        public static implicit operator EncryptionStatus(string value) => new EncryptionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EncryptionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EncryptionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
