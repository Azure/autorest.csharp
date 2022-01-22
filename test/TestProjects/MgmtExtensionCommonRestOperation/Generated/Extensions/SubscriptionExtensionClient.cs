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
using Azure.ResourceManager.Resources;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary> An internal class to add extension methods to. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _typeOneClientDiagnostics;
        private CommonRestOperations _typeOneRestClient;
        private ClientDiagnostics _typeTwoClientDiagnostics;
        private CommonRestOperations _typeTwoRestClient;

        private static string _defaultRpNamespace = ClientDiagnostics.GetResourceProviderNamespace(typeof(SubscriptionExtensionClient).Assembly);

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
        }

        private ClientDiagnostics TypeOneClientDiagnostics => _typeOneClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeOne.ResourceType.Namespace, DiagnosticOptions);
        private CommonRestOperations TypeOneRestClient => _typeOneRestClient ??= new CommonRestOperations(TypeOneClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(TypeOne.ResourceType));
        private ClientDiagnostics TypeTwoClientDiagnostics => _typeTwoClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionCommonRestOperation", TypeTwo.ResourceType.Namespace, DiagnosticOptions);
        private CommonRestOperations TypeTwoRestClient => _typeTwoRestClient ??= new CommonRestOperations(TypeTwoClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(TypeTwo.ResourceType));

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
                using var scope = TypeOneClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeOnes");
                scope.Start();
                try
                {
                    var response = await TypeOneRestClient.ListTypeOnesBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = TypeOneClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeOnes");
                scope.Start();
                try
                {
                    var response = TypeOneRestClient.ListTypeOnesBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
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

        /// <summary> Filters the list of TypeOnes for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetTypeOnesAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(TypeOne.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of TypeOnes for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetTypeOnesAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(TypeOne.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
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
                using var scope = TypeTwoClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeTwos");
                scope.Start();
                try
                {
                    var response = await TypeTwoRestClient.ListTypeTwosBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = TypeTwoClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTypeTwos");
                scope.Start();
                try
                {
                    var response = TypeTwoRestClient.ListTypeTwosBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
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

        /// <summary> Filters the list of TypeTwos for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetTypeTwosAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(TypeTwo.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of TypeTwos for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetTypeTwosAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(TypeTwo.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }
    }
}
