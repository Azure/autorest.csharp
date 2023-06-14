// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The QueryStringMatchConditionParametersTypeName. </summary>
    public readonly partial struct QueryStringMatchConditionParametersTypeName : IEquatable<QueryStringMatchConditionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QueryStringMatchConditionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QueryStringMatchConditionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleQueryStringConditionParametersValue = "DeliveryRuleQueryStringConditionParameters";

        /// <summary> DeliveryRuleQueryStringConditionParameters. </summary>
        public static QueryStringMatchConditionParametersTypeName DeliveryRuleQueryStringConditionParameters { get; } = new QueryStringMatchConditionParametersTypeName(DeliveryRuleQueryStringConditionParametersValue);
        /// <summary> Determines if two <see cref="QueryStringMatchConditionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(QueryStringMatchConditionParametersTypeName left, QueryStringMatchConditionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QueryStringMatchConditionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(QueryStringMatchConditionParametersTypeName left, QueryStringMatchConditionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="QueryStringMatchConditionParametersTypeName"/>. </summary>
        public static implicit operator QueryStringMatchConditionParametersTypeName(string value) => new QueryStringMatchConditionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QueryStringMatchConditionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QueryStringMatchConditionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
