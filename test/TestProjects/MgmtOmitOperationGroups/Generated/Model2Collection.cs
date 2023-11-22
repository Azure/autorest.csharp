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

namespace MgmtOmitOperationGroups
{
    /// <summary>
    /// A class representing a collection of <see cref="Model2Resource"/> and their operations.
    /// Each <see cref="Model2Resource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="Model2Collection"/> instance call the GetModel2s method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class Model2Collection : ArmCollection, IEnumerable<Model2Resource>, IAsyncEnumerable<Model2Resource>
    {
        private readonly ClientDiagnostics _model2ClientDiagnostics;
        private readonly Model2SRestOperations _model2RestClient;

        /// <summary> Initializes a new instance of the <see cref="Model2Collection"/> class for mocking. </summary>
        protected Model2Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Model2Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal Model2Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _model2ClientDiagnostics = new ClientDiagnostics("MgmtOmitOperationGroups", Model2Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(Model2Resource.ResourceType, out string model2ApiVersion);
            _model2RestClient = new Model2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, model2ApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="Model2Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<Model2Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string model2SName, Model2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _model2RestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOmitOperationGroupsArmOperation<Model2Resource>(Response.FromValue(new Model2Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="Model2Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<Model2Resource> CreateOrUpdate(WaitUntil waitUntil, string model2SName, Model2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _model2RestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, model2SName, data, cancellationToken);
                var operation = new MgmtOmitOperationGroupsArmOperation<Model2Resource>(Response.FromValue(new Model2Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual async Task<Response<Model2Resource>> GetAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<Model2Resource> Get(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Model2Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Model2Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _model2RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new Model2Resource(Client, Model2Data.DeserializeModel2Data(e)), _model2ClientDiagnostics, Pipeline, "Model2Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Model2Resource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Model2Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _model2RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new Model2Resource(Client, Model2Data.DeserializeModel2Data(e)), _model2ClientDiagnostics, Pipeline, "Model2Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Exists");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<bool> Exists(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Exists");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual async Task<NullableResponse<Model2Resource>> GetIfExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<Model2Resource>(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model2SName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual NullableResponse<Model2Resource> GetIfExists(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<Model2Resource>(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Model2Resource> IEnumerable<Model2Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Model2Resource> IAsyncEnumerable<Model2Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
