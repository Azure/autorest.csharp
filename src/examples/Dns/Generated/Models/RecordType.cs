// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Dns.Models.V20180501
{
    public readonly struct RecordType : IEquatable<RecordType>
    {
        internal const string AValue = "A";
        internal const string AAAAValue = "AAAA";
        internal const string CAAValue = "CAA";
        internal const string CNAMEValue = "CNAME";
        internal const string MXValue = "MX";
        internal const string NSValue = "NS";
        internal const string PTRValue = "PTR";
        internal const string SOAValue = "SOA";
        internal const string SRVValue = "SRV";
        internal const string TXTValue = "TXT";
        private readonly string? _value;

        public RecordType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static RecordType A { get; } = new RecordType(AValue);
        public static RecordType AAAA { get; } = new RecordType(AAAAValue);
        public static RecordType CAA { get; } = new RecordType(CAAValue);
        public static RecordType CNAME { get; } = new RecordType(CNAMEValue);
        public static RecordType MX { get; } = new RecordType(MXValue);
        public static RecordType NS { get; } = new RecordType(NSValue);
        public static RecordType PTR { get; } = new RecordType(PTRValue);
        public static RecordType SOA { get; } = new RecordType(SOAValue);
        public static RecordType SRV { get; } = new RecordType(SRVValue);
        public static RecordType TXT { get; } = new RecordType(TXTValue);

        public static bool operator ==(RecordType left, RecordType right) => left.Equals(right);
        public static bool operator !=(RecordType left, RecordType right) => !left.Equals(right);
        public static implicit operator RecordType(string value) => new RecordType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is RecordType other && Equals(other);
        public bool Equals(RecordType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
