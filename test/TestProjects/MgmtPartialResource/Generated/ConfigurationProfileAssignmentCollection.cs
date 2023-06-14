// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtPartialResource
{
    /// <summary>
    /// A class representing a collection of <see cref="ConfigurationProfileAssignmentResource" /> and their operations.
    /// Each <see cref="ConfigurationProfileAssignmentResource" /> in the collection will belong to the same instance of <see cref="VirtualMachineMgmtPartialResource" />.
    /// To get a <see cref="ConfigurationProfileAssignmentCollection" /> instance call the GetConfigurationProfileAssignments method from an instance of <see cref="VirtualMachineMgmtPartialResource" />.
    /// </summary>
    public partial class ConfigurationProfileAssignmentCollection : ArmCollection, IEnumerable<ConfigurationProfileAssignmentResource>, IAsyncEnumerable<ConfigurationProfileAssignmentResource>
    {
        private readonly ClientDiagnostics _configurationProfileAssignmentClientDiagnostics;
        private readonly ConfigurationProfileAssignmentsRestOperations _configurationProfileAssignmentRestClient;

        /// <summary> Initializes a new instance of the <see cref="ConfigurationProfileAssignmentCollection"/> class for mocking. </summary>
        protected ConfigurationProfileAssignmentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ConfigurationProfileAssignmentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ConfigurationProfileAssignmentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _configurationProfileAssignmentClientDiagnostics = new ClientDiagnostics("MgmtPartialResource", ConfigurationProfileAssignmentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ConfigurationProfileAssignmentResource.ResourceType, out string configurationProfileAssignmentApiVersion);
            _configurationProfileAssignmentRestClient = new ConfigurationProfileAssignmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, configurationProfileAssignmentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualMachineMgmtPartialResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualMachineMgmtPartialResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates an association between a VM and Automanage configuration profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="configurationProfileAssignmentName"> Name of the configuration profile assignment. Only default is supported. </param>
        /// <param name="data"> Parameters supplied to the create or update configuration profile assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ConfigurationProfileAssignmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string configurationProfileAssignmentName, ConfigurationProfileAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _configurationProfileAssignmentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPartialResourceArmOperation<ConfigurationProfileAssignmentResource>(Response.FromValue(new ConfigurationProfileAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Creates an association between a VM and Automanage configuration profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="configurationProfileAssignmentName"> Name of the configuration profile assignment. Only default is supported. </param>
        /// <param name="data"> Parameters supplied to the create or update configuration profile assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ConfigurationProfileAssignmentResource> CreateOrUpdate(WaitUntil waitUntil, string configurationProfileAssignmentName, ConfigurationProfileAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _configurationProfileAssignmentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, data, cancellationToken);
                var operation = new MgmtPartialResourceArmOperation<ConfigurationProfileAssignmentResource>(Response.FromValue(new ConfigurationProfileAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Get information about a configuration profile assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        public virtual async Task<Response<ConfigurationProfileAssignmentResource>> GetAsync(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = await _configurationProfileAssignmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ConfigurationProfileAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get information about a configuration profile assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        public virtual Response<ConfigurationProfileAssignmentResource> Get(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.Get");
            scope.Start();
            try
            {
                var response = _configurationProfileAssignmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ConfigurationProfileAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get list of configuration profile assignments
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_ListByVirtualMachines</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConfigurationProfileAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConfigurationProfileAssignmentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _configurationProfileAssignmentRestClient.CreateListByVirtualMachinesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new ConfigurationProfileAssignmentResource(Client, ConfigurationProfileAssignmentData.DeserializeConfigurationProfileAssignmentData(e)), _configurationProfileAssignmentClientDiagnostics, Pipeline, "ConfigurationProfileAssignmentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get list of configuration profile assignments
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_ListByVirtualMachines</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConfigurationProfileAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConfigurationProfileAssignmentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _configurationProfileAssignmentRestClient.CreateListByVirtualMachinesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new ConfigurationProfileAssignmentResource(Client, ConfigurationProfileAssignmentData.DeserializeConfigurationProfileAssignmentData(e)), _configurationProfileAssignmentClientDiagnostics, Pipeline, "ConfigurationProfileAssignmentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _configurationProfileAssignmentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationProfileAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        public virtual Response<bool> Exists(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationProfileAssignmentName, nameof(configurationProfileAssignmentName));

            using var scope = _configurationProfileAssignmentClientDiagnostics.CreateScope("ConfigurationProfileAssignmentCollection.Exists");
            scope.Start();
            try
            {
                var response = _configurationProfileAssignmentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, configurationProfileAssignmentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ConfigurationProfileAssignmentResource> IEnumerable<ConfigurationProfileAssignmentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ConfigurationProfileAssignmentResource> IAsyncEnumerable<ConfigurationProfileAssignmentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
