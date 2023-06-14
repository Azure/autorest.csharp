// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// LogAnalytics operation status response
    /// Serialized Name: LogAnalyticsOperationResult
    /// </summary>
    public partial class LogAnalytics
    {
        /// <summary> Initializes a new instance of LogAnalytics. </summary>
        internal LogAnalytics()
        {
        }

        /// <summary> Initializes a new instance of LogAnalytics. </summary>
        /// <param name="properties">
        /// LogAnalyticsOutput
        /// Serialized Name: LogAnalyticsOperationResult.properties
        /// </param>
        internal LogAnalytics(LogAnalyticsOutput properties)
        {
            Properties = properties;
        }

        /// <summary>
        /// LogAnalyticsOutput
        /// Serialized Name: LogAnalyticsOperationResult.properties
        /// </summary>
        internal LogAnalyticsOutput Properties { get; }
        /// <summary>
        /// Output file Uri path to blob container.
        /// Serialized Name: LogAnalyticsOutput.output
        /// </summary>
        public string LogAnalyticsOutput
        {
            get => Properties?.Output;
        }
    }
}
