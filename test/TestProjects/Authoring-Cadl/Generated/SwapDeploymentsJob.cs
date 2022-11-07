// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.Foundations;

namespace Azure.Language.Authoring
{
    /// <summary> The SwapDeploymentsJob. </summary>
    public partial class SwapDeploymentsJob
    {
        /// <summary> Initializes a new instance of SwapDeploymentsJob. </summary>
        /// <param name="jobId"></param>
        /// <param name="status"></param>
        /// <param name="warnings"></param>
        /// <param name="errors"></param>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="warnings"/>, <paramref name="errors"/> or <paramref name="id"/> is null. </exception>
        internal SwapDeploymentsJob(string jobId, JobStatus status, IEnumerable<JobWarning> warnings, Core.Foundations.Error errors, string id)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));
            Argument.AssertNotNull(warnings, nameof(warnings));
            Argument.AssertNotNull(errors, nameof(errors));
            Argument.AssertNotNull(id, nameof(id));

            JobId = jobId;
            Status = status;
            Warnings = warnings.ToList();
            Errors = errors;
            Id = id;
        }

        /// <summary> Initializes a new instance of SwapDeploymentsJob. </summary>
        /// <param name="jobId"></param>
        /// <param name="createdDateTime"></param>
        /// <param name="lastUpdatedDateTime"></param>
        /// <param name="expirationDateTime"></param>
        /// <param name="status"></param>
        /// <param name="warnings"></param>
        /// <param name="errors"></param>
        /// <param name="id"></param>
        internal SwapDeploymentsJob(string jobId, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime, DateTimeOffset expirationDateTime, JobStatus status, IReadOnlyList<JobWarning> warnings, Core.Foundations.Error errors, string id)
        {
            JobId = jobId;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            ExpirationDateTime = expirationDateTime;
            Status = status;
            Warnings = warnings.ToList();
            Errors = errors;
            Id = id;
        }

        /// <summary> Gets the job id. </summary>
        public string JobId { get; }
        /// <summary> Gets the created date time. </summary>
        public DateTimeOffset CreatedDateTime { get; }
        /// <summary> Gets the last updated date time. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; }
        /// <summary> Gets the expiration date time. </summary>
        public DateTimeOffset ExpirationDateTime { get; }
        /// <summary> Gets the status. </summary>
        public JobStatus Status { get; }
        /// <summary> Gets the warnings. </summary>
        public IReadOnlyList<JobWarning> Warnings { get; }
        /// <summary> Gets the errors. </summary>
        public Core.Foundations.Error Errors { get; }
        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
