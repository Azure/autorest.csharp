// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> A set of extracted fields corresponding to the input document. </summary>
    public partial class DocumentResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DocumentResult"/>. </summary>
        /// <param name="docType"> Document type. </param>
        /// <param name="pageRange"> First and last page number where the document is found. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="docType"/>, <paramref name="pageRange"/> or <paramref name="fields"/> is null. </exception>
        internal DocumentResult(string docType, IEnumerable<int> pageRange, IReadOnlyDictionary<string, FieldValue> fields)
        {
            Argument.AssertNotNull(docType, nameof(docType));
            Argument.AssertNotNull(pageRange, nameof(pageRange));
            Argument.AssertNotNull(fields, nameof(fields));

            DocType = docType;
            PageRange = pageRange.ToList();
            Fields = fields;
        }

        /// <summary> Initializes a new instance of <see cref="DocumentResult"/>. </summary>
        /// <param name="docType"> Document type. </param>
        /// <param name="pageRange"> First and last page number where the document is found. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DocumentResult(string docType, IReadOnlyList<int> pageRange, IReadOnlyDictionary<string, FieldValue> fields, Dictionary<string, BinaryData> rawData)
        {
            DocType = docType;
            PageRange = pageRange;
            Fields = fields;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DocumentResult"/> for deserialization. </summary>
        internal DocumentResult()
        {
        }

        /// <summary> Document type. </summary>
        public string DocType { get; }
        /// <summary> First and last page number where the document is found. </summary>
        public IReadOnlyList<int> PageRange { get; }
        /// <summary> Dictionary of named field values. </summary>
        public IReadOnlyDictionary<string, FieldValue> Fields { get; }
    }
}
