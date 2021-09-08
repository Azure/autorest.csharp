// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    /// <summary> A class representing the Workspace data model. </summary>
    public partial class WorkspaceData : TrackedResource
    {
        /// <summary> Initializes a new instance of WorkspaceData. </summary>
        /// <param name="location"> The location. </param>
        public WorkspaceData(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of WorkspaceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="systemData"> Metadata pertaining to creation and last modification of the resource. </param>
        /// <param name="workspaceId"> The immutable id associated with this workspace. </param>
        /// <param name="description"> The description of this workspace. </param>
        /// <param name="friendlyName"> The friendly name for this workspace. This name in mutable. </param>
        /// <param name="keyVault"> ARM id of the key vault associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="applicationInsights"> ARM id of the application insights associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="containerRegistry"> ARM id of the container registry associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="storageAccount"> ARM id of the storage account associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="discoveryUrl"> Url for the discovery service to identify regional endpoints for machine learning experimentation services. </param>
        /// <param name="provisioningState"> The current deployment state of workspace resource. The provisioningState is to indicate states for resource provisioning. </param>
        /// <param name="hbiWorkspace"> The flag to signal HBI data in the workspace and reduce diagnostic data collected by the service. </param>
        /// <param name="serviceProvisionedResourceGroup"> The name of the managed resource group created by workspace RP in customer subscription if the workspace is CMK workspace. </param>
        /// <param name="privateLinkCount"> Count of private connections in the workspace. </param>
        /// <param name="imageBuildCompute"> The compute name for image build. </param>
        /// <param name="allowPublicAccessWhenBehindVnet"> The flag to indicate whether to allow public access when behind VNet. </param>
        /// <param name="primaryUserAssignedIdentity"> The user assigned identity resource id that represents the workspace identity. </param>
        /// <param name="tenantId"> The tenant id associated with this workspace. </param>
        internal WorkspaceData(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, SystemData systemData, string workspaceId, string description, string friendlyName, string keyVault, string applicationInsights, string containerRegistry, string storageAccount, string discoveryUrl, ProvisioningState? provisioningState, bool? hbiWorkspace, string serviceProvisionedResourceGroup, int? privateLinkCount, string imageBuildCompute, bool? allowPublicAccessWhenBehindVnet, string primaryUserAssignedIdentity, string tenantId) : base(id, name, type, tags, location)
        {
            SystemData = systemData;
            WorkspaceId = workspaceId;
            Description = description;
            FriendlyName = friendlyName;
            KeyVault = keyVault;
            ApplicationInsights = applicationInsights;
            ContainerRegistry = containerRegistry;
            StorageAccount = storageAccount;
            DiscoveryUrl = discoveryUrl;
            ProvisioningState = provisioningState;
            HbiWorkspace = hbiWorkspace;
            ServiceProvisionedResourceGroup = serviceProvisionedResourceGroup;
            PrivateLinkCount = privateLinkCount;
            ImageBuildCompute = imageBuildCompute;
            AllowPublicAccessWhenBehindVnet = allowPublicAccessWhenBehindVnet;
            PrimaryUserAssignedIdentity = primaryUserAssignedIdentity;
            TenantId = tenantId;
        }

        /// <summary> Metadata pertaining to creation and last modification of the resource. </summary>
        public SystemData SystemData { get; }
        /// <summary> The immutable id associated with this workspace. </summary>
        public string WorkspaceId { get; }
        /// <summary> The description of this workspace. </summary>
        public string Description { get; set; }
        /// <summary> The friendly name for this workspace. This name in mutable. </summary>
        public string FriendlyName { get; set; }
        /// <summary> ARM id of the key vault associated with this workspace. This cannot be changed once the workspace has been created. </summary>
        public string KeyVault { get; set; }
        /// <summary> ARM id of the application insights associated with this workspace. This cannot be changed once the workspace has been created. </summary>
        public string ApplicationInsights { get; set; }
        /// <summary> ARM id of the container registry associated with this workspace. This cannot be changed once the workspace has been created. </summary>
        public string ContainerRegistry { get; set; }
        /// <summary> ARM id of the storage account associated with this workspace. This cannot be changed once the workspace has been created. </summary>
        public string StorageAccount { get; set; }
        /// <summary> Url for the discovery service to identify regional endpoints for machine learning experimentation services. </summary>
        public string DiscoveryUrl { get; set; }
        /// <summary> The current deployment state of workspace resource. The provisioningState is to indicate states for resource provisioning. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> The flag to signal HBI data in the workspace and reduce diagnostic data collected by the service. </summary>
        public bool? HbiWorkspace { get; set; }
        /// <summary> The name of the managed resource group created by workspace RP in customer subscription if the workspace is CMK workspace. </summary>
        public string ServiceProvisionedResourceGroup { get; }
        /// <summary> Count of private connections in the workspace. </summary>
        public int? PrivateLinkCount { get; }
        /// <summary> The compute name for image build. </summary>
        public string ImageBuildCompute { get; set; }
        /// <summary> The flag to indicate whether to allow public access when behind VNet. </summary>
        public bool? AllowPublicAccessWhenBehindVnet { get; set; }
        /// <summary> The user assigned identity resource id that represents the workspace identity. </summary>
        public string PrimaryUserAssignedIdentity { get; set; }
        /// <summary> The tenant id associated with this workspace. </summary>
        public string TenantId { get; }
    }
}
