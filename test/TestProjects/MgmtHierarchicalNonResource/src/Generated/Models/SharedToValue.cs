// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> The SharedToValue. </summary>
    public readonly partial struct SharedToValue : IEquatable<SharedToValue>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SharedToValue"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SharedToValue(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TenantValue = "tenant";

        /// <summary> tenant. </summary>
        public static SharedToValue Tenant { get; } = new SharedToValue(TenantValue);
        /// <summary> Determines if two <see cref="SharedToValue"/> values are the same. </summary>
        public static bool operator ==(SharedToValue left, SharedToValue right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SharedToValue"/> values are not the same. </summary>
        public static bool operator !=(SharedToValue left, SharedToValue right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SharedToValue"/>. </summary>
        public static implicit operator SharedToValue(string value) => new SharedToValue(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SharedToValue other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SharedToValue other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
