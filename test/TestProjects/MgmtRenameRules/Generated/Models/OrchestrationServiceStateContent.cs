// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The input for OrchestrationServiceState
    /// Serialized Name: OrchestrationServiceStateInput
    /// </summary>
    public partial class OrchestrationServiceStateContent
    {
        /// <summary> Initializes a new instance of OrchestrationServiceStateContent. </summary>
        /// <param name="serviceName">
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceStateInput.serviceName
        /// </param>
        /// <param name="action">
        /// The action to be performed.
        /// Serialized Name: OrchestrationServiceStateInput.action
        /// </param>
        public OrchestrationServiceStateContent(OrchestrationServiceName serviceName, OrchestrationServiceStateAction action)
        {
            ServiceName = serviceName;
            Action = action;
        }

        /// <summary>
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceStateInput.serviceName
        /// </summary>
        public OrchestrationServiceName ServiceName { get; }
        /// <summary>
        /// The action to be performed.
        /// Serialized Name: OrchestrationServiceStateInput.action
        /// </summary>
        public OrchestrationServiceStateAction Action { get; }
    }
}
