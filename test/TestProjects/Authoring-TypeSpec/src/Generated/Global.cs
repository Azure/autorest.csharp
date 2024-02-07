// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AuthoringTypeSpec
{
    // Data plane generated sub-client.
    /// <summary> The Global sub-client. </summary>
    public partial class Global
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Global for mocking. </summary>
        protected Global()
        {
        }

        /// <summary> Initializes a new instance of Global. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal Global(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The <see cref="int"/>? to use. </param>
        /// <param name="skip"> The <see cref="int"/>? to use. </param>
        /// <param name="maxpagesize"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Global.xml" path="doc/members/member[@name='GetSupportedLanguagesAsync(int?,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetSupportedLanguagesAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedLanguagesRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedLanguagesNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Global.GetSupportedLanguages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The <see cref="int"/>? to use. </param>
        /// <param name="skip"> The <see cref="int"/>? to use. </param>
        /// <param name="maxpagesize"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Global.xml" path="doc/members/member[@name='GetSupportedLanguages(int?,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetSupportedLanguages(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedLanguagesRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedLanguagesNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Global.GetSupportedLanguages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The <see cref="int"/>? to use. </param>
        /// <param name="skip"> The <see cref="int"/>? to use. </param>
        /// <param name="maxpagesize"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Global.xml" path="doc/members/member[@name='GetTrainingConfigVersionsAsync(int?,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetTrainingConfigVersionsAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Global.GetTrainingConfigVersions", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The <see cref="int"/>? to use. </param>
        /// <param name="skip"> The <see cref="int"/>? to use. </param>
        /// <param name="maxpagesize"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/Global.xml" path="doc/members/member[@name='GetTrainingConfigVersions(int?,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetTrainingConfigVersions(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "Global.GetTrainingConfigVersions", "value", "nextLink", context);
        }

        internal RequestUriBuilder CreateGetSupportedLanguagesRequestUri(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/languages", false);
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
            return uri;
        }

        internal HttpMessage CreateGetSupportedLanguagesRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/languages", false);
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

        internal RequestUriBuilder CreateGetTrainingConfigVersionsRequestUri(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/training-config-versions", false);
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
            return uri;
        }

        internal HttpMessage CreateGetTrainingConfigVersionsRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/training-config-versions", false);
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

        internal RequestUriBuilder CreateGetSupportedLanguagesNextPageRequestUri(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateGetSupportedLanguagesNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal RequestUriBuilder CreateGetTrainingConfigVersionsNextPageRequestUri(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            return uri;
        }

        internal HttpMessage CreateGetTrainingConfigVersionsNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
