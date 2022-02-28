// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of ResourceModel1 and their operations over its parent. </summary>
    public partial class ResourceModel1Collection : ArmCollection, IEnumerable<ResourceModel1>, IAsyncEnumerable<ResourceModel1>
    {
        private readonly ClientDiagnostics _resourceModel1ClientDiagnostics;
        private readonly ResourceModel1SRestOperations _resourceModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceModel1Collection"/> class for mocking. </summary>
        protected ResourceModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResourceModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resourceModel1ClientDiagnostics = new ClientDiagnostics("SupersetFlattenInheritance", ResourceModel1.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceModel1.ResourceType, out string resourceModel1ApiVersion);
            _resourceModel1RestClient = new ResourceModel1SRestOperations(_resourceModel1ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resourceModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ResourceModel1>> CreateOrUpdateAsync(bool waitForCompletion, string resourceModel1SName, ResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resourceModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SupersetFlattenInheritanceArmOperation<ResourceModel1>(Response.FromValue(new ResourceModel1(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ResourceModel1> CreateOrUpdate(bool waitForCompletion, string resourceModel1SName, ResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resourceModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, parameters, cancellationToken);
                var operation = new SupersetFlattenInheritanceArmOperation<ResourceModel1>(Response.FromValue(new ResourceModel1(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual async Task<Response<ResourceModel1>> GetAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _resourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceModel1(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<ResourceModel1> Get(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _resourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceModel1(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s
        /// Operation Id: ResourceModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceModel1> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceModel1>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resourceModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceModel1(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s
        /// Operation Id: ResourceModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceModel1> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResourceModel1> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _resourceModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceModel1(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resourceModel1SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual async Task<Response<ResourceModel1>> GetIfExistsAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resourceModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResourceModel1>(null, response.GetRawResponse());
                return Response.FromValue(new ResourceModel1(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1SName}
        /// Operation Id: ResourceModel1s_Get
        /// </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<ResourceModel1> GetIfExists(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceModel1SName, nameof(resourceModel1SName));

            using var scope = _resourceModel1ClientDiagnostics.CreateScope("ResourceModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resourceModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResourceModel1>(null, response.GetRawResponse());
                return Response.FromValue(new ResourceModel1(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResourceModel1> IEnumerable<ResourceModel1>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResourceModel1> IAsyncEnumerable<ResourceModel1>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
