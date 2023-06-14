// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The UrlRewriteActionParametersTypeName. </summary>
    public readonly partial struct UrlRewriteActionParametersTypeName : IEquatable<UrlRewriteActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UrlRewriteActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UrlRewriteActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleUrlRewriteActionParametersValue = "DeliveryRuleUrlRewriteActionParameters";

        /// <summary> DeliveryRuleUrlRewriteActionParameters. </summary>
        public static UrlRewriteActionParametersTypeName DeliveryRuleUrlRewriteActionParameters { get; } = new UrlRewriteActionParametersTypeName(DeliveryRuleUrlRewriteActionParametersValue);
        /// <summary> Determines if two <see cref="UrlRewriteActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(UrlRewriteActionParametersTypeName left, UrlRewriteActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="UrlRewriteActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(UrlRewriteActionParametersTypeName left, UrlRewriteActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="UrlRewriteActionParametersTypeName"/>. </summary>
        public static implicit operator UrlRewriteActionParametersTypeName(string value) => new UrlRewriteActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is UrlRewriteActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(UrlRewriteActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
