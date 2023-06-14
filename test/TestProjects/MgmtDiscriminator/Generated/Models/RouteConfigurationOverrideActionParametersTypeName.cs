// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The RouteConfigurationOverrideActionParametersTypeName. </summary>
    public readonly partial struct RouteConfigurationOverrideActionParametersTypeName : IEquatable<RouteConfigurationOverrideActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RouteConfigurationOverrideActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RouteConfigurationOverrideActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleRouteConfigurationOverrideActionParametersValue = "DeliveryRuleRouteConfigurationOverrideActionParameters";

        /// <summary> DeliveryRuleRouteConfigurationOverrideActionParameters. </summary>
        public static RouteConfigurationOverrideActionParametersTypeName DeliveryRuleRouteConfigurationOverrideActionParameters { get; } = new RouteConfigurationOverrideActionParametersTypeName(DeliveryRuleRouteConfigurationOverrideActionParametersValue);
        /// <summary> Determines if two <see cref="RouteConfigurationOverrideActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(RouteConfigurationOverrideActionParametersTypeName left, RouteConfigurationOverrideActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RouteConfigurationOverrideActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(RouteConfigurationOverrideActionParametersTypeName left, RouteConfigurationOverrideActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RouteConfigurationOverrideActionParametersTypeName"/>. </summary>
        public static implicit operator RouteConfigurationOverrideActionParametersTypeName(string value) => new RouteConfigurationOverrideActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RouteConfigurationOverrideActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RouteConfigurationOverrideActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
