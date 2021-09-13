// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace AppConfiguration.Models
{
    /// <summary> The Enum5. </summary>
    public readonly partial struct Enum5 : IEquatable<Enum5>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of Enum5. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Enum5(string value)
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
        public static Enum5 Key { get; } = new Enum5(KeyValue);
        /// <summary> label. </summary>
        public static Enum5 Label { get; } = new Enum5(LabelValue);
        /// <summary> content_type. </summary>
        public static Enum5 ContentType { get; } = new Enum5(ContentTypeValue);
        /// <summary> value. </summary>
        public static Enum5 Value { get; } = new Enum5(ValueValue);
        /// <summary> last_modified. </summary>
        public static Enum5 LastModified { get; } = new Enum5(LastModifiedValue);
        /// <summary> tags. </summary>
        public static Enum5 Tags { get; } = new Enum5(TagsValue);
        /// <summary> locked. </summary>
        public static Enum5 Locked { get; } = new Enum5(LockedValue);
        /// <summary> etag. </summary>
        public static Enum5 Etag { get; } = new Enum5(EtagValue);
        /// <summary> Determines if two <see cref="Enum5"/> values are the same. </summary>
        public static bool operator ==(Enum5 left, Enum5 right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Enum5"/> values are not the same. </summary>
        public static bool operator !=(Enum5 left, Enum5 right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Enum5"/>. </summary>
        public static implicit operator Enum5(string value) => new Enum5(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Enum5 other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Enum5 other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
