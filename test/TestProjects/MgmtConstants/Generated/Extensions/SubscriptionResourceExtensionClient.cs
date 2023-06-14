// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtConstants
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _optionalMachineOptionalsClientDiagnostics;
        private OptionalsRestOperations _optionalMachineOptionalsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics OptionalMachineOptionalsClientDiagnostics => _optionalMachineOptionalsClientDiagnostics ??= new ClientDiagnostics("MgmtConstants", OptionalMachineResource.ResourceType.Namespace, Diagnostics);
        private OptionalsRestOperations OptionalMachineOptionalsRestClient => _optionalMachineOptionalsRestClient ??= new OptionalsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(OptionalMachineResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OptionalMachineResource> GetOptionalMachinesAsync(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => OptionalMachineOptionalsRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => OptionalMachineOptionalsRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new OptionalMachineResource(Client, OptionalMachineData.DeserializeOptionalMachineData(e)), OptionalMachineOptionalsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOptionalMachines", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OptionalMachineResource> GetOptionalMachines(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => OptionalMachineOptionalsRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => OptionalMachineOptionalsRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new OptionalMachineResource(Client, OptionalMachineData.DeserializeOptionalMachineData(e)), OptionalMachineOptionalsClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOptionalMachines", "value", "nextLink", cancellationToken);
        }
    }
}
