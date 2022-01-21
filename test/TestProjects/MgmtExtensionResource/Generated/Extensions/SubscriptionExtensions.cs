// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Resources;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        #region SubscriptionPolicyDefinition
        /// <summary> Gets an object representing a SubscriptionPolicyDefinitionCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="SubscriptionPolicyDefinitionCollection" /> object. </returns>
        public static SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions(this Subscription subscription)
        {
            return new SubscriptionPolicyDefinitionCollection(subscription);
        }
        #endregion

        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((armClient) =>
            {
                return new SubscriptionExtensionClient(armClient, subscription.Id);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: OrphanedPost_ValidateSomething
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="validateSomethingOptions"/> is null. </exception>
        public static async Task<Response> ValidateSomethingOrphanedPostAsync(this Subscription subscription, ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(subscription).ValidateSomethingOrphanedPostAsync(validateSomethingOptions, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: OrphanedPost_ValidateSomething
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="validateSomethingOptions"/> is null. </exception>
        public static Response ValidateSomethingOrphanedPost(this Subscription subscription, ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).ValidateSomethingOrphanedPost(validateSomethingOptions, cancellationToken);
        }
    }
}
