// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    internal partial class IndexersRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of IndexersRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public IndexersRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-05-06-Preview")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
        }

        internal HttpMessage CreateResetRequest(string indexerName, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')/search.reset", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public async Task<Response> ResetAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateResetRequest(indexerName, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public Response Reset(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateResetRequest(indexerName, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRunRequest(string indexerName, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')/search.run", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to run. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public async Task<Response> RunAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateRunRequest(indexerName, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to run. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public Response Run(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateRunRequest(indexerName, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string indexerName, Enum0 prefer, Indexer indexer, RequestOptions requestOptions, AccessCondition accessCondition)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (accessCondition?.IfMatch != null)
            {
                request.Headers.Add("If-Match", accessCondition.IfMatch);
            }
            if (accessCondition?.IfNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", accessCondition.IfNoneMatch);
            }
            request.Headers.Add("Prefer", prefer.ToString());
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(indexer);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> or <paramref name="indexer"/> is null. </exception>
        public async Task<Response<Indexer>> CreateOrUpdateAsync(string indexerName, Enum0 prefer, Indexer indexer, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }
            if (indexer == null)
            {
                throw new ArgumentNullException(nameof(indexer));
            }

            using var message = CreateCreateOrUpdateRequest(indexerName, prefer, indexer, requestOptions, accessCondition);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        Indexer value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> or <paramref name="indexer"/> is null. </exception>
        public Response<Indexer> CreateOrUpdate(string indexerName, Enum0 prefer, Indexer indexer, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }
            if (indexer == null)
            {
                throw new ArgumentNullException(nameof(indexer));
            }

            using var message = CreateCreateOrUpdateRequest(indexerName, prefer, indexer, requestOptions, accessCondition);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        Indexer value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string indexerName, RequestOptions requestOptions, AccessCondition accessCondition)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (accessCondition?.IfMatch != null)
            {
                request.Headers.Add("If-Match", accessCondition.IfMatch);
            }
            if (accessCondition?.IfNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", accessCondition.IfNoneMatch);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public async Task<Response> DeleteAsync(string indexerName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateDeleteRequest(indexerName, requestOptions, accessCondition);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public Response Delete(string indexerName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateDeleteRequest(indexerName, requestOptions, accessCondition);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string indexerName, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public async Task<Response<Indexer>> GetAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateGetRequest(indexerName, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Indexer value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public Response<Indexer> Get(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateGetRequest(indexerName, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Indexer value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string select, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers", false);
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the indexers to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ListIndexersResult>> ListAsync(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(select, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListIndexersResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = ListIndexersResult.DeserializeListIndexersResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the indexers to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListIndexersResult> List(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListRequest(select, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListIndexersResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = ListIndexersResult.DeserializeListIndexersResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateRequest(Indexer indexer, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(indexer);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new indexer. </summary>
        /// <param name="indexer"> The definition of the indexer to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexer"/> is null. </exception>
        public async Task<Response<Indexer>> CreateAsync(Indexer indexer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexer == null)
            {
                throw new ArgumentNullException(nameof(indexer));
            }

            using var message = CreateCreateRequest(indexer, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        Indexer value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a new indexer. </summary>
        /// <param name="indexer"> The definition of the indexer to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexer"/> is null. </exception>
        public Response<Indexer> Create(Indexer indexer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexer == null)
            {
                throw new ArgumentNullException(nameof(indexer));
            }

            using var message = CreateCreateRequest(indexer, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        Indexer value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = Indexer.DeserializeIndexer(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStatusRequest(string indexerName, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/indexers('", false);
            uri.AppendPath(indexerName, true);
            uri.AppendPath("')/search.status", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer for which to retrieve status. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public async Task<Response<IndexerExecutionInfo>> GetStatusAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateGetStatusRequest(indexerName, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IndexerExecutionInfo value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = IndexerExecutionInfo.DeserializeIndexerExecutionInfo(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer for which to retrieve status. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public Response<IndexerExecutionInfo> GetStatus(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (indexerName == null)
            {
                throw new ArgumentNullException(nameof(indexerName));
            }

            using var message = CreateGetStatusRequest(indexerName, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IndexerExecutionInfo value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = IndexerExecutionInfo.DeserializeIndexerExecutionInfo(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
