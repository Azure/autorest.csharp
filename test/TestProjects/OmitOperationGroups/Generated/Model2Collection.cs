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

namespace OmitOperationGroups
{
    /// <summary> A class representing collection of Model2 and their operations over its parent. </summary>
    public partial class Model2Collection : ArmCollection, IEnumerable<Model2>, IAsyncEnumerable<Model2>
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
            _model2ClientDiagnostics = new ClientDiagnostics("OmitOperationGroups", Model2.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(Model2.ResourceType, out string model2ApiVersion);
            _model2RestClient = new Model2SRestOperations(_model2ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, model2ApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<Model2>> CreateOrUpdateAsync(bool waitForCompletion, string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _model2RestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new OmitOperationGroupsArmOperation<Model2>(Response.FromValue(new Model2(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Model2> CreateOrUpdate(bool waitForCompletion, string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _model2RestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, model2SName, parameters, cancellationToken);
                var operation = new OmitOperationGroupsArmOperation<Model2>(Response.FromValue(new Model2(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual async Task<Response<Model2>> GetAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<Model2> Get(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s
        /// Operation Id: Model2s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Model2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Model2> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Model2>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _model2RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Model2(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s
        /// Operation Id: Model2s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Model2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Model2> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Model2> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _model2RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Model2(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
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
                var response = await GetIfExistsAsync(model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
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
                var response = GetIfExists(model2SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual async Task<Response<Model2>> GetIfExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Model2>(null, response.GetRawResponse());
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<Model2> GetIfExists(string model2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model2SName, nameof(model2SName));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Model2>(null, response.GetRawResponse());
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Model2> IEnumerable<Model2>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Model2> IAsyncEnumerable<Model2>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
