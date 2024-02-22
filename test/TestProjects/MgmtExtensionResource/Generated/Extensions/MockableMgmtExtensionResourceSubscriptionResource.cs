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
using MgmtExtensionResource;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableMgmtExtensionResourceSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _defaultClientDiagnostics;
        private PolicyRestOperations _defaultRestClient;
        private ClientDiagnostics _orphanedPostClientDiagnostics;
        private OrphanedPostRestOperations _orphanedPostRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtExtensionResourceSubscriptionResource"/> class for mocking. </summary>
        protected MockableMgmtExtensionResourceSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtExtensionResourceSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtExtensionResourceSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics DefaultClientDiagnostics => _defaultClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionResource", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyRestOperations DefaultRestClient => _defaultRestClient ??= new PolicyRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics OrphanedPostClientDiagnostics => _orphanedPostClientDiagnostics ??= new ClientDiagnostics("MgmtExtensionResource", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private OrphanedPostRestOperations OrphanedPostRestClient => _orphanedPostRestClient ??= new OrphanedPostRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets an object representing a SubSingletonResource along with the instance operations that can be performed on it in the SubscriptionResource. </summary>
        /// <returns> Returns a <see cref="SubSingletonResource"/> object. </returns>
        public virtual SubSingletonResource GetSubSingleton()
        {
            return new SubSingletonResource(Client, Id.AppendProviderResource("Microsoft.Singleton", "subSingletons", "default"));
        }

        /// <summary> Gets a collection of SubscriptionPolicyDefinitionResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubscriptionPolicyDefinitionResources and their operations over a SubscriptionPolicyDefinitionResource. </returns>
        public virtual SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions()
        {
            return GetCachedClient(client => new SubscriptionPolicyDefinitionCollection(client, Id));
        }

        /// <summary>
        /// This operation retrieves the policy definition in the given subscription with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SubscriptionPolicyDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SubscriptionPolicyDefinitionResource>> GetSubscriptionPolicyDefinitionAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            return await GetSubscriptionPolicyDefinitions().GetAsync(policyDefinitionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves the policy definition in the given subscription with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SubscriptionPolicyDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<SubscriptionPolicyDefinitionResource> GetSubscriptionPolicyDefinition(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionPolicyDefinitions().Get(policyDefinitionName, cancellationToken);
        }

        /// <summary>
        /// Checks whether a domain name in the cloudapp.azure.com zone is available for use.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckDnsNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="domainNameLabel"/> is null. </exception>
        public virtual async Task<Response<DnsNameAvailabilityResult>> CheckDnsNameAvailabilityAsync(string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            if (location.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(location));
            }
            if (domainNameLabel == null)
            {
                throw new ArgumentNullException(nameof(domainNameLabel));
            }

            using var scope = DefaultClientDiagnostics.CreateScope("MockableMgmtExtensionResourceSubscriptionResource.CheckDnsNameAvailability");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckDnsNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the domain name. </param>
        /// <param name="domainNameLabel"> The domain name to be verified. It must conform to the following regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="domainNameLabel"/> is null. </exception>
        public virtual Response<DnsNameAvailabilityResult> CheckDnsNameAvailability(string location, string domainNameLabel, CancellationToken cancellationToken = default)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
            if (location.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(location));
            }
            if (domainNameLabel == null)
            {
                throw new ArgumentNullException(nameof(domainNameLabel));
            }

            using var scope = DefaultClientDiagnostics.CreateScope("MockableMgmtExtensionResourceSubscriptionResource.CheckDnsNameAvailability");
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrphanedPost_ValidateSomething</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> ValidateSomethingOrphanedPostAsync(ValidateSomethingContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = OrphanedPostClientDiagnostics.CreateScope("MockableMgmtExtensionResourceSubscriptionResource.ValidateSomethingOrphanedPost");
            scope.Start();
            try
            {
                var response = await OrphanedPostRestClient.ValidateSomethingAsync(Id.SubscriptionId, content, cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.OrphanedPost/validateSomething</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OrphanedPost_ValidateSomething</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response ValidateSomethingOrphanedPost(ValidateSomethingContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = OrphanedPostClientDiagnostics.CreateScope("MockableMgmtExtensionResourceSubscriptionResource.ValidateSomethingOrphanedPost");
            scope.Start();
            try
            {
                var response = OrphanedPostRestClient.ValidateSomething(Id.SubscriptionId, content, cancellationToken);
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
