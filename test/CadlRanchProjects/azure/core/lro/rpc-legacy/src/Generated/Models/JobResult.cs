// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Azure.Lro.RpcLegacy.Models
{
    /// <summary> Result of the job. </summary>
    public partial class JobResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="JobResult"/>. </summary>
        internal JobResult()
        {
            Errors = new ChangeTrackingList<ErrorResponse>();
            Results = new ChangeTrackingList<string>();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="JobResult"/>. </summary>
        /// <param name="jobId"> A processing job identifier. </param>
        /// <param name="comment"> Comment. </param>
        /// <param name="status"> The status of the processing job. </param>
        /// <param name="errors"> Error objects that describes the error when status is "Failed". </param>
        /// <param name="results"> The results. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal JobResult(string jobId, string comment, JobStatus status, IReadOnlyList<ErrorResponse> errors, IReadOnlyList<string> results, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            JobId = jobId;
            Comment = comment;
            Status = status;
            Errors = errors;
            Results = results;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> A processing job identifier. </summary>
        public string JobId { get; }
        /// <summary> Comment. </summary>
        public string Comment { get; }
        /// <summary> The status of the processing job. </summary>
        public JobStatus Status { get; }
        /// <summary> Error objects that describes the error when status is "Failed". </summary>
        public IReadOnlyList<ErrorResponse> Errors { get; }
        /// <summary> The results. </summary>
        public IReadOnlyList<string> Results { get; }
    }
}
