// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The SecretPermission. </summary>
    public readonly partial struct SecretPermission : IEquatable<SecretPermission>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SecretPermission"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SecretPermission(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllValue = "all";
        private const string GetValue = "get";
        private const string ListValue = "list";
        private const string SetValue = "set";
        private const string DeleteValue = "delete";
        private const string BackupValue = "backup";
        private const string RestoreValue = "restore";
        private const string RecoverValue = "recover";
        private const string PurgeValue = "purge";

        /// <summary> all. </summary>
        public static SecretPermission All { get; } = new SecretPermission(AllValue);
        /// <summary> get. </summary>
        public static SecretPermission Get { get; } = new SecretPermission(GetValue);
        /// <summary> list. </summary>
        public static SecretPermission List { get; } = new SecretPermission(ListValue);
        /// <summary> set. </summary>
        public static SecretPermission Set { get; } = new SecretPermission(SetValue);
        /// <summary> delete. </summary>
        public static SecretPermission Delete { get; } = new SecretPermission(DeleteValue);
        /// <summary> backup. </summary>
        public static SecretPermission Backup { get; } = new SecretPermission(BackupValue);
        /// <summary> restore. </summary>
        public static SecretPermission Restore { get; } = new SecretPermission(RestoreValue);
        /// <summary> recover. </summary>
        public static SecretPermission Recover { get; } = new SecretPermission(RecoverValue);
        /// <summary> purge. </summary>
        public static SecretPermission Purge { get; } = new SecretPermission(PurgeValue);
        /// <summary> Determines if two <see cref="SecretPermission"/> values are the same. </summary>
        public static bool operator ==(SecretPermission left, SecretPermission right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SecretPermission"/> values are not the same. </summary>
        public static bool operator !=(SecretPermission left, SecretPermission right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SecretPermission"/>. </summary>
        public static implicit operator SecretPermission(string value) => new SecretPermission(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SecretPermission other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SecretPermission other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
