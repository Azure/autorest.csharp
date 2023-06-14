// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The OriginGroupOverrideActionParametersTypeName. </summary>
    public readonly partial struct OriginGroupOverrideActionParametersTypeName : IEquatable<OriginGroupOverrideActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OriginGroupOverrideActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OriginGroupOverrideActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleOriginGroupOverrideActionParametersValue = "DeliveryRuleOriginGroupOverrideActionParameters";

        /// <summary> DeliveryRuleOriginGroupOverrideActionParameters. </summary>
        public static OriginGroupOverrideActionParametersTypeName DeliveryRuleOriginGroupOverrideActionParameters { get; } = new OriginGroupOverrideActionParametersTypeName(DeliveryRuleOriginGroupOverrideActionParametersValue);
        /// <summary> Determines if two <see cref="OriginGroupOverrideActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(OriginGroupOverrideActionParametersTypeName left, OriginGroupOverrideActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OriginGroupOverrideActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(OriginGroupOverrideActionParametersTypeName left, OriginGroupOverrideActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OriginGroupOverrideActionParametersTypeName"/>. </summary>
        public static implicit operator OriginGroupOverrideActionParametersTypeName(string value) => new OriginGroupOverrideActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OriginGroupOverrideActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OriginGroupOverrideActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
