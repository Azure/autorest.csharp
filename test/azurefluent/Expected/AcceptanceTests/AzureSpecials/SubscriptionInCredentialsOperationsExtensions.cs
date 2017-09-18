// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureSpecials
{
    using Fixtures.Azure;
    using Fixtures.Azure.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for SubscriptionInCredentialsOperations.
    /// </summary>
    public static partial class SubscriptionInCredentialsOperationsExtensions
    {
            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostMethodGlobalValid(this ISubscriptionInCredentialsOperations operations)
            {
                operations.PostMethodGlobalValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostMethodGlobalValidAsync(this ISubscriptionInCredentialsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostMethodGlobalValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to null, and client-side validation should prevent you from
            /// making this call
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostMethodGlobalNull(this ISubscriptionInCredentialsOperations operations)
            {
                operations.PostMethodGlobalNullAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to null, and client-side validation should prevent you from
            /// making this call
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostMethodGlobalNullAsync(this ISubscriptionInCredentialsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostMethodGlobalNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostMethodGlobalNotProvidedValid(this ISubscriptionInCredentialsOperations operations)
            {
                operations.PostMethodGlobalNotProvidedValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostMethodGlobalNotProvidedValidAsync(this ISubscriptionInCredentialsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostMethodGlobalNotProvidedValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostPathGlobalValid(this ISubscriptionInCredentialsOperations operations)
            {
                operations.PostPathGlobalValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostPathGlobalValidAsync(this ISubscriptionInCredentialsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostPathGlobalValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostSwaggerGlobalValid(this ISubscriptionInCredentialsOperations operations)
            {
                operations.PostSwaggerGlobalValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// POST method with subscriptionId modeled in credentials.  Set the credential
            /// subscriptionId to '1234-5678-9012-3456' to succeed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostSwaggerGlobalValidAsync(this ISubscriptionInCredentialsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostSwaggerGlobalValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
