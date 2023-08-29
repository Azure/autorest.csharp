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
    /// <summary> Log Analytics Resources for Firewall Policy Insights. </summary>
    public partial class FirewallPolicyLogAnalyticsResources
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyLogAnalyticsResources"/>. </summary>
        public FirewallPolicyLogAnalyticsResources()
        {
            Workspaces = new ChangeTrackingList<FirewallPolicyLogAnalyticsWorkspace>();
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyLogAnalyticsResources"/>. </summary>
        /// <param name="workspaces"> List of workspaces for Firewall Policy Insights. </param>
        /// <param name="defaultWorkspaceId"> The default workspace Id for Firewall Policy Insights. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyLogAnalyticsResources(IList<FirewallPolicyLogAnalyticsWorkspace> workspaces, WritableSubResource defaultWorkspaceId, Dictionary<string, BinaryData> rawData)
        {
            Workspaces = workspaces;
            DefaultWorkspaceId = defaultWorkspaceId;
            _rawData = rawData;
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
