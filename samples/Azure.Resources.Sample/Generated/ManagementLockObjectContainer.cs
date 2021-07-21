// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.Resources.Sample
{
    /// <summary> A class representing collection of ManagementLockObject and their operations over a Tenant. </summary>
    public partial class ManagementLockObjectContainer : ResourceContainerBase<TenantResourceIdentifier, ManagementLockObject, ManagementLockObjectData>
    {
        /// <summary> Initializes a new instance of the <see cref="ManagementLockObjectContainer"/> class for mocking. </summary>
        protected ManagementLockObjectContainer()
        {
        }

        /// <summary> Initializes a new instance of ManagementLockObjectContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ManagementLockObjectContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        /// <summary> Verify that the input resource Id is a valid container for this type. </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        protected override void Validate(ResourceIdentifier identifier)
        {
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ManagementLocksRestOperations _restClient => new ManagementLocksRestOperations(_clientDiagnostics, Pipeline, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new TenantResourceIdentifier Id => base.Id as TenantResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        // Container level operations.

        /// <summary> Create or update a management lock by scope. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ManagementLockObject> CreateOrUpdate(string lockName, ManagementLockObjectData parameters, CancellationToken cancellationToken = default)
        {
            if (lockName == null)
            {
                throw new ArgumentNullException(nameof(lockName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(lockName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a management lock by scope. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ManagementLockObject>> CreateOrUpdateAsync(string lockName, ManagementLockObjectData parameters, CancellationToken cancellationToken = default)
        {
            if (lockName == null)
            {
                throw new ArgumentNullException(nameof(lockName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(lockName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a management lock by scope. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ManagementLocksCreateOrUpdateByScopeOperation StartCreateOrUpdate(string lockName, ManagementLockObjectData parameters, CancellationToken cancellationToken = default)
        {
            if (lockName == null)
            {
                throw new ArgumentNullException(nameof(lockName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdateByScope(Id, lockName, parameters, cancellationToken);
                return new ManagementLocksCreateOrUpdateByScopeOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a management lock by scope. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ManagementLocksCreateOrUpdateByScopeOperation> StartCreateOrUpdateAsync(string lockName, ManagementLockObjectData parameters, CancellationToken cancellationToken = default)
        {
            if (lockName == null)
            {
                throw new ArgumentNullException(nameof(lockName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateByScopeAsync(Id, lockName, parameters, cancellationToken).ConfigureAwait(false);
                return new ManagementLocksCreateOrUpdateByScopeOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ManagementLockObject> Get(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.Get");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                var response = _restClient.GetByScope(Id, lockName, cancellationToken: cancellationToken);
                return Response.FromValue(new ManagementLockObject(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ManagementLockObject>> GetAsync(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.Get");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                var response = await _restClient.GetByScopeAsync(Id, lockName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ManagementLockObject(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ManagementLockObject TryGet(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.TryGet");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                return Get(lockName, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ManagementLockObject> TryGetAsync(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.TryGet");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                return await GetAsync(lockName, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.DoesExist");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                return TryGet(lockName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string lockName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.DoesExist");
            scope.Start();
            try
            {
                if (lockName == null)
                {
                    throw new ArgumentNullException(nameof(lockName));
                }

                return await TryGetAsync(lockName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List resources at the specified scope. </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagementLockObject" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ManagementLockObject> List(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagementLockObject> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByScope(Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockObject(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagementLockObject> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByScopeNextPage(nextLink, Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockObject(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List resources at the specified scope. </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagementLockObject" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ManagementLockObject> ListAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagementLockObject>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.ListAsync");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByScopeAsync(Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockObject(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagementLockObject>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ManagementLockObjectContainer.ListAsync");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByScopeNextPageAsync(nextLink, Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockObject(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        // public ArmBuilder<TenantResourceIdentifier, ManagementLockObject, ManagementLockObjectData> Construct() { }
    }
}
