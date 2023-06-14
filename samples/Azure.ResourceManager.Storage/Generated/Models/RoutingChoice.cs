// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Routing Choice defines the kind of network routing opted by the user. </summary>
    public readonly partial struct RoutingChoice : IEquatable<RoutingChoice>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RoutingChoice"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RoutingChoice(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftRoutingValue = "MicrosoftRouting";
        private const string InternetRoutingValue = "InternetRouting";

        /// <summary> MicrosoftRouting. </summary>
        public static RoutingChoice MicrosoftRouting { get; } = new RoutingChoice(MicrosoftRoutingValue);
        /// <summary> InternetRouting. </summary>
        public static RoutingChoice InternetRouting { get; } = new RoutingChoice(InternetRoutingValue);
        /// <summary> Determines if two <see cref="RoutingChoice"/> values are the same. </summary>
        public static bool operator ==(RoutingChoice left, RoutingChoice right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RoutingChoice"/> values are not the same. </summary>
        public static bool operator !=(RoutingChoice left, RoutingChoice right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RoutingChoice"/>. </summary>
        public static implicit operator RoutingChoice(string value) => new RoutingChoice(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RoutingChoice other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RoutingChoice other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
