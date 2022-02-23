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
    /// <summary> A class representing collection of SupersetModel6 and their operations over its parent. </summary>
    public partial class SupersetModel6Collection : ArmCollection, IEnumerable<SupersetModel6>, IAsyncEnumerable<SupersetModel6>
    {
        private readonly ClientDiagnostics _supersetModel6ClientDiagnostics;
        private readonly SupersetModel6SRestOperations _supersetModel6RestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6Collection"/> class for mocking. </summary>
        protected SupersetModel6Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupersetModel6Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel6ClientDiagnostics = new ClientDiagnostics("SupersetInheritance", SupersetModel6.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SupersetModel6.ResourceType, out string supersetModel6ApiVersion);
            _supersetModel6RestClient = new SupersetModel6SRestOperations(_supersetModel6ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, supersetModel6ApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel6 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<SupersetModel6>> CreateOrUpdateAsync(bool waitForCompletion, string supersetModel6SName, SupersetModel6Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, parameters, cancellationToken).ConfigureAwait(false);
                return ArmOperationHelpers.FromResponse(new SupersetModel6(Client, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel6 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SupersetModel6> CreateOrUpdate(bool waitForCompletion, string supersetModel6SName, SupersetModel6Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, parameters, cancellationToken);
                return ArmOperationHelpers.FromResponse(new SupersetModel6(Client, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel6>> GetAsync(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _supersetModel6ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual Response<SupersetModel6> Get(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken);
                if (response.Value == null)
                    throw _supersetModel6ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s
        /// Operation Id: SupersetModel6s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel6" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel6> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SupersetModel6>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _supersetModel6RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel6(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s
        /// Operation Id: SupersetModel6s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel6" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel6> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SupersetModel6> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _supersetModel6RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel6(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(supersetModel6SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual Response<bool> Exists(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(supersetModel6SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel6>> GetIfExistsAsync(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel6>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual Response<SupersetModel6> GetIfExists(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel6>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel6> IEnumerable<SupersetModel6>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupersetModel6> IAsyncEnumerable<SupersetModel6>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
