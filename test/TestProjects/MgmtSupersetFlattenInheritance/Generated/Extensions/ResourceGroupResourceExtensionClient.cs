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
using MgmtSupersetFlattenInheritance.Models;

namespace MgmtSupersetFlattenInheritance
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _customModel1sClientDiagnostics;
        private CustomModel1SRestOperations _customModel1sRestClient;
        private ClientDiagnostics _customModel2sClientDiagnostics;
        private CustomModel2SRestOperations _customModel2sRestClient;
        private ClientDiagnostics _subResourceModel1sClientDiagnostics;
        private SubResourceModel1SRestOperations _subResourceModel1sRestClient;
        private ClientDiagnostics _subResourceModel2sClientDiagnostics;
        private SubResourceModel2SRestOperations _subResourceModel2sRestClient;
        private ClientDiagnostics _writableSubResourceModel1sClientDiagnostics;
        private WritableSubResourceModel1SRestOperations _writableSubResourceModel1sRestClient;
        private ClientDiagnostics _writableSubResourceModel2sClientDiagnostics;
        private WritableSubResourceModel2SRestOperations _writableSubResourceModel2sRestClient;
        private ClientDiagnostics _resourceModel2sClientDiagnostics;
        private ResourceModel2SRestOperations _resourceModel2sRestClient;
        private ClientDiagnostics _trackedResourceModel2sClientDiagnostics;
        private TrackedResourceModel2SRestOperations _trackedResourceModel2sRestClient;
        private ClientDiagnostics _nonResourceModel1sClientDiagnostics;
        private NonResourceModel1SRestOperations _nonResourceModel1sRestClient;

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

        private ClientDiagnostics CustomModel1sClientDiagnostics => _customModel1sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private CustomModel1SRestOperations CustomModel1sRestClient => _customModel1sRestClient ??= new CustomModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics CustomModel2sClientDiagnostics => _customModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private CustomModel2SRestOperations CustomModel2sRestClient => _customModel2sRestClient ??= new CustomModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics SubResourceModel1sClientDiagnostics => _subResourceModel1sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SubResourceModel1SRestOperations SubResourceModel1sRestClient => _subResourceModel1sRestClient ??= new SubResourceModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics SubResourceModel2sClientDiagnostics => _subResourceModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SubResourceModel2SRestOperations SubResourceModel2sRestClient => _subResourceModel2sRestClient ??= new SubResourceModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics WritableSubResourceModel1sClientDiagnostics => _writableSubResourceModel1sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private WritableSubResourceModel1SRestOperations WritableSubResourceModel1sRestClient => _writableSubResourceModel1sRestClient ??= new WritableSubResourceModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics WritableSubResourceModel2sClientDiagnostics => _writableSubResourceModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private WritableSubResourceModel2SRestOperations WritableSubResourceModel2sRestClient => _writableSubResourceModel2sRestClient ??= new WritableSubResourceModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics ResourceModel2sClientDiagnostics => _resourceModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private ResourceModel2SRestOperations ResourceModel2sRestClient => _resourceModel2sRestClient ??= new ResourceModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics TrackedResourceModel2sClientDiagnostics => _trackedResourceModel2sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private TrackedResourceModel2SRestOperations TrackedResourceModel2sRestClient => _trackedResourceModel2sRestClient ??= new TrackedResourceModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics NonResourceModel1sClientDiagnostics => _nonResourceModel1sClientDiagnostics ??= new ClientDiagnostics("MgmtSupersetFlattenInheritance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private NonResourceModel1SRestOperations NonResourceModel1sRestClient => _nonResourceModel1sRestClient ??= new NonResourceModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ResourceModel1Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResourceModel1Resources and their operations over a ResourceModel1Resource. </returns>
        public virtual ResourceModel1Collection GetResourceModel1s()
        {
            return GetCachedClient(Client => new ResourceModel1Collection(Client, Id));
        }

        /// <summary> Gets a collection of TrackedResourceModel1Resources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of TrackedResourceModel1Resources and their operations over a TrackedResourceModel1Resource. </returns>
        public virtual TrackedResourceModel1Collection GetTrackedResourceModel1s()
        {
            return GetCachedClient(Client => new TrackedResourceModel1Collection(Client, Id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CustomModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CustomModel1> GetCustomModel1sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CustomModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, CustomModel1.DeserializeCustomModel1, CustomModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetCustomModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CustomModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CustomModel1> GetCustomModel1s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CustomModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, CustomModel1.DeserializeCustomModel1, CustomModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetCustomModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="customModel1"> The CustomModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CustomModel1>> PutCustomModel1Async(string customModel1SName, CustomModel1 customModel1, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutCustomModel1");
            scope.Start();
            try
            {
                var response = await CustomModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, customModel1SName, customModel1, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="customModel1"> The CustomModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CustomModel1> PutCustomModel1(string customModel1SName, CustomModel1 customModel1, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutCustomModel1");
            scope.Start();
            try
            {
                var response = CustomModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, customModel1SName, customModel1, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CustomModel1>> GetCustomModel1Async(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetCustomModel1");
            scope.Start();
            try
            {
                var response = await CustomModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, customModel1SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel1s/{customModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CustomModel1> GetCustomModel1(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetCustomModel1");
            scope.Start();
            try
            {
                var response = CustomModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, customModel1SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CustomModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CustomModel2> GetCustomModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CustomModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, CustomModel2.DeserializeCustomModel2, CustomModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetCustomModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CustomModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CustomModel2> GetCustomModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CustomModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, CustomModel2.DeserializeCustomModel2, CustomModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetCustomModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="customModel2"> The CustomModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CustomModel2>> PutCustomModel2Async(string customModel2SName, CustomModel2 customModel2, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutCustomModel2");
            scope.Start();
            try
            {
                var response = await CustomModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, customModel2SName, customModel2, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="customModel2"> The CustomModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CustomModel2> PutCustomModel2(string customModel2SName, CustomModel2 customModel2, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutCustomModel2");
            scope.Start();
            try
            {
                var response = CustomModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, customModel2SName, customModel2, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CustomModel2>> GetCustomModel2Async(string customModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetCustomModel2");
            scope.Start();
            try
            {
                var response = await CustomModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, customModel2SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/customModel2s/{customModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CustomModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="customModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CustomModel2> GetCustomModel2(string customModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = CustomModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetCustomModel2");
            scope.Start();
            try
            {
                var response = CustomModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, customModel2SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubResourceModel1> GetSubResourceModel1sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SubResourceModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, SubResourceModel1.DeserializeSubResourceModel1, SubResourceModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetSubResourceModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubResourceModel1> GetSubResourceModel1s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SubResourceModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, SubResourceModel1.DeserializeSubResourceModel1, SubResourceModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetSubResourceModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="subResourceModel1"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SubResourceModel1>> PutSubResourceModel1Async(string subResourceModel1SName, SubResourceModel1 subResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSubResourceModel1");
            scope.Start();
            try
            {
                var response = await SubResourceModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel1SName, subResourceModel1, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="subResourceModel1"> The SubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubResourceModel1> PutSubResourceModel1(string subResourceModel1SName, SubResourceModel1 subResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSubResourceModel1");
            scope.Start();
            try
            {
                var response = SubResourceModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel1SName, subResourceModel1, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SubResourceModel1>> GetSubResourceModel1Async(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSubResourceModel1");
            scope.Start();
            try
            {
                var response = await SubResourceModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel1SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel1s/{subResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubResourceModel1> GetSubResourceModel1(string subResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSubResourceModel1");
            scope.Start();
            try
            {
                var response = SubResourceModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel1SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubResourceModel2> GetSubResourceModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SubResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, SubResourceModel2.DeserializeSubResourceModel2, SubResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetSubResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubResourceModel2> GetSubResourceModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SubResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, SubResourceModel2.DeserializeSubResourceModel2, SubResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetSubResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="subResourceModel2"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SubResourceModel2>> PutSubResourceModel2Async(string subResourceModel2SName, SubResourceModel2 subResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSubResourceModel2");
            scope.Start();
            try
            {
                var response = await SubResourceModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel2SName, subResourceModel2, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="subResourceModel2"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubResourceModel2> PutSubResourceModel2(string subResourceModel2SName, SubResourceModel2 subResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutSubResourceModel2");
            scope.Start();
            try
            {
                var response = SubResourceModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel2SName, subResourceModel2, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SubResourceModel2>> GetSubResourceModel2Async(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSubResourceModel2");
            scope.Start();
            try
            {
                var response = await SubResourceModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel2SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/subResourceModel2s/{subResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubResourceModel2> GetSubResourceModel2(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = SubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetSubResourceModel2");
            scope.Start();
            try
            {
                var response = SubResourceModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, subResourceModel2SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WritableSubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WritableSubResourceModel1> GetWritableSubResourceModel1sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => WritableSubResourceModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, WritableSubResourceModel1.DeserializeWritableSubResourceModel1, WritableSubResourceModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetWritableSubResourceModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WritableSubResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WritableSubResourceModel1> GetWritableSubResourceModel1s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => WritableSubResourceModel1sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, WritableSubResourceModel1.DeserializeWritableSubResourceModel1, WritableSubResourceModel1sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetWritableSubResourceModel1s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="writableSubResourceModel1"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WritableSubResourceModel1>> PutWritableSubResourceModel1Async(string writableSubResourceModel1SName, WritableSubResourceModel1 writableSubResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutWritableSubResourceModel1");
            scope.Start();
            try
            {
                var response = await WritableSubResourceModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel1SName, writableSubResourceModel1, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="writableSubResourceModel1"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WritableSubResourceModel1> PutWritableSubResourceModel1(string writableSubResourceModel1SName, WritableSubResourceModel1 writableSubResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutWritableSubResourceModel1");
            scope.Start();
            try
            {
                var response = WritableSubResourceModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel1SName, writableSubResourceModel1, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WritableSubResourceModel1>> GetWritableSubResourceModel1Async(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetWritableSubResourceModel1");
            scope.Start();
            try
            {
                var response = await WritableSubResourceModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel1s/{writableSubResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WritableSubResourceModel1> GetWritableSubResourceModel1(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetWritableSubResourceModel1");
            scope.Start();
            try
            {
                var response = WritableSubResourceModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WritableSubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WritableSubResourceModel2> GetWritableSubResourceModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => WritableSubResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, WritableSubResourceModel2.DeserializeWritableSubResourceModel2, WritableSubResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetWritableSubResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WritableSubResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WritableSubResourceModel2> GetWritableSubResourceModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => WritableSubResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, WritableSubResourceModel2.DeserializeWritableSubResourceModel2, WritableSubResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetWritableSubResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="writableSubResourceModel2"> The WritableSubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WritableSubResourceModel2>> PutWritableSubResourceModel2Async(string writableSubResourceModel2SName, WritableSubResourceModel2 writableSubResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutWritableSubResourceModel2");
            scope.Start();
            try
            {
                var response = await WritableSubResourceModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel2SName, writableSubResourceModel2, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="writableSubResourceModel2"> The WritableSubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WritableSubResourceModel2> PutWritableSubResourceModel2(string writableSubResourceModel2SName, WritableSubResourceModel2 writableSubResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutWritableSubResourceModel2");
            scope.Start();
            try
            {
                var response = WritableSubResourceModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel2SName, writableSubResourceModel2, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WritableSubResourceModel2>> GetWritableSubResourceModel2Async(string writableSubResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetWritableSubResourceModel2");
            scope.Start();
            try
            {
                var response = await WritableSubResourceModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel2SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/writableSubResourceModel2s/{writableSubResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WritableSubResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="writableSubResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WritableSubResourceModel2> GetWritableSubResourceModel2(string writableSubResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = WritableSubResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetWritableSubResourceModel2");
            scope.Start();
            try
            {
                var response = WritableSubResourceModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, writableSubResourceModel2SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceModel2> GetResourceModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, ResourceModel2.DeserializeResourceModel2, ResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceModel2> GetResourceModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, ResourceModel2.DeserializeResourceModel2, ResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="resourceModel2"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceModel2>> PutResourceModel2Async(string resourceModel2SName, ResourceModel2 resourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = ResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutResourceModel2");
            scope.Start();
            try
            {
                var response = await ResourceModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel2SName, resourceModel2, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="resourceModel2"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceModel2> PutResourceModel2(string resourceModel2SName, ResourceModel2 resourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = ResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutResourceModel2");
            scope.Start();
            try
            {
                var response = ResourceModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, resourceModel2SName, resourceModel2, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceModel2>> GetResourceModel2Async(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = ResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetResourceModel2");
            scope.Start();
            try
            {
                var response = await ResourceModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel2SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel2s/{resourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceModel2> GetResourceModel2(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = ResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetResourceModel2");
            scope.Start();
            try
            {
                var response = ResourceModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceModel2SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TrackedResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TrackedResourceModel2> GetTrackedResourceModel2sAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TrackedResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, TrackedResourceModel2.DeserializeTrackedResourceModel2, TrackedResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetTrackedResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TrackedResourceModel2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TrackedResourceModel2> GetTrackedResourceModel2s(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TrackedResourceModel2sRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, TrackedResourceModel2.DeserializeTrackedResourceModel2, TrackedResourceModel2sClientDiagnostics, Pipeline, "ResourceGroupResourceExtensionClient.GetTrackedResourceModel2s", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="trackedResourceModel2"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrackedResourceModel2>> PutTrackedResourceModel2Async(string trackedResourceModel2SName, TrackedResourceModel2 trackedResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = TrackedResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutTrackedResourceModel2");
            scope.Start();
            try
            {
                var response = await TrackedResourceModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel2SName, trackedResourceModel2, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="trackedResourceModel2"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrackedResourceModel2> PutTrackedResourceModel2(string trackedResourceModel2SName, TrackedResourceModel2 trackedResourceModel2, CancellationToken cancellationToken = default)
        {
            using var scope = TrackedResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutTrackedResourceModel2");
            scope.Start();
            try
            {
                var response = TrackedResourceModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel2SName, trackedResourceModel2, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TrackedResourceModel2>> GetTrackedResourceModel2Async(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = TrackedResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetTrackedResourceModel2");
            scope.Start();
            try
            {
                var response = await TrackedResourceModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/trackedResourceModel2s/{trackedResourceModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TrackedResourceModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TrackedResourceModel2> GetTrackedResourceModel2(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = TrackedResourceModel2sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetTrackedResourceModel2");
            scope.Start();
            try
            {
                var response = TrackedResourceModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="nonResourceModel1"> The NonResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NonResourceModel1>> PutNonResourceModel1Async(string nonResourceModel1SName, NonResourceModel1 nonResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = NonResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutNonResourceModel1");
            scope.Start();
            try
            {
                var response = await NonResourceModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, nonResourceModel1SName, nonResourceModel1, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="nonResourceModel1"> The NonResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NonResourceModel1> PutNonResourceModel1(string nonResourceModel1SName, NonResourceModel1 nonResourceModel1, CancellationToken cancellationToken = default)
        {
            using var scope = NonResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.PutNonResourceModel1");
            scope.Start();
            try
            {
                var response = NonResourceModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, nonResourceModel1SName, nonResourceModel1, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NonResourceModel1>> GetNonResourceModel1Async(string nonResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = NonResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetNonResourceModel1");
            scope.Start();
            try
            {
                var response = await NonResourceModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, nonResourceModel1SName, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/nonResourceModel1s/{nonResourceModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NonResourceModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nonResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NonResourceModel1> GetNonResourceModel1(string nonResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = NonResourceModel1sClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetNonResourceModel1");
            scope.Start();
            try
            {
                var response = NonResourceModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, nonResourceModel1SName, cancellationToken);
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
