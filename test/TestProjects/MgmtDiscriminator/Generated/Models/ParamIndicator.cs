// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Indicates the purpose of the parameter. </summary>
    public readonly partial struct ParamIndicator : IEquatable<ParamIndicator>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ParamIndicator"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ParamIndicator(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ExpiresValue = "Expires";
        private const string KeyIdValue = "KeyId";
        private const string SignatureValue = "Signature";

        /// <summary> Expires. </summary>
        public static ParamIndicator Expires { get; } = new ParamIndicator(ExpiresValue);
        /// <summary> KeyId. </summary>
        public static ParamIndicator KeyId { get; } = new ParamIndicator(KeyIdValue);
        /// <summary> Signature. </summary>
        public static ParamIndicator Signature { get; } = new ParamIndicator(SignatureValue);
        /// <summary> Determines if two <see cref="ParamIndicator"/> values are the same. </summary>
        public static bool operator ==(ParamIndicator left, ParamIndicator right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ParamIndicator"/> values are not the same. </summary>
        public static bool operator !=(ParamIndicator left, ParamIndicator right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ParamIndicator"/>. </summary>
        public static implicit operator ParamIndicator(string value) => new ParamIndicator(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ParamIndicator other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ParamIndicator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
