// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The redirect type the rule will use when redirecting traffic. </summary>
    public readonly partial struct RedirectType : IEquatable<RedirectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RedirectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RedirectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MovedValue = "Moved";
        private const string FoundValue = "Found";
        private const string TemporaryRedirectValue = "TemporaryRedirect";
        private const string PermanentRedirectValue = "PermanentRedirect";

        /// <summary> Moved. </summary>
        public static RedirectType Moved { get; } = new RedirectType(MovedValue);
        /// <summary> Found. </summary>
        public static RedirectType Found { get; } = new RedirectType(FoundValue);
        /// <summary> TemporaryRedirect. </summary>
        public static RedirectType TemporaryRedirect { get; } = new RedirectType(TemporaryRedirectValue);
        /// <summary> PermanentRedirect. </summary>
        public static RedirectType PermanentRedirect { get; } = new RedirectType(PermanentRedirectValue);
        /// <summary> Determines if two <see cref="RedirectType"/> values are the same. </summary>
        public static bool operator ==(RedirectType left, RedirectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RedirectType"/> values are not the same. </summary>
        public static bool operator !=(RedirectType left, RedirectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RedirectType"/>. </summary>
        public static implicit operator RedirectType(string value) => new RedirectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RedirectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RedirectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
