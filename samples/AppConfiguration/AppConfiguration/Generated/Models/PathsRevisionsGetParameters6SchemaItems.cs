// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace AppConfiguration.Models.V10
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct PathsRevisionsGetParameters6SchemaItems : IEquatable<PathsRevisionsGetParameters6SchemaItems>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="PathsRevisionsGetParameters6SchemaItems"/> values are the same. </summary>
        public PathsRevisionsGetParameters6SchemaItems(string value)
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
        public static PathsRevisionsGetParameters6SchemaItems Key { get; } = new PathsRevisionsGetParameters6SchemaItems(KeyValue);
        /// <summary> label. </summary>
        public static PathsRevisionsGetParameters6SchemaItems Label { get; } = new PathsRevisionsGetParameters6SchemaItems(LabelValue);
        /// <summary> content_type. </summary>
        public static PathsRevisionsGetParameters6SchemaItems ContentType { get; } = new PathsRevisionsGetParameters6SchemaItems(ContentTypeValue);
        /// <summary> value. </summary>
        public static PathsRevisionsGetParameters6SchemaItems Value { get; } = new PathsRevisionsGetParameters6SchemaItems(ValueValue);
        /// <summary> last_modified. </summary>
        public static PathsRevisionsGetParameters6SchemaItems LastModified { get; } = new PathsRevisionsGetParameters6SchemaItems(LastModifiedValue);
        /// <summary> tags. </summary>
        public static PathsRevisionsGetParameters6SchemaItems Tags { get; } = new PathsRevisionsGetParameters6SchemaItems(TagsValue);
        /// <summary> locked. </summary>
        public static PathsRevisionsGetParameters6SchemaItems Locked { get; } = new PathsRevisionsGetParameters6SchemaItems(LockedValue);
        /// <summary> etag. </summary>
        public static PathsRevisionsGetParameters6SchemaItems Etag { get; } = new PathsRevisionsGetParameters6SchemaItems(EtagValue);
        /// <summary> Determines if two <see cref="PathsRevisionsGetParameters6SchemaItems"/> values are the same. </summary>
        public static bool operator ==(PathsRevisionsGetParameters6SchemaItems left, PathsRevisionsGetParameters6SchemaItems right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PathsRevisionsGetParameters6SchemaItems"/> values are not the same. </summary>
        public static bool operator !=(PathsRevisionsGetParameters6SchemaItems left, PathsRevisionsGetParameters6SchemaItems right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PathsRevisionsGetParameters6SchemaItems"/>. </summary>
        public static implicit operator PathsRevisionsGetParameters6SchemaItems(string value) => new PathsRevisionsGetParameters6SchemaItems(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is PathsRevisionsGetParameters6SchemaItems other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PathsRevisionsGetParameters6SchemaItems other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
