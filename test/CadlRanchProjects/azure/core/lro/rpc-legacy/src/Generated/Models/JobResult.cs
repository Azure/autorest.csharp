// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Azure.Lro.RpcLegacy.Models
{
    /// <summary> Result of the job. </summary>
    public partial class JobResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="JobResult"/>. </summary>
        internal JobResult()
        {
            Errors = new ChangeTrackingList<ErrorResponse>();
            Results = new ChangeTrackingList<string>();
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
