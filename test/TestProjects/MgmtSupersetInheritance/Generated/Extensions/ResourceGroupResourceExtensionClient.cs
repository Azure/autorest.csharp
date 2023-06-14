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
using MgmtSupersetInheritance.Models;

namespace MgmtSupersetInheritance
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _supersetModel2sClientDiagnostics;
        private SupersetModel2SRestOperations _supersetModel2sRestClient;
        private ClientDiagnostics _supersetModel3sClientDiagnostics;
        private SupersetModel3SRestOperations _supersetModel3sRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics SupersetModel2sClientDiagnostics => _supersetModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SupersetModel2SRestOperations SupersetModel2sRestClient => _supersetModel2sRestClient ??= new SupersetModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics SupersetModel3sClientDiagnostics => _supersetModel3sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SupersetModel3SRestOperations SupersetModel3sRestClient => _supersetModel3sRestClient ??= new SupersetModel3SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of SupersetModel1Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of SupersetModel1Resources and their operations over a SupersetModel1Resource. </returns>
        public virtual SupersetModel1Collection GetSupersetModel1s()
        {
            return GetCachedClient(Client => new SupersetModel1Collection(Client, Id));
        }

        /// <summary> Gets a collection of SupersetModel4Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of SupersetModel4Resources and their operations over a SupersetModel4Resource. </returns>
        public virtual SupersetModel4Collection GetSupersetModel4s()
        {
            return GetCachedClient(Client => new SupersetModel4Collection(Client, Id));
        }

        /// <summary> Gets a collection of SupersetModel6Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of SupersetModel6Resources and their operations over a SupersetModel6Resource. </returns>
        public virtual SupersetModel6Collection GetSupersetModel6s()
        {
            return GetCachedClient(Client => new SupersetModel6Collection(Client, Id));
        }

        /// <summary> Gets a collection of SupersetModel7Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of SupersetModel7Resources and their operations over a SupersetModel7Resource. </returns>
        public virtual SupersetModel7Collection GetSupersetModel7s()
        {
            return GetCachedClient(Client => new SupersetModel7Collection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="supersetModel2"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SupersetModel2>> PutSupersetModel2Async(string supersetModel2SName, SupersetModel2 supersetModel2, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSupersetModel2");
            scope.Start();
            try
            {
                var response = await SupersetModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, supersetModel2, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="supersetModel2"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel2> PutSupersetModel2(string supersetModel2SName, SupersetModel2 supersetModel2, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSupersetModel2");
            scope.Start();
            try
            {
                var response = SupersetModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel2SName, supersetModel2, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SupersetModel2>> GetSupersetModel2Async(string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSupersetModel2");
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

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel2> GetSupersetModel2(string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSupersetModel2");
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

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="supersetModel3"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SupersetModel3>> PutSupersetModel3Async(string supersetModel3SName, SupersetModel3 supersetModel3, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSupersetModel3");
            scope.Start();
            try
            {
                var response = await SupersetModel3sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, supersetModel3, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="supersetModel3"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel3> PutSupersetModel3(string supersetModel3SName, SupersetModel3 supersetModel3, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSupersetModel3");
            scope.Start();
            try
            {
                var response = SupersetModel3sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel3SName, supersetModel3, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SupersetModel3>> GetSupersetModel3Async(string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSupersetModel3");
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

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel3> GetSupersetModel3(string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = SupersetModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSupersetModel3");
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
