// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace xml_service.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct ArchiveStatus : IEquatable<ArchiveStatus>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="ArchiveStatus"/> values are the same. </summary>
        public ArchiveStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RehydratePendingToHotValue = "rehydrate-pending-to-hot";
        private const string RehydratePendingToCoolValue = "rehydrate-pending-to-cool";

        /// <summary> rehydrate-pending-to-hot. </summary>
        public static ArchiveStatus RehydratePendingToHot { get; } = new ArchiveStatus(RehydratePendingToHotValue);
        /// <summary> rehydrate-pending-to-cool. </summary>
        public static ArchiveStatus RehydratePendingToCool { get; } = new ArchiveStatus(RehydratePendingToCoolValue);
        /// <summary> Determines if two <see cref="ArchiveStatus"/> values are the same. </summary>
        public static bool operator ==(ArchiveStatus left, ArchiveStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ArchiveStatus"/> values are not the same. </summary>
        public static bool operator !=(ArchiveStatus left, ArchiveStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ArchiveStatus"/>. </summary>
        public static implicit operator ArchiveStatus(string value) => new ArchiveStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ArchiveStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ArchiveStatus other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
