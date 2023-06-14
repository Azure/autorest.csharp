// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Indicates the type of storage account. </summary>
    public readonly partial struct StorageKind : IEquatable<StorageKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StorageValue = "Storage";
        private const string StorageV2Value = "StorageV2";
        private const string BlobStorageValue = "BlobStorage";
        private const string FileStorageValue = "FileStorage";
        private const string BlockBlobStorageValue = "BlockBlobStorage";

        /// <summary> Storage. </summary>
        public static StorageKind Storage { get; } = new StorageKind(StorageValue);
        /// <summary> StorageV2. </summary>
        public static StorageKind StorageV2 { get; } = new StorageKind(StorageV2Value);
        /// <summary> BlobStorage. </summary>
        public static StorageKind BlobStorage { get; } = new StorageKind(BlobStorageValue);
        /// <summary> FileStorage. </summary>
        public static StorageKind FileStorage { get; } = new StorageKind(FileStorageValue);
        /// <summary> BlockBlobStorage. </summary>
        public static StorageKind BlockBlobStorage { get; } = new StorageKind(BlockBlobStorageValue);
        /// <summary> Determines if two <see cref="StorageKind"/> values are the same. </summary>
        public static bool operator ==(StorageKind left, StorageKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StorageKind"/> values are not the same. </summary>
        public static bool operator !=(StorageKind left, StorageKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StorageKind"/>. </summary>
        public static implicit operator StorageKind(string value) => new StorageKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
