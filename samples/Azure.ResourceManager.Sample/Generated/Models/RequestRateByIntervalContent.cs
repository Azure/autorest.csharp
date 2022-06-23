// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Api request input for LogAnalytics getRequestRateByInterval Api. </summary>
    public partial class RequestRateByIntervalContent : LogAnalyticsInputBase
    {
        /// <summary> Initializes a new instance of RequestRateByIntervalContent. </summary>
        /// <param name="blobContainerSasUri"> SAS Uri of the logging blob container to which LogAnalytics Api writes output logs to. </param>
        /// <param name="fromOn"> From time of the query. </param>
        /// <param name="toOn"> To time of the query. </param>
        /// <param name="intervalLength"> Interval value in minutes used to create LogAnalytics call rate logs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobContainerSasUri"/> is null. </exception>
        public RequestRateByIntervalContent(Uri blobContainerSasUri, DateTimeOffset fromOn, DateTimeOffset toOn, IntervalInMin intervalLength) : base(blobContainerSasUri, fromOn, toOn)
        {
            if (blobContainerSasUri == null)
            {
                throw new ArgumentNullException(nameof(blobContainerSasUri));
            }

            IntervalLength = intervalLength;
        }

        /// <summary> Interval value in minutes used to create LogAnalytics call rate logs. </summary>
        public IntervalInMin IntervalLength { get; }
    }
}
