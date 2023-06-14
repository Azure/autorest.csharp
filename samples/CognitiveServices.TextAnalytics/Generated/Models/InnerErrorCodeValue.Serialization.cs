// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static partial class InnerErrorCodeValueExtensions
    {
        public static string ToSerialString(this InnerErrorCodeValue value) => value switch
        {
            InnerErrorCodeValue.InvalidParameterValue => "invalidParameterValue",
            InnerErrorCodeValue.InvalidRequestBodyFormat => "invalidRequestBodyFormat",
            InnerErrorCodeValue.EmptyRequest => "emptyRequest",
            InnerErrorCodeValue.MissingInputRecords => "missingInputRecords",
            InnerErrorCodeValue.InvalidDocument => "invalidDocument",
            InnerErrorCodeValue.ModelVersionIncorrect => "modelVersionIncorrect",
            InnerErrorCodeValue.InvalidDocumentBatch => "invalidDocumentBatch",
            InnerErrorCodeValue.UnsupportedLanguageCode => "unsupportedLanguageCode",
            InnerErrorCodeValue.InvalidCountryHint => "invalidCountryHint",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown InnerErrorCodeValue value.")
        };

        public static InnerErrorCodeValue ToInnerErrorCodeValue(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidParameterValue")) return InnerErrorCodeValue.InvalidParameterValue;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidRequestBodyFormat")) return InnerErrorCodeValue.InvalidRequestBodyFormat;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "emptyRequest")) return InnerErrorCodeValue.EmptyRequest;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "missingInputRecords")) return InnerErrorCodeValue.MissingInputRecords;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidDocument")) return InnerErrorCodeValue.InvalidDocument;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "modelVersionIncorrect")) return InnerErrorCodeValue.ModelVersionIncorrect;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidDocumentBatch")) return InnerErrorCodeValue.InvalidDocumentBatch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "unsupportedLanguageCode")) return InnerErrorCodeValue.UnsupportedLanguageCode;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "invalidCountryHint")) return InnerErrorCodeValue.InvalidCountryHint;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown InnerErrorCodeValue value.");
        }
    }
}
