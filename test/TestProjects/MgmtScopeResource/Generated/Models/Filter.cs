// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtScopeResource.Models
{
    /// <summary> The Filter. </summary>
    public readonly partial struct Filter : IEquatable<Filter>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Filter"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Filter(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AtScopeValue = "atScope()";

        /// <summary> atScope(). </summary>
        public static Filter AtScope { get; } = new Filter(AtScopeValue);
        /// <summary> Determines if two <see cref="Filter"/> values are the same. </summary>
        public static bool operator ==(Filter left, Filter right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Filter"/> values are not the same. </summary>
        public static bool operator !=(Filter left, Filter right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Filter"/>. </summary>
        public static implicit operator Filter(string value) => new Filter(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Filter other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Filter other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
