// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The UrlSigningActionParametersTypeName. </summary>
    public readonly partial struct UrlSigningActionParametersTypeName : IEquatable<UrlSigningActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UrlSigningActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UrlSigningActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleUrlSigningActionParametersValue = "DeliveryRuleUrlSigningActionParameters";

        /// <summary> DeliveryRuleUrlSigningActionParameters. </summary>
        public static UrlSigningActionParametersTypeName DeliveryRuleUrlSigningActionParameters { get; } = new UrlSigningActionParametersTypeName(DeliveryRuleUrlSigningActionParametersValue);
        /// <summary> Determines if two <see cref="UrlSigningActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(UrlSigningActionParametersTypeName left, UrlSigningActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UrlSigningActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(UrlSigningActionParametersTypeName left, UrlSigningActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="UrlSigningActionParametersTypeName"/>. </summary>
        public static implicit operator UrlSigningActionParametersTypeName(string value) => new UrlSigningActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UrlSigningActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UrlSigningActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
