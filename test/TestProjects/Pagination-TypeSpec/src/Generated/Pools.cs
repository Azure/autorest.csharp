// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Pagination.Models;

namespace Pagination
{
    // Data plane generated sub-client.
    /// <summary> The Pools sub-client. </summary>
    public partial class Pools
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://pagination.azure.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Pools for mocking. </summary>
        protected Pools()
        {
        }

        /// <summary> Initializes a new instance of Pools. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Pagination Service. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal Pools(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Lists all of the Pools in the specified Account. </summary>
        /// <param name="filter">
        /// An OData $filter clause. For more information on constructing this filter, see
        /// https://docs.microsoft.com/en-us/rest/api/batchservice/odata-filters-in-batch#list-pools.
        /// </param>
        /// <param name="select"> An OData $select clause. </param>
        /// <param name="expand"> An OData $expand clause. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pools.xml" path="doc/members/member[@name='GetPoolsAsync(string,IEnumerable{string},IEnumerable{string},CancellationToken)']/*" />
        public virtual AsyncPageable<BatchPool> GetPoolsAsync(string filter = null, IEnumerable<string> select = null, IEnumerable<string> expand = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPoolsRequest(filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPoolsNextPageRequest(nextLink, filter, select, expand, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BatchPool.DeserializeBatchPool(e), ClientDiagnostics, _pipeline, "Pools.GetPools", "value", "odata.nextLink", context);
        }

        /// <summary> Lists all of the Pools in the specified Account. </summary>
        /// <param name="filter">
        /// An OData $filter clause. For more information on constructing this filter, see
        /// https://docs.microsoft.com/en-us/rest/api/batchservice/odata-filters-in-batch#list-pools.
        /// </param>
        /// <param name="select"> An OData $select clause. </param>
        /// <param name="expand"> An OData $expand clause. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pools.xml" path="doc/members/member[@name='GetPools(string,IEnumerable{string},IEnumerable{string},CancellationToken)']/*" />
        public virtual Pageable<BatchPool> GetPools(string filter = null, IEnumerable<string> select = null, IEnumerable<string> expand = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPoolsRequest(filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPoolsNextPageRequest(nextLink, filter, select, expand, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BatchPool.DeserializeBatchPool(e), ClientDiagnostics, _pipeline, "Pools.GetPools", "value", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists all of the Pools in the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPoolsAsync(string,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter">
        /// An OData $filter clause. For more information on constructing this filter, see
        /// https://docs.microsoft.com/en-us/rest/api/batchservice/odata-filters-in-batch#list-pools.
        /// </param>
        /// <param name="select"> An OData $select clause. </param>
        /// <param name="expand"> An OData $expand clause. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Pools.xml" path="doc/members/member[@name='GetPoolsAsync(string,IEnumerable{string},IEnumerable{string},RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPoolsAsync(string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPoolsRequest(filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPoolsNextPageRequest(nextLink, filter, select, expand, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Pools.GetPools", "value", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists all of the Pools in the specified Account.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPools(string,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter">
        /// An OData $filter clause. For more information on constructing this filter, see
        /// https://docs.microsoft.com/en-us/rest/api/batchservice/odata-filters-in-batch#list-pools.
        /// </param>
        /// <param name="select"> An OData $select clause. </param>
        /// <param name="expand"> An OData $expand clause. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Pools.xml" path="doc/members/member[@name='GetPools(string,IEnumerable{string},IEnumerable{string},RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPools(string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPoolsRequest(filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPoolsNextPageRequest(nextLink, filter, select, expand, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Pools.GetPools", "value", "odata.nextLink", context);
        }

        internal HttpMessage CreateGetPoolsRequest(string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/app/pools", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (select != null && !(select is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("$select", select, ",", true);
            }
            if (expand != null && !(expand is ChangeTrackingList<string> changeTrackingList0 && changeTrackingList0.IsUndefined))
            {
                uri.AppendQueryDelimited("$expand", expand, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPoolsNextPageRequest(string nextLink, string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
