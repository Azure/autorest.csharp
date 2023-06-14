// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> Tells what traffic can bypass network rules. This can be 'AzureServices' or 'None'.  If not specified the default is 'AzureServices'. </summary>
    public readonly partial struct NetworkRuleBypassOption : IEquatable<NetworkRuleBypassOption>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetworkRuleBypassOption"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NetworkRuleBypassOption(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureServicesValue = "AzureServices";
        private const string NoneValue = "None";

        /// <summary> AzureServices. </summary>
        public static NetworkRuleBypassOption AzureServices { get; } = new NetworkRuleBypassOption(AzureServicesValue);
        /// <summary> None. </summary>
        public static NetworkRuleBypassOption None { get; } = new NetworkRuleBypassOption(NoneValue);
        /// <summary> Determines if two <see cref="NetworkRuleBypassOption"/> values are the same. </summary>
        public static bool operator ==(NetworkRuleBypassOption left, NetworkRuleBypassOption right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NetworkRuleBypassOption"/> values are not the same. </summary>
        public static bool operator !=(NetworkRuleBypassOption left, NetworkRuleBypassOption right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NetworkRuleBypassOption"/>. </summary>
        public static implicit operator NetworkRuleBypassOption(string value) => new NetworkRuleBypassOption(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NetworkRuleBypassOption other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NetworkRuleBypassOption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
