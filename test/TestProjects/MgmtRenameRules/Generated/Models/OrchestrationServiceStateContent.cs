// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The input for OrchestrationServiceState
    /// Serialized Name: OrchestrationServiceStateInput
    /// </summary>
    public partial class OrchestrationServiceStateContent
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.OrchestrationServiceStateContent
        ///
        /// </summary>
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
        /// Initializes a new instance of global::MgmtRenameRules.Models.OrchestrationServiceStateContent
        ///
        /// </summary>
        /// <param name="serviceName">
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceStateInput.serviceName
        /// </param>
        /// <param name="action">
        /// The action to be performed.
        /// Serialized Name: OrchestrationServiceStateInput.action
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OrchestrationServiceStateContent(OrchestrationServiceName serviceName, OrchestrationServiceStateAction action, Dictionary<string, BinaryData> rawData)
        {
            ServiceName = serviceName;
            Action = action;
            _rawData = rawData;
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
