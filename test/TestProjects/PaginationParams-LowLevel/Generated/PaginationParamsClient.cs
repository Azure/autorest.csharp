// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace PaginationParams_LowLevel
{
    // Data plane generated client.
    /// <summary> The PaginationParams service client. </summary>
    public partial class PaginationParamsClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "user_impersonation" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PaginationParamsClient for mocking. </summary>
        protected PaginationParamsClient()
        {
        }

        /// <summary> Initializes a new instance of PaginationParamsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public PaginationParamsClient(TokenCredential credential) : this(credential, new Uri("https://management.azure.com"), new PaginationParamsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PaginationParamsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public PaginationParamsClient(TokenCredential credential, Uri endpoint, PaginationParamsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new PaginationParamsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="maxCount"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='GetPaginationParamsAsync(int?,int?,int?,global::Azure.RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPaginationParamsAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationParamsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationParamsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.GetPaginationParams", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="maxCount"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='GetPaginationParams(int?,int?,int?,global::Azure.RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPaginationParams(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationParamsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationParamsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.GetPaginationParams", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="limit"> Optional. Specified maximum number of total containers. </param>
        /// <param name="offset"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get2sAsync(int?,int?,long?,global::Azure.RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> Get2sAsync(int? limit = null, int? offset = null, long? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet2sRequest(limit, offset, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet2sNextPageRequest(nextLink, limit, offset, maxpagesize, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get2s", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="limit"> Optional. Specified maximum number of total containers. </param>
        /// <param name="offset"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get2s(int?,int?,long?,global::Azure.RequestContext)']/*" />
        public virtual Pageable<BinaryData> Get2s(int? limit = null, int? offset = null, long? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet2sRequest(limit, offset, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet2sNextPageRequest(nextLink, limit, offset, maxpagesize, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get2s", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="maxCount"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get3sAsync(int?,int?,int?,global::Azure.RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> Get3sAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet3sRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet3sNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get3s", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="maxCount"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get3s(int?,int?,int?,global::Azure.RequestContext)']/*" />
        public virtual Pageable<BinaryData> Get3s(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet3sRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet3sNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get3s", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="top"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxcount"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get4sAsync(int?,int?,float?,global::Azure.RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> Get4sAsync(int? top = null, int? skip = null, float? maxcount = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet4sRequest(top, skip, maxcount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet4sNextPageRequest(nextLink, top, skip, maxcount, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get4s", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="top"> Optional. Specified maximum number of total containers. </param>
        /// <param name="skip"> Optional. Specified number of containers to skip. </param>
        /// <param name="maxcount"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationParamsClient.xml" path="doc/members/member[@name='Get4s(int?,int?,float?,global::Azure.RequestContext)']/*" />
        public virtual Pageable<BinaryData> Get4s(int? top = null, int? skip = null, float? maxcount = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGet4sRequest(top, skip, maxcount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGet4sNextPageRequest(nextLink, top, skip, maxcount, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationParamsClient.Get4s", "value", "nextLink", context);
        }

        internal HttpMessage CreateGetPaginationParamsRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authoring/analyze-text/projects", false);
            if (maxCount != null)
            {
                uri.AppendQuery("top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet2sRequest(int? limit, int? offset, long? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authoring/analyze-language/projects", false);
            if (limit != null)
            {
                uri.AppendQuery("limit", limit.Value, true);
            }
            if (offset != null)
            {
                uri.AppendQuery("offset", offset.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet3sRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authoring/analyze-lyrics/projects", false);
            if (maxCount != null)
            {
                uri.AppendQuery("Top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet4sRequest(int? top, int? skip, float? maxcount, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authoring/analyze-song/projects", false);
            if (top != null)
            {
                uri.AppendQuery("top", top.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxcount != null)
            {
                uri.AppendQuery("maxcount", maxcount.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPaginationParamsNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
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

        internal HttpMessage CreateGet2sNextPageRequest(string nextLink, int? limit, int? offset, long? maxpagesize, RequestContext context)
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

        internal HttpMessage CreateGet3sNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
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

        internal HttpMessage CreateGet4sNextPageRequest(string nextLink, int? top, int? skip, float? maxcount, RequestContext context)
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

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
