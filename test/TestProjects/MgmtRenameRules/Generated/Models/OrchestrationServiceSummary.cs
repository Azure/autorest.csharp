// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Summary for an orchestration service of a virtual machine scale set.
    /// Serialized Name: OrchestrationServiceSummary
    /// </summary>
    public partial class OrchestrationServiceSummary
    {
        /// <summary> Initializes a new instance of OrchestrationServiceSummary. </summary>
        internal OrchestrationServiceSummary()
        {
        }

        /// <summary> Initializes a new instance of OrchestrationServiceSummary. </summary>
        /// <param name="serviceName">
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceName
        /// </param>
        /// <param name="serviceState">
        /// The current state of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceState
        /// </param>
        internal OrchestrationServiceSummary(OrchestrationServiceName? serviceName, OrchestrationServiceState? serviceState)
        {
            ServiceName = serviceName;
            ServiceState = serviceState;
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
