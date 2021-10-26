// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of MgmtGrpParentWithLoc and their operations over a ManagementGroup. </summary>
    public partial class MgmtGrpParentWithLocCollection : ArmCollection, IEnumerable<MgmtGrpParentWithLoc>, IAsyncEnumerable<MgmtGrpParentWithLoc>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly MgmtGrpParentWithLocsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of MgmtGrpParentWithLocCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal MgmtGrpParentWithLocCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new MgmtGrpParentWithLocsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        IEnumerator<MgmtGrpParentWithLoc> IEnumerable<MgmtGrpParentWithLoc>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGrpParentWithLoc> IAsyncEnumerable<MgmtGrpParentWithLoc>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ManagementGroup.ResourceType;

        // Collection level operations.

        /// <summary> Create or update. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual MgmtGrpParentWithLocCreateOrUpdateOperation CreateOrUpdate(string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken);
                var operation = new MgmtGrpParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// <summary> Create or update. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<MgmtGrpParentWithLocCreateOrUpdateOperation> CreateOrUpdateAsync(string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtGrpParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<MgmtGrpParentWithLoc> Get(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = _restClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = await _restClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new MgmtGrpParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<MgmtGrpParentWithLoc> GetIfExists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = _restClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new MgmtGrpParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetIfExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = await _restClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new MgmtGrpParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = GetIfExists(mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (mgmtGrpParentWithLocName == null)
                {
                    throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
                }

                var response = await GetIfExistsAsync(mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGrpParentWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGrpParentWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGrpParentWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGrpParentWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        // public ArmBuilder<ResourceIdentifier, MgmtGrpParentWithLoc, MgmtGrpParentWithLocData> Construct() { }
    }
}
