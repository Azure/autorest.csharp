// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace xml_service.Models.V100
{
    public readonly partial struct PublicAccessType : IEquatable<PublicAccessType>
    {
        private readonly string? _value;

        public PublicAccessType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ContainerValue = "container";
        private const string BlobValue = "blob";

        public static PublicAccessType Container { get; } = new PublicAccessType(ContainerValue);
        public static PublicAccessType Blob { get; } = new PublicAccessType(BlobValue);
        public static bool operator ==(PublicAccessType left, PublicAccessType right) => left.Equals(right);
        public static bool operator !=(PublicAccessType left, PublicAccessType right) => !left.Equals(right);
        public static implicit operator PublicAccessType(string value) => new PublicAccessType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is PublicAccessType other && Equals(other);
        public bool Equals(PublicAccessType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
