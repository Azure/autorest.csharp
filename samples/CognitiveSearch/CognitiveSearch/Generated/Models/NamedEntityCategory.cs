// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> A string indicating which named entity categories to return. </summary>
    public readonly partial struct NamedEntityCategory : IEquatable<NamedEntityCategory>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="NamedEntityCategory"/> values are the same. </summary>
        public NamedEntityCategory(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LocationValue = "location";
        private const string OrganizationValue = "organization";
        private const string PersonValue = "person";

        /// <summary> location. </summary>
        public static NamedEntityCategory Location { get; } = new NamedEntityCategory(LocationValue);
        /// <summary> organization. </summary>
        public static NamedEntityCategory Organization { get; } = new NamedEntityCategory(OrganizationValue);
        /// <summary> person. </summary>
        public static NamedEntityCategory Person { get; } = new NamedEntityCategory(PersonValue);
        /// <summary> Determines if two <see cref="NamedEntityCategory"/> values are the same. </summary>
        public static bool operator ==(NamedEntityCategory left, NamedEntityCategory right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NamedEntityCategory"/> values are not the same. </summary>
        public static bool operator !=(NamedEntityCategory left, NamedEntityCategory right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NamedEntityCategory"/>. </summary>
        public static implicit operator NamedEntityCategory(string value) => new NamedEntityCategory(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NamedEntityCategory other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NamedEntityCategory other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
