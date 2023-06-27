// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtParamOrderingModelFactory
    {
        /// <summary> Initializes a new instance of AvailabilitySetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.AvailabilitySetData"/> instance for mocking. </returns>
        public static AvailabilitySetData AvailabilitySetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AvailabilitySetData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of DedicatedHostGroupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> specifies the foo. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.DedicatedHostGroupData"/> instance for mocking. </returns>
        public static DedicatedHostGroupData DedicatedHostGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string foo = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DedicatedHostGroupData(id, name, resourceType, systemData, tags, location, foo);
        }

        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> specifies the foo. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.DedicatedHostData"/> instance for mocking. </returns>
        public static DedicatedHostData DedicatedHostData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string foo = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DedicatedHostData(id, name, resourceType, systemData, tags, location, foo);
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionImageData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.VirtualMachineExtensionImageData"/> instance for mocking. </returns>
        public static VirtualMachineExtensionImageData VirtualMachineExtensionImageData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VirtualMachineExtensionImageData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of EnvironmentContainerResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Additional attributes of the entity. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.EnvironmentContainerResourceData"/> instance for mocking. </returns>
        public static EnvironmentContainerResourceData EnvironmentContainerResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, EnvironmentContainer properties = null)
        {
            tags ??= new Dictionary<string, string>();

            return new EnvironmentContainerResourceData(id, name, resourceType, systemData, tags, location, properties);
        }

        /// <summary> Initializes a new instance of WorkspaceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="workspaceId"> The immutable id associated with this workspace. </param>
        /// <param name="description"> The description of this workspace. </param>
        /// <param name="friendlyName"> The friendly name for this workspace. This name in mutable. </param>
        /// <param name="keyVault"> ARM id of the key vault associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="applicationInsights"> ARM id of the application insights associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="containerRegistry"> ARM id of the container registry associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="storageAccount"> ARM id of the storage account associated with this workspace. This cannot be changed once the workspace has been created. </param>
        /// <param name="discoveryUri"> Url for the discovery service to identify regional endpoints for machine learning experimentation services. </param>
        /// <param name="provisioningState"> The current deployment state of workspace resource. The provisioningState is to indicate states for resource provisioning. </param>
        /// <param name="hbiWorkspace"> The flag to signal HBI data in the workspace and reduce diagnostic data collected by the service. </param>
        /// <param name="serviceProvisionedResourceGroup"> The name of the managed resource group created by workspace RP in customer subscription if the workspace is CMK workspace. </param>
        /// <param name="privateLinkCount"> Count of private connections in the workspace. </param>
        /// <param name="imageBuildCompute"> The compute name for image build. </param>
        /// <param name="allowPublicAccessWhenBehindVnet"> The flag to indicate whether to allow public access when behind VNet. </param>
        /// <param name="primaryUserAssignedIdentity"> The user assigned identity resource id that represents the workspace identity. </param>
        /// <param name="tenantId"> The tenant id associated with this workspace. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.WorkspaceData"/> instance for mocking. </returns>
        public static WorkspaceData WorkspaceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string workspaceId = null, string description = null, string friendlyName = null, string keyVault = null, string applicationInsights = null, string containerRegistry = null, string storageAccount = null, Uri discoveryUri = null, ProvisioningState? provisioningState = null, bool? hbiWorkspace = null, string serviceProvisionedResourceGroup = null, int? privateLinkCount = null, string imageBuildCompute = null, bool? allowPublicAccessWhenBehindVnet = null, string primaryUserAssignedIdentity = null, Guid? tenantId = null)
        {
            tags ??= new Dictionary<string, string>();

            return new WorkspaceData(id, name, resourceType, systemData, tags, location, workspaceId, description, friendlyName, keyVault, applicationInsights, containerRegistry, storageAccount, discoveryUri, provisioningState, hbiWorkspace, serviceProvisionedResourceGroup, privateLinkCount, imageBuildCompute, allowPublicAccessWhenBehindVnet, primaryUserAssignedIdentity, tenantId);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </param>
        /// <returns> A new <see cref="MgmtParamOrdering.VirtualMachineScaleSetData"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, IEnumerable<string> zones = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();

            return new VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, zones?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        /// <param name="virtualMachine"> The instance view status summary for the virtual machine scale set. </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetInstanceView VirtualMachineScaleSetInstanceView(string virtualMachine = null)
        {
            return new VirtualMachineScaleSetInstanceView(virtualMachine);
        }
    }
}
