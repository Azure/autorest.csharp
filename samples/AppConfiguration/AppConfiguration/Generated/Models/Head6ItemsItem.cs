// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    public readonly partial struct Head6ItemsItem : IEquatable<Head6ItemsItem>
    {
        private readonly string? _value;

        public Head6ItemsItem(string value)
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

        public static Head6ItemsItem Key { get; } = new Head6ItemsItem(KeyValue);
        public static Head6ItemsItem Label { get; } = new Head6ItemsItem(LabelValue);
        public static Head6ItemsItem ContentType { get; } = new Head6ItemsItem(ContentTypeValue);
        public static Head6ItemsItem Value { get; } = new Head6ItemsItem(ValueValue);
        public static Head6ItemsItem LastModified { get; } = new Head6ItemsItem(LastModifiedValue);
        public static Head6ItemsItem Tags { get; } = new Head6ItemsItem(TagsValue);
        public static Head6ItemsItem Locked { get; } = new Head6ItemsItem(LockedValue);
        public static Head6ItemsItem Etag { get; } = new Head6ItemsItem(EtagValue);
        public static bool operator ==(Head6ItemsItem left, Head6ItemsItem right) => left.Equals(right);
        public static bool operator !=(Head6ItemsItem left, Head6ItemsItem right) => !left.Equals(right);
        public static implicit operator Head6ItemsItem(string value) => new Head6ItemsItem(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Head6ItemsItem other && Equals(other);
        public bool Equals(Head6ItemsItem other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
