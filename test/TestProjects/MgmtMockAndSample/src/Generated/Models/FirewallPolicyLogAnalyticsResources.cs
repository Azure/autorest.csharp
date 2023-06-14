// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> Log Analytics Resources for Firewall Policy Insights. </summary>
    public partial class FirewallPolicyLogAnalyticsResources
    {
        /// <summary> Initializes a new instance of FirewallPolicyLogAnalyticsResources. </summary>
        public FirewallPolicyLogAnalyticsResources()
        {
            Workspaces = new ChangeTrackingList<FirewallPolicyLogAnalyticsWorkspace>();
        }

        /// <summary> Initializes a new instance of FirewallPolicyLogAnalyticsResources. </summary>
        /// <param name="workspaces"> List of workspaces for Firewall Policy Insights. </param>
        /// <param name="defaultWorkspaceId"> The default workspace Id for Firewall Policy Insights. </param>
        internal FirewallPolicyLogAnalyticsResources(IList<FirewallPolicyLogAnalyticsWorkspace> workspaces, WritableSubResource defaultWorkspaceId)
        {
            Workspaces = workspaces;
            DefaultWorkspaceId = defaultWorkspaceId;
        }

        /// <summary> List of workspaces for Firewall Policy Insights. </summary>
        public IList<FirewallPolicyLogAnalyticsWorkspace> Workspaces { get; }
        /// <summary> The default workspace Id for Firewall Policy Insights. </summary>
        internal WritableSubResource DefaultWorkspaceId { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier DefaultWorkspaceIdId
        {
            get => DefaultWorkspaceId is null ? default : DefaultWorkspaceId.Id;
            set
            {
                if (DefaultWorkspaceId is null)
                    DefaultWorkspaceId = new WritableSubResource();
                DefaultWorkspaceId.Id = value;
            }
        }
    }
}
