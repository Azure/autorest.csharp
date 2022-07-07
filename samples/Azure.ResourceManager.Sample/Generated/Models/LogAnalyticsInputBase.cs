// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Api input base class for LogAnalytics Api.
    /// Serialized Name: LogAnalyticsInputBase
    /// </summary>
    public partial class LogAnalyticsInputBase
    {
        /// <summary> Initializes a new instance of LogAnalyticsInputBase. </summary>
        /// <param name="blobContainerSasUri">
        /// SAS Uri of the logging blob container to which LogAnalytics Api writes output logs to.
        /// Serialized Name: LogAnalyticsInputBase.blobContainerSasUri
        /// </param>
        /// <param name="fromOn">
        /// From time of the query
        /// Serialized Name: LogAnalyticsInputBase.fromTime
        /// </param>
        /// <param name="toOn">
        /// To time of the query
        /// Serialized Name: LogAnalyticsInputBase.toTime
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobContainerSasUri"/> is null. </exception>
        public LogAnalyticsInputBase(Uri blobContainerSasUri, DateTimeOffset fromOn, DateTimeOffset toOn)
        {
            if (blobContainerSasUri == null)
            {
                throw new ArgumentNullException(nameof(blobContainerSasUri));
            }

            BlobContainerSasUri = blobContainerSasUri;
            FromOn = fromOn;
            ToOn = toOn;
        }

        /// <summary>
        /// SAS Uri of the logging blob container to which LogAnalytics Api writes output logs to.
        /// Serialized Name: LogAnalyticsInputBase.blobContainerSasUri
        /// </summary>
        public Uri BlobContainerSasUri { get; }
        /// <summary>
        /// From time of the query
        /// Serialized Name: LogAnalyticsInputBase.fromTime
        /// </summary>
        public DateTimeOffset FromOn { get; }
        /// <summary>
        /// To time of the query
        /// Serialized Name: LogAnalyticsInputBase.toTime
        /// </summary>
        public DateTimeOffset ToOn { get; }
        /// <summary>
        /// Group query result by Throttle Policy applied.
        /// Serialized Name: LogAnalyticsInputBase.groupByThrottlePolicy
        /// </summary>
        public bool? GroupByThrottlePolicy { get; set; }
        /// <summary>
        /// Group query result by Operation Name.
        /// Serialized Name: LogAnalyticsInputBase.groupByOperationName
        /// </summary>
        public bool? GroupByOperationName { get; set; }
        /// <summary>
        /// Group query result by Resource Name.
        /// Serialized Name: LogAnalyticsInputBase.groupByResourceName
        /// </summary>
        public bool? GroupByResourceName { get; set; }
    }
}
