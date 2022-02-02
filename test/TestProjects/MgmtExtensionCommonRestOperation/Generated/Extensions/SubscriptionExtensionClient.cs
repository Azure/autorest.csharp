// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _typeOneCommonClientDiagnostics;
        private CommonRestOperations _typeOneCommonRestClient;
        private ClientDiagnostics _typeTwoCommonClientDiagnostics;
        private CommonRestOperations _typeTwoCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics TypeOneCommonClientDiagnostics => _typeOneCommonClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeOne.ResourceType.Namespace, DiagnosticOptions);
        private CommonRestOperations TypeOneCommonRestClient => _typeOneCommonRestClient ??= new CommonRestOperations(TypeOneCommonClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(TypeOne.ResourceType));
        private ClientDiagnostics TypeTwoCommonClientDiagnostics => _typeTwoCommonClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeTwo.ResourceType.Namespace, DiagnosticOptions);
        private CommonRestOperations TypeTwoCommonRestClient => _typeTwoCommonRestClient ??= new CommonRestOperations(TypeTwoCommonClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(TypeTwo.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            ArmClient.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Common_ListTypeOnesBySubscription
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeOne> GetTypeOnesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TypeOne>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TypeOneCommonClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeOnes");
                scope.Start();
                try
                {
                    var response = await TypeOneCommonRestClient.ListTypeOnesBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeOne(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Common_ListTypeOnesBySubscription
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeOne> GetTypeOnes(CancellationToken cancellationToken = default)
        {
            Page<TypeOne> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TypeOneCommonClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeOnes");
                scope.Start();
                try
                {
                    var response = TypeOneCommonRestClient.ListTypeOnesBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeOne(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Common_ListTypeTwosBySubscription
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeTwo> GetTypeTwosAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TypeTwo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TypeTwoCommonClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeTwos");
                scope.Start();
                try
                {
                    var response = await TypeTwoCommonRestClient.ListTypeTwosBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeTwo(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Common_ListTypeTwosBySubscription
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeTwo> GetTypeTwos(CancellationToken cancellationToken = default)
        {
            Page<TypeTwo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TypeTwoCommonClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeTwos");
                scope.Start();
                try
                {
                    var response = TypeTwoCommonRestClient.ListTypeTwosBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TypeTwo(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
