// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a EncryptionScope along with the instance operations that can be performed on it. </summary>
    public partial class EncryptionScope : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="EncryptionScope"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string encryptionScopeName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly EncryptionScopesRestOperations _encryptionScopesRestClient;
        private readonly EncryptionScopeData _data;

        /// <summary> Initializes a new instance of the <see cref="EncryptionScope"/> class for mocking. </summary>
        protected EncryptionScope()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "EncryptionScope"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal EncryptionScope(ArmResource options, EncryptionScopeData resource) : base(options, resource.Id)
        {
            HasData = true;
            _data = resource;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _encryptionScopesRestClient = new EncryptionScopesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="EncryptionScope"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal EncryptionScope(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _encryptionScopesRestClient = new EncryptionScopesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="EncryptionScope"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal EncryptionScope(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _encryptionScopesRestClient = new EncryptionScopesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/encryptionScopes";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual EncryptionScopeData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// OperationId: EncryptionScopes_Get
        /// <summary> Returns the properties for the specified encryption scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<EncryptionScope>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("EncryptionScope.Get");
            scope.Start();
            try
            {
                var response = await _encryptionScopesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new EncryptionScope(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// OperationId: EncryptionScopes_Get
        /// <summary> Returns the properties for the specified encryption scope. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EncryptionScope> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("EncryptionScope.Get");
            scope.Start();
            try
            {
                var response = _encryptionScopesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EncryptionScope(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<Location>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<Location> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// OperationId: EncryptionScopes_Patch
        /// <summary> Update encryption scope properties as specified in the request body. Update fails if the specified encryption scope does not already exist. </summary>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScope"/> is null. </exception>
        public async virtual Task<Response<EncryptionScope>> UpdateAsync(EncryptionScopeData encryptionScope, CancellationToken cancellationToken = default)
        {
            if (encryptionScope == null)
            {
                throw new ArgumentNullException(nameof(encryptionScope));
            }

            using var scope = _clientDiagnostics.CreateScope("EncryptionScope.Update");
            scope.Start();
            try
            {
                var response = await _encryptionScopesRestClient.PatchAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, encryptionScope, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new EncryptionScope(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// OperationId: EncryptionScopes_Patch
        /// <summary> Update encryption scope properties as specified in the request body. Update fails if the specified encryption scope does not already exist. </summary>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScope"/> is null. </exception>
        public virtual Response<EncryptionScope> Update(EncryptionScopeData encryptionScope, CancellationToken cancellationToken = default)
        {
            if (encryptionScope == null)
            {
                throw new ArgumentNullException(nameof(encryptionScope));
            }

            using var scope = _clientDiagnostics.CreateScope("EncryptionScope.Update");
            scope.Start();
            try
            {
                var response = _encryptionScopesRestClient.Patch(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, encryptionScope, cancellationToken);
                return Response.FromValue(new EncryptionScope(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
