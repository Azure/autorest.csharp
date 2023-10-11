// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using MgmtResourceName;

namespace MgmtResourceName.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MgmtResourceNameTenantMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtResourceNameTenantMockingExtension"/> class for mocking. </summary>
        protected MgmtResourceNameTenantMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtResourceNameTenantMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtResourceNameTenantMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ProviderOperationResources in the TenantResource. </summary>
        /// <returns> An object representing collection of ProviderOperationResources and their operations over a ProviderOperationResource. </returns>
        public virtual ProviderOperationCollection GetProviderOperations()
        {
            return GetCachedClient(client => new ProviderOperationCollection(client, Id));
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ProviderOperationResource>> GetProviderOperationAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetProviderOperations().GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ProviderOperationResource> GetProviderOperation(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetProviderOperations().Get(resourceProviderNamespace, expand, cancellationToken);
        }
    }
}
