// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> The input for OrchestrationServiceState. </summary>
    public partial class OrchestrationServiceStateInput
    {
        /// <summary> Initializes a new instance of OrchestrationServiceStateInput. </summary>
        /// <param name="serviceName"> The name of the service. </param>
        /// <param name="action"> The action to be performed. </param>
        public OrchestrationServiceStateInput(OrchestrationServiceNames serviceName, OrchestrationServiceStateAction action)
        {
            ServiceName = serviceName;
            Action = action;
        }

        /// <summary> The name of the service. </summary>
        public OrchestrationServiceNames ServiceName { get; }
        /// <summary> The action to be performed. </summary>
        public OrchestrationServiceStateAction Action { get; }
    }
}
