// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The name of the condition for the delivery rule. </summary>
    internal readonly partial struct MatchVariable : IEquatable<MatchVariable>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MatchVariable"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MatchVariable(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RemoteAddressValue = "RemoteAddress";
        private const string RequestMethodValue = "RequestMethod";
        private const string QueryStringValue = "QueryString";

        /// <summary> RemoteAddress. </summary>
        public static MatchVariable RemoteAddress { get; } = new MatchVariable(RemoteAddressValue);
        /// <summary> RequestMethod. </summary>
        public static MatchVariable RequestMethod { get; } = new MatchVariable(RequestMethodValue);
        /// <summary> QueryString. </summary>
        public static MatchVariable QueryString { get; } = new MatchVariable(QueryStringValue);
        /// <summary> Determines if two <see cref="MatchVariable"/> values are the same. </summary>
        public static bool operator ==(MatchVariable left, MatchVariable right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MatchVariable"/> values are not the same. </summary>
        public static bool operator !=(MatchVariable left, MatchVariable right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MatchVariable"/>. </summary>
        public static implicit operator MatchVariable(string value) => new MatchVariable(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MatchVariable other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MatchVariable other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
