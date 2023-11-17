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
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyLogAnalyticsWorkspace"/>. </summary>
        public FirewallPolicyLogAnalyticsWorkspace()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyLogAnalyticsWorkspace"/>. </summary>
        /// <param name="region"> Region to configure the Workspace. </param>
        /// <param name="workspaceId"> The workspace Id for Firewall Policy Insights. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyLogAnalyticsWorkspace(string region, WritableSubResource workspaceId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Region = region;
            WorkspaceId = workspaceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
