// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace xml_service.Models.V100
{
    public readonly partial struct ArchiveStatus : IEquatable<ArchiveStatus>
    {
        private readonly string? _value;

        public ArchiveStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RehydratePendingToHotValue = "rehydrate-pending-to-hot";
        private const string RehydratePendingToCoolValue = "rehydrate-pending-to-cool";

        public static ArchiveStatus RehydratePendingToHot { get; } = new ArchiveStatus(RehydratePendingToHotValue);
        public static ArchiveStatus RehydratePendingToCool { get; } = new ArchiveStatus(RehydratePendingToCoolValue);
        public static bool operator ==(ArchiveStatus left, ArchiveStatus right) => left.Equals(right);
        public static bool operator !=(ArchiveStatus left, ArchiveStatus right) => !left.Equals(right);
        public static implicit operator ArchiveStatus(string value) => new ArchiveStatus(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ArchiveStatus other && Equals(other);
        public bool Equals(ArchiveStatus other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
