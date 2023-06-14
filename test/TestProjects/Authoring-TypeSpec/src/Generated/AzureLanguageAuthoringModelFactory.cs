// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;

namespace Azure.Language.Authoring.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AzureLanguageAuthoringModelFactory
    {
        /// <summary> Initializes a new instance of DeploymentJob. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="createdDateTime"> The creation date time of the job. </param>
        /// <param name="lastUpdatedDateTime"> The the last date time the job was updated. </param>
        /// <param name="expirationDateTime"> The expiration date time of the job. </param>
        /// <param name="status"> The job status. </param>
        /// <param name="warnings"> The warnings that were encountered while executing the job. </param>
        /// <param name="errors"> The errors encountered while executing the job. </param>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Models.DeploymentJob"/> instance for mocking. </returns>
        public static DeploymentJob DeploymentJob(string jobId = null, DateTimeOffset createdDateTime = default, DateTimeOffset lastUpdatedDateTime = default, DateTimeOffset expirationDateTime = default, JobStatus status = default, IEnumerable<JobWarning> warnings = null, ResponseError errors = null, string id = null)
        {
            warnings ??= new List<JobWarning>();

            return new DeploymentJob(jobId, createdDateTime, lastUpdatedDateTime, expirationDateTime, status, warnings?.ToList(), errors, id);
        }

        /// <summary> Initializes a new instance of JobWarning. </summary>
        /// <param name="code"> The warning code. </param>
        /// <param name="message"> The warning message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        /// <returns> A new <see cref="Models.JobWarning"/> instance for mocking. </returns>
        public static JobWarning JobWarning(string code = null, string message = null)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return new JobWarning(code, message);
        }

        /// <summary> Initializes a new instance of SwapDeploymentsJob. </summary>
        /// <param name="jobId"> The job ID. </param>
        /// <param name="createdDateTime"> The creation date time of the job. </param>
        /// <param name="lastUpdatedDateTime"> The the last date time the job was updated. </param>
        /// <param name="expirationDateTime"> The expiration date time of the job. </param>
        /// <param name="status"> The job status. </param>
        /// <param name="warnings"> The warnings that were encountered while executing the job. </param>
        /// <param name="errors"> The errors encountered while executing the job. </param>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Models.SwapDeploymentsJob"/> instance for mocking. </returns>
        public static SwapDeploymentsJob SwapDeploymentsJob(string jobId = null, DateTimeOffset createdDateTime = default, DateTimeOffset lastUpdatedDateTime = default, DateTimeOffset expirationDateTime = default, JobStatus status = default, IEnumerable<JobWarning> warnings = null, ResponseError errors = null, string id = null)
        {
            warnings ??= new List<JobWarning>();

            return new SwapDeploymentsJob(jobId, createdDateTime, lastUpdatedDateTime, expirationDateTime, status, warnings?.ToList(), errors, id);
        }
    }
}
