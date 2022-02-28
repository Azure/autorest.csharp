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

namespace MgmtExtensionCommonRestOperation
{
    /// <summary> A class representing collection of TypeTwo and their operations over its parent. </summary>
    public partial class TypeTwoCollection : ArmCollection, IEnumerable<TypeTwo>, IAsyncEnumerable<TypeTwo>
    {
        private readonly ClientDiagnostics _typeTwoCommonClientDiagnostics;
        private readonly CommonRestOperations _typeTwoCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeTwoCollection"/> class for mocking. </summary>
        protected TypeTwoCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeTwoCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TypeTwoCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _typeTwoCommonClientDiagnostics = new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeTwo.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(TypeTwo.ResourceType, out string typeTwoCommonApiVersion);
            _typeTwoCommonRestClient = new CommonRestOperations(_typeTwoCommonClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, typeTwoCommonApiVersion);
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
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_CreateOrUpdateTypeTwo
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="typeTwo"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> or <paramref name="typeTwo"/> is null. </exception>
        public virtual async Task<ArmOperation<TypeTwo>> CreateOrUpdateAsync(bool waitForCompletion, string typeTwoName, TypeTwoData typeTwo, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));
            Argument.AssertNotNull(typeTwo, nameof(typeTwo));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.CreateOrUpdateTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, typeTwo, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExtensionCommonRestOperationArmOperation<TypeTwo>(Response.FromValue(new TypeTwo(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_CreateOrUpdateTypeTwo
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="typeTwo"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> or <paramref name="typeTwo"/> is null. </exception>
        public virtual ArmOperation<TypeTwo> CreateOrUpdate(bool waitForCompletion, string typeTwoName, TypeTwoData typeTwo, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));
            Argument.AssertNotNull(typeTwo, nameof(typeTwo));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.CreateOrUpdateTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, typeTwo, cancellationToken);
                var operation = new MgmtExtensionCommonRestOperationArmOperation<TypeTwo>(Response.FromValue(new TypeTwo(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<Response<TypeTwo>> GetAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Get");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.GetTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TypeTwo(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual Response<TypeTwo> Get(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Get");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.GetTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TypeTwo(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwos
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeTwo> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TypeTwo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _typeTwoCommonRestClient.ListTypeTwosAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeTwo(Client, value)), null, response.GetRawResponse());
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
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwos
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeTwo> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TypeTwo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _typeTwoCommonRestClient.ListTypeTwos(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeTwo(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(typeTwoName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual Response<bool> Exists(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(typeTwoName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<Response<TypeTwo>> GetIfExistsAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.GetTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TypeTwo>(null, response.GetRawResponse());
                return Response.FromValue(new TypeTwo(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual Response<TypeTwo> GetIfExists(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.GetTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TypeTwo>(null, response.GetRawResponse());
                return Response.FromValue(new TypeTwo(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TypeTwo> IEnumerable<TypeTwo>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TypeTwo> IAsyncEnumerable<TypeTwo>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
