// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace AppConfiguration.Models
{
    /// <summary> The Enum7. </summary>
    public readonly partial struct Enum7 : IEquatable<Enum7>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Enum7"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Enum7(string value)
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
        public static Enum7 Key { get; } = new Enum7(KeyValue);
        /// <summary> label. </summary>
        public static Enum7 Label { get; } = new Enum7(LabelValue);
        /// <summary> content_type. </summary>
        public static Enum7 ContentType { get; } = new Enum7(ContentTypeValue);
        /// <summary> value. </summary>
        public static Enum7 Value { get; } = new Enum7(ValueValue);
        /// <summary> last_modified. </summary>
        public static Enum7 LastModified { get; } = new Enum7(LastModifiedValue);
        /// <summary> tags. </summary>
        public static Enum7 Tags { get; } = new Enum7(TagsValue);
        /// <summary> locked. </summary>
        public static Enum7 Locked { get; } = new Enum7(LockedValue);
        /// <summary> etag. </summary>
        public static Enum7 Etag { get; } = new Enum7(EtagValue);
        /// <summary> Determines if two <see cref="Enum7"/> values are the same. </summary>
        public static bool operator ==(Enum7 left, Enum7 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum7"/> values are not the same. </summary>
        public static bool operator !=(Enum7 left, Enum7 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum7"/>. </summary>
        public static implicit operator Enum7(string value) => new Enum7(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Enum7 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum7 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
