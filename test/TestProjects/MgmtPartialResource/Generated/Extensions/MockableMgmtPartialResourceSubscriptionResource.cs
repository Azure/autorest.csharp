// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtPartialResource;

namespace MgmtPartialResource.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableMgmtPartialResourceSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _publicIPAddressClientDiagnostics;
        private PublicIPAddressesRestOperations _publicIPAddressRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtPartialResourceSubscriptionResource"/> class for mocking. </summary>
        protected MockableMgmtPartialResourceSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtPartialResourceSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtPartialResourceSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PublicIPAddressClientDiagnostics => _publicIPAddressClientDiagnostics ??= new ClientDiagnostics("MgmtPartialResource", PublicIPAddressResource.ResourceType.Namespace, Diagnostics);
        private PublicIPAddressesRestOperations PublicIPAddressRestClient => _publicIPAddressRestClient ??= new PublicIPAddressesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(PublicIPAddressResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPAddressResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPAddressResource> GetPublicIPAddressesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PublicIPAddressRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PublicIPAddressRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PublicIPAddressResource(Client, PublicIPAddressData.DeserializePublicIPAddressData(e)), PublicIPAddressClientDiagnostics, Pipeline, "MockableMgmtPartialResourceSubscriptionResource.GetPublicIPAddresses", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPAddressResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPAddressResource> GetPublicIPAddresses(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => PublicIPAddressRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => PublicIPAddressRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PublicIPAddressResource(Client, PublicIPAddressData.DeserializePublicIPAddressData(e)), PublicIPAddressClientDiagnostics, Pipeline, "MockableMgmtPartialResourceSubscriptionResource.GetPublicIPAddresses", "value", "nextLink", cancellationToken);
        }
    }
}
