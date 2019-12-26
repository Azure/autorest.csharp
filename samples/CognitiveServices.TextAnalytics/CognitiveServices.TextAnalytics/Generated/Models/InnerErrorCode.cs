// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public readonly partial struct InnerErrorCode : IEquatable<InnerErrorCode>
    {
        private readonly string? _value;

        public InnerErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidParameterValueValue = "invalidParameterValue";
        private const string InvalidRequestBodyFormatValue = "invalidRequestBodyFormat";
        private const string EmptyRequestValue = "emptyRequest";
        private const string MissingInputRecordsValue = "missingInputRecords";
        private const string InvalidDocumentValue = "invalidDocument";
        private const string ModelVersionIncorrectValue = "modelVersionIncorrect";
        private const string InvalidDocumentBatchValue = "invalidDocumentBatch";
        private const string UnsupportedLanguageCodeValue = "unsupportedLanguageCode";
        private const string InvalidCountryHintValue = "invalidCountryHint";

        public static InnerErrorCode InvalidParameterValue { get; } = new InnerErrorCode(InvalidParameterValueValue);
        public static InnerErrorCode InvalidRequestBodyFormat { get; } = new InnerErrorCode(InvalidRequestBodyFormatValue);
        public static InnerErrorCode EmptyRequest { get; } = new InnerErrorCode(EmptyRequestValue);
        public static InnerErrorCode MissingInputRecords { get; } = new InnerErrorCode(MissingInputRecordsValue);
        public static InnerErrorCode InvalidDocument { get; } = new InnerErrorCode(InvalidDocumentValue);
        public static InnerErrorCode ModelVersionIncorrect { get; } = new InnerErrorCode(ModelVersionIncorrectValue);
        public static InnerErrorCode InvalidDocumentBatch { get; } = new InnerErrorCode(InvalidDocumentBatchValue);
        public static InnerErrorCode UnsupportedLanguageCode { get; } = new InnerErrorCode(UnsupportedLanguageCodeValue);
        public static InnerErrorCode InvalidCountryHint { get; } = new InnerErrorCode(InvalidCountryHintValue);
        public static bool operator ==(InnerErrorCode left, InnerErrorCode right) => left.Equals(right);
        public static bool operator !=(InnerErrorCode left, InnerErrorCode right) => !left.Equals(right);
        public static implicit operator InnerErrorCode(string value) => new InnerErrorCode(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is InnerErrorCode other && Equals(other);
        public bool Equals(InnerErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
