// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Language.Authoring.Models
{
    /// <summary> The DeploymentJob. </summary>
    public partial class DeploymentJob
    {
        /// <summary> Initializes a new instance of DeploymentJob. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="status"> The job status. </param>
        /// <param name="warnings"> The warnings that were encountered while executing the job. </param>
        /// <param name="errors"> The errors encountered while executing the job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="warnings"/> or <paramref name="errors"/> is null. </exception>
        internal DeploymentJob(string jobId, JobStatus status, IEnumerable<JobWarning> warnings, ResponseError errors)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));
            Argument.AssertNotNull(warnings, nameof(warnings));
            Argument.AssertNotNull(errors, nameof(errors));

            JobId = jobId;
            Status = status;
            Warnings = warnings.ToList();
            Errors = errors;
        }

        /// <summary> Initializes a new instance of DeploymentJob. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="createdDateTime"> The creation date time of the job. </param>
        /// <param name="lastUpdatedDateTime"> The the last date time the job was updated. </param>
        /// <param name="expirationDateTime"> The expiration date time of the job. </param>
        /// <param name="status"> The job status. </param>
        /// <param name="warnings"> The warnings that were encountered while executing the job. </param>
        /// <param name="errors"> The errors encountered while executing the job. </param>
        /// <param name="id"></param>
        internal DeploymentJob(string jobId, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime, DateTimeOffset expirationDateTime, JobStatus status, IReadOnlyList<JobWarning> warnings, ResponseError errors, string id)
        {
            JobId = jobId;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            ExpirationDateTime = expirationDateTime;
            Status = status;
            Warnings = warnings;
            Errors = errors;
            Id = id;
        }

        /// <summary> The job ID. </summary>
        public string JobId { get; }
        /// <summary> The creation date time of the job. </summary>
        public DateTimeOffset CreatedDateTime { get; }
        /// <summary> The the last date time the job was updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; }
        /// <summary> The expiration date time of the job. </summary>
        public DateTimeOffset ExpirationDateTime { get; }
        /// <summary> The job status. </summary>
        public JobStatus Status { get; }
        /// <summary> The warnings that were encountered while executing the job. </summary>
        public IReadOnlyList<JobWarning> Warnings { get; }
        /// <summary> The errors encountered while executing the job. </summary>
        public ResponseError Errors { get; }
        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
