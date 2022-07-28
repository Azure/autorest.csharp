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

namespace MgmtResourceName
{
    /// <summary>
    /// A Class representing a ProviderOperation along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ProviderOperationResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetProviderOperationResource method.
    /// Otherwise you can get one from its parent resource <see cref="TenantResource" /> using the GetProviderOperation method.
    /// </summary>
    public partial class ProviderOperationResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ProviderOperationResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string resourceProviderNamespace)
        {
            var resourceId = $"/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _providerOperationClientDiagnostics;
        private readonly ProviderRestOperations _providerOperationRestClient;
        private readonly ProviderOperationData _data;

        /// <summary> Initializes a new instance of the <see cref="ProviderOperationResource"/> class for mocking. </summary>
        protected ProviderOperationResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ProviderOperationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ProviderOperationResource(ArmClient client, ProviderOperationData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ProviderOperationResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ProviderOperationResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _providerOperationClientDiagnostics = new ClientDiagnostics("MgmtResourceName", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string providerOperationApiVersion);
            _providerOperationRestClient = new ProviderRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, providerOperationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/providerOperations";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ProviderOperationData Data
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
        /// Gets provider operations metadata for the specified resource provider.
        /// Request Path: /providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}
        /// Operation Id: ProviderOperations_Get
        /// </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ProviderOperationResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationResource.Get");
            scope.Start();
            try
            {
                var response = await _providerOperationRestClient.GetAsync(Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProviderOperationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// Request Path: /providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}
        /// Operation Id: ProviderOperations_Get
        /// </summary>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ProviderOperationResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _providerOperationClientDiagnostics.CreateScope("ProviderOperationResource.Get");
            scope.Start();
            try
            {
                var response = _providerOperationRestClient.Get(Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProviderOperationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
