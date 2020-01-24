// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> Storage Service Properties. </summary>
    public partial class StorageServiceProperties
    {
        /// <summary> Azure Analytics Logging settings. </summary>
        public Logging Logging { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public Metrics HourMetrics { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public Metrics MinuteMetrics { get; set; }
        /// <summary> The set of CORS rules. </summary>
        public ICollection<CorsRule> Cors { get; set; }
        /// <summary> The default version to use for requests to the Blob service if an incoming request&apos;s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </summary>
        public string DefaultServiceVersion { get; set; }
        /// <summary> the retention policy. </summary>
        public RetentionPolicy DeleteRetentionPolicy { get; set; }
    }
}
