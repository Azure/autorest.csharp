// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtParent.Models;

namespace MgmtParent
{
    /// <summary> A class representing collection of DedicatedHost and their operations over its parent. </summary>
    public partial class DedicatedHostContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DedicatedHostsRestOperations _dedicatedHostsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DedicatedHostContainer"/> class for mocking. </summary>
        protected DedicatedHostContainer()
        {
        }

        /// <summary> Initializes a new instance of DedicatedHostContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DedicatedHostContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _dedicatedHostsRestClient = new DedicatedHostsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => "Single";

        // Container level operations.

        /// <summary> Create or update a dedicated host . </summary>
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual DedicatedHostCreateOrUpdateOperation CreateOrUpdate(string hostName, DedicatedHostData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(nameof(hostName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _dedicatedHostsRestClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, hostName, parameters, cancellationToken);
                var operation = new DedicatedHostCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _dedicatedHostsRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, hostName, parameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a dedicated host . </summary>
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<DedicatedHostCreateOrUpdateOperation> CreateOrUpdateAsync(string hostName, DedicatedHostData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(nameof(hostName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _dedicatedHostsRestClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, hostName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new DedicatedHostCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _dedicatedHostsRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, hostName, parameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about a dedicated host. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<DedicatedHost> Get(string hostName, CancellationToken cancellationToken = default)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(nameof(hostName));
            }

            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.Get");
            scope.Start();
            try
            {
                var response = _dedicatedHostsRestClient.Get(Id.ResourceGroupName, Id.Name, hostName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DedicatedHost(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about a dedicated host. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<DedicatedHost>> GetAsync(string hostName, CancellationToken cancellationToken = default)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException(nameof(hostName));
            }

            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.Get");
            scope.Start();
            try
            {
                var response = await _dedicatedHostsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, hostName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DedicatedHost(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<DedicatedHost> GetIfExists(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetIfExists");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = _dedicatedHostsRestClient.Get(Id.ResourceGroupName, Id.Name, hostName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<DedicatedHost>(null, response.GetRawResponse())
                    : Response.FromValue(new DedicatedHost(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<DedicatedHost>> GetIfExistsAsync(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = await _dedicatedHostsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, hostName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<DedicatedHost>(null, response.GetRawResponse())
                    : Response.FromValue(new DedicatedHost(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = GetIfExists(hostName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = await GetIfExistsAsync(hostName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all of the dedicated hosts in the specified dedicated host group. Use the nextLink property in the response to get the next page of dedicated hosts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DedicatedHostData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DedicatedHostData> GetAllByHostGroup(CancellationToken cancellationToken = default)
        {
            Page<DedicatedHostData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetAllByHostGroup");
                scope.Start();
                try
                {
                    var response = _dedicatedHostsRestClient.GetAllByHostGroup(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DedicatedHostData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetAllByHostGroup");
                scope.Start();
                try
                {
                    var response = _dedicatedHostsRestClient.GetAllByHostGroupNextPage(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all of the dedicated hosts in the specified dedicated host group. Use the nextLink property in the response to get the next page of dedicated hosts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DedicatedHostData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DedicatedHostData> GetAllByHostGroupAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DedicatedHostData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetAllByHostGroup");
                scope.Start();
                try
                {
                    var response = await _dedicatedHostsRestClient.GetAllByHostGroupAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DedicatedHostData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.GetAllByHostGroup");
                scope.Start();
                try
                {
                    var response = await _dedicatedHostsRestClient.GetAllByHostGroupNextPageAsync(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, DedicatedHost, DedicatedHostData> Construct() { }
    }
}
