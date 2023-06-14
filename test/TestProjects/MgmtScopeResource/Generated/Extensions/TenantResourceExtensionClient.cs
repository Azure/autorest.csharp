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
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    internal partial class TenantResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _deploymentExtendedDeploymentsClientDiagnostics;
        private DeploymentsRestOperations _deploymentExtendedDeploymentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantResourceExtensionClient"/> class for mocking. </summary>
        protected TenantResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics DeploymentExtendedDeploymentsClientDiagnostics => _deploymentExtendedDeploymentsClientDiagnostics ??= new ClientDiagnostics("MgmtScopeResource", DeploymentExtendedResource.ResourceType.Namespace, Diagnostics);
        private DeploymentsRestOperations DeploymentExtendedDeploymentsRestClient => _deploymentExtendedDeploymentsRestClient ??= new DeploymentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(DeploymentExtendedResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the TenantResource. </summary>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public virtual DeploymentExtendedCollection GetDeploymentExtendeds()
        {
            return GetCachedClient(Client => new DeploymentExtendedCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResourceLinkResources in the TenantResource. </summary>
        /// <param name="scope"> The fully qualified ID of the scope for getting the resource links. For example, to list resource links at and under a resource group, set the scope to /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup. </param>
        /// <returns> An object representing collection of ResourceLinkResources and their operations over a ResourceLinkResource. </returns>
        public virtual ResourceLinkCollection GetResourceLinks(string scope)
        {
            return new ResourceLinkCollection(Client, Id, scope);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TemplateHashResult>> CalculateTemplateHashDeploymentAsync(BinaryData template, CancellationToken cancellationToken = default)
        {
            using var scope = DeploymentExtendedDeploymentsClientDiagnostics.CreateScope("TenantResourceExtensionClient.CalculateTemplateHashDeployment");
            scope.Start();
            try
            {
                var response = await DeploymentExtendedDeploymentsRestClient.CalculateTemplateHashAsync(template, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TemplateHashResult> CalculateTemplateHashDeployment(BinaryData template, CancellationToken cancellationToken = default)
        {
            using var scope = DeploymentExtendedDeploymentsClientDiagnostics.CreateScope("TenantResourceExtensionClient.CalculateTemplateHashDeployment");
            scope.Start();
            try
            {
                var response = DeploymentExtendedDeploymentsRestClient.CalculateTemplateHash(template, cancellationToken);
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
