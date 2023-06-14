// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share (s). </summary>
    public readonly partial struct SignedResource : IEquatable<SignedResource>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SignedResource"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SignedResource(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string CValue = "c";
        private const string FValue = "f";
        private const string SValue = "s";

        /// <summary> b. </summary>
        public static SignedResource B { get; } = new SignedResource(BValue);
        /// <summary> c. </summary>
        public static SignedResource C { get; } = new SignedResource(CValue);
        /// <summary> f. </summary>
        public static SignedResource F { get; } = new SignedResource(FValue);
        /// <summary> s. </summary>
        public static SignedResource S { get; } = new SignedResource(SValue);
        /// <summary> Determines if two <see cref="SignedResource"/> values are the same. </summary>
        public static bool operator ==(SignedResource left, SignedResource right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SignedResource"/> values are not the same. </summary>
        public static bool operator !=(SignedResource left, SignedResource right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SignedResource"/>. </summary>
        public static implicit operator SignedResource(string value) => new SignedResource(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SignedResource other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SignedResource other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
