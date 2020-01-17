// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct Enum0 : IEquatable<Enum0>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
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

        /// <summary> key. </summary>
        public static Enum0 Key { get; } = new Enum0(KeyValue);
        /// <summary> label. </summary>
        public static Enum0 Label { get; } = new Enum0(LabelValue);
        /// <summary> content_type. </summary>
        public static Enum0 ContentType { get; } = new Enum0(ContentTypeValue);
        /// <summary> value. </summary>
        public static Enum0 Value { get; } = new Enum0(ValueValue);
        /// <summary> last_modified. </summary>
        public static Enum0 LastModified { get; } = new Enum0(LastModifiedValue);
        /// <summary> tags. </summary>
        public static Enum0 Tags { get; } = new Enum0(TagsValue);
        /// <summary> locked. </summary>
        public static Enum0 Locked { get; } = new Enum0(LockedValue);
        /// <summary> etag. </summary>
        public static Enum0 Etag { get; } = new Enum0(EtagValue);
        /// <summary> Determines if two <see cref="Enum0"/> values are the same. </summary>
        public static bool operator ==(Enum0 left, Enum0 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum0"/> values are not the same. </summary>
        public static bool operator !=(Enum0 left, Enum0 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum0"/>. </summary>
        public static implicit operator Enum0(string value) => new Enum0(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is Enum0 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum0 other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
