// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    public readonly partial struct Head7ItemsItem : IEquatable<Head7ItemsItem>
    {
        private readonly string? _value;

        public Head7ItemsItem(string value)
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

        public static Head7ItemsItem Key { get; } = new Head7ItemsItem(KeyValue);
        public static Head7ItemsItem Label { get; } = new Head7ItemsItem(LabelValue);
        public static Head7ItemsItem ContentType { get; } = new Head7ItemsItem(ContentTypeValue);
        public static Head7ItemsItem Value { get; } = new Head7ItemsItem(ValueValue);
        public static Head7ItemsItem LastModified { get; } = new Head7ItemsItem(LastModifiedValue);
        public static Head7ItemsItem Tags { get; } = new Head7ItemsItem(TagsValue);
        public static Head7ItemsItem Locked { get; } = new Head7ItemsItem(LockedValue);
        public static Head7ItemsItem Etag { get; } = new Head7ItemsItem(EtagValue);
        public static bool operator ==(Head7ItemsItem left, Head7ItemsItem right) => left.Equals(right);
        public static bool operator !=(Head7ItemsItem left, Head7ItemsItem right) => !left.Equals(right);
        public static implicit operator Head7ItemsItem(string value) => new Head7ItemsItem(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Head7ItemsItem other && Equals(other);
        public bool Equals(Head7ItemsItem other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
