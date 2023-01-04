// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Pagination.Models;

namespace Pagination
{
    // Data plane generated client.
    /// <summary> The Pagination service client. </summary>
    public partial class PaginationClient
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

        /// <summary> Initializes a new instance of PaginationClient for mocking. </summary>
        protected PaginationClient()
        {
        }

        /// <summary> Initializes a new instance of PaginationClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public PaginationClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new PaginationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PaginationClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public PaginationClient(Uri endpoint, TokenCredential credential, PaginationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PaginationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Gets ledger entries from a collection corresponding to a range. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned. </remarks>
        public virtual AsyncPageable<LedgerEntry> GetPaginationLedgerEntryValuesAsync(CancellationToken cancellationToken = default)
        {
            var context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLedgerEntriesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetLedgerEntriesNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, LedgerEntry.DeserializeLedgerEntry, ClientDiagnostics, _pipeline, "PaginationClient.GetLedgerEntries", "value", "nextLink", context);
        }

        /// <summary> Gets ledger entries from a collection corresponding to a range. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned. </remarks>
        public virtual Pageable<LedgerEntry> GetPaginationLedgerEntryValues(CancellationToken cancellationToken = default)
        {
            var context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLedgerEntriesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetLedgerEntriesNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, LedgerEntry.DeserializeLedgerEntry, ClientDiagnostics, _pipeline, "PaginationClient.GetLedgerEntries", "value", "nextLink", context);
        }

        /// <summary> Gets ledger entries from a collection corresponding to a range. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationClient.xml" path="doc/members/member[@name='GetPaginationLedgerEntriesAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPaginationLedgerEntriesAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLedgerEntriesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetLedgerEntriesNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationClient.GetLedgerEntries", "value", "nextLink", context);
        }

        /// <summary> Gets ledger entries from a collection corresponding to a range. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationClient.xml" path="doc/members/member[@name='GetPaginationLedgerEntries(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPaginationLedgerEntries(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLedgerEntriesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetLedgerEntriesNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationClient.GetLedgerEntries", "value", "nextLink", context);
        }

        /// <summary> List upload detail for the discovery resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<LedgerEntry> GetPaginationClientValuesAsync(CancellationToken cancellationToken = default)
        {
            var context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationClientsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationClientsNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, LedgerEntry.DeserializeLedgerEntry, ClientDiagnostics, _pipeline, "PaginationClient.GetPaginationClients", "value", "nextLink", context);
        }

        /// <summary> List upload detail for the discovery resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<LedgerEntry> GetPaginationClientValues(CancellationToken cancellationToken = default)
        {
            var context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationClientsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationClientsNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, LedgerEntry.DeserializeLedgerEntry, ClientDiagnostics, _pipeline, "PaginationClient.GetPaginationClients", "value", "nextLink", context);
        }

        /// <summary> List upload detail for the discovery resource. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationClient.xml" path="doc/members/member[@name='GetLedgerEntriesAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetLedgerEntriesAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationClientsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationClientsNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationClient.GetPaginationClients", "value", "nextLink", context);
        }

        /// <summary> List upload detail for the discovery resource. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PaginationClient.xml" path="doc/members/member[@name='GetLedgerEntries(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetLedgerEntries(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPaginationClientsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPaginationClientsNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PaginationClient.GetPaginationClients", "value", "nextLink", context);
        }

        internal HttpMessage CreateGetPaginationLedgerEntriesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/app/transactions", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetLedgerEntriesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/app/adp/transactions", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPaginationLedgerEntriesNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetLedgerEntriesNextPageRequest(string nextLink, RequestContext context)
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
