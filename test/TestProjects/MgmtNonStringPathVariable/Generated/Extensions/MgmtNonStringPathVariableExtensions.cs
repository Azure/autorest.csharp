// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtNonStringPathVariable.Models;

namespace MgmtNonStringPathVariable
{
    /// <summary> A class to add extension methods to MgmtNonStringPathVariable. </summary>
    public static partial class MgmtNonStringPathVariableExtensions
    {
        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }
        #region FakeResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeResource.CreateResourceIdentifier" /> to create a <see cref="FakeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeResource" /> object. </returns>
        public static FakeResource GetFakeResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeResource.ValidateResourceId(id);
                return new FakeResource(client, id);
            }
            );
        }
        #endregion

        #region BarResource
        /// <summary>
        /// Gets an object representing a <see cref="BarResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BarResource.CreateResourceIdentifier" /> to create a <see cref="BarResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BarResource" /> object. </returns>
        public static BarResource GetBarResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BarResource.ValidateResourceId(id);
                return new BarResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of FakeResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of FakeResources and their operations over a FakeResource. </returns>
        public static FakeCollection GetFakes(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetFakes();
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static async Task<Response<FakeResource>> GetFakeAsync(this ResourceGroupResource resourceGroupResource, FakeNameAsEnum fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetFakes().GetAsync(fakeName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Response<FakeResource> GetFake(this ResourceGroupResource resourceGroupResource, FakeNameAsEnum fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetFakes().Get(fakeName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of BarResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of BarResources and their operations over a BarResource. </returns>
        public static BarCollection GetBars(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetBars();
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static async Task<Response<BarResource>> GetBarAsync(this ResourceGroupResource resourceGroupResource, int barName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetBars().GetAsync(barName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Response<BarResource> GetBar(this ResourceGroupResource resourceGroupResource, int barName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetBars().Get(barName, cancellationToken);
        }
    }
}
