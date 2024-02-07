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

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary>
    /// A class representing a collection of <see cref="AzureResourceFlattenModel1Resource"/> and their operations.
    /// Each <see cref="AzureResourceFlattenModel1Resource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get an <see cref="AzureResourceFlattenModel1Collection"/> instance call the GetAzureResourceFlattenModel1s method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class AzureResourceFlattenModel1Collection : ArmCollection, IEnumerable<AzureResourceFlattenModel1Resource>, IAsyncEnumerable<AzureResourceFlattenModel1Resource>
    {
        private readonly ClientDiagnostics _azureResourceFlattenModel1ClientDiagnostics;
        private readonly AzureResourceFlattenModel1SRestOperations _azureResourceFlattenModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="AzureResourceFlattenModel1Collection"/> class for mocking. </summary>
        protected AzureResourceFlattenModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AzureResourceFlattenModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AzureResourceFlattenModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _azureResourceFlattenModel1ClientDiagnostics = new ClientDiagnostics("MgmtExactMatchFlattenInheritance", AzureResourceFlattenModel1Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AzureResourceFlattenModel1Resource.ResourceType, out string azureResourceFlattenModel1ApiVersion);
            _azureResourceFlattenModel1RestClient = new AzureResourceFlattenModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, azureResourceFlattenModel1ApiVersion);
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
        /// Create or update an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="AzureResourceFlattenModel1Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AzureResourceFlattenModel1Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, AzureResourceFlattenModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _azureResourceFlattenModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var uri = _azureResourceFlattenModel1RestClient.CreatePutRequestUri(Id.SubscriptionId, Id.ResourceGroupName, name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtExactMatchFlattenInheritanceArmOperation<AzureResourceFlattenModel1Resource>(Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create or update an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="AzureResourceFlattenModel1Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AzureResourceFlattenModel1Resource> CreateOrUpdate(WaitUntil waitUntil, string name, AzureResourceFlattenModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _azureResourceFlattenModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var uri = _azureResourceFlattenModel1RestClient.CreatePutRequestUri(Id.SubscriptionId, Id.ResourceGroupName, name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtExactMatchFlattenInheritanceArmOperation<AzureResourceFlattenModel1Resource>(Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<AzureResourceFlattenModel1Resource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _azureResourceFlattenModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<AzureResourceFlattenModel1Resource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _azureResourceFlattenModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel1Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AzureResourceFlattenModel1Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _azureResourceFlattenModel1RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new AzureResourceFlattenModel1Resource(Client, AzureResourceFlattenModel1Data.DeserializeAzureResourceFlattenModel1Data(e)), _azureResourceFlattenModel1ClientDiagnostics, Pipeline, "AzureResourceFlattenModel1Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel1.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel1Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AzureResourceFlattenModel1Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _azureResourceFlattenModel1RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new AzureResourceFlattenModel1Resource(Client, AzureResourceFlattenModel1Data.DeserializeAzureResourceFlattenModel1Data(e)), _azureResourceFlattenModel1ClientDiagnostics, Pipeline, "AzureResourceFlattenModel1Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await _azureResourceFlattenModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = _azureResourceFlattenModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<AzureResourceFlattenModel1Resource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _azureResourceFlattenModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<AzureResourceFlattenModel1Resource>(response.GetRawResponse());
                return Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel1s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel1s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AzureResourceFlattenModel1Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<AzureResourceFlattenModel1Resource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _azureResourceFlattenModel1ClientDiagnostics.CreateScope("AzureResourceFlattenModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _azureResourceFlattenModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<AzureResourceFlattenModel1Resource>(response.GetRawResponse());
                return Response.FromValue(new AzureResourceFlattenModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AzureResourceFlattenModel1Resource> IEnumerable<AzureResourceFlattenModel1Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AzureResourceFlattenModel1Resource> IAsyncEnumerable<AzureResourceFlattenModel1Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
