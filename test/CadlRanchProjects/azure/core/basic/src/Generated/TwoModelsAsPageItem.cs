// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using _Specs_.Azure.Core.Basic.Models;

namespace _Specs_.Azure.Core.Basic
{
    // Data plane generated sub-client.
    /// <summary> The TwoModelsAsPageItem sub-client. </summary>
    public partial class TwoModelsAsPageItem
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of TwoModelsAsPageItem for mocking. </summary>
        protected TwoModelsAsPageItem()
        {
        }

        /// <summary> Initializes a new instance of TwoModelsAsPageItem. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal TwoModelsAsPageItem(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Two operations with two different page item types should be successfully generated. Should generate model for FirstItem. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetFirstItemsAsync(CancellationToken)']/*" />
        public virtual AsyncPageable<FirstItem> GetFirstItemsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFirstItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetFirstItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, FirstItem.DeserializeFirstItem, ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetFirstItems", "value", "nextLink", context);
        }

        /// <summary> Two operations with two different page item types should be successfully generated. Should generate model for FirstItem. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetFirstItems(CancellationToken)']/*" />
        public virtual Pageable<FirstItem> GetFirstItems(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFirstItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetFirstItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, FirstItem.DeserializeFirstItem, ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetFirstItems", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Two operations with two different page item types should be successfully generated. Should generate model for FirstItem.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstItemsAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetFirstItemsAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetFirstItemsAsync(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFirstItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetFirstItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetFirstItems", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Two operations with two different page item types should be successfully generated. Should generate model for FirstItem.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstItems(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetFirstItems(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetFirstItems(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFirstItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetFirstItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetFirstItems", "value", "nextLink", context);
        }

        /// <summary> Two operations with two different page item types should be successfully generated. Should generate model for SecondItem. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetSecondItemsAsync(CancellationToken)']/*" />
        public virtual AsyncPageable<SecondItem> GetSecondItemsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSecondItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSecondItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, SecondItem.DeserializeSecondItem, ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetSecondItems", "value", "nextLink", context);
        }

        /// <summary> Two operations with two different page item types should be successfully generated. Should generate model for SecondItem. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetSecondItems(CancellationToken)']/*" />
        public virtual Pageable<SecondItem> GetSecondItems(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSecondItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSecondItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, SecondItem.DeserializeSecondItem, ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetSecondItems", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Two operations with two different page item types should be successfully generated. Should generate model for SecondItem.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSecondItemsAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetSecondItemsAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetSecondItemsAsync(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSecondItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSecondItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetSecondItems", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Two operations with two different page item types should be successfully generated. Should generate model for SecondItem.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSecondItems(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TwoModelsAsPageItem.xml" path="doc/members/member[@name='GetSecondItems(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetSecondItems(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSecondItemsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSecondItemsNextPageRequest(nextLink, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TwoModelsAsPageItem.GetSecondItems", "value", "nextLink", context);
        }

        internal HttpMessage CreateGetFirstItemsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/first-item", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSecondItemsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/second-item", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetFirstItemsNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetSecondItemsNextPageRequest(string nextLink, RequestContext context)
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
