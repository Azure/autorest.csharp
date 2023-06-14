// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A Class representing a DeploymentExtended along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DeploymentExtendedResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDeploymentExtendedResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" />, <see cref="ResourceGroupResource" />, <see cref="ManagementGroupResource" /> or <see cref="TenantResource" /> using the GetDeploymentExtended method.
    /// </summary>
    public partial class DeploymentExtendedResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeploymentExtendedResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName)
        {
            var resourceId = $"{scope}/providers/Microsoft.Resources/deployments/{deploymentName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deploymentExtendedDeploymentsClientDiagnostics;
        private readonly DeploymentsRestOperations _deploymentExtendedDeploymentsRestClient;
        private readonly ClientDiagnostics _deploymentOperationsClientDiagnostics;
        private readonly DeploymentRestOperations _deploymentOperationsRestClient;
        private readonly DeploymentExtendedData _data;

        /// <summary> Initializes a new instance of the <see cref="DeploymentExtendedResource"/> class for mocking. </summary>
        protected DeploymentExtendedResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeploymentExtendedResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeploymentExtendedResource(ArmClient client, DeploymentExtendedData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeploymentExtendedResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeploymentExtendedResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deploymentExtendedDeploymentsClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string deploymentExtendedDeploymentsApiVersion);
            _deploymentExtendedDeploymentsRestClient = new DeploymentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, deploymentExtendedDeploymentsApiVersion);
            _deploymentOperationsClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _deploymentOperationsRestClient = new DeploymentRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/deployments";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeploymentExtendedData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentExtendedResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Get");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtendedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentExtendedResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Get");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id.Parent, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeploymentExtendedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// A template deployment that is currently running cannot be deleted. Deleting a template deployment removes the associated deployment operations. This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted. The Location response header contains the URI that is used to obtain the status of the process. While the process is running, a call to the URI in the Location header returns a status of 202. When the process finishes, the URI in the Location header returns a status of 204 on success. If the asynchronous request failed, the URI in the Location header returns an error-level status code.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_DeleteAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Delete");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.DeleteAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation(_deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateDeleteAtScopeRequest(Id.Parent, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// A template deployment that is currently running cannot be deleted. Deleting a template deployment removes the associated deployment operations. This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted. The Location response header contains the URI that is used to obtain the status of the process. While the process is running, a call to the URI in the Location header returns a status of 202. When the process finishes, the URI in the Location header returns a status of 204 on success. If the asynchronous request failed, the URI in the Location header returns an error-level status code.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_DeleteAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Delete");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.DeleteAtScope(Id.Parent, Id.Name, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation(_deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateDeleteAtScopeRequest(Id.Parent, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// You can provide the template and parameters directly in the request or link to JSON files.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CreateOrUpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deployment"/> is null. </exception>
        public virtual async Task<ArmOperation<DeploymentExtendedResource>> UpdateAsync(WaitUntil waitUntil, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Update");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScopeAsync(Id.Parent, Id.Name, deployment, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<DeploymentExtendedResource>(new DeploymentExtendedOperationSource(Client), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id.Parent, Id.Name, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// You can provide the template and parameters directly in the request or link to JSON files.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CreateOrUpdateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deployment"/> is null. </exception>
        public virtual ArmOperation<DeploymentExtendedResource> Update(WaitUntil waitUntil, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.Update");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.CreateOrUpdateAtScope(Id.Parent, Id.Name, deployment, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<DeploymentExtendedResource>(new DeploymentExtendedOperationSource(Client), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateCreateOrUpdateAtScopeRequest(Id.Parent, Id.Name, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// You can cancel a deployment only if the provisioningState is Accepted or Running. After the deployment is canceled, the provisioningState is set to Canceled. Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CancelAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CancelAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.CancelAtScope");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.CancelAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// You can cancel a deployment only if the provisioningState is Accepted or Running. After the deployment is canceled, the provisioningState is set to Canceled. Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CancelAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CancelAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.CancelAtScope");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.CancelAtScope(Id.Parent, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/validate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ValidateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deployment"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deployment"/> is null. </exception>
        public virtual async Task<ArmOperation<DeploymentValidateResult>> ValidateAtScopeAsync(WaitUntil waitUntil, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.ValidateAtScope");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.ValidateAtScopeAsync(Id.Parent, Id.Name, deployment, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtScopeResourceArmOperation<DeploymentValidateResult>(new DeploymentValidateResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateValidateAtScopeRequest(Id.Parent, Id.Name, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/validate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ValidateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deployment"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deployment"/> is null. </exception>
        public virtual ArmOperation<DeploymentValidateResult> ValidateAtScope(WaitUntil waitUntil, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.ValidateAtScope");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.ValidateAtScope(Id.Parent, Id.Name, deployment, cancellationToken);
                var operation = new MgmtScopeResourceArmOperation<DeploymentValidateResult>(new DeploymentValidateResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateValidateAtScopeRequest(Id.Parent, Id.Name, deployment).Request, response, OperationFinalStateVia.Location);
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
        /// Exports the template used for specified deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/exportTemplate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ExportTemplateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeploymentExportResult>> ExportTemplateAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.ExportTemplateAtScope");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.ExportTemplateAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Exports the template used for specified deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/exportTemplate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_ExportTemplateAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeploymentExportResult> ExportTemplateAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.ExportTemplateAtScope");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.ExportTemplateAtScope(Id.Parent, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns changes that will be made by the deployment if executed at the scope of the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIf</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtManagementGroupScope</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtSubscriptionScope</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtTenantScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentWhatIf"/> is null. </exception>
        public virtual async Task<ArmOperation<WhatIfOperationResult>> WhatIfAsync(WaitUntil waitUntil, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.WhatIf");
            scope.Start();
            try
            {
                if (Id.Parent.ResourceType == ResourceGroupResource.ResourceType)
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.WhatIfAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, deploymentWhatIf, cancellationToken).ConfigureAwait(false);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return operation;
                }
                else if (Id.Parent.ResourceType == ManagementGroupResource.ResourceType)
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.WhatIfAtManagementGroupScopeAsync(Id.Parent.Name, Id.Name, deploymentWhatIf, cancellationToken).ConfigureAwait(false);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtManagementGroupScopeRequest(Id.Parent.Name, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return operation;
                }
                else if (Id.Parent.ResourceType == SubscriptionResource.ResourceType)
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.WhatIfAtSubscriptionScopeAsync(Id.SubscriptionId, Id.Name, deploymentWhatIf, cancellationToken).ConfigureAwait(false);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtSubscriptionScopeRequest(Id.SubscriptionId, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return operation;
                }
                else if (Id.Parent.ResourceType == TenantResource.ResourceType)
                {
                    var response = await _deploymentExtendedDeploymentsRestClient.WhatIfAtTenantScopeAsync(Id.Name, deploymentWhatIf, cancellationToken).ConfigureAwait(false);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtTenantScopeRequest(Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    return operation;
                }
                else
                {
                    throw new InvalidOperationException($"{Id.Parent.ResourceType} is not supported here");
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns changes that will be made by the deployment if executed at the scope of the resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIf</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtManagementGroupScope</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtSubscriptionScope</description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtTenantScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentWhatIf"/> is null. </exception>
        public virtual ArmOperation<WhatIfOperationResult> WhatIf(WaitUntil waitUntil, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.WhatIf");
            scope.Start();
            try
            {
                if (Id.Parent.ResourceType == ResourceGroupResource.ResourceType)
                {
                    var response = _deploymentExtendedDeploymentsRestClient.WhatIf(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, deploymentWhatIf, cancellationToken);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        operation.WaitForCompletion(cancellationToken);
                    return operation;
                }
                else if (Id.Parent.ResourceType == ManagementGroupResource.ResourceType)
                {
                    var response = _deploymentExtendedDeploymentsRestClient.WhatIfAtManagementGroupScope(Id.Parent.Name, Id.Name, deploymentWhatIf, cancellationToken);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtManagementGroupScopeRequest(Id.Parent.Name, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        operation.WaitForCompletion(cancellationToken);
                    return operation;
                }
                else if (Id.Parent.ResourceType == SubscriptionResource.ResourceType)
                {
                    var response = _deploymentExtendedDeploymentsRestClient.WhatIfAtSubscriptionScope(Id.SubscriptionId, Id.Name, deploymentWhatIf, cancellationToken);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtSubscriptionScopeRequest(Id.SubscriptionId, Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        operation.WaitForCompletion(cancellationToken);
                    return operation;
                }
                else if (Id.Parent.ResourceType == TenantResource.ResourceType)
                {
                    var response = _deploymentExtendedDeploymentsRestClient.WhatIfAtTenantScope(Id.Name, deploymentWhatIf, cancellationToken);
                    var operation = new MgmtScopeResourceArmOperation<WhatIfOperationResult>(new WhatIfOperationResultOperationSource(), _deploymentExtendedDeploymentsClientDiagnostics, Pipeline, _deploymentExtendedDeploymentsRestClient.CreateWhatIfAtTenantScopeRequest(Id.Name, deploymentWhatIf).Request, response, OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                        operation.WaitForCompletion(cancellationToken);
                    return operation;
                }
                else
                {
                    throw new InvalidOperationException($"{Id.Parent.ResourceType} is not supported here");
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a deployments operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/operations/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentOperations_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationId"> The ID of the operation to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual async Task<Response<DeploymentOperation>> GetAtScopeDeploymentOperationAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = _deploymentOperationsClientDiagnostics.CreateScope("DeploymentExtendedResource.GetAtScopeDeploymentOperation");
            scope.Start();
            try
            {
                var response = await _deploymentOperationsRestClient.GetAtScopeAsync(Id.Parent, Id.Name, operationId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a deployments operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/operations/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentOperations_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operationId"> The ID of the operation to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual Response<DeploymentOperation> GetAtScopeDeploymentOperation(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = _deploymentOperationsClientDiagnostics.CreateScope("DeploymentExtendedResource.GetAtScopeDeploymentOperation");
            scope.Start();
            try
            {
                var response = _deploymentOperationsRestClient.GetAtScope(Id.Parent, Id.Name, operationId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all deployments operations for a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentOperations_ListAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeploymentOperation" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeploymentOperation> GetAtScopeDeploymentOperationsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _deploymentOperationsRestClient.CreateListAtScopeRequest(Id.Parent, Id.Name, top);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _deploymentOperationsRestClient.CreateListAtScopeNextPageRequest(nextLink, Id.Parent, Id.Name, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, DeploymentOperation.DeserializeDeploymentOperation, _deploymentOperationsClientDiagnostics, Pipeline, "DeploymentExtendedResource.GetAtScopeDeploymentOperations", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all deployments operations for a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentOperations_ListAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeploymentOperation" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeploymentOperation> GetAtScopeDeploymentOperations(int? top = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => _deploymentOperationsRestClient.CreateListAtScopeRequest(Id.Parent, Id.Name, top);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _deploymentOperationsRestClient.CreateListAtScopeNextPageRequest(nextLink, Id.Parent, Id.Name, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, DeploymentOperation.DeserializeDeploymentOperation, _deploymentOperationsClientDiagnostics, Pipeline, "DeploymentExtendedResource.GetAtScopeDeploymentOperations", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks whether the deployment exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CheckExistenceAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> CheckExistenceAtScopeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.CheckExistenceAtScope");
            scope.Start();
            try
            {
                var response = await _deploymentExtendedDeploymentsRestClient.CheckExistenceAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks whether the deployment exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CheckExistenceAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> CheckExistenceAtScope(CancellationToken cancellationToken = default)
        {
            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.CheckExistenceAtScope");
            scope.Start();
            try
            {
                var response = _deploymentExtendedDeploymentsRestClient.CheckExistenceAtScope(Id.Parent, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<DeploymentExtendedResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<DeploymentExtendedResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id.Parent, Id.Name, cancellationToken);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<DeploymentExtendedResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<DeploymentExtendedResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id.Parent, Id.Name, cancellationToken);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<DeploymentExtendedResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _deploymentExtendedDeploymentsRestClient.GetAtScopeAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<DeploymentExtendedResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _deploymentExtendedDeploymentsClientDiagnostics.CreateScope("DeploymentExtendedResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _deploymentExtendedDeploymentsRestClient.GetAtScope(Id.Parent, Id.Name, cancellationToken);
                    return Response.FromValue(new DeploymentExtendedResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new Deployment(new DeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : DeploymentMode.Incremental));
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
