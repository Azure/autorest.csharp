// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public readonly partial struct ErrorCode : IEquatable<ErrorCode>
    {
        private readonly string? _value;

        public ErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidRequestValue = "invalidRequest";
        private const string InvalidArgumentValue = "invalidArgument";
        private const string InternalServerErrorValue = "internalServerError";
        private const string ServiceUnavailableValue = "serviceUnavailable";

        public static ErrorCode InvalidRequest { get; } = new ErrorCode(InvalidRequestValue);
        public static ErrorCode InvalidArgument { get; } = new ErrorCode(InvalidArgumentValue);
        public static ErrorCode InternalServerError { get; } = new ErrorCode(InternalServerErrorValue);
        public static ErrorCode ServiceUnavailable { get; } = new ErrorCode(ServiceUnavailableValue);
        public static bool operator ==(ErrorCode left, ErrorCode right) => left.Equals(right);
        public static bool operator !=(ErrorCode left, ErrorCode right) => !left.Equals(right);
        public static implicit operator ErrorCode(string value) => new ErrorCode(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is ErrorCode other && Equals(other);
        public bool Equals(ErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
