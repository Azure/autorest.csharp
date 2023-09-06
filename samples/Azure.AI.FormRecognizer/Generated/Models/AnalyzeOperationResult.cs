// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Status and result of the queued analyze operation. </summary>
    public partial class AnalyzeOperationResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="AnalyzeOperationResult"/>. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the analyze operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        internal AnalyzeOperationResult(OperationStatus status, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime)
        {
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
        }

        /// <summary> Initializes a new instance of <see cref="AnalyzeOperationResult"/>. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the analyze operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="analyzeResult"> Results of the analyze operation. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AnalyzeOperationResult(OperationStatus status, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime, AnalyzeResult analyzeResult, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            AnalyzeResult = analyzeResult;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="AnalyzeOperationResult"/> for deserialization. </summary>
        internal AnalyzeOperationResult()
        {
        }

        /// <summary> Operation status. </summary>
        public OperationStatus Status { get; }
        /// <summary> Date and time (UTC) when the analyze operation was submitted. </summary>
        public DateTimeOffset CreatedDateTime { get; }
        /// <summary> Date and time (UTC) when the status was last updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; }
        /// <summary> Results of the analyze operation. </summary>
        public AnalyzeResult AnalyzeResult { get; }
    }
}
