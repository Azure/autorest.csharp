// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Analyze operation result. </summary>
    public partial class AnalyzeResult
    {
        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="version"> Version of schema used for this result. </param>
        /// <param name="readResults"> Text extracted from the input. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> or <paramref name="readResults"/> is null. </exception>
        internal AnalyzeResult(string version, IEnumerable<ReadResult> readResults)
        {
            Argument.AssertNotNull(version, nameof(version));
            Argument.AssertNotNull(readResults, nameof(readResults));

            Version = version;
            ReadResults = readResults.ToList();
            PageResults = new ChangeTrackingList<PageResult>();
            DocumentResults = new ChangeTrackingList<DocumentResult>();
            Errors = new ChangeTrackingList<ErrorInformation>();
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="version"> Version of schema used for this result. </param>
        /// <param name="readResults"> Text extracted from the input. </param>
        /// <param name="pageResults"> Page-level information extracted from the input. </param>
        /// <param name="documentResults"> Document-level information extracted from the input. </param>
        /// <param name="errors"> List of errors reported during the analyze operation. </param>
        internal AnalyzeResult(string version, IReadOnlyList<ReadResult> readResults, IReadOnlyList<PageResult> pageResults, IReadOnlyList<DocumentResult> documentResults, IReadOnlyList<ErrorInformation> errors)
        {
            Version = version;
            ReadResults = readResults;
            PageResults = pageResults;
            DocumentResults = documentResults;
            Errors = errors;
        }

        /// <summary> Version of schema used for this result. </summary>
        public string Version { get; }
        /// <summary> Text extracted from the input. </summary>
        public IReadOnlyList<ReadResult> ReadResults { get; }
        /// <summary> Page-level information extracted from the input. </summary>
        public IReadOnlyList<PageResult> PageResults { get; }
        /// <summary> Document-level information extracted from the input. </summary>
        public IReadOnlyList<DocumentResult> DocumentResults { get; }
        /// <summary> List of errors reported during the analyze operation. </summary>
        public IReadOnlyList<ErrorInformation> Errors { get; }
    }
}
