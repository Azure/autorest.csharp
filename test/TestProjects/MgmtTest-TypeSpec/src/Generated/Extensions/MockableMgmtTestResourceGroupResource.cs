// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtTest.Models;

namespace MgmtTest.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMgmtTestResourceGroupResource : ArmResource
    {
        private ClientDiagnostics _privateLinksClientDiagnostics;
        private PrivateLinksRestOperations _privateLinksRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtTestResourceGroupResource"/> class for mocking. </summary>
        protected MockableMgmtTestResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtTestResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtTestResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PrivateLinksClientDiagnostics => _privateLinksClientDiagnostics ??= new ClientDiagnostics("MgmtTest", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PrivateLinksRestOperations PrivateLinksRestClient => _privateLinksRestClient ??= new PrivateLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of PrivateEndpointConnectionResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PrivateEndpointConnectionResources and their operations over a PrivateEndpointConnectionResource. </returns>
        public virtual PrivateEndpointConnectionResourceCollection GetPrivateEndpointConnectionResources()
        {
            return GetCachedClient(client => new PrivateEndpointConnectionResourceCollection(client, Id));
        }

        /// <summary>
        /// Get a specific private connection
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtTest/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateEndpointConnections_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PrivateEndpointConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return await GetPrivateEndpointConnectionResources().GetAsync(privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a specific private connection
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtTest/privateEndpointConnections/{privateEndpointConnectionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateEndpointConnections_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PrivateEndpointConnectionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<PrivateEndpointConnectionResource> GetPrivateEndpointConnectionResource(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetPrivateEndpointConnectionResources().Get(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtTest/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_ListByMongoCluster</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtTestPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtTestPrivateLinkResourceData> GetPrivateLinksByMongoClusterAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PrivateLinksRestClient.CreateListByMongoClusterRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PrivateLinksRestClient.CreateListByMongoClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => MgmtTestPrivateLinkResourceData.DeserializeMgmtTestPrivateLinkResourceData(e), PrivateLinksClientDiagnostics, Pipeline, "MockableMgmtTestResourceGroupResource.GetPrivateLinksByMongoCluster", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// list private links on the given resource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtTest/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_ListByMongoCluster</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtTestPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtTestPrivateLinkResourceData> GetPrivateLinksByMongoCluster(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PrivateLinksRestClient.CreateListByMongoClusterRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PrivateLinksRestClient.CreateListByMongoClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => MgmtTestPrivateLinkResourceData.DeserializeMgmtTestPrivateLinkResourceData(e), PrivateLinksClientDiagnostics, Pipeline, "MockableMgmtTestResourceGroupResource.GetPrivateLinksByMongoCluster", "value", "nextLink", cancellationToken);
        }
    }
}
