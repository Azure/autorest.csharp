// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Api request input for LogAnalytics getRequestRateByInterval Api.
    /// Serialized Name: RequestRateByIntervalInput
    /// </summary>
    public partial class RequestRateByIntervalContent : LogAnalyticsInputBase
    {
        /// <summary> Initializes a new instance of RequestRateByIntervalContent. </summary>
        /// <param name="blobContainerSasUri">
        /// SAS Uri of the logging blob container to which LogAnalytics Api writes output logs to.
        /// Serialized Name: LogAnalyticsInputBase.blobContainerSasUri
        /// </param>
        /// <param name="fromTime">
        /// From time of the query
        /// Serialized Name: LogAnalyticsInputBase.fromTime
        /// </param>
        /// <param name="toTime">
        /// To time of the query
        /// Serialized Name: LogAnalyticsInputBase.toTime
        /// </param>
        /// <param name="intervalLength">
        /// Interval value in minutes used to create LogAnalytics call rate logs.
        /// Serialized Name: RequestRateByIntervalInput.intervalLength
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobContainerSasUri"/> is null. </exception>
        public RequestRateByIntervalContent(Uri blobContainerSasUri, DateTimeOffset fromTime, DateTimeOffset toTime, IntervalInMin intervalLength) : base(blobContainerSasUri, fromTime, toTime)
        {
            Argument.AssertNotNull(blobContainerSasUri, nameof(blobContainerSasUri));

            IntervalLength = intervalLength;
        }

        /// <summary>
        /// Interval value in minutes used to create LogAnalytics call rate logs.
        /// Serialized Name: RequestRateByIntervalInput.intervalLength
        /// </summary>
        public IntervalInMin IntervalLength { get; }
    }
}
