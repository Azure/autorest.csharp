// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _virtualMachineClientDiagnostics;
        private VirtualMachinesRestOperations _virtualMachineRestClient;
        private ClientDiagnostics _imageClientDiagnostics;
        private ImagesRestOperations _imageRestClient;
        private ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;
        private ClientDiagnostics _logAnalyticsClientDiagnostics;
        private LogAnalyticsRestOperations _logAnalyticsRestClient;

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

        private ClientDiagnostics VirtualMachineClientDiagnostics => _virtualMachineClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", VirtualMachine.ResourceType.Namespace, DiagnosticOptions);
        private VirtualMachinesRestOperations VirtualMachineRestClient => _virtualMachineRestClient ??= new VirtualMachinesRestOperations(VirtualMachineClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(VirtualMachine.ResourceType));
        private ClientDiagnostics ImageClientDiagnostics => _imageClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", Image.ResourceType.Namespace, DiagnosticOptions);
        private ImagesRestOperations ImageRestClient => _imageRestClient ??= new ImagesRestOperations(ImageClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(Image.ResourceType));
        private ClientDiagnostics VirtualMachineScaleSetClientDiagnostics => _virtualMachineScaleSetClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", VirtualMachineScaleSet.ResourceType.Namespace, DiagnosticOptions);
        private VirtualMachineScaleSetsRestOperations VirtualMachineScaleSetRestClient => _virtualMachineScaleSetRestClient ??= new VirtualMachineScaleSetsRestOperations(VirtualMachineScaleSetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(VirtualMachineScaleSet.ResourceType));
        private ClientDiagnostics LogAnalyticsClientDiagnostics => _logAnalyticsClientDiagnostics ??= new ClientDiagnostics("MgmtRenameRules", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private LogAnalyticsRestOperations LogAnalyticsRestClient => _logAnalyticsRestClient ??= new LogAnalyticsRestOperations(LogAnalyticsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachines_ListByLocation
        /// <summary> Gets all the virtual machines under the specified subscription for the specified location. </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachine> GetVirtualMachinesByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachine>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachinesByLocation");
                scope.Start();
                try
                {
                    var response = await VirtualMachineRestClient.ListByLocationAsync(Id.SubscriptionId, location, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachine>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachinesByLocation");
                scope.Start();
                try
                {
                    var response = await VirtualMachineRestClient.ListByLocationNextPageAsync(nextLink, Id.SubscriptionId, location, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachines_ListByLocation
        /// <summary> Gets all the virtual machines under the specified subscription for the specified location. </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachine> GetVirtualMachinesByLocation(string location, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachine> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachinesByLocation");
                scope.Start();
                try
                {
                    var response = VirtualMachineRestClient.ListByLocation(Id.SubscriptionId, location, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachine> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachinesByLocation");
                scope.Start();
                try
                {
                    var response = VirtualMachineRestClient.ListByLocationNextPage(nextLink, Id.SubscriptionId, location, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachines_ListAll
        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachine> GetVirtualMachinesAsync(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachine>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachines");
                scope.Start();
                try
                {
                    var response = await VirtualMachineRestClient.ListAllAsync(Id.SubscriptionId, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachine>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachines");
                scope.Start();
                try
                {
                    var response = await VirtualMachineRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, statusOnly, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachines_ListAll
        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachine> GetVirtualMachines(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachine> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachines");
                scope.Start();
                try
                {
                    var response = VirtualMachineRestClient.ListAll(Id.SubscriptionId, statusOnly, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachine> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachines");
                scope.Start();
                try
                {
                    var response = VirtualMachineRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, statusOnly, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/images
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Images_List
        /// <summary> Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Image> GetImagesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Image>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ImageClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetImages");
                scope.Start();
                try
                {
                    var response = await ImageRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Image>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ImageClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetImages");
                scope.Start();
                try
                {
                    var response = await ImageRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/images
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Images_List
        /// <summary> Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Image> GetImages(CancellationToken cancellationToken = default)
        {
            Page<Image> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ImageClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetImages");
                scope.Start();
                try
                {
                    var response = ImageRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Image> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ImageClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetImages");
                scope.Start();
                try
                {
                    var response = ImageRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachineScaleSets_ListAll
        /// <summary> Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSet>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineScaleSetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachineScaleSets");
                scope.Start();
                try
                {
                    var response = await VirtualMachineScaleSetRestClient.ListAllAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineScaleSet>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineScaleSetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachineScaleSets");
                scope.Start();
                try
                {
                    var response = await VirtualMachineScaleSetRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: VirtualMachineScaleSets_ListAll
        /// <summary> Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSet> GetVirtualMachineScaleSets(CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineScaleSet> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VirtualMachineScaleSetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachineScaleSets");
                scope.Start();
                try
                {
                    var response = VirtualMachineScaleSetRestClient.ListAll(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineScaleSet> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VirtualMachineScaleSetClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVirtualMachineScaleSets");
                scope.Start();
                try
                {
                    var response = VirtualMachineScaleSetRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: LogAnalytics_ExportRequestRateByInterval
        /// <summary> Export logs that show Api requests made by this subscription in the given time window to show throttling activities. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="parameters"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<LogAnalytics>> ExportRequestRateByIntervalLogAnalyticAsync(bool waitForCompletion, string location, RequestRateByIntervalInput parameters, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportRequestRateByIntervalAsync(Id.SubscriptionId, location, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: LogAnalytics_ExportRequestRateByInterval
        /// <summary> Export logs that show Api requests made by this subscription in the given time window to show throttling activities. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="parameters"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportRequestRateByIntervalLogAnalytic(bool waitForCompletion, string location, RequestRateByIntervalInput parameters, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportRequestRateByInterval(Id.SubscriptionId, location, parameters, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: LogAnalytics_ExportThrottledRequests
        /// <summary> Export logs that show total throttled Api requests for this subscription in the given time window. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="parameters"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<LogAnalytics>> ExportThrottledRequestsLogAnalyticAsync(bool waitForCompletion, string location, ThrottledRequestsInput parameters, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportThrottledRequestsAsync(Id.SubscriptionId, location, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: LogAnalytics_ExportThrottledRequests
        /// <summary> Export logs that show total throttled Api requests for this subscription in the given time window. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="parameters"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportThrottledRequestsLogAnalytic(bool waitForCompletion, string location, ThrottledRequestsInput parameters, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportThrottledRequests(Id.SubscriptionId, location, parameters, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
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
