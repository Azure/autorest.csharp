// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> Storage Service Properties. </summary>
    public partial class StorageServiceProperties
    {
        /// <summary> Initializes a new instance of StorageServiceProperties. </summary>
        internal StorageServiceProperties()
        {
        }

        /// <summary> Initializes a new instance of StorageServiceProperties. </summary>
        /// <param name="logging"> Azure Analytics Logging settings. </param>
        /// <param name="hourMetrics"> A summary of request statistics grouped by API in hourly aggregates for blobs. </param>
        /// <param name="minuteMetrics"> a summary of request statistics grouped by API in minute aggregates for blobs. </param>
        /// <param name="cors"> The set of CORS rules. </param>
        /// <param name="defaultServiceVersion"> The default version to use for requests to the Blob service if an incoming request&apos;s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </param>
        /// <param name="deleteRetentionPolicy"> The Delete Retention Policy for the service. </param>
        internal StorageServiceProperties(Logging logging, Metrics hourMetrics, Metrics minuteMetrics, IList<CorsRule> cors, string defaultServiceVersion, RetentionPolicy deleteRetentionPolicy)
        {
            Logging = logging;
            HourMetrics = hourMetrics;
            MinuteMetrics = minuteMetrics;
            Cors = cors;
            DefaultServiceVersion = defaultServiceVersion;
            DeleteRetentionPolicy = deleteRetentionPolicy;
        }

        /// <summary> Azure Analytics Logging settings. </summary>
        public Logging Logging { get; set; }
        /// <summary> A summary of request statistics grouped by API in hourly aggregates for blobs. </summary>
        public Metrics HourMetrics { get; set; }
        /// <summary> a summary of request statistics grouped by API in minute aggregates for blobs. </summary>
        public Metrics MinuteMetrics { get; set; }
        /// <summary> The set of CORS rules. </summary>
        public IList<CorsRule> Cors { get; set; }
        /// <summary> The default version to use for requests to the Blob service if an incoming request&apos;s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </summary>
        public string DefaultServiceVersion { get; set; }
        /// <summary> The Delete Retention Policy for the service. </summary>
        public RetentionPolicy DeleteRetentionPolicy { get; set; }
    }
}
