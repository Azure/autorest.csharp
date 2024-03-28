// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary>
    /// A class representing a collection of <see cref="TypeOneResource"/> and their operations.
    /// Each <see cref="TypeOneResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="TypeOneCollection"/> instance call the GetTypeOnes method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class TypeOneCollection : ArmCollection, IEnumerable<TypeOneResource>, IAsyncEnumerable<TypeOneResource>
    {
        private readonly ClientDiagnostics _typeOneCommonClientDiagnostics;
        private readonly CommonRestOperations _typeOneCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeOneCollection"/> class for mocking. </summary>
        protected TypeOneCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeOneCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TypeOneCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _typeOneCommonClientDiagnostics = new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeOneResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TypeOneResource.ResourceType, out string typeOneCommonApiVersion);
            _typeOneCommonRestClient = new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, typeOneCommonApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_CreateOrUpdateTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="data"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TypeOneResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string typeOneName, TypeOneData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _typeOneCommonRestClient.CreateOrUpdateTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExtensionCommonRestOperationArmOperation<TypeOneResource>(Response.FromValue(new TypeOneResource(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_CreateOrUpdateTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="data"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TypeOneResource> CreateOrUpdate(WaitUntil waitUntil, string typeOneName, TypeOneData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _typeOneCommonRestClient.CreateOrUpdateTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, data, cancellationToken);
                var operation = new MgmtExtensionCommonRestOperationArmOperation<TypeOneResource>(Response.FromValue(new TypeOneResource(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual async Task<Response<TypeOneResource>> GetAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.Get");
            scope.Start();
            try
            {
                var response = await _typeOneCommonRestClient.GetTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TypeOneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual Response<TypeOneResource> Get(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.Get");
            scope.Start();
            try
            {
                var response = _typeOneCommonRestClient.GetTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TypeOneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnes</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOneResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeOneResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _typeOneCommonRestClient.CreateListTypeOnesRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), _typeOneCommonClientDiagnostics, Pipeline, "TypeOneCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnes</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOneResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeOneResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _typeOneCommonRestClient.CreateListTypeOnesRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), _typeOneCommonClientDiagnostics, Pipeline, "TypeOneCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.Exists");
            scope.Start();
            try
            {
                var response = await _typeOneCommonRestClient.GetTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual Response<bool> Exists(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.Exists");
            scope.Start();
            try
            {
                var response = _typeOneCommonRestClient.GetTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual async Task<NullableResponse<TypeOneResource>> GetIfExistsAsync(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _typeOneCommonRestClient.GetTypeOneAsync(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<TypeOneResource>(response.GetRawResponse());
                return Response.FromValue(new TypeOneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TypeOneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public virtual NullableResponse<TypeOneResource> GetIfExists(string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeOneName, nameof(typeOneName));

            using var scope = _typeOneCommonClientDiagnostics.CreateScope("TypeOneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _typeOneCommonRestClient.GetTypeOne(Id.SubscriptionId, Id.ResourceGroupName, typeOneName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<TypeOneResource>(response.GetRawResponse());
                return Response.FromValue(new TypeOneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TypeOneResource> IEnumerable<TypeOneResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TypeOneResource> IAsyncEnumerable<TypeOneResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}