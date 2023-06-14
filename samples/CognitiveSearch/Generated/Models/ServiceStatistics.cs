// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a get service statistics request. If successful, it includes service level counters and limits. </summary>
    public partial class ServiceStatistics
    {
        /// <summary> Initializes a new instance of ServiceStatistics. </summary>
        /// <param name="counters"> Service level resource counters. </param>
        /// <param name="limits"> Service level general limits. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="counters"/> or <paramref name="limits"/> is null. </exception>
        internal ServiceStatistics(ServiceCounters counters, ServiceLimits limits)
        {
            Argument.AssertNotNull(counters, nameof(counters));
            Argument.AssertNotNull(limits, nameof(limits));

            Counters = counters;
            Limits = limits;
        }

        /// <summary> Service level resource counters. </summary>
        public ServiceCounters Counters { get; }
        /// <summary> Service level general limits. </summary>
        public ServiceLimits Limits { get; }
    }
}
