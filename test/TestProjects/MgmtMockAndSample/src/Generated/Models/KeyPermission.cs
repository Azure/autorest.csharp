// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The KeyPermission. </summary>
    public readonly partial struct KeyPermission : IEquatable<KeyPermission>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KeyPermission"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KeyPermission(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllValue = "all";
        private const string EncryptValue = "encrypt";
        private const string DecryptValue = "decrypt";
        private const string WrapKeyValue = "wrapKey";
        private const string UnwrapKeyValue = "unwrapKey";
        private const string SignValue = "sign";
        private const string VerifyValue = "verify";
        private const string GetValue = "get";
        private const string ListValue = "list";
        private const string CreateValue = "create";
        private const string UpdateValue = "update";
        private const string ImportValue = "import";
        private const string DeleteValue = "delete";
        private const string BackupValue = "backup";
        private const string RestoreValue = "restore";
        private const string RecoverValue = "recover";
        private const string PurgeValue = "purge";

        /// <summary> all. </summary>
        public static KeyPermission All { get; } = new KeyPermission(AllValue);
        /// <summary> encrypt. </summary>
        public static KeyPermission Encrypt { get; } = new KeyPermission(EncryptValue);
        /// <summary> decrypt. </summary>
        public static KeyPermission Decrypt { get; } = new KeyPermission(DecryptValue);
        /// <summary> wrapKey. </summary>
        public static KeyPermission WrapKey { get; } = new KeyPermission(WrapKeyValue);
        /// <summary> unwrapKey. </summary>
        public static KeyPermission UnwrapKey { get; } = new KeyPermission(UnwrapKeyValue);
        /// <summary> sign. </summary>
        public static KeyPermission Sign { get; } = new KeyPermission(SignValue);
        /// <summary> verify. </summary>
        public static KeyPermission Verify { get; } = new KeyPermission(VerifyValue);
        /// <summary> get. </summary>
        public static KeyPermission Get { get; } = new KeyPermission(GetValue);
        /// <summary> list. </summary>
        public static KeyPermission List { get; } = new KeyPermission(ListValue);
        /// <summary> create. </summary>
        public static KeyPermission Create { get; } = new KeyPermission(CreateValue);
        /// <summary> update. </summary>
        public static KeyPermission Update { get; } = new KeyPermission(UpdateValue);
        /// <summary> import. </summary>
        public static KeyPermission Import { get; } = new KeyPermission(ImportValue);
        /// <summary> delete. </summary>
        public static KeyPermission Delete { get; } = new KeyPermission(DeleteValue);
        /// <summary> backup. </summary>
        public static KeyPermission Backup { get; } = new KeyPermission(BackupValue);
        /// <summary> restore. </summary>
        public static KeyPermission Restore { get; } = new KeyPermission(RestoreValue);
        /// <summary> recover. </summary>
        public static KeyPermission Recover { get; } = new KeyPermission(RecoverValue);
        /// <summary> purge. </summary>
        public static KeyPermission Purge { get; } = new KeyPermission(PurgeValue);
        /// <summary> Determines if two <see cref="KeyPermission"/> values are the same. </summary>
        public static bool operator ==(KeyPermission left, KeyPermission right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KeyPermission"/> values are not the same. </summary>
        public static bool operator !=(KeyPermission left, KeyPermission right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="KeyPermission"/>. </summary>
        public static implicit operator KeyPermission(string value) => new KeyPermission(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KeyPermission other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KeyPermission other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
