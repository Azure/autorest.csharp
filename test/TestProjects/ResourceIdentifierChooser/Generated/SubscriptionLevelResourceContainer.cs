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

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing collection of SubscriptionLevelResource and their operations over a Subscription. </summary>
    public partial class SubscriptionLevelResourceContainer : ResourceContainerBase<SubscriptionResourceIdentifier, SubscriptionLevelResource, SubscriptionLevelResourceData>
    {
        /// <summary> Initializes a new instance of the <see cref="SubscriptionLevelResourceContainer"/> class for mocking. </summary>
        protected SubscriptionLevelResourceContainer()
        {
        }

        /// <summary> Initializes a new instance of SubscriptionLevelResourceContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubscriptionLevelResourceContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private SubscriptionLevelResourcesRestOperations _restClient => new SubscriptionLevelResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new SubscriptionResourceIdentifier Id => base.Id as SubscriptionResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a SubscriptionLevelResource. Please note some properties can be set only during creation. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="parameters"> The SubscriptionLevelResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<SubscriptionLevelResource> CreateOrUpdate(string subscriptionLevelResourcesName, SubscriptionLevelResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(subscriptionLevelResourcesName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SubscriptionLevelResource. Please note some properties can be set only during creation. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="parameters"> The SubscriptionLevelResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<SubscriptionLevelResource>> CreateOrUpdateAsync(string subscriptionLevelResourcesName, SubscriptionLevelResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(subscriptionLevelResourcesName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SubscriptionLevelResource. Please note some properties can be set only during creation. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="parameters"> The SubscriptionLevelResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public SubscriptionLevelResourcesPutOperation StartCreateOrUpdate(string subscriptionLevelResourcesName, SubscriptionLevelResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.Name, subscriptionLevelResourcesName, parameters, cancellationToken: cancellationToken);
                return new SubscriptionLevelResourcesPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a SubscriptionLevelResource. Please note some properties can be set only during creation. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="parameters"> The SubscriptionLevelResource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<SubscriptionLevelResourcesPutOperation> StartCreateOrUpdateAsync(string subscriptionLevelResourcesName, SubscriptionLevelResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.Name, subscriptionLevelResourcesName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new SubscriptionLevelResourcesPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<SubscriptionLevelResource> Get(string subscriptionLevelResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.Get");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }

                var response = _restClient.Get(Id.Name, subscriptionLevelResourcesName, cancellationToken: cancellationToken);
                return Response.FromValue(new SubscriptionLevelResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subscriptionLevelResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<SubscriptionLevelResource>> GetAsync(string subscriptionLevelResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.Get");
            scope.Start();
            try
            {
                if (subscriptionLevelResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionLevelResourcesName));
                }

                var response = await _restClient.GetAsync(Id.Name, subscriptionLevelResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SubscriptionLevelResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SubscriptionLevelResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubscriptionLevelResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SubscriptionLevelResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionLevelResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubscriptionLevelResourceOperations.ResourceType);
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
        // public ArmBuilder<SubscriptionResourceIdentifier, SubscriptionLevelResource, SubscriptionLevelResourceData> Construct() { }
    }
}
