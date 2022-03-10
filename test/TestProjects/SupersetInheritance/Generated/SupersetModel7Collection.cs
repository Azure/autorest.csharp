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

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel7 and their operations over its parent. </summary>
    public partial class SupersetModel7Collection : ArmCollection, IEnumerable<SupersetModel7>, IAsyncEnumerable<SupersetModel7>
    {
        private readonly ClientDiagnostics _supersetModel7ClientDiagnostics;
        private readonly SupersetModel7SRestOperations _supersetModel7RestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel7Collection"/> class for mocking. </summary>
        protected SupersetModel7Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel7Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupersetModel7Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel7ClientDiagnostics = new ClientDiagnostics("SupersetInheritance", SupersetModel7.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SupersetModel7.ResourceType, out string supersetModel7ApiVersion);
            _supersetModel7RestClient = new SupersetModel7SRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, supersetModel7ApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel7 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<SupersetModel7>> CreateOrUpdateAsync(WaitUntil waitUntil, string supersetModel7SName, SupersetModel7Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel7RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SupersetInheritanceArmOperation<SupersetModel7>(Response.FromValue(new SupersetModel7(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel7 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SupersetModel7> CreateOrUpdate(WaitUntil waitUntil, string supersetModel7SName, SupersetModel7Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel7RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, parameters, cancellationToken);
                var operation = new SupersetInheritanceArmOperation<SupersetModel7>(Response.FromValue(new SupersetModel7(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel7>> GetAsync(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel7RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel7(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual Response<SupersetModel7> Get(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel7RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel7(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s
        /// Operation Id: SupersetModel7s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel7" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel7> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SupersetModel7>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _supersetModel7RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel7(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s
        /// Operation Id: SupersetModel7s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel7" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel7> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SupersetModel7> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _supersetModel7RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel7(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(supersetModel7SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual Response<bool> Exists(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(supersetModel7SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel7>> GetIfExistsAsync(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _supersetModel7RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel7>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel7(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel7s/{supersetModel7SName}
        /// Operation Id: SupersetModel7s_Get
        /// </summary>
        /// <param name="supersetModel7SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel7SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel7SName"/> is null. </exception>
        public virtual Response<SupersetModel7> GetIfExists(string supersetModel7SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel7SName, nameof(supersetModel7SName));

            using var scope = _supersetModel7ClientDiagnostics.CreateScope("SupersetModel7Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _supersetModel7RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel7SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel7>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel7(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel7> IEnumerable<SupersetModel7>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupersetModel7> IAsyncEnumerable<SupersetModel7>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
