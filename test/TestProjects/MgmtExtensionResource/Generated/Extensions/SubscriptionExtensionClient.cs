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
using Azure.ResourceManager.Core;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _defaultClientDiagnostics;
        private PolicyRestOperations _defaultRestClient;
        private ClientDiagnostics _orphanedPostClientDiagnostics;
        private OrphanedPostRestOperations _orphanedPostRestClient;

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

        private ClientDiagnostics DefaultClientDiagnostics => _defaultClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionResource", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private PolicyRestOperations DefaultRestClient => _defaultRestClient ??= new PolicyRestOperations(DefaultClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        private ClientDiagnostics OrphanedPostClientDiagnostics => _orphanedPostClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionResource", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private OrphanedPostRestOperations OrphanedPostRestClient => _orphanedPostRestClient ??= new OrphanedPostRestOperations(OrphanedPostClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets an object representing a SubSingleton along with the instance operations that can be performed on it in the SubscriptionExtensionClient. </summary>
        /// <returns> Returns a <see cref="SubSingleton" /> object. </returns>
        public virtual SubSingleton GetSubSingleton()
        {
            return new SubSingleton(Client, new ResourceIdentifier(Id.ToString() + "/providers/Microsoft.Singleton/subSingletons/default"));
        }

        /// <summary> Gets a collection of SubscriptionPolicyDefinitions in the SubscriptionPolicyDefinition. </summary>
        /// <returns> An object representing collection of SubscriptionPolicyDefinitions and their operations over a SubscriptionPolicyDefinition. </returns>
        public virtual SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions()
        {
            return new SubscriptionPolicyDefinitionCollection(Client, Id);
        }

        /// <summary>
        /// Checks whether a domain name in the cloudapp.azure.com zone is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability
        /// Operation Id: CheckDnsNameAvailability
        /// </summary>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckDnsNameAvailability");
            scope.Start();
            try
            {
                var response = await DefaultRestClient.CheckDnsNameAvailabilityAsync(Id.SubscriptionId, location, domainNameLabel, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks whether a domain name in the cloudapp.azure.com zone is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability
        /// Operation Id: CheckDnsNameAvailability
        /// </summary>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DnsNameAvailabilityResult> CheckDnsNameAvailability(string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckDnsNameAvailability");
            scope.Start();
            try
            {
                var response = DefaultRestClient.CheckDnsNameAvailability(Id.SubscriptionId, location, domainNameLabel, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// Operation Id: OrphanedPost_ValidateSomething
        /// </summary>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> ValidateSomethingOrphanedPostAsync(ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            using var scope = OrphanedPostClientDiagnostics.CreateScope("SubscriptionExtensionClient.ValidateSomethingOrphanedPost");
            scope.Start();
            try
            {
                var response = await OrphanedPostRestClient.ValidateSomethingAsync(Id.SubscriptionId, validateSomethingOptions, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething
        /// Operation Id: OrphanedPost_ValidateSomething
        /// </summary>
        /// <param name="validateSomethingOptions"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ValidateSomethingOrphanedPost(ValidateSomethingOptions validateSomethingOptions, CancellationToken cancellationToken = default)
        {
            using var scope = OrphanedPostClientDiagnostics.CreateScope("SubscriptionExtensionClient.ValidateSomethingOrphanedPost");
            scope.Start();
            try
            {
                var response = OrphanedPostRestClient.ValidateSomething(Id.SubscriptionId, validateSomethingOptions, cancellationToken);
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
