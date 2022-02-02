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
using NoTypeReplacement.Models;

namespace NoTypeReplacement
{
    /// <summary> A class representing collection of NoTypeReplacementModel1 and their operations over its parent. </summary>
    public partial class NoTypeReplacementModel1Collection : ArmCollection, IEnumerable<NoTypeReplacementModel1>, IAsyncEnumerable<NoTypeReplacementModel1>
    {
        private readonly ClientDiagnostics _noTypeReplacementModel1ClientDiagnostics;
        private readonly NoTypeReplacementModel1SRestOperations _noTypeReplacementModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NoTypeReplacementModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel1ClientDiagnostics = new ClientDiagnostics("NoTypeReplacement", NoTypeReplacementModel1.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(NoTypeReplacementModel1.ResourceType, out string noTypeReplacementModel1ApiVersion);
            _noTypeReplacementModel1RestClient = new NoTypeReplacementModel1SRestOperations(_noTypeReplacementModel1ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, noTypeReplacementModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<NoTypeReplacementModel1CreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NoTypeReplacementModel1CreateOrUpdateOperation(ArmClient, response);
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

        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual NoTypeReplacementModel1CreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, parameters, cancellationToken);
                var operation = new NoTypeReplacementModel1CreateOrUpdateOperation(ArmClient, response);
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

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel1>> GetAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _noTypeReplacementModel1ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NoTypeReplacementModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel1> Get(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken);
                if (response.Value == null)
                    throw _noTypeReplacementModel1ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NoTypeReplacementModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NoTypeReplacementModel1> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NoTypeReplacementModel1>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _noTypeReplacementModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NoTypeReplacementModel1(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NoTypeReplacementModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NoTypeReplacementModel1> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NoTypeReplacementModel1> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _noTypeReplacementModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NoTypeReplacementModel1(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(noTypeReplacementModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(noTypeReplacementModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel1>> GetIfExistsAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<NoTypeReplacementModel1>(null, response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel1> GetIfExists(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<NoTypeReplacementModel1>(null, response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel1> IEnumerable<NoTypeReplacementModel1>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NoTypeReplacementModel1> IAsyncEnumerable<NoTypeReplacementModel1>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
