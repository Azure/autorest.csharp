// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Pagination
{
    /// <summary>
    /// A Class representing a PageSizeIntegerModel along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="PageSizeIntegerModelResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetPageSizeIntegerModelResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetPageSizeIntegerModel method.
    /// </summary>
    public partial class PageSizeIntegerModelResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PageSizeIntegerModelResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _pageSizeIntegerModelClientDiagnostics;
        private readonly PageSizeIntegerModelsRestOperations _pageSizeIntegerModelRestClient;
        private readonly PageSizeIntegerModelData _data;

        /// <summary> Initializes a new instance of the <see cref="PageSizeIntegerModelResource"/> class for mocking. </summary>
        protected PageSizeIntegerModelResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PageSizeIntegerModelResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PageSizeIntegerModelResource(ArmClient client, PageSizeIntegerModelData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeIntegerModelResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PageSizeIntegerModelResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeIntegerModelClientDiagnostics = new ClientDiagnostics("Pagination", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string pageSizeIntegerModelApiVersion);
            _pageSizeIntegerModelRestClient = new PageSizeIntegerModelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, pageSizeIntegerModelApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/pageSizeIntegerModel";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PageSizeIntegerModelData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PageSizeIntegerModelResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelResource.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeIntegerModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeIntegerModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PageSizeIntegerModelResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelResource.Get");
            scope.Start();
            try
            {
                var response = _pageSizeIntegerModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeIntegerModelResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
