// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing a collection of <see cref="ProviderOperationResource" /> and their operations.
    /// Each <see cref="ProviderOperationResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="ProviderOperationCollection" /> instance call the GetProviderOperations method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class ProviderOperationCollection : ArmCollection, IEnumerable<ProviderOperationResource>, IAsyncEnumerable<ProviderOperationResource>
    {
        private readonly ClientDiagnostics _providerOperationClientDiagnostics;
        private readonly ProviderRestOperations _providerOperationRestClient;

        /// <summary> Initializes a new instance of the <see cref="ProviderOperationCollection"/> class for mocking. </summary>
        protected ProviderOperationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ProviderOperationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ProviderOperationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _providerOperationClientDiagnostics = new ClientDiagnostics("MgmtResourceName", ProviderOperationResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ProviderOperationResource.ResourceType, out string providerOperationApiVersion);
            _providerOperationRestClient = new ProviderRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, providerOperationApiVersion);
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
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual async Task<Response<ProviderOperationResource>> GetAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationCollection.Get");
            scope.Start();
            try
            {
                var response = await _providerOperationRestClient.GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProviderOperationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<ProviderOperationResource> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationCollection.Get");
            scope.Start();
            try
            {
                var response = _providerOperationRestClient.Get(resourceProviderNamespace, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProviderOperationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets provider operations metadata for all resource providers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProviderOperationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProviderOperationResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _providerOperationRestClient.CreateListRequest(expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _providerOperationRestClient.CreateListNextPageRequest(nextLink, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ProviderOperationResource(Client, ProviderOperationData.DeserializeProviderOperationData(e)), _providerOperationClientDiagnostics, Pipeline, "ProviderOperationCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets provider operations metadata for all resource providers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProviderOperationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProviderOperationResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _providerOperationRestClient.CreateListRequest(expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _providerOperationRestClient.CreateListNextPageRequest(nextLink, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ProviderOperationResource(Client, ProviderOperationData.DeserializeProviderOperationData(e)), _providerOperationClientDiagnostics, Pipeline, "ProviderOperationCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationCollection.Exists");
            scope.Start();
            try
            {
                var response = await _providerOperationRestClient.GetAsync(resourceProviderNamespace, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationCollection.Exists");
            scope.Start();
            try
            {
                var response = _providerOperationRestClient.Get(resourceProviderNamespace, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ProviderOperationResource> IEnumerable<ProviderOperationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ProviderOperationResource> IAsyncEnumerable<ProviderOperationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
