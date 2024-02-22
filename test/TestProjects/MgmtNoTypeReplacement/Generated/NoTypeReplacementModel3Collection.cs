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

namespace MgmtNoTypeReplacement
{
    /// <summary>
    /// A class representing a collection of <see cref="NoTypeReplacementModel3Resource"/> and their operations.
    /// Each <see cref="NoTypeReplacementModel3Resource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="NoTypeReplacementModel3Collection"/> instance call the GetNoTypeReplacementModel3s method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class NoTypeReplacementModel3Collection : ArmCollection, IEnumerable<NoTypeReplacementModel3Resource>, IAsyncEnumerable<NoTypeReplacementModel3Resource>
    {
        private readonly ClientDiagnostics _noTypeReplacementModel3ClientDiagnostics;
        private readonly NoTypeReplacementModel3SRestOperations _noTypeReplacementModel3RestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel3Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel3Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel3Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NoTypeReplacementModel3Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel3ClientDiagnostics = new ClientDiagnostics("MgmtNoTypeReplacement", NoTypeReplacementModel3Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NoTypeReplacementModel3Resource.ResourceType, out string noTypeReplacementModel3ApiVersion);
            _noTypeReplacementModel3RestClient = new NoTypeReplacementModel3SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, noTypeReplacementModel3ApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="NoTypeReplacementModel3Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NoTypeReplacementModel3Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string noTypeReplacementModel3SName, NoTypeReplacementModel3Data data, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel3RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel3Resource>(Response.FromValue(new NoTypeReplacementModel3Resource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="NoTypeReplacementModel3Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NoTypeReplacementModel3Resource> CreateOrUpdate(WaitUntil waitUntil, string noTypeReplacementModel3SName, NoTypeReplacementModel3Data data, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel3RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, data, cancellationToken);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel3Resource>(Response.FromValue(new NoTypeReplacementModel3Resource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual async Task<Response<NoTypeReplacementModel3Resource>> GetAsync(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel3RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel3Resource> Get(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel3RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NoTypeReplacementModel3Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NoTypeReplacementModel3Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel3RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new NoTypeReplacementModel3Resource(Client, NoTypeReplacementModel3Data.DeserializeNoTypeReplacementModel3Data(e)), _noTypeReplacementModel3ClientDiagnostics, Pipeline, "NoTypeReplacementModel3Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NoTypeReplacementModel3Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NoTypeReplacementModel3Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel3RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new NoTypeReplacementModel3Resource(Client, NoTypeReplacementModel3Data.DeserializeNoTypeReplacementModel3Data(e)), _noTypeReplacementModel3ClientDiagnostics, Pipeline, "NoTypeReplacementModel3Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.Exists");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel3RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.Exists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel3RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual async Task<NullableResponse<NoTypeReplacementModel3Resource>> GetIfExistsAsync(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel3RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<NoTypeReplacementModel3Resource>(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel3s_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NoTypeReplacementModel3Resource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel3SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel3SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel3SName"/> is null. </exception>
        public virtual NullableResponse<NoTypeReplacementModel3Resource> GetIfExists(string noTypeReplacementModel3SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel3SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel3SName));
            }
            if (noTypeReplacementModel3SName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(noTypeReplacementModel3SName));
            }

            using var scope = _noTypeReplacementModel3ClientDiagnostics.CreateScope("NoTypeReplacementModel3Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel3RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel3SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<NoTypeReplacementModel3Resource>(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel3Resource> IEnumerable<NoTypeReplacementModel3Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NoTypeReplacementModel3Resource> IAsyncEnumerable<NoTypeReplacementModel3Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
