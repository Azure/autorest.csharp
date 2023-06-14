// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _virtualMachineClientDiagnostics;
        private VirtualMachinesRestOperations _virtualMachineRestClient;
        private ClientDiagnostics _imageClientDiagnostics;
        private ImagesRestOperations _imageRestClient;
        private ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;
        private ClientDiagnostics _logAnalyticsClientDiagnostics;
        private LogAnalyticsRestOperations _logAnalyticsRestClient;

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

        private ClientDiagnostics VirtualMachineClientDiagnostics => _virtualMachineClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", VirtualMachineResource.ResourceType.Namespace, Diagnostics);
        private VirtualMachinesRestOperations VirtualMachineRestClient => _virtualMachineRestClient ??= new VirtualMachinesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VirtualMachineResource.ResourceType));
        private ClientDiagnostics ImageClientDiagnostics => _imageClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", ImageResource.ResourceType.Namespace, Diagnostics);
        private ImagesRestOperations ImageRestClient => _imageRestClient ??= new ImagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ImageResource.ResourceType));
        private ClientDiagnostics VirtualMachineScaleSetClientDiagnostics => _virtualMachineScaleSetClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", VirtualMachineScaleSetResource.ResourceType.Namespace, Diagnostics);
        private VirtualMachineScaleSetsRestOperations VirtualMachineScaleSetRestClient => _virtualMachineScaleSetRestClient ??= new VirtualMachineScaleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VirtualMachineScaleSetResource.ResourceType));
        private ClientDiagnostics LogAnalyticsClientDiagnostics => _logAnalyticsClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private LogAnalyticsRestOperations LogAnalyticsRestClient => _logAnalyticsRestClient ??= new LogAnalyticsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineResource> GetVirtualMachinesByLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListByLocationRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachinesByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineResource> GetVirtualMachinesByLocation(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListByLocationRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachinesByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineResource> GetVirtualMachinesAsync(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachines", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineResource> GetVirtualMachines(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachines", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ImageResource> GetImagesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ImageRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ImageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ImageResource(Client, ImageData.DeserializeImageData(e)), ImageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetImages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ImageResource> GetImages(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ImageRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ImageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ImageResource(Client, ImageData.DeserializeImageData(e)), ImageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetImages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineScaleSetRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineScaleSetRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineScaleSetRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineScaleSetRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<LogAnalytics>> ExportRequestRateByIntervalLogAnalyticAsync(WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportRequestRateByIntervalAsync(Id.SubscriptionId, location, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportRequestRateByIntervalLogAnalytic(WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportRequestRateByInterval(Id.SubscriptionId, location, content, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<LogAnalytics>> ExportThrottledRequestsLogAnalyticAsync(WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportThrottledRequestsAsync(Id.SubscriptionId, location, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportThrottledRequestsLogAnalytic(WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportThrottledRequests(Id.SubscriptionId, location, content, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
