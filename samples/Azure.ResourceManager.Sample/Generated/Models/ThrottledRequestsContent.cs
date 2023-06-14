// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Api request input for LogAnalytics getThrottledRequests Api.
    /// Serialized Name: ThrottledRequestsInput
    /// </summary>
    public partial class ThrottledRequestsContent : LogAnalyticsInputBase
    {
        /// <summary> Initializes a new instance of ThrottledRequestsContent. </summary>
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
        /// <exception cref="ArgumentNullException"> <paramref name="blobContainerSasUri"/> is null. </exception>
        public ThrottledRequestsContent(Uri blobContainerSasUri, DateTimeOffset fromTime, DateTimeOffset toTime) : base(blobContainerSasUri, fromTime, toTime)
        {
            Argument.AssertNotNull(blobContainerSasUri, nameof(blobContainerSasUri));
        }
    }
}
