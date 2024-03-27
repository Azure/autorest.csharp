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

namespace MgmtLRO.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMgmtLROResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtLROResourceGroupResource"/> class for mocking. </summary>
        protected MockableMgmtLROResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtLROResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtLROResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of FakeResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of FakeResources and their operations over a FakeResource. </returns>
        public virtual FakeCollection GetFakes()
        {
            return GetCachedClient(client => new FakeCollection(client, Id));
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
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeResource>> GetFakeAsync(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetFakes().GetAsync(fakeName, expand, cancellationToken).ConfigureAwait(false);
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
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeResource> GetFake(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetFakes().Get(fakeName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of BarResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of BarResources and their operations over a BarResource. </returns>
        public virtual BarCollection GetBars()
        {
            return GetCachedClient(client => new BarCollection(client, Id));
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
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<BarResource>> GetBarAsync(string barName, CancellationToken cancellationToken = default)
        {
            return await GetBars().GetAsync(barName, cancellationToken).ConfigureAwait(false);
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
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<BarResource> GetBar(string barName, CancellationToken cancellationToken = default)
        {
            return GetBars().Get(barName, cancellationToken);
        }
    }
}
