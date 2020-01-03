// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace xml_service.Models.V100
{
    public readonly partial struct AccessTier : IEquatable<AccessTier>
    {
        private readonly string? _value;

        public AccessTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string P4Value = "P4";
        private const string P6Value = "P6";
        private const string P10Value = "P10";
        private const string P20Value = "P20";
        private const string P30Value = "P30";
        private const string P40Value = "P40";
        private const string P50Value = "P50";
        private const string HotValue = "Hot";
        private const string CoolValue = "Cool";
        private const string ArchiveValue = "Archive";

        public static AccessTier P4 { get; } = new AccessTier(P4Value);
        public static AccessTier P6 { get; } = new AccessTier(P6Value);
        public static AccessTier P10 { get; } = new AccessTier(P10Value);
        public static AccessTier P20 { get; } = new AccessTier(P20Value);
        public static AccessTier P30 { get; } = new AccessTier(P30Value);
        public static AccessTier P40 { get; } = new AccessTier(P40Value);
        public static AccessTier P50 { get; } = new AccessTier(P50Value);
        public static AccessTier Hot { get; } = new AccessTier(HotValue);
        public static AccessTier Cool { get; } = new AccessTier(CoolValue);
        public static AccessTier Archive { get; } = new AccessTier(ArchiveValue);
        public static bool operator ==(AccessTier left, AccessTier right) => left.Equals(right);
        public static bool operator !=(AccessTier left, AccessTier right) => !left.Equals(right);
        public static implicit operator AccessTier(string value) => new AccessTier(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is AccessTier other && Equals(other);
        public bool Equals(AccessTier other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
