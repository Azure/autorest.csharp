// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing a collection of <see cref="ResourceLinkResource" /> and their operations.
    /// Each <see cref="ResourceLinkResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="ResourceLinkCollection" /> instance call the GetResourceLinks method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class ResourceLinkCollection : ArmCollection
    {
        private readonly ClientDiagnostics _resourceLinkClientDiagnostics;
        private readonly ResourceLinksRestOperations _resourceLinkRestClient;
        private readonly string _scope;

        /// <summary> Initializes a new instance of the <see cref="ResourceLinkCollection"/> class for mocking. </summary>
        protected ResourceLinkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceLinkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="scope"> The fully qualified ID of the scope for getting the resource links. For example, to list resource links at and under a resource group, set the scope to /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        internal ResourceLinkCollection(ArmClient client, ResourceIdentifier id, string scope) : base(client, id)
        {
            _scope = scope;
            _resourceLinkClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", ResourceLinkResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceLinkResource.ResourceType, out string resourceLinkApiVersion);
            _resourceLinkRestClient = new ResourceLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resourceLinkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a resource link between the specified resources.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters for creating or updating a resource link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ResourceLinkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, ResourceLinkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.CreateOrUpdateAsync(_scope, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<ResourceLinkResource>(Response.FromValue(new ResourceLinkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a resource link between the specified resources.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters for creating or updating a resource link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ResourceLinkResource> CreateOrUpdate(WaitUntil waitUntil, ResourceLinkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.CreateOrUpdate(_scope, data, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<ResourceLinkResource>(Response.FromValue(new ResourceLinkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a resource link with the specified ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceLinkResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.Get");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.GetAsync(_scope, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a resource link with the specified ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceLinkResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.Get");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.Get(_scope, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceLinkResource> GetAllAsync(Filter? filter = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _resourceLinkRestClient.CreateListAtSourceScopeRequest(_scope, filter);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resourceLinkRestClient.CreateListAtSourceScopeNextPageRequest(nextLink, _scope, filter);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), _resourceLinkClientDiagnostics, Pipeline, "ResourceLinkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceLinkResource> GetAll(Filter? filter = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _resourceLinkRestClient.CreateListAtSourceScopeRequest(_scope, filter);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resourceLinkRestClient.CreateListAtSourceScopeNextPageRequest(nextLink, _scope, filter);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), _resourceLinkClientDiagnostics, Pipeline, "ResourceLinkCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.GetAsync(_scope, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.Get(_scope, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<ResourceLinkResource>> GetIfExistsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resourceLinkRestClient.GetAsync(_scope, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ResourceLinkResource>(response.GetRawResponse());
                return Response.FromValue(new ResourceLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<ResourceLinkResource> GetIfExists(CancellationToken cancellationToken = default)
        {
            using var scope = _resourceLinkClientDiagnostics.CreateScope("ResourceLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resourceLinkRestClient.Get(_scope, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ResourceLinkResource>(response.GetRawResponse());
                return Response.FromValue(new ResourceLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
