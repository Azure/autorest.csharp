// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Response from a get service statistics request. If successful, it includes service level counters and limits. </summary>
    public partial class ServiceStatistics
    {
        /// <summary> Represents service-level resource counters and quotas. </summary>
        public ServiceCounters? Counters { get; set; }
        /// <summary> Represents various service level limits. </summary>
        public ServiceLimits? Limits { get; set; }
    }
}
