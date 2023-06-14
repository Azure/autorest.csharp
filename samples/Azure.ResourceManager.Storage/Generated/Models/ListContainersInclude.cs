// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The ListContainersInclude. </summary>
    public readonly partial struct ListContainersInclude : IEquatable<ListContainersInclude>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ListContainersInclude"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ListContainersInclude(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeletedValue = "deleted";

        /// <summary> deleted. </summary>
        public static ListContainersInclude Deleted { get; } = new ListContainersInclude(DeletedValue);
        /// <summary> Determines if two <see cref="ListContainersInclude"/> values are the same. </summary>
        public static bool operator ==(ListContainersInclude left, ListContainersInclude right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ListContainersInclude"/> values are not the same. </summary>
        public static bool operator !=(ListContainersInclude left, ListContainersInclude right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ListContainersInclude"/>. </summary>
        public static implicit operator ListContainersInclude(string value) => new ListContainersInclude(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ListContainersInclude other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ListContainersInclude other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
