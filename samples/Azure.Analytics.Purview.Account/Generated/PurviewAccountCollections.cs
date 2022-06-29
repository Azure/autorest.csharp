// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Account
{
    /// <summary> The PurviewAccountCollections service client. </summary>
    public partial class PurviewAccountCollections
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://purview.azure.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The String to use. </summary>
        public string CollectionName { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PurviewAccountCollections for mocking. </summary>
        protected PurviewAccountCollections()
        {
        }

        /// <summary> Initializes a new instance of PurviewAccountCollections. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="collectionName"> The String to use. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal PurviewAccountCollections(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string collectionName, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            CollectionName = collectionName;
            _apiVersion = apiVersion;
        }

        /// <summary> Get a collection. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetCollectionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.GetCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCollectionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a collection. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response GetCollection(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.GetCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCollectionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a collection entity. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> CreateOrUpdateCollectionAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.CreateOrUpdateCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateCollectionRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a collection entity. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Collection</c>:
        /// <code>{
        ///   collectionProvisioningState: &quot;Unknown&quot; | &quot;Creating&quot; | &quot;Moving&quot; | &quot;Deleting&quot; | &quot;Failed&quot; | &quot;Succeeded&quot;, # Optional. Gets the state of the provisioning.
        ///   description: string, # Optional. Gets or sets the description.
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        ///   parentCollection: {
        ///     referenceName: string, # Optional. Gets or sets the reference name.
        ///     type: string, # Optional. Gets the reference type property.
        ///   }, # Optional. Gets or sets the parent collection reference.
        ///   systemData: {
        ///     createdAt: string (ISO 8601 Format), # Optional. The timestamp of resource creation (UTC).
        ///     createdBy: string, # Optional. The identity that created the resource.
        ///     createdByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that created the resource.
        ///     lastModifiedAt: string (ISO 8601 Format), # Optional. The timestamp of the last modification the resource (UTC).
        ///     lastModifiedBy: string, # Optional. The identity that last modified the resource.
        ///     lastModifiedByType: &quot;User&quot; | &quot;Application&quot; | &quot;ManagedIdentity&quot; | &quot;Key&quot;, # Optional. The type of identity that last modified the resource.
        ///   }, # Optional. Gets the system data that contains information about who and when created and updated the resource.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response CreateOrUpdateCollection(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.CreateOrUpdateCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateCollectionRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a Collection entity. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeleteCollectionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.DeleteCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteCollectionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a Collection entity. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeleteCollection(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.DeleteCollection");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteCollectionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the parent name and parent friendly name chains that represent the collection path. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionPathResponse</c>:
        /// <code>{
        ///   parentFriendlyNameChain: [string], # Optional. The friendly names of ancestors starting from the default (root) collection and ending with the immediate parent.
        ///   parentNameChain: [string], # Optional. The names of ancestors starting from the default (root) collection and ending with the immediate parent.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetCollectionPathAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.GetCollectionPath");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCollectionPathRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the parent name and parent friendly name chains that represent the collection path. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionPathResponse</c>:
        /// <code>{
        ///   parentFriendlyNameChain: [string], # Optional. The friendly names of ancestors starting from the default (root) collection and ending with the immediate parent.
        ///   parentNameChain: [string], # Optional. The names of ancestors starting from the default (root) collection and ending with the immediate parent.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response GetCollectionPath(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PurviewAccountCollections.GetCollectionPath");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCollectionPathRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists the child collections names in the collection. </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for one item in the pageable response.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionNameResponseListValue</c>:
        /// <code>{
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual AsyncPageable<BinaryData> GetChildCollectionNamesAsync(string skipToken = null, RequestContext context = null)
        {
            return GetChildCollectionNamesImplementationAsync("PurviewAccountCollections.GetChildCollectionNames", skipToken, context);
        }

        private AsyncPageable<BinaryData> GetChildCollectionNamesImplementationAsync(string diagnosticsScopeName, string skipToken, RequestContext context)
        {
            return PageableHelpers.CreateAsyncPageable(CreateEnumerableAsync, ClientDiagnostics, diagnosticsScopeName);
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerableAsync(string nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetChildCollectionNamesRequest(skipToken, context)
                        : CreateGetChildCollectionNamesNextPageRequest(nextLink, skipToken, context);
                    var page = await LowLevelPageableHelpers.ProcessMessageAsync(_pipeline, message, context, "value", "nextLink", cancellationToken).ConfigureAwait(false);
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        /// <summary> Lists the child collections names in the collection. </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <remarks>
        /// Below is the JSON schema for one item in the pageable response.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionNameResponseListValue</c>:
        /// <code>{
        ///   friendlyName: string, # Optional. Gets or sets the friendly name of the collection.
        ///   name: string, # Optional. Gets the name.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Pageable<BinaryData> GetChildCollectionNames(string skipToken = null, RequestContext context = null)
        {
            return GetChildCollectionNamesImplementation("PurviewAccountCollections.GetChildCollectionNames", skipToken, context);
        }

        private Pageable<BinaryData> GetChildCollectionNamesImplementation(string diagnosticsScopeName, string skipToken, RequestContext context)
        {
            return PageableHelpers.CreatePageable(CreateEnumerable, ClientDiagnostics, diagnosticsScopeName);
            IEnumerable<Page<BinaryData>> CreateEnumerable(string nextLink, int? pageSizeHint)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetChildCollectionNamesRequest(skipToken, context)
                        : CreateGetChildCollectionNamesNextPageRequest(nextLink, skipToken, context);
                    var page = LowLevelPageableHelpers.ProcessMessage(_pipeline, message, context, "value", "nextLink");
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        internal HttpMessage CreateGetCollectionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/collections/", false);
            uri.AppendPath(CollectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateOrUpdateCollectionRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/collections/", false);
            uri.AppendPath(CollectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteCollectionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/collections/", false);
            uri.AppendPath(CollectionName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetChildCollectionNamesRequest(string skipToken, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/collections/", false);
            uri.AppendPath(CollectionName, true);
            uri.AppendPath("/getChildCollectionNames", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (skipToken != null)
            {
                uri.AppendQuery("$skipToken", skipToken, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetCollectionPathRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/collections/", false);
            uri.AppendPath(CollectionName, true);
            uri.AppendPath("/getCollectionPath", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetChildCollectionNamesNextPageRequest(string nextLink, string skipToken, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
