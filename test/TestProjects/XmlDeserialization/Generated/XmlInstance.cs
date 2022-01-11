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
using XmlDeserialization.Models;

namespace XmlDeserialization
{
    /// <summary> A Class representing a XmlInstance along with the instance operations that can be performed on it. </summary>
    public partial class XmlInstance : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="XmlInstance"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string xmlName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly XmlDeserializationRestOperations _xmlDeserializationRestClient;
        private readonly XmlInstanceData _data;

        /// <summary> Initializes a new instance of the <see cref="XmlInstance"/> class for mocking. </summary>
        protected XmlInstance()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "XmlInstance"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal XmlInstance(ArmResource options, ResourceIdentifier id, XmlInstanceData data) : base(options, id)
        {
            HasData = true;
            _data = data;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _xmlDeserializationRestClient = new XmlDeserializationRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="XmlInstance"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal XmlInstance(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _xmlDeserializationRestClient = new XmlDeserializationRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="XmlInstance"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal XmlInstance(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _xmlDeserializationRestClient = new XmlDeserializationRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.XmlDeserialization/xmls";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual XmlInstanceData Data
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
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_Get
        /// <summary> Gets the details of the Xml specified by its identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<XmlInstance>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstance.Get");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new XmlInstance(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_Get
        /// <summary> Gets the details of the Xml specified by its identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<XmlInstance> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstance.Get");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new XmlInstance(this, response.Value.Id, response.Value), response.GetRawResponse());
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
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_Delete
        /// <summary> Deletes specific Xml. </summary>
        /// <param name="ifMatch"> ETag of the Entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<XmlDeserializationDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstance.Delete");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new XmlDeserializationDeleteOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_Delete
        /// <summary> Deletes specific Xml. </summary>
        /// <param name="ifMatch"> ETag of the Entity. ETag should match the current entity state from the header response of the GET request or it should be * for unconditional update. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual XmlDeserializationDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstance.Delete");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, cancellationToken);
                var operation = new XmlDeserializationDeleteOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_GetEntityTag
        /// <summary> Gets the entity state (Etag) version of the Xml specified by its identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstance.GetEntityTag");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.GetEntityTagAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// OperationId: XmlDeserialization_GetEntityTag
        /// <summary> Gets the entity state (Etag) version of the Xml specified by its identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstance.GetEntityTag");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.GetEntityTag(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
