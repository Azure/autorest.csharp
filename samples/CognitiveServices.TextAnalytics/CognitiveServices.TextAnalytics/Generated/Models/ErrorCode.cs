// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> Error code. </summary>
    public readonly partial struct ErrorCode : IEquatable<ErrorCode>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="ErrorCode"/> values are the same. </summary>
        public ErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidRequestValue = "invalidRequest";
        private const string InvalidArgumentValue = "invalidArgument";
        private const string InternalServerErrorValue = "internalServerError";
        private const string ServiceUnavailableValue = "serviceUnavailable";

        /// <summary> invalidRequest. </summary>
        public static ErrorCode InvalidRequest { get; } = new ErrorCode(InvalidRequestValue);
        /// <summary> invalidArgument. </summary>
        public static ErrorCode InvalidArgument { get; } = new ErrorCode(InvalidArgumentValue);
        /// <summary> internalServerError. </summary>
        public static ErrorCode InternalServerError { get; } = new ErrorCode(InternalServerErrorValue);
        /// <summary> serviceUnavailable. </summary>
        public static ErrorCode ServiceUnavailable { get; } = new ErrorCode(ServiceUnavailableValue);
        /// <summary> Determines if two <see cref="ErrorCode"/> values are the same. </summary>
        public static bool operator ==(ErrorCode left, ErrorCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ErrorCode"/> values are not the same. </summary>
        public static bool operator !=(ErrorCode left, ErrorCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <cref="ErrorCode"/>. </summary>
        public static implicit operator ErrorCode(string value) => new ErrorCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ErrorCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
