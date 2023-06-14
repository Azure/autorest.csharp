// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Storage Service Properties. </summary>
    public partial class StorageServiceProperties
    {
        /// <summary> Initializes a new instance of StorageServiceProperties. </summary>
        public StorageServiceProperties()
        {
            Cors = new ChangeTrackingList<CorsRule>();
        }

        /// <summary> Initializes a new instance of StorageServiceProperties. </summary>
        /// <param name="logging"> Azure Analytics Logging settings. </param>
        /// <param name="hourMetrics"> A summary of request statistics grouped by API in hourly aggregates for queues. </param>
        /// <param name="minuteMetrics"> a summary of request statistics grouped by API in minute aggregates for queues. </param>
        /// <param name="cors"> The set of CORS rules. </param>
        internal StorageServiceProperties(Logging logging, Metrics hourMetrics, Metrics minuteMetrics, IList<CorsRule> cors)
        {
            Logging = logging;
            HourMetrics = hourMetrics;
            MinuteMetrics = minuteMetrics;
            Cors = cors;
        }

        /// <summary> Azure Analytics Logging settings. </summary>
        public Logging Logging { get; set; }
        /// <summary> A summary of request statistics grouped by API in hourly aggregates for queues. </summary>
        public Metrics HourMetrics { get; set; }
        /// <summary> a summary of request statistics grouped by API in minute aggregates for queues. </summary>
        public Metrics MinuteMetrics { get; set; }
        /// <summary> The set of CORS rules. </summary>
        public IList<CorsRule> Cors { get; }
    }
}
