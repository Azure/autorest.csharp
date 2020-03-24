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
    internal partial class DataSourcesRestClient
    {
        private string searchServiceName;
        private string searchDnsSuffix;
        private string apiVersion;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;

        /// <summary> Initializes a new instance of DataSourcesRestClient. </summary>
        public DataSourcesRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string searchServiceName, string searchDnsSuffix = "search.windows.net", string apiVersion = "2019-05-06")
        {
            if (searchServiceName == null)
            {
                throw new ArgumentNullException(nameof(searchServiceName));
            }
            if (searchDnsSuffix == null)
            {
                throw new ArgumentNullException(nameof(searchDnsSuffix));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.searchServiceName = searchServiceName;
            this.searchDnsSuffix = searchDnsSuffix;
            this.apiVersion = apiVersion;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, DataSource dataSource)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(searchServiceName, false);
            uri.AppendRaw(".", false);
            uri.AppendRaw(searchDnsSuffix, false);
            uri.AppendPath("/datasources('", false);
            uri.AppendPath(dataSourceName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId.Value);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Prefer", "return=representation");
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(dataSource);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new datasource or updates a datasource if it already exists. </summary>
        /// <param name="dataSourceName"> The name of the datasource to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="dataSource"> The definition of the datasource to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DataSource>> CreateOrUpdateAsync(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, DataSource dataSource, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }
            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = CreateCreateOrUpdateRequest(dataSourceName, clientRequestId, ifMatch, ifNoneMatch, dataSource);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            DataSource value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new datasource or updates a datasource if it already exists. </summary>
        /// <param name="dataSourceName"> The name of the datasource to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="dataSource"> The definition of the datasource to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DataSource> CreateOrUpdate(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, DataSource dataSource, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }
            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = CreateCreateOrUpdateRequest(dataSourceName, clientRequestId, ifMatch, ifNoneMatch, dataSource);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            DataSource value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteRequest(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(searchServiceName, false);
            uri.AppendRaw(".", false);
            uri.AppendRaw(searchDnsSuffix, false);
            uri.AppendPath("/datasources('", false);
            uri.AppendPath(dataSourceName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId.Value);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            return message;
        }

        /// <summary> Deletes a datasource. </summary>
        /// <param name="dataSourceName"> The name of the datasource to delete. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(dataSourceName, clientRequestId, ifMatch, ifNoneMatch);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a datasource. </summary>
        /// <param name="dataSourceName"> The name of the datasource to delete. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string dataSourceName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(dataSourceName, clientRequestId, ifMatch, ifNoneMatch);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetRequest(string dataSourceName, Guid? clientRequestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(searchServiceName, false);
            uri.AppendRaw(".", false);
            uri.AppendRaw(searchDnsSuffix, false);
            uri.AppendPath("/datasources('", false);
            uri.AppendPath(dataSourceName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId.Value);
            }
            return message;
        }

        /// <summary> Retrieves a datasource definition. </summary>
        /// <param name="dataSourceName"> The name of the datasource to retrieve. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DataSource>> GetAsync(string dataSourceName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest(dataSourceName, clientRequestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            DataSource value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves a datasource definition. </summary>
        /// <param name="dataSourceName"> The name of the datasource to retrieve. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DataSource> Get(string dataSourceName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            if (dataSourceName == null)
            {
                throw new ArgumentNullException(nameof(dataSourceName));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest(dataSourceName, clientRequestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            DataSource value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateListRequest(string select, Guid? clientRequestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(searchServiceName, false);
            uri.AppendRaw(".", false);
            uri.AppendRaw(searchDnsSuffix, false);
            uri.AppendPath("/datasources", false);
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId.Value);
            }
            return message;
        }

        /// <summary> Lists all datasources available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListDataSourcesResult>> ListAsync(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.List");
            scope.Start();
            try
            {
                using var message = CreateListRequest(select, clientRequestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            ListDataSourcesResult value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = ListDataSourcesResult.DeserializeListDataSourcesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all datasources available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListDataSourcesResult> List(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.List");
            scope.Start();
            try
            {
                using var message = CreateListRequest(select, clientRequestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            ListDataSourcesResult value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = ListDataSourcesResult.DeserializeListDataSourcesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateRequest(Guid? clientRequestId, DataSource dataSource)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(searchServiceName, false);
            uri.AppendRaw(".", false);
            uri.AppendRaw(searchDnsSuffix, false);
            uri.AppendPath("/datasources", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId.Value);
            }
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(dataSource);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new datasource. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="dataSource"> The definition of the datasource to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DataSource>> CreateAsync(Guid? clientRequestId, DataSource dataSource, CancellationToken cancellationToken = default)
        {
            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(clientRequestId, dataSource);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            DataSource value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new datasource. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="dataSource"> The definition of the datasource to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DataSource> Create(Guid? clientRequestId, DataSource dataSource, CancellationToken cancellationToken = default)
        {
            if (dataSource == null)
            {
                throw new ArgumentNullException(nameof(dataSource));
            }

            using var scope = clientDiagnostics.CreateScope("DataSourcesClient.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(clientRequestId, dataSource);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            DataSource value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = DataSource.DeserializeDataSource(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
