// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The RemoteAddressMatchConditionParametersTypeName. </summary>
    public readonly partial struct RemoteAddressMatchConditionParametersTypeName : IEquatable<RemoteAddressMatchConditionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RemoteAddressMatchConditionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RemoteAddressMatchConditionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleRemoteAddressConditionParametersValue = "DeliveryRuleRemoteAddressConditionParameters";

        /// <summary> DeliveryRuleRemoteAddressConditionParameters. </summary>
        public static RemoteAddressMatchConditionParametersTypeName DeliveryRuleRemoteAddressConditionParameters { get; } = new RemoteAddressMatchConditionParametersTypeName(DeliveryRuleRemoteAddressConditionParametersValue);
        /// <summary> Determines if two <see cref="RemoteAddressMatchConditionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(RemoteAddressMatchConditionParametersTypeName left, RemoteAddressMatchConditionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RemoteAddressMatchConditionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(RemoteAddressMatchConditionParametersTypeName left, RemoteAddressMatchConditionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RemoteAddressMatchConditionParametersTypeName"/>. </summary>
        public static implicit operator RemoteAddressMatchConditionParametersTypeName(string value) => new RemoteAddressMatchConditionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RemoteAddressMatchConditionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RemoteAddressMatchConditionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
