// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((client) =>
            {
                return new SubscriptionExtensionClient(client, subscription.Id);
            }
            );
        }

        /// <summary> Gets a collection of Fakes in the Fake. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Fakes and their operations over a Fake. </returns>
        public static FakeCollection GetFakes(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetFakes();
        }

        /// <summary> Gets a collection of SubParentWithNonResChWithLocs in the SubParentWithNonResChWithLoc. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithNonResChWithLocs and their operations over a SubParentWithNonResChWithLoc. </returns>
        public static SubParentWithNonResChWithLocCollection GetSubParentWithNonResChWithLocs(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubParentWithNonResChWithLocs();
        }

        /// <summary> Gets a collection of SubParentWithNonResChes in the SubParentWithNonResCh. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithNonResChes and their operations over a SubParentWithNonResCh. </returns>
        public static SubParentWithNonResChCollection GetSubParentWithNonResChes(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubParentWithNonResChes();
        }

        /// <summary> Gets a collection of SubParentWithLocs in the SubParentWithLoc. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithLocs and their operations over a SubParentWithLoc. </returns>
        public static SubParentWithLocCollection GetSubParentWithLocs(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubParentWithLocs();
        }

        /// <summary> Gets a collection of SubParents in the SubParent. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParents and their operations over a SubParent. </returns>
        public static SubParentCollection GetSubParents(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubParents();
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithNonResChWithLoc> GetFakeParentWithAncestorWithNonResourceChWithLocAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithNonResourceChWithLocAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithNonResChWithLoc> GetFakeParentWithAncestorWithNonResourceChWithLoc(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithNonResourceChWithLoc(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocsAsync(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocsAsync(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChes_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithNonResCh> GetFakeParentWithAncestorWithNonResChesAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithNonResChesAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithNonResChes_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithNonResCh> GetFakeParentWithAncestorWithNonResChes(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithNonResChes(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithLoc> GetFakeParentWithAncestorWithLocsAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithLocsAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithLoc> GetFakeParentWithAncestorWithLocs(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithLocs(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithLocs_ListTestByLocations
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithLoc> GetFakeParentWithAncestorWithLocsByLocationAsync(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithLocsByLocationAsync(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestorWithLocs_ListTestByLocations
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithLoc> GetFakeParentWithAncestorWithLocsByLocation(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetFakeParentWithAncestorWithLocsByLocation(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestors_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestor> GetFakeParentWithAncestorsAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestorsAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: FakeParentWithAncestors_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestor> GetFakeParentWithAncestors(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetFakeParentWithAncestors(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetResGrpParentWithAncestorWithNonResChWithLocsAsync(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChWithLocsAsync(expand, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetResGrpParentWithAncestorWithNonResChWithLocs(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChWithLocs(expand, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResCh> GetResGrpParentWithAncestorWithNonResChesAsync(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChesAsync(expand, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_ListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResCh> GetResGrpParentWithAncestorWithNonResChes(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChes(expand, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithLocs_ListTest
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithLoc> GetResGrpParentWithAncestorWithLocsAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithLocsAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithLocs_ListTest
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithLoc> GetResGrpParentWithAncestorWithLocs(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithLocs(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithLocs_ListAll
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLocAsync(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLocAsync(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestorWithLocs_ListAll
        /// <summary> Gets all under the specified subscription for the specified location. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc(this Subscription subscription, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetExtensionClient(subscription).GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc(location, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestors_NonPageableListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestor> GetResGrpParentWithAncestorsAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestorsAsync(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResGrpParentWithAncestors_NonPageableListBySubscription
        /// <summary> Lists all in a subscription. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestor> GetResGrpParentWithAncestors(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetResGrpParentWithAncestors(cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Quotas_Update
        /// <summary> Update quota for each VM family in workspace. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="parameters"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="parameters"/> is null. </exception>
        /// <returns> An async collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<UpdateWorkspaceQuotas> UpdateQuotasAsync(this Subscription subscription, string location, QuotaUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return GetExtensionClient(subscription).UpdateQuotasAsync(location, parameters, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Quotas_Update
        /// <summary> Update quota for each VM family in workspace. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="parameters"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="parameters"/> is null. </exception>
        /// <returns> A collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<UpdateWorkspaceQuotas> UpdateQuotas(this Subscription subscription, string location, QuotaUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return GetExtensionClient(subscription).UpdateQuotas(location, parameters, cancellationToken);
        }
    }
}
