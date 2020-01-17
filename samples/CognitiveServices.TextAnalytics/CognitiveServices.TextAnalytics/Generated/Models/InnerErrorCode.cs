// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Error code. </summary>
    public readonly partial struct InnerErrorCode : IEquatable<InnerErrorCode>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="InnerErrorCode"/> values are the same. </summary>
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

        /// <summary> invalidParameterValue. </summary>
        public static InnerErrorCode InvalidParameterValue { get; } = new InnerErrorCode(InvalidParameterValueValue);
        /// <summary> invalidRequestBodyFormat. </summary>
        public static InnerErrorCode InvalidRequestBodyFormat { get; } = new InnerErrorCode(InvalidRequestBodyFormatValue);
        /// <summary> emptyRequest. </summary>
        public static InnerErrorCode EmptyRequest { get; } = new InnerErrorCode(EmptyRequestValue);
        /// <summary> missingInputRecords. </summary>
        public static InnerErrorCode MissingInputRecords { get; } = new InnerErrorCode(MissingInputRecordsValue);
        /// <summary> invalidDocument. </summary>
        public static InnerErrorCode InvalidDocument { get; } = new InnerErrorCode(InvalidDocumentValue);
        /// <summary> modelVersionIncorrect. </summary>
        public static InnerErrorCode ModelVersionIncorrect { get; } = new InnerErrorCode(ModelVersionIncorrectValue);
        /// <summary> invalidDocumentBatch. </summary>
        public static InnerErrorCode InvalidDocumentBatch { get; } = new InnerErrorCode(InvalidDocumentBatchValue);
        /// <summary> unsupportedLanguageCode. </summary>
        public static InnerErrorCode UnsupportedLanguageCode { get; } = new InnerErrorCode(UnsupportedLanguageCodeValue);
        /// <summary> invalidCountryHint. </summary>
        public static InnerErrorCode InvalidCountryHint { get; } = new InnerErrorCode(InvalidCountryHintValue);
        /// <summary> Determines if two <see cref="InnerErrorCode"/> values are the same. </summary>
        public static bool operator ==(InnerErrorCode left, InnerErrorCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InnerErrorCode"/> values are not the same. </summary>
        public static bool operator !=(InnerErrorCode left, InnerErrorCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InnerErrorCode"/>. </summary>
        public static implicit operator InnerErrorCode(string value) => new InnerErrorCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is InnerErrorCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InnerErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
