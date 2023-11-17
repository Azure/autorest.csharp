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

namespace MgmtExtensionResource
{
    /// <summary>
    /// A Class representing a BuiltInPolicyDefinition along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="BuiltInPolicyDefinitionResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetBuiltInPolicyDefinitionResource method.
    /// Otherwise you can get one from its parent resource <see cref="TenantResource"/> using the GetBuiltInPolicyDefinition method.
    /// </summary>
    public partial class BuiltInPolicyDefinitionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BuiltInPolicyDefinitionResource"/> instance. </summary>
        /// <param name="policyDefinitionName"> The policyDefinitionName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string policyDefinitionName)
        {
            var resourceId = $"/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics;
        private readonly PolicyDefinitionsRestOperations _builtInPolicyDefinitionPolicyDefinitionsRestClient;
        private readonly PolicyDefinitionData _data;

        /// <summary> Initializes a new instance of the <see cref="BuiltInPolicyDefinitionResource"/> class for mocking. </summary>
        protected BuiltInPolicyDefinitionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BuiltInPolicyDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BuiltInPolicyDefinitionResource(ArmClient client, PolicyDefinitionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BuiltInPolicyDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BuiltInPolicyDefinitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics = new ClientDiagnostics("MgmtExtensionResource", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string builtInPolicyDefinitionPolicyDefinitionsApiVersion);
            _builtInPolicyDefinitionPolicyDefinitionsRestClient = new PolicyDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, builtInPolicyDefinitionPolicyDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/policyDefinitions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PolicyDefinitionData Data
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
        /// This operation retrieves the built-in policy definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BuiltInPolicyDefinitionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionResource.Get");
            scope.Start();
            try
            {
                var response = await _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltInAsync(Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BuiltInPolicyDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the built-in policy definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BuiltInPolicyDefinitionResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionResource.Get");
            scope.Start();
            try
            {
                var response = _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltIn(Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BuiltInPolicyDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
