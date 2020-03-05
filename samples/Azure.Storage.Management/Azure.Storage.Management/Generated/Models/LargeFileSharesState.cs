// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Management.Models
{
    /// <summary> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </summary>
    public readonly partial struct LargeFileSharesState : IEquatable<LargeFileSharesState>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="LargeFileSharesState"/> values are the same. </summary>
        public LargeFileSharesState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DisabledValue = "Disabled";
        private const string EnabledValue = "Enabled";

        /// <summary> Disabled. </summary>
        public static LargeFileSharesState Disabled { get; } = new LargeFileSharesState(DisabledValue);
        /// <summary> Enabled. </summary>
        public static LargeFileSharesState Enabled { get; } = new LargeFileSharesState(EnabledValue);
        /// <summary> Determines if two <see cref="LargeFileSharesState"/> values are the same. </summary>
        public static bool operator ==(LargeFileSharesState left, LargeFileSharesState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LargeFileSharesState"/> values are not the same. </summary>
        public static bool operator !=(LargeFileSharesState left, LargeFileSharesState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LargeFileSharesState"/>. </summary>
        public static implicit operator LargeFileSharesState(string value) => new LargeFileSharesState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LargeFileSharesState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LargeFileSharesState other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
