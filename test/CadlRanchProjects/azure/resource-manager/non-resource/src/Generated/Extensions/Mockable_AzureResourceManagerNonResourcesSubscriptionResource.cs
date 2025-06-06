// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using _Azure.ResourceManager.NonResources.Models;

namespace _Azure.ResourceManager.NonResources.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class Mockable_AzureResourceManagerNonResourcesSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _nonResourceOperationsClientDiagnostics;
        private NonResourceRestOperations _nonResourceOperationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerNonResourcesSubscriptionResource"/> class for mocking. </summary>
        protected Mockable_AzureResourceManagerNonResourcesSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerNonResourcesSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Mockable_AzureResourceManagerNonResourcesSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics NonResourceOperationsClientDiagnostics => _nonResourceOperationsClientDiagnostics ??= new ClientDiagnostics("_Azure.ResourceManager.NonResources", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private NonResourceRestOperations NonResourceOperationsRestClient => _nonResourceOperationsRestClient ??= new NonResourceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Get.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NonResource/locations/{location}/otherParameters/{parameter}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location parameter. </param>
        /// <param name="parameter"> Another parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="parameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="parameter"/> is null. </exception>
        public virtual async Task<Response<NonResource>> GetNonResourceOperationAsync(string location, string parameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(parameter, nameof(parameter));

            using var scope = NonResourceOperationsClientDiagnostics.CreateScope("Mockable_AzureResourceManagerNonResourcesSubscriptionResource.GetNonResourceOperation");
            scope.Start();
            try
            {
                var response = await NonResourceOperationsRestClient.GetAsync(Id.SubscriptionId, location, parameter, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NonResource/locations/{location}/otherParameters/{parameter}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location parameter. </param>
        /// <param name="parameter"> Another parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="parameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="parameter"/> is null. </exception>
        public virtual Response<NonResource> GetNonResourceOperation(string location, string parameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(parameter, nameof(parameter));

            using var scope = NonResourceOperationsClientDiagnostics.CreateScope("Mockable_AzureResourceManagerNonResourcesSubscriptionResource.GetNonResourceOperation");
            scope.Start();
            try
            {
                var response = NonResourceOperationsRestClient.Get(Id.SubscriptionId, location, parameter, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NonResource/locations/{location}/otherParameters/{parameter}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceOperations_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location parameter. </param>
        /// <param name="parameter"> Another parameter. </param>
        /// <param name="body"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="parameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="parameter"/> or <paramref name="body"/> is null. </exception>
        public virtual async Task<Response<NonResource>> CreateNonResourceOperationAsync(string location, string parameter, NonResource body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(parameter, nameof(parameter));
            Argument.AssertNotNull(body, nameof(body));

            using var scope = NonResourceOperationsClientDiagnostics.CreateScope("Mockable_AzureResourceManagerNonResourcesSubscriptionResource.CreateNonResourceOperation");
            scope.Start();
            try
            {
                var response = await NonResourceOperationsRestClient.CreateAsync(Id.SubscriptionId, location, parameter, body, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NonResource/locations/{location}/otherParameters/{parameter}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceOperations_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location parameter. </param>
        /// <param name="parameter"> Another parameter. </param>
        /// <param name="body"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="parameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="parameter"/> or <paramref name="body"/> is null. </exception>
        public virtual Response<NonResource> CreateNonResourceOperation(string location, string parameter, NonResource body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(parameter, nameof(parameter));
            Argument.AssertNotNull(body, nameof(body));

            using var scope = NonResourceOperationsClientDiagnostics.CreateScope("Mockable_AzureResourceManagerNonResourcesSubscriptionResource.CreateNonResourceOperation");
            scope.Start();
            try
            {
                var response = NonResourceOperationsRestClient.Create(Id.SubscriptionId, location, parameter, body, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
