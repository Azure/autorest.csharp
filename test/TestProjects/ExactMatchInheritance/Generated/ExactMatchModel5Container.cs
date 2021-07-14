// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel5 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel5Container : ResourceContainerBase<ResourceGroupResourceIdentifier, ExactMatchModel5, ExactMatchModel5Data>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Container"/> class for mocking. </summary>
        protected ExactMatchModel5Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel5Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel5Container(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel5SRestOperations _restClient => new ExactMatchModel5SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel5> CreateOrUpdate(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(exactMatchModel5SName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel5>> CreateOrUpdateAsync(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(exactMatchModel5SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ExactMatchModel5SPutOperation StartCreateOrUpdate(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken: cancellationToken);
                return new ExactMatchModel5SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ExactMatchModel5SPutOperation> StartCreateOrUpdateAsync(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel5SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel5> Get(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken);
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel5>> GetAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ExactMatchModel5 TryGet(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.TryGet");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                return Get(exactMatchModel5SName, cancellationToken: cancellationToken).Value;
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
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ExactMatchModel5> TryGetAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.TryGet");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                return await GetAsync(exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.DoesExist");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                return TryGet(exactMatchModel5SName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.DoesExist");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                return await TryGetAsync(exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel5 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel5 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, ExactMatchModel5, ExactMatchModel5Data> Construct() { }
    }
}
