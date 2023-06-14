// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The HeaderActionParametersTypeName. </summary>
    public readonly partial struct HeaderActionParametersTypeName : IEquatable<HeaderActionParametersTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HeaderActionParametersTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HeaderActionParametersTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeliveryRuleHeaderActionParametersValue = "DeliveryRuleHeaderActionParameters";

        /// <summary> DeliveryRuleHeaderActionParameters. </summary>
        public static HeaderActionParametersTypeName DeliveryRuleHeaderActionParameters { get; } = new HeaderActionParametersTypeName(DeliveryRuleHeaderActionParametersValue);
        /// <summary> Determines if two <see cref="HeaderActionParametersTypeName"/> values are the same. </summary>
        public static bool operator ==(HeaderActionParametersTypeName left, HeaderActionParametersTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HeaderActionParametersTypeName"/> values are not the same. </summary>
        public static bool operator !=(HeaderActionParametersTypeName left, HeaderActionParametersTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="HeaderActionParametersTypeName"/>. </summary>
        public static implicit operator HeaderActionParametersTypeName(string value) => new HeaderActionParametersTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HeaderActionParametersTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HeaderActionParametersTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
