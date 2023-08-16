// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> Log Analytics Workspace for Firewall Policy Insights. </summary>
    public partial class FirewallPolicyLogAnalyticsWorkspace
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.FirewallPolicyLogAnalyticsWorkspace
        ///
        /// </summary>
        public FirewallPolicyLogAnalyticsWorkspace()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.FirewallPolicyLogAnalyticsWorkspace
        ///
        /// </summary>
        /// <param name="region"> Region to configure the Workspace. </param>
        /// <param name="workspaceId"> The workspace Id for Firewall Policy Insights. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyLogAnalyticsWorkspace(string region, WritableSubResource workspaceId, Dictionary<string, BinaryData> rawData)
        {
            Region = region;
            WorkspaceId = workspaceId;
            _rawData = rawData;
        }

        /// <summary> Region to configure the Workspace. </summary>
        public string Region { get; set; }
        /// <summary> The workspace Id for Firewall Policy Insights. </summary>
        internal WritableSubResource WorkspaceId { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier WorkspaceIdId
        {
            get => WorkspaceId is null ? default : WorkspaceId.Id;
            set
            {
                if (WorkspaceId is null)
                    WorkspaceId = new WritableSubResource();
                WorkspaceId.Id = value;
            }
        }
    }
}
