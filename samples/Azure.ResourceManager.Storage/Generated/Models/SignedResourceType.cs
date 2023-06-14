// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities, and files. </summary>
    public readonly partial struct SignedResourceType : IEquatable<SignedResourceType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SignedResourceType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SignedResourceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SValue = "s";
        private const string CValue = "c";
        private const string OValue = "o";

        /// <summary> s. </summary>
        public static SignedResourceType S { get; } = new SignedResourceType(SValue);
        /// <summary> c. </summary>
        public static SignedResourceType C { get; } = new SignedResourceType(CValue);
        /// <summary> o. </summary>
        public static SignedResourceType O { get; } = new SignedResourceType(OValue);
        /// <summary> Determines if two <see cref="SignedResourceType"/> values are the same. </summary>
        public static bool operator ==(SignedResourceType left, SignedResourceType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SignedResourceType"/> values are not the same. </summary>
        public static bool operator !=(SignedResourceType left, SignedResourceType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SignedResourceType"/>. </summary>
        public static implicit operator SignedResourceType(string value) => new SignedResourceType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SignedResourceType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SignedResourceType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
