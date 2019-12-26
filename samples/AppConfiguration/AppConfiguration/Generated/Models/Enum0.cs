// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    public readonly partial struct Enum0 : IEquatable<Enum0>
    {
        private readonly string? _value;

        public Enum0(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string KeyValue = "key";
        private const string LabelValue = "label";
        private const string ContentTypeValue = "content_type";
        private const string ValueValue = "value";
        private const string LastModifiedValue = "last_modified";
        private const string TagsValue = "tags";
        private const string LockedValue = "locked";
        private const string EtagValue = "etag";

        public static Enum0 Key { get; } = new Enum0(KeyValue);
        public static Enum0 Label { get; } = new Enum0(LabelValue);
        public static Enum0 ContentType { get; } = new Enum0(ContentTypeValue);
        public static Enum0 Value { get; } = new Enum0(ValueValue);
        public static Enum0 LastModified { get; } = new Enum0(LastModifiedValue);
        public static Enum0 Tags { get; } = new Enum0(TagsValue);
        public static Enum0 Locked { get; } = new Enum0(LockedValue);
        public static Enum0 Etag { get; } = new Enum0(EtagValue);
        public static bool operator ==(Enum0 left, Enum0 right) => left.Equals(right);
        public static bool operator !=(Enum0 left, Enum0 right) => !left.Equals(right);
        public static implicit operator Enum0(string value) => new Enum0(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Enum0 other && Equals(other);
        public bool Equals(Enum0 other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
