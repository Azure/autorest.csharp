// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static partial class WarningCodeValueExtensions
    {
        public static string ToSerialString(this WarningCodeValue value) => value switch
        {
            WarningCodeValue.LongWordsInDocument => "LongWordsInDocument",
            WarningCodeValue.DocumentTruncated => "DocumentTruncated",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown WarningCodeValue value.")
        };

        public static WarningCodeValue ToWarningCodeValue(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "LongWordsInDocument")) return WarningCodeValue.LongWordsInDocument;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "DocumentTruncated")) return WarningCodeValue.DocumentTruncated;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown WarningCodeValue value.");
        }
    }
}
