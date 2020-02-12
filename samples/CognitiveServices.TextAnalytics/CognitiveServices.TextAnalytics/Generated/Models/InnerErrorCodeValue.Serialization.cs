// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static class InnerErrorCodeValueExtensions
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

        public static InnerErrorCodeValue ToInnerErrorCodeValue(this string value) => value switch
        {
            "invalidParameterValue" => InnerErrorCodeValue.InvalidParameterValue,
            "invalidRequestBodyFormat" => InnerErrorCodeValue.InvalidRequestBodyFormat,
            "emptyRequest" => InnerErrorCodeValue.EmptyRequest,
            "missingInputRecords" => InnerErrorCodeValue.MissingInputRecords,
            "invalidDocument" => InnerErrorCodeValue.InvalidDocument,
            "modelVersionIncorrect" => InnerErrorCodeValue.ModelVersionIncorrect,
            "invalidDocumentBatch" => InnerErrorCodeValue.InvalidDocumentBatch,
            "unsupportedLanguageCode" => InnerErrorCodeValue.UnsupportedLanguageCode,
            "invalidCountryHint" => InnerErrorCodeValue.InvalidCountryHint,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown InnerErrorCodeValue value.")
        };
    }
}
