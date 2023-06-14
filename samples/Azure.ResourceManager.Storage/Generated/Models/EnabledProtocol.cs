// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The authentication protocol that is used for the file share. Can only be specified when creating a share. </summary>
    public readonly partial struct EnabledProtocol : IEquatable<EnabledProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EnabledProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EnabledProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SMBValue = "SMB";
        private const string NFSValue = "NFS";

        /// <summary> SMB. </summary>
        public static EnabledProtocol SMB { get; } = new EnabledProtocol(SMBValue);
        /// <summary> NFS. </summary>
        public static EnabledProtocol NFS { get; } = new EnabledProtocol(NFSValue);
        /// <summary> Determines if two <see cref="EnabledProtocol"/> values are the same. </summary>
        public static bool operator ==(EnabledProtocol left, EnabledProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EnabledProtocol"/> values are not the same. </summary>
        public static bool operator !=(EnabledProtocol left, EnabledProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="EnabledProtocol"/>. </summary>
        public static implicit operator EnabledProtocol(string value) => new EnabledProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EnabledProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EnabledProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
