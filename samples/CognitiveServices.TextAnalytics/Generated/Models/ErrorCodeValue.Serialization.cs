// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static partial class ErrorCodeValueExtensions
    {
        public static string ToSerialString(this ErrorCodeValue value) => value switch
        {
            ErrorCodeValue.InvalidRequest => "invalidRequest",
            ErrorCodeValue.InvalidArgument => "invalidArgument",
            ErrorCodeValue.InternalServerError => "internalServerError",
            ErrorCodeValue.ServiceUnavailable => "serviceUnavailable",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ErrorCodeValue value.")
        };

        public static ErrorCodeValue ToErrorCodeValue(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidRequest")) return ErrorCodeValue.InvalidRequest;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidArgument")) return ErrorCodeValue.InvalidArgument;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "internalServerError")) return ErrorCodeValue.InternalServerError;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "serviceUnavailable")) return ErrorCodeValue.ServiceUnavailable;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ErrorCodeValue value.");
        }
    }
}
