// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This is a required field. This field specifies the scope of the inventory created either at the blob or container level. </summary>
    public readonly partial struct ObjectType : IEquatable<ObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BlobValue = "Blob";
        private const string ContainerValue = "Container";

        /// <summary> Blob. </summary>
        public static ObjectType Blob { get; } = new ObjectType(BlobValue);
        /// <summary> Container. </summary>
        public static ObjectType Container { get; } = new ObjectType(ContainerValue);
        /// <summary> Determines if two <see cref="ObjectType"/> values are the same. </summary>
        public static bool operator ==(ObjectType left, ObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ObjectType"/> values are not the same. </summary>
        public static bool operator !=(ObjectType left, ObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ObjectType"/>. </summary>
        public static implicit operator ObjectType(string value) => new ObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
