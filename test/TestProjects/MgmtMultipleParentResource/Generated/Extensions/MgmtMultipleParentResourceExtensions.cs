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
using MgmtMultipleParentResource.Mocking;

namespace MgmtMultipleParentResource
{
    /// <summary> A class to add extension methods to MgmtMultipleParentResource. </summary>
    public static partial class MgmtMultipleParentResourceExtensions
    {
        private static MockableMgmtMultipleParentResourceArmClient GetMockableMgmtMultipleParentResourceArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtMultipleParentResourceArmClient(client0));
        }

        private static MockableMgmtMultipleParentResourceResourceGroupResource GetMockableMgmtMultipleParentResourceResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtMultipleParentResourceResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing an <see cref="AnotherParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AnotherParentResource.CreateResourceIdentifier" /> to create an <see cref="AnotherParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceArmClient.GetAnotherParentResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AnotherParentResource" /> object. </returns>
        public static AnotherParentResource GetAnotherParentResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtMultipleParentResourceArmClient(client).GetAnotherParentResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="AnotherParentChildResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AnotherParentChildResource.CreateResourceIdentifier" /> to create an <see cref="AnotherParentChildResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceArmClient.GetAnotherParentChildResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="AnotherParentChildResource" /> object. </returns>
        public static AnotherParentChildResource GetAnotherParentChildResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtMultipleParentResourceArmClient(client).GetAnotherParentChildResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TheParentSubParentChildResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TheParentSubParentChildResource.CreateResourceIdentifier" /> to create a <see cref="TheParentSubParentChildResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceArmClient.GetTheParentSubParentChildResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TheParentSubParentChildResource" /> object. </returns>
        public static TheParentSubParentChildResource GetTheParentSubParentChildResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtMultipleParentResourceArmClient(client).GetTheParentSubParentChildResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TheParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TheParentResource.CreateResourceIdentifier" /> to create a <see cref="TheParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceArmClient.GetTheParentResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TheParentResource" /> object. </returns>
        public static TheParentResource GetTheParentResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtMultipleParentResourceArmClient(client).GetTheParentResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SubParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubParentResource.CreateResourceIdentifier" /> to create a <see cref="SubParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceArmClient.GetSubParentResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SubParentResource" /> object. </returns>
        public static SubParentResource GetSubParentResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtMultipleParentResourceArmClient(client).GetSubParentResource(id);
        }

        /// <summary>
        /// Gets a collection of AnotherParentResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetAnotherParents()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of AnotherParentResources and their operations over a AnotherParentResource. </returns>
        public static AnotherParentCollection GetAnotherParents(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetAnotherParents();
        }

        /// <summary>
        /// The operation to get the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetAnotherParentAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="anotherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<AnotherParentResource>> GetAnotherParentAsync(this ResourceGroupResource resourceGroupResource, string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetAnotherParentAsync(anotherName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to get the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetAnotherParent(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="anotherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<AnotherParentResource> GetAnotherParent(this ResourceGroupResource resourceGroupResource, string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetAnotherParent(anotherName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of TheParentResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetTheParents()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of TheParentResources and their operations over a TheParentResource. </returns>
        public static TheParentCollection GetTheParents(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetTheParents();
        }

        /// <summary>
        /// The operation to get the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetTheParentAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="theParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<TheParentResource>> GetTheParentAsync(this ResourceGroupResource resourceGroupResource, string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetTheParentAsync(theParentName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to get the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtMultipleParentResourceResourceGroupResource.GetTheParent(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="theParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<TheParentResource> GetTheParent(this ResourceGroupResource resourceGroupResource, string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtMultipleParentResourceResourceGroupResource(resourceGroupResource).GetTheParent(theParentName, expand, cancellationToken);
        }
    }
}
