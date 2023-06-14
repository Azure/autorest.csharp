// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.DocumentTranslation
{
    // Data plane generated client.
    /// <summary> The DocumentTranslation service client. </summary>
    public partial class DocumentTranslationClient
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of DocumentTranslationClient for mocking. </summary>
        protected DocumentTranslationClient()
        {
        }

        /// <summary> Initializes a new instance of DocumentTranslationClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoints (protocol and hostname, for example: https://westus.api.cognitive.microsoft.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public DocumentTranslationClient(string endpoint, AzureKeyCredential credential) : this(endpoint, credential, new DocumentTranslationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of DocumentTranslationClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoints (protocol and hostname, for example: https://westus.api.cognitive.microsoft.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public DocumentTranslationClient(string endpoint, AzureKeyCredential credential, DocumentTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new DocumentTranslationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Returns the status for a specific document
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The batch id. </param>
        /// <param name="documentId"> Format - uuid.  The document id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetDocumentStatusAsync(Guid,Guid,RequestContext)']/*" />
        public virtual async Task<Response> GetDocumentStatusAsync(Guid id, Guid documentId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetDocumentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDocumentStatusRequest(id, documentId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns the status for a specific document
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The batch id. </param>
        /// <param name="documentId"> Format - uuid.  The document id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetDocumentStatus(Guid,Guid,RequestContext)']/*" />
        public virtual Response GetDocumentStatus(Guid id, Guid documentId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetDocumentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDocumentStatusRequest(id, documentId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns the status for a document translation request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetTranslationStatusAsync(Guid,RequestContext)']/*" />
        public virtual async Task<Response> GetTranslationStatusAsync(Guid id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetTranslationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTranslationStatusRequest(id, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns the status for a document translation request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetTranslationStatus(Guid,RequestContext)']/*" />
        public virtual Response GetTranslationStatus(Guid id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetTranslationStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTranslationStatusRequest(id, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Cancel a currently processing or queued translation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation-id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='CancelTranslationAsync(Guid,RequestContext)']/*" />
        public virtual async Task<Response> CancelTranslationAsync(Guid id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.CancelTranslation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTranslationRequest(id, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Cancel a currently processing or queued translation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation-id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='CancelTranslation(Guid,RequestContext)']/*" />
        public virtual Response CancelTranslation(Guid id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.CancelTranslation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelTranslationRequest(id, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a list of supported document formats
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedDocumentFormatsAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetSupportedDocumentFormatsAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedDocumentFormats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedDocumentFormatsRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a list of supported document formats
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedDocumentFormats(RequestContext)']/*" />
        public virtual Response GetSupportedDocumentFormats(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedDocumentFormats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedDocumentFormatsRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns the list of supported glossary formats
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedGlossaryFormatsAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetSupportedGlossaryFormatsAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedGlossaryFormats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedGlossaryFormatsRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns the list of supported glossary formats
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedGlossaryFormats(RequestContext)']/*" />
        public virtual Response GetSupportedGlossaryFormats(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedGlossaryFormats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedGlossaryFormatsRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a list of supported storage sources
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedStorageSourcesAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetSupportedStorageSourcesAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedStorageSources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedStorageSourcesRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a list of supported storage sources
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetSupportedStorageSources(RequestContext)']/*" />
        public virtual Response GetSupportedStorageSources(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.GetSupportedStorageSources");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSupportedStorageSourcesRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top">
        /// $top indicates the total number of records the user wants to be returned across all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified.  By default, we sort by descending start time.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are requested via $top (or $top is not specified and there are more items to be returned), @nextLink will contain the link to the next page.
        ///
        /// Clients MAY request server-driven paging with a specific page size by specifying a $maxpagesize preference. The server SHOULD honor this preference if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc', 'CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetTranslationsStatusAsync(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetTranslationsStatusAsync(int? top = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationsStatus", "value", "@nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Returns a list of batch requests submitted and the status for each request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top">
        /// $top indicates the total number of records the user wants to be returned across all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified.  By default, we sort by descending start time.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are requested via $top (or $top is not specified and there are more items to be returned), @nextLink will contain the link to the next page.
        ///
        /// Clients MAY request server-driven paging with a specific page size by specifying a $maxpagesize preference. The server SHOULD honor this preference if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc', 'CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetTranslationsStatus(int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetTranslationsStatus(int? top = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTranslationsStatusRequest(top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTranslationsStatusNextPageRequest(nextLink, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetTranslationsStatus", "value", "@nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Returns the status for all documents in a batch document translation request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation id. </param>
        /// <param name="top">
        /// $top indicates the total number of records the user wants to be returned across all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified.  By default, we sort by descending start time.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are requested via $top (or $top is not specified and there are more items to be returned), @nextLink will contain the link to the next page.
        ///
        /// Clients MAY request server-driven paging with a specific page size by specifying a $maxpagesize preference. The server SHOULD honor this preference if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc', 'CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetDocumentsStatusAsync(Guid,int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetDocumentsStatusAsync(Guid id, int? top = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDocumentsStatusRequest(id, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDocumentsStatusNextPageRequest(nextLink, id, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetDocumentsStatus", "value", "@nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Returns the status for all documents in a batch document translation request
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Format - uuid.  The operation id. </param>
        /// <param name="top">
        /// $top indicates the total number of records the user wants to be returned across all pages.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="skip">
        /// $skip indicates the number of records to skip from the list of records held by the server based on the sorting method specified.  By default, we sort by descending start time.
        ///
        /// Clients MAY use $top and $skip query parameters to specify a number of results to return and an offset into the collection.
        /// When both $top and $skip are given by a client, the server SHOULD first apply $skip and then $top on the collection.
        ///
        /// Note: If the server can't honor $top and/or $skip, the server MUST return an error to the client informing about it instead of just ignoring the query options.
        /// </param>
        /// <param name="maxpagesize">
        /// $maxpagesize is the maximum items returned in a page.  If more items are requested via $top (or $top is not specified and there are more items to be returned), @nextLink will contain the link to the next page.
        ///
        /// Clients MAY request server-driven paging with a specific page size by specifying a $maxpagesize preference. The server SHOULD honor this preference if the specified page size is smaller than the server's default page size.
        /// </param>
        /// <param name="ids"> Ids to use in filtering. </param>
        /// <param name="statuses"> Statuses to use in filtering. </param>
        /// <param name="createdDateTimeUtcStart"> the start datetime to get items after. </param>
        /// <param name="createdDateTimeUtcEnd"> the end datetime to get items before. </param>
        /// <param name="orderBy"> the sorting query for the collection (ex: 'CreatedDateTimeUtc asc', 'CreatedDateTimeUtc desc'). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='GetDocumentsStatus(Guid,int?,int?,int?,IEnumerable{Guid},IEnumerable{string},DateTimeOffset?,DateTimeOffset?,IEnumerable{string},RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetDocumentsStatus(Guid id, int? top = null, int? skip = null, int? maxpagesize = null, IEnumerable<Guid> ids = null, IEnumerable<string> statuses = null, DateTimeOffset? createdDateTimeUtcStart = null, DateTimeOffset? createdDateTimeUtcEnd = null, IEnumerable<string> orderBy = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDocumentsStatusRequest(id, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDocumentsStatusNextPageRequest(nextLink, id, top, skip, maxpagesize, ids, statuses, createdDateTimeUtcStart, createdDateTimeUtcEnd, orderBy, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "DocumentTranslationClient.GetDocumentsStatus", "value", "@nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Submit a document translation request to the Document Translation service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Body Parameter content-type. Allowed values: "application/*+json" | "application/json" | "text/json". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='StartTranslationAsync(WaitUntil,RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Operation> StartTranslationAsync(WaitUntil waitUntil, RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.StartTranslation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStartTranslationRequest(content, contentType, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "DocumentTranslationClient.StartTranslation", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Submit a document translation request to the Document Translation service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Body Parameter content-type. Allowed values: "application/*+json" | "application/json" | "text/json". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/DocumentTranslationClient.xml" path="doc/members/member[@name='StartTranslation(WaitUntil,RequestContent,ContentType,RequestContext)']/*" />
        public virtual Operation StartTranslation(WaitUntil waitUntil, RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.StartTranslation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStartTranslationRequest(content, contentType, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "DocumentTranslationClient.StartTranslation", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateStartTranslationRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetTranslationsStatusRequest(int? top, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("$skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("$maxpagesize", maxpagesize.Value, true);
            }
            if (ids != null && Optional.IsCollectionDefined(ids))
            {
                uri.AppendQueryDelimited("ids", ids, ",", true);
            }
            if (statuses != null && Optional.IsCollectionDefined(statuses))
            {
                uri.AppendQueryDelimited("statuses", statuses, ",", true);
            }
            if (createdDateTimeUtcStart != null)
            {
                uri.AppendQuery("createdDateTimeUtcStart", createdDateTimeUtcStart.Value, "O", true);
            }
            if (createdDateTimeUtcEnd != null)
            {
                uri.AppendQuery("createdDateTimeUtcEnd", createdDateTimeUtcEnd.Value, "O", true);
            }
            if (orderBy != null && Optional.IsCollectionDefined(orderBy))
            {
                uri.AppendQueryDelimited("$orderBy", orderBy, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDocumentStatusRequest(Guid id, Guid documentId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/documents/", false);
            uri.AppendPath(documentId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTranslationStatusRequest(Guid id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCancelTranslationRequest(Guid id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDocumentsStatusRequest(Guid id, int? top, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/documents", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("$skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("$maxpagesize", maxpagesize.Value, true);
            }
            if (ids != null && Optional.IsCollectionDefined(ids))
            {
                uri.AppendQueryDelimited("ids", ids, ",", true);
            }
            if (statuses != null && Optional.IsCollectionDefined(statuses))
            {
                uri.AppendQueryDelimited("statuses", statuses, ",", true);
            }
            if (createdDateTimeUtcStart != null)
            {
                uri.AppendQuery("createdDateTimeUtcStart", createdDateTimeUtcStart.Value, "O", true);
            }
            if (createdDateTimeUtcEnd != null)
            {
                uri.AppendQuery("createdDateTimeUtcEnd", createdDateTimeUtcEnd.Value, "O", true);
            }
            if (orderBy != null && Optional.IsCollectionDefined(orderBy))
            {
                uri.AppendQueryDelimited("$orderBy", orderBy, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedDocumentFormatsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/documents/formats", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedGlossaryFormatsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/glossaries/formats", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedStorageSourcesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendPath("/storagesources", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTranslationsStatusNextPageRequest(string nextLink, int? top, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDocumentsStatusNextPageRequest(string nextLink, Guid id, int? top, int? skip, int? maxpagesize, IEnumerable<Guid> ids, IEnumerable<string> statuses, DateTimeOffset? createdDateTimeUtcStart, DateTimeOffset? createdDateTimeUtcEnd, IEnumerable<string> orderBy, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/translator/text/batch/v1.0-preview.1", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
