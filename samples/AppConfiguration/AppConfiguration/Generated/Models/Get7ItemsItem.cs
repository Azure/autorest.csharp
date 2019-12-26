// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    public readonly partial struct Get7ItemsItem : IEquatable<Get7ItemsItem>
    {
        private readonly string? _value;

        public Get7ItemsItem(string value)
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

        public static Get7ItemsItem Key { get; } = new Get7ItemsItem(KeyValue);
        public static Get7ItemsItem Label { get; } = new Get7ItemsItem(LabelValue);
        public static Get7ItemsItem ContentType { get; } = new Get7ItemsItem(ContentTypeValue);
        public static Get7ItemsItem Value { get; } = new Get7ItemsItem(ValueValue);
        public static Get7ItemsItem LastModified { get; } = new Get7ItemsItem(LastModifiedValue);
        public static Get7ItemsItem Tags { get; } = new Get7ItemsItem(TagsValue);
        public static Get7ItemsItem Locked { get; } = new Get7ItemsItem(LockedValue);
        public static Get7ItemsItem Etag { get; } = new Get7ItemsItem(EtagValue);
        public static bool operator ==(Get7ItemsItem left, Get7ItemsItem right) => left.Equals(right);
        public static bool operator !=(Get7ItemsItem left, Get7ItemsItem right) => !left.Equals(right);
        public static implicit operator Get7ItemsItem(string value) => new Get7ItemsItem(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Get7ItemsItem other && Equals(other);
        public bool Equals(Get7ItemsItem other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
