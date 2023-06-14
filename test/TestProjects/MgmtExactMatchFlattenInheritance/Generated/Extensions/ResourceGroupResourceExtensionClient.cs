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
using MgmtExactMatchFlattenInheritance.Models;

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _azureResourceFlattenModel2sClientDiagnostics;
        private AzureResourceFlattenModel2SRestOperations _azureResourceFlattenModel2sRestClient;
        private ClientDiagnostics _azureResourceFlattenModel3sClientDiagnostics;
        private AzureResourceFlattenModel3SRestOperations _azureResourceFlattenModel3sRestClient;
        private ClientDiagnostics _azureResourceFlattenModel4sClientDiagnostics;
        private AzureResourceFlattenModel4SRestOperations _azureResourceFlattenModel4sRestClient;
        private ClientDiagnostics _azureResourceFlattenModel5sClientDiagnostics;
        private AzureResourceFlattenModel5SRestOperations _azureResourceFlattenModel5sRestClient;

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

        private ClientDiagnostics AzureResourceFlattenModel2sClientDiagnostics => _azureResourceFlattenModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtExactMatchFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AzureResourceFlattenModel2SRestOperations AzureResourceFlattenModel2sRestClient => _azureResourceFlattenModel2sRestClient ??= new AzureResourceFlattenModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics AzureResourceFlattenModel3sClientDiagnostics => _azureResourceFlattenModel3sClientDiagnostics ??= new ClientDiagnostics("MgmtExactMatchFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AzureResourceFlattenModel3SRestOperations AzureResourceFlattenModel3sRestClient => _azureResourceFlattenModel3sRestClient ??= new AzureResourceFlattenModel3SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics AzureResourceFlattenModel4sClientDiagnostics => _azureResourceFlattenModel4sClientDiagnostics ??= new ClientDiagnostics("MgmtExactMatchFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AzureResourceFlattenModel4SRestOperations AzureResourceFlattenModel4sRestClient => _azureResourceFlattenModel4sRestClient ??= new AzureResourceFlattenModel4SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics AzureResourceFlattenModel5sClientDiagnostics => _azureResourceFlattenModel5sClientDiagnostics ??= new ClientDiagnostics("MgmtExactMatchFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AzureResourceFlattenModel5SRestOperations AzureResourceFlattenModel5sRestClient => _azureResourceFlattenModel5sRestClient ??= new AzureResourceFlattenModel5SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AzureResourceFlattenModel1Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of AzureResourceFlattenModel1Resources and their operations over a AzureResourceFlattenModel1Resource. </returns>
        public virtual AzureResourceFlattenModel1Collection GetAzureResourceFlattenModel1s()
        {
            return GetCachedClient(Client => new AzureResourceFlattenModel1Collection(Client, Id));
        }

        /// <summary> Gets a collection of CustomModel2Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of CustomModel2Resources and their operations over a CustomModel2Resource. </returns>
        public virtual CustomModel2Collection GetCustomModel2s()
        {
            return GetCachedClient(Client => new CustomModel2Collection(Client, Id));
        }

        /// <summary> Gets a collection of CustomModel3Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of CustomModel3Resources and their operations over a CustomModel3Resource. </returns>
        public virtual CustomModel3Collection GetCustomModel3s()
        {
            return GetCachedClient(Client => new CustomModel3Collection(Client, Id));
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2, AzureResourceFlattenModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2, AzureResourceFlattenModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel2"> The AzureResourceFlattenModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel2>> PutAzureResourceFlattenModel2Async(string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel2");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel2, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel2"> The AzureResourceFlattenModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel2> PutAzureResourceFlattenModel2(string name, AzureResourceFlattenModel2 azureResourceFlattenModel2, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel2");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel2, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel2>> GetAzureResourceFlattenModel2Async(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel2");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel2.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel2s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel2> GetAzureResourceFlattenModel2(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel2");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel3" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel3sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, AzureResourceFlattenModel3.DeserializeAzureResourceFlattenModel3, AzureResourceFlattenModel3sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel3s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel3" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel3sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, AzureResourceFlattenModel3.DeserializeAzureResourceFlattenModel3, AzureResourceFlattenModel3sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel3s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel3"> The AzureResourceFlattenModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel3>> PutAzureResourceFlattenModel3Async(string name, AzureResourceFlattenModel3 azureResourceFlattenModel3, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel3");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel3sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel3, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel3"> The AzureResourceFlattenModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel3> PutAzureResourceFlattenModel3(string name, AzureResourceFlattenModel3 azureResourceFlattenModel3, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel3");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel3sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel3, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel3>> GetAzureResourceFlattenModel3Async(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel3");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel3sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel3.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel3s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel3s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel3> GetAzureResourceFlattenModel3(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel3sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel3");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel3sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel4" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel4sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, AzureResourceFlattenModel4.DeserializeAzureResourceFlattenModel4, AzureResourceFlattenModel4sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel4s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel4" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel4sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, AzureResourceFlattenModel4.DeserializeAzureResourceFlattenModel4, AzureResourceFlattenModel4sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel4s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel4"> The AzureResourceFlattenModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel4>> PutAzureResourceFlattenModel4Async(string name, AzureResourceFlattenModel4 azureResourceFlattenModel4, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel4sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel4");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel4sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel4, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="azureResourceFlattenModel4"> The AzureResourceFlattenModel4 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel4> PutAzureResourceFlattenModel4(string name, AzureResourceFlattenModel4 azureResourceFlattenModel4, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel4sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel4");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel4sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, azureResourceFlattenModel4, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel4>> GetAzureResourceFlattenModel4Async(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel4sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel4");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel4sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel4.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel4s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel4> GetAzureResourceFlattenModel4(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel4sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel4");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel4sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AzureResourceFlattenModel5" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel5sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, AzureResourceFlattenModel5.DeserializeAzureResourceFlattenModel5, AzureResourceFlattenModel5sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel5s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AzureResourceFlattenModel5" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AzureResourceFlattenModel5sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, AzureResourceFlattenModel5.DeserializeAzureResourceFlattenModel5, AzureResourceFlattenModel5sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel5s", "value", null, cancellationToken);
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel5>> PutAzureResourceFlattenModel5Async(string name, int? foo = null, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel5sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel5");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel5sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, foo, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel5> PutAzureResourceFlattenModel5(string name, int? foo = null, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel5sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutAzureResourceFlattenModel5");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel5sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, foo, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AzureResourceFlattenModel5>> GetAzureResourceFlattenModel5Async(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel5sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel5");
            scope.Start();
            try
            {
                var response = await AzureResourceFlattenModel5sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an AzureResourceFlattenModel5.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/azureResourceFlattenModel5s/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AzureResourceFlattenModel5s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AzureResourceFlattenModel5> GetAzureResourceFlattenModel5(string name, CancellationToken cancellationToken = default)
        {
            using var scope = AzureResourceFlattenModel5sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetAzureResourceFlattenModel5");
            scope.Start();
            try
            {
                var response = AzureResourceFlattenModel5sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
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
