// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> The Metrics. </summary>
    public partial class Metrics
    {
        /// <summary> Initializes a new instance of Metrics. </summary>
        /// <param name="enabled"> Indicates whether metrics are enabled for the Blob service. </param>
        public Metrics(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary> Initializes a new instance of Metrics. </summary>
        /// <param name="version"> The version of Storage Analytics to configure. </param>
        /// <param name="enabled"> Indicates whether metrics are enabled for the Blob service. </param>
        /// <param name="includeAPIs"> Indicates whether metrics should generate summary statistics for called API operations. </param>
        /// <param name="retentionPolicy"> the retention policy. </param>
        internal Metrics(string version, bool enabled, bool? includeAPIs, RetentionPolicy retentionPolicy)
        {
            Version = version;
            Enabled = enabled;
            IncludeAPIs = includeAPIs;
            RetentionPolicy = retentionPolicy;
        }

        /// <summary> The version of Storage Analytics to configure. </summary>
        public string Version { get; set; }
        /// <summary> Indicates whether metrics are enabled for the Blob service. </summary>
        public bool Enabled { get; set; }
        /// <summary> Indicates whether metrics should generate summary statistics for called API operations. </summary>
        public bool? IncludeAPIs { get; set; }
        /// <summary> the retention policy. </summary>
        public RetentionPolicy RetentionPolicy { get; set; }
    }
}
