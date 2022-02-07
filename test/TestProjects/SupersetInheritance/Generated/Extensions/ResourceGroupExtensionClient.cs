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
using SupersetInheritance.Models;

namespace SupersetInheritance
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        private ClientDiagnostics _supersetModel2sClientDiagnostics;
        private SupersetModel2SRestOperations _supersetModel2sRestClient;
        private ClientDiagnostics _supersetModel3sClientDiagnostics;
        private SupersetModel3SRestOperations _supersetModel3sRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics SupersetModel2sClientDiagnostics => _supersetModel2sClientDiagnostics ??= new ClientDiagnostics("SupersetInheritance", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private SupersetModel2SRestOperations SupersetModel2sRestClient => _supersetModel2sRestClient ??= new SupersetModel2SRestOperations(SupersetModel2sClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        private ClientDiagnostics SupersetModel3sClientDiagnostics => _supersetModel3sClientDiagnostics ??= new ClientDiagnostics("SupersetInheritance", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private SupersetModel3SRestOperations SupersetModel3sRestClient => _supersetModel3sRestClient ??= new SupersetModel3SRestOperations(SupersetModel3sClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of SupersetModel1s in the SupersetModel1. </summary>
        /// <returns> An object representing collection of SupersetModel1s and their operations over a SupersetModel1. </returns>
        public virtual SupersetModel1Collection GetSupersetModel1s()
        {
            return new SupersetModel1Collection(Client, Id);
        }

        /// <summary> Gets a collection of SupersetModel4s in the SupersetModel4. </summary>
        /// <returns> An object representing collection of SupersetModel4s and their operations over a SupersetModel4. </returns>
        public virtual SupersetModel4Collection GetSupersetModel4s()
        {
            return new SupersetModel4Collection(Client, Id);
        }

        /// <summary> Gets a collection of SupersetModel6s in the SupersetModel6. </summary>
        /// <returns> An object representing collection of SupersetModel6s and their operations over a SupersetModel6. </returns>
        public virtual SupersetModel6Collection GetSupersetModel6s()
        {
            return new SupersetModel6Collection(Client, Id);
        }

        /// <summary> Gets a collection of SupersetModel7s in the SupersetModel7. </summary>
        /// <returns> An object representing collection of SupersetModel7s and their operations over a SupersetModel7. </returns>
        public virtual SupersetModel7Collection GetSupersetModel7s()
        {
            return new SupersetModel7Collection(Client, Id);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Put
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SupersetModel2>> PutSupersetModel2Async(string supersetModel2SName, SupersetModel2 parameters, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.PutSupersetModel2");
            scope.Start();
            try
            {
                var response = await SupersetModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Put
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel2> PutSupersetModel2(string supersetModel2SName, SupersetModel2 parameters, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.PutSupersetModel2");
            scope.Start();
            try
            {
                var response = SupersetModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, parameters, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Get
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SupersetModel2>> GetSupersetModel2Async(string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetSupersetModel2");
            scope.Start();
            try
            {
                var response = await SupersetModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Get
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel2> GetSupersetModel2(string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetSupersetModel2");
            scope.Start();
            try
            {
                var response = SupersetModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Put
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SupersetModel3>> PutSupersetModel3Async(string supersetModel3SName, SupersetModel3 parameters, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.PutSupersetModel3");
            scope.Start();
            try
            {
                var response = await SupersetModel3sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, parameters, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Put
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel3> PutSupersetModel3(string supersetModel3SName, SupersetModel3 parameters, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.PutSupersetModel3");
            scope.Start();
            try
            {
                var response = SupersetModel3sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, parameters, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Get
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SupersetModel3>> GetSupersetModel3Async(string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetSupersetModel3");
            scope.Start();
            try
            {
                var response = await SupersetModel3sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Get
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel3> GetSupersetModel3(string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupExtensionClient.GetSupersetModel3");
            scope.Start();
            try
            {
                var response = SupersetModel3sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, cancellationToken);
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
