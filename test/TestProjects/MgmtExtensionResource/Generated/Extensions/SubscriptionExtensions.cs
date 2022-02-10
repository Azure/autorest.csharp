// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
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

        /// <summary> Gets an object representing a SubSingleton along with the instance operations that can be performed on it in the SubscriptionExtensions. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="SubSingleton" /> object. </returns>
        public static SubSingleton GetSubSingleton(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubSingleton();
        }

        /// <summary> Gets a collection of SubscriptionPolicyDefinitions in the SubscriptionPolicyDefinition. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubscriptionPolicyDefinitions and their operations over a SubscriptionPolicyDefinition. </returns>
        public static SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions(this Subscription subscription)
        {
            return GetExtensionClient(subscription).GetSubscriptionPolicyDefinitions();
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: CheckDnsNameAvailability
        /// <summary> Checks whether a domain name in the cloudapp.azure.com zone is available for use. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="domainNameLabel"/> is null. </exception>
        public async static Task<Response<DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(this Subscription subscription, string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            if (domainNameLabel == null)
            {
                throw new ArgumentNullException(nameof(domainNameLabel));
            }

            return await GetExtensionClient(subscription).CheckDnsNameAvailabilityAsync(location, domainNameLabel, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: CheckDnsNameAvailability
        /// <summary> Checks whether a domain name in the cloudapp.azure.com zone is available for use. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="domainNameLabel"/> is null. </exception>
        public static Response<DnsNameAvailabilityResult> CheckDnsNameAvailability(this Subscription subscription, string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            if (domainNameLabel == null)
            {
                throw new ArgumentNullException(nameof(domainNameLabel));
            }

            return GetExtensionClient(subscription).CheckDnsNameAvailability(location, domainNameLabel, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: OrphanedPost_ValidateSomething
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validateSomethingOptions"/> is null. </exception>
        public async static Task<Response> ValidateSomethingOrphanedPostAsync(this Subscription subscription, ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            if (validateSomethingOptions == null)
            {
                throw new ArgumentNullException(nameof(validateSomethingOptions));
            }

            return await GetExtensionClient(subscription).ValidateSomethingOrphanedPostAsync(validateSomethingOptions, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: OrphanedPost_ValidateSomething
        /// <summary> Description for Validate information for a certificate order. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validateSomethingOptions"/> is null. </exception>
        public static Response ValidateSomethingOrphanedPost(this Subscription subscription, ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            if (validateSomethingOptions == null)
            {
                throw new ArgumentNullException(nameof(validateSomethingOptions));
            }

            return GetExtensionClient(subscription).ValidateSomethingOrphanedPost(validateSomethingOptions, cancellationToken);
        }
    }
}
