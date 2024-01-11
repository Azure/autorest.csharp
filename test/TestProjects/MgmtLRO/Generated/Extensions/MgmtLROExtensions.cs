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
using MgmtLRO.Mocking;

namespace MgmtLRO
{
    /// <summary> A class to add extension methods to MgmtLRO. </summary>
    public static partial class MgmtLROExtensions
    {
        private static MockableMgmtLROArmClient GetMockableMgmtLROArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtLROArmClient(client0));
        }

        private static MockableMgmtLROResourceGroupResource GetMockableMgmtLROResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtLROResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="FakeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeResource.CreateResourceIdentifier" /> to create a <see cref="FakeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROArmClient.GetFakeResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="FakeResource"/> object. </returns>
        public static FakeResource GetFakeResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtLROArmClient(client).GetFakeResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="BarResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BarResource.CreateResourceIdentifier" /> to create a <see cref="BarResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROArmClient.GetBarResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="BarResource"/> object. </returns>
        public static BarResource GetBarResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtLROArmClient(client).GetBarResource(id);
        }

        /// <summary>
        /// Gets a collection of FakeResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetFakes()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of FakeResources and their operations over a FakeResource. </returns>
        public static FakeCollection GetFakes(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetFakes();
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetFakeAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FakeResource>> GetFakeAsync(this ResourceGroupResource resourceGroupResource, string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetFakeAsync(fakeName, expand, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetFake(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<FakeResource> GetFake(this ResourceGroupResource resourceGroupResource, string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetFake(fakeName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BarResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetBars()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of BarResources and their operations over a BarResource. </returns>
        public static BarCollection GetBars(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetBars();
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BarResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetBarAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="barName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<BarResource>> GetBarAsync(this ResourceGroupResource resourceGroupResource, string barName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetBarAsync(barName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BarResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtLROResourceGroupResource.GetBar(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="barName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<BarResource> GetBar(this ResourceGroupResource resourceGroupResource, string barName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtLROResourceGroupResource(resourceGroupResource).GetBar(barName, cancellationToken);
        }
    }
}
