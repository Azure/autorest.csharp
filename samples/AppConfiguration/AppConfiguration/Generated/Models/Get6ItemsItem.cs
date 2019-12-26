// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    public readonly partial struct Get6ItemsItem : IEquatable<Get6ItemsItem>
    {
        private readonly string? _value;

        public Get6ItemsItem(string value)
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

        public static Get6ItemsItem Key { get; } = new Get6ItemsItem(KeyValue);
        public static Get6ItemsItem Label { get; } = new Get6ItemsItem(LabelValue);
        public static Get6ItemsItem ContentType { get; } = new Get6ItemsItem(ContentTypeValue);
        public static Get6ItemsItem Value { get; } = new Get6ItemsItem(ValueValue);
        public static Get6ItemsItem LastModified { get; } = new Get6ItemsItem(LastModifiedValue);
        public static Get6ItemsItem Tags { get; } = new Get6ItemsItem(TagsValue);
        public static Get6ItemsItem Locked { get; } = new Get6ItemsItem(LockedValue);
        public static Get6ItemsItem Etag { get; } = new Get6ItemsItem(EtagValue);
        public static bool operator ==(Get6ItemsItem left, Get6ItemsItem right) => left.Equals(right);
        public static bool operator !=(Get6ItemsItem left, Get6ItemsItem right) => !left.Equals(right);
        public static implicit operator Get6ItemsItem(string value) => new Get6ItemsItem(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Get6ItemsItem other && Equals(other);
        public bool Equals(Get6ItemsItem other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
