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
using MgmtTypeSpec.Models;

namespace MgmtTypeSpec.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMgmtTypeSpecResourceGroupResource : ArmResource
    {
        private ClientDiagnostics _privateLinksClientDiagnostics;
        private PrivateLinksRestOperations _privateLinksRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtTypeSpecResourceGroupResource"/> class for mocking. </summary>
        protected MockableMgmtTypeSpecResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtTypeSpecResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtTypeSpecResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PrivateLinksClientDiagnostics => _privateLinksClientDiagnostics ??= new ClientDiagnostics("MgmtTypeSpec", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PrivateLinksRestOperations PrivateLinksRestClient => _privateLinksRestClient ??= new PrivateLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of FooResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of FooResources and their operations over a FooResource. </returns>
        public virtual FooCollection GetFoos()
        {
            return GetCachedClient(client => new FooCollection(client, Id));
        }

        /// <summary>
        /// Get.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FooResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fooName"> The name of the Foo. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fooName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FooResource>> GetFooAsync(string fooName, CancellationToken cancellationToken = default)
        {
            return await GetFoos().GetAsync(fooName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FooResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fooName"> The name of the Foo. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fooName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<FooResource> GetFoo(string fooName, CancellationToken cancellationToken = default)
        {
            return GetFoos().Get(fooName, cancellationToken);
        }

        /// <summary>
        /// Get all private link resources.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_GetAllPrivateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtTypeSpecPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtTypeSpecPrivateLinkResourceData> GetAllPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PrivateLinksRestClient.CreateGetAllPrivateLinkResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PrivateLinksRestClient.CreateGetAllPrivateLinkResourcesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => MgmtTypeSpecPrivateLinkResourceData.DeserializeMgmtTypeSpecPrivateLinkResourceData(e), PrivateLinksClientDiagnostics, Pipeline, "MockableMgmtTypeSpecResourceGroupResource.GetAllPrivateLinkResources", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get all private link resources.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PrivateLinkResource_GetAllPrivateLinkResources</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>v1</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtTypeSpecPrivateLinkResourceData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtTypeSpecPrivateLinkResourceData> GetAllPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PrivateLinksRestClient.CreateGetAllPrivateLinkResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PrivateLinksRestClient.CreateGetAllPrivateLinkResourcesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => MgmtTypeSpecPrivateLinkResourceData.DeserializeMgmtTypeSpecPrivateLinkResourceData(e), PrivateLinksClientDiagnostics, Pipeline, "MockableMgmtTypeSpecResourceGroupResource.GetAllPrivateLinkResources", "value", "nextLink", cancellationToken);
        }
    }
}
