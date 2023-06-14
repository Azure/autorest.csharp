// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The StoragePermission. </summary>
    public readonly partial struct StoragePermission : IEquatable<StoragePermission>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StoragePermission"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StoragePermission(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllValue = "all";
        private const string GetValue = "get";
        private const string ListValue = "list";
        private const string DeleteValue = "delete";
        private const string SetValue = "set";
        private const string UpdateValue = "update";
        private const string RegeneratekeyValue = "regeneratekey";
        private const string RecoverValue = "recover";
        private const string PurgeValue = "purge";
        private const string BackupValue = "backup";
        private const string RestoreValue = "restore";
        private const string SetsasValue = "setsas";
        private const string ListsasValue = "listsas";
        private const string GetsasValue = "getsas";
        private const string DeletesasValue = "deletesas";

        /// <summary> all. </summary>
        public static StoragePermission All { get; } = new StoragePermission(AllValue);
        /// <summary> get. </summary>
        public static StoragePermission Get { get; } = new StoragePermission(GetValue);
        /// <summary> list. </summary>
        public static StoragePermission List { get; } = new StoragePermission(ListValue);
        /// <summary> delete. </summary>
        public static StoragePermission Delete { get; } = new StoragePermission(DeleteValue);
        /// <summary> set. </summary>
        public static StoragePermission Set { get; } = new StoragePermission(SetValue);
        /// <summary> update. </summary>
        public static StoragePermission Update { get; } = new StoragePermission(UpdateValue);
        /// <summary> regeneratekey. </summary>
        public static StoragePermission Regeneratekey { get; } = new StoragePermission(RegeneratekeyValue);
        /// <summary> recover. </summary>
        public static StoragePermission Recover { get; } = new StoragePermission(RecoverValue);
        /// <summary> purge. </summary>
        public static StoragePermission Purge { get; } = new StoragePermission(PurgeValue);
        /// <summary> backup. </summary>
        public static StoragePermission Backup { get; } = new StoragePermission(BackupValue);
        /// <summary> restore. </summary>
        public static StoragePermission Restore { get; } = new StoragePermission(RestoreValue);
        /// <summary> setsas. </summary>
        public static StoragePermission Setsas { get; } = new StoragePermission(SetsasValue);
        /// <summary> listsas. </summary>
        public static StoragePermission Listsas { get; } = new StoragePermission(ListsasValue);
        /// <summary> getsas. </summary>
        public static StoragePermission Getsas { get; } = new StoragePermission(GetsasValue);
        /// <summary> deletesas. </summary>
        public static StoragePermission Deletesas { get; } = new StoragePermission(DeletesasValue);
        /// <summary> Determines if two <see cref="StoragePermission"/> values are the same. </summary>
        public static bool operator ==(StoragePermission left, StoragePermission right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StoragePermission"/> values are not the same. </summary>
        public static bool operator !=(StoragePermission left, StoragePermission right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StoragePermission"/>. </summary>
        public static implicit operator StoragePermission(string value) => new StoragePermission(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StoragePermission other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StoragePermission other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
