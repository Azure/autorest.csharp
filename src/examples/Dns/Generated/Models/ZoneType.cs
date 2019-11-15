// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Dns.Models.V20180501
{
    public readonly struct ZoneType : IEquatable<ZoneType>
    {
        internal const string PublicValue = "Public";
        internal const string PrivateValue = "Private";
        private readonly string? _value;

        public ZoneType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static ZoneType Public { get; } = new ZoneType(PublicValue);
        public static ZoneType Private { get; } = new ZoneType(PrivateValue);

        public static bool operator ==(ZoneType left, ZoneType right) => left.Equals(right);
        public static bool operator !=(ZoneType left, ZoneType right) => !left.Equals(right);
        public static implicit operator ZoneType(string value) => new ZoneType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ZoneType other && Equals(other);
        public bool Equals(ZoneType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
