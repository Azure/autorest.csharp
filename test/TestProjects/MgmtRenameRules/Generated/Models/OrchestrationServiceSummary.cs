// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Summary for an orchestration service of a virtual machine scale set.
    /// Serialized Name: OrchestrationServiceSummary
    /// </summary>
    public partial class OrchestrationServiceSummary
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="OrchestrationServiceSummary"/>. </summary>
        internal OrchestrationServiceSummary()
        {
        }

        /// <summary> Initializes a new instance of <see cref="OrchestrationServiceSummary"/>. </summary>
        /// <param name="serviceName">
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceName
        /// </param>
        /// <param name="serviceState">
        /// The current state of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceState
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OrchestrationServiceSummary(OrchestrationServiceName? serviceName, OrchestrationServiceState? serviceState, Dictionary<string, BinaryData> rawData)
        {
            ServiceName = serviceName;
            ServiceState = serviceState;
            _rawData = rawData;
        }

        /// <summary>
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceName
        /// </summary>
        public OrchestrationServiceName? ServiceName { get; }
        /// <summary>
        /// The current state of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceState
        /// </summary>
        public OrchestrationServiceState? ServiceState { get; }
    }
}
