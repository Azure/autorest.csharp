// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtParamOrdering.Mocking;
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    /// <summary> A class to add extension methods to MgmtParamOrdering. </summary>
    public static partial class MgmtParamOrderingExtensions
    {
        private static MockableMgmtParamOrderingArmClient GetMockableMgmtParamOrderingArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtParamOrderingArmClient(client0));
        }

        private static MockableMgmtParamOrderingResourceGroupResource GetMockableMgmtParamOrderingResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtParamOrderingResourceGroupResource(client, resource.Id));
        }

        private static MockableMgmtParamOrderingSubscriptionResource GetMockableMgmtParamOrderingSubscriptionResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtParamOrderingSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetAvailabilitySetResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetResource" /> object. </returns>
        public static AvailabilitySetResource GetAvailabilitySetResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetAvailabilitySetResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostGroupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostGroupResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostGroupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetDedicatedHostGroupResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostGroupResource" /> object. </returns>
        public static DedicatedHostGroupResource GetDedicatedHostGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetDedicatedHostGroupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetDedicatedHostResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostResource" /> object. </returns>
        public static DedicatedHostResource GetDedicatedHostResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetDedicatedHostResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionImageResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetVirtualMachineExtensionImageResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionImageResource" /> object. </returns>
        public static VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetVirtualMachineExtensionImageResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="EnvironmentContainerResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="EnvironmentContainerResource.CreateResourceIdentifier" /> to create an <see cref="EnvironmentContainerResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetEnvironmentContainerResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="EnvironmentContainerResource" /> object. </returns>
        public static EnvironmentContainerResource GetEnvironmentContainerResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetEnvironmentContainerResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="WorkspaceResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="WorkspaceResource.CreateResourceIdentifier" /> to create a <see cref="WorkspaceResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetWorkspaceResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="WorkspaceResource" /> object. </returns>
        public static WorkspaceResource GetWorkspaceResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetWorkspaceResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingArmClient.GetVirtualMachineScaleSetResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetResource" /> object. </returns>
        public static VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtParamOrderingArmClient(client).GetVirtualMachineScaleSetResource(id);
        }

        /// <summary>
        /// Gets a collection of AvailabilitySetResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetAvailabilitySets()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of AvailabilitySetResources and their operations over a AvailabilitySetResource. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetAvailabilitySets();
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetAvailabilitySetAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<AvailabilitySetResource>> GetAvailabilitySetAsync(this ResourceGroupResource resourceGroupResource, string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetAvailabilitySetAsync(availabilitySetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetAvailabilitySet(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<AvailabilitySetResource> GetAvailabilitySet(this ResourceGroupResource resourceGroupResource, string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetAvailabilitySet(availabilitySetName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of DedicatedHostGroupResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetDedicatedHostGroups()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DedicatedHostGroupResources and their operations over a DedicatedHostGroupResource. </returns>
        public static DedicatedHostGroupCollection GetDedicatedHostGroups(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetDedicatedHostGroups();
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetDedicatedHostGroupAsync(string,InstanceViewType?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. The response shows the list of instance view of the dedicated hosts under the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(this ResourceGroupResource resourceGroupResource, string hostGroupName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetDedicatedHostGroupAsync(hostGroupName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetDedicatedHostGroup(string,InstanceViewType?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. The response shows the list of instance view of the dedicated hosts under the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<DedicatedHostGroupResource> GetDedicatedHostGroup(this ResourceGroupResource resourceGroupResource, string hostGroupName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetDedicatedHostGroup(hostGroupName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of WorkspaceResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetWorkspaces()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of WorkspaceResources and their operations over a WorkspaceResource. </returns>
        public static WorkspaceCollection GetWorkspaces(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetWorkspaces();
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workspaces_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetWorkspaceAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<WorkspaceResource>> GetWorkspaceAsync(this ResourceGroupResource resourceGroupResource, string workspaceName, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetWorkspaceAsync(workspaceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the properties of the specified machine learning workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workspaces_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetWorkspace(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="workspaceName"> Name of Azure Machine Learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<WorkspaceResource> GetWorkspace(this ResourceGroupResource resourceGroupResource, string workspaceName, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetWorkspace(workspaceName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of VirtualMachineScaleSetResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetVirtualMachineScaleSets()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VirtualMachineScaleSetResources and their operations over a VirtualMachineScaleSetResource. </returns>
        public static VirtualMachineScaleSetCollection GetVirtualMachineScaleSets(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetVirtualMachineScaleSets();
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetVirtualMachineScaleSetAsync(string,ExpandTypesForGetVMScaleSet?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. 'UserData' retrieves the UserData property of the VM scale set that was provided by the user during the VM scale set Create/Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(this ResourceGroupResource resourceGroupResource, string vmScaleSetName, ExpandTypesForGetVMScaleSet? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetVirtualMachineScaleSetAsync(vmScaleSetName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingResourceGroupResource.GetVirtualMachineScaleSet(string,ExpandTypesForGetVMScaleSet?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. 'UserData' retrieves the UserData property of the VM scale set that was provided by the user during the VM scale set Create/Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(this ResourceGroupResource resourceGroupResource, string vmScaleSetName, ExpandTypesForGetVMScaleSet? expand = null, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingResourceGroupResource(resourceGroupResource).GetVirtualMachineScaleSet(vmScaleSetName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingSubscriptionResource.GetVirtualMachineExtensionImages(AzureLocation,string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName)
        {
            return GetMockableMgmtParamOrderingSubscriptionResource(subscriptionResource).GetVirtualMachineExtensionImages(location, publisherName);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingSubscriptionResource.GetVirtualMachineExtensionImageAsync(AzureLocation,string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtParamOrderingSubscriptionResource(subscriptionResource).GetVirtualMachineExtensionImageAsync(location, publisherName, type, version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingSubscriptionResource.GetVirtualMachineExtensionImage(AzureLocation,string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingSubscriptionResource(subscriptionResource).GetVirtualMachineExtensionImage(location, publisherName, type, version, cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingSubscriptionResource.GetAvailabilitySets(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AvailabilitySetResource> GetAvailabilitySetsAsync(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingSubscriptionResource(subscriptionResource).GetAvailabilitySetsAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtParamOrderingSubscriptionResource.GetAvailabilitySets(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AvailabilitySetResource> GetAvailabilitySets(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtParamOrderingSubscriptionResource(subscriptionResource).GetAvailabilitySets(expand, cancellationToken);
        }
    }
}
