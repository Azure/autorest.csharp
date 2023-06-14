// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Protocol this rule will use when forwarding traffic to backends. </summary>
    public readonly partial struct ForwardingProtocol : IEquatable<ForwardingProtocol>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ForwardingProtocol"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ForwardingProtocol(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HttpOnlyValue = "HttpOnly";
        private const string HttpsOnlyValue = "HttpsOnly";
        private const string MatchRequestValue = "MatchRequest";

        /// <summary> HttpOnly. </summary>
        public static ForwardingProtocol HttpOnly { get; } = new ForwardingProtocol(HttpOnlyValue);
        /// <summary> HttpsOnly. </summary>
        public static ForwardingProtocol HttpsOnly { get; } = new ForwardingProtocol(HttpsOnlyValue);
        /// <summary> MatchRequest. </summary>
        public static ForwardingProtocol MatchRequest { get; } = new ForwardingProtocol(MatchRequestValue);
        /// <summary> Determines if two <see cref="ForwardingProtocol"/> values are the same. </summary>
        public static bool operator ==(ForwardingProtocol left, ForwardingProtocol right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ForwardingProtocol"/> values are not the same. </summary>
        public static bool operator !=(ForwardingProtocol left, ForwardingProtocol right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ForwardingProtocol"/>. </summary>
        public static implicit operator ForwardingProtocol(string value) => new ForwardingProtocol(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ForwardingProtocol other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ForwardingProtocol other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
