// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Encode.Datetime
{
    // Data plane generated sub-client.
    /// <summary> The Header sub-client. </summary>
    public partial class Header
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Header for mocking. </summary>
        protected Header()
        {
        }

        /// <summary> Initializes a new instance of Header. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="string"/> to use. </param>
        internal Header(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Default.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='DefaultAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> DefaultAsync(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Default");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDefaultRequest(value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Default.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='Default(DateTimeOffset,RequestContext)']/*" />
        public virtual Response Default(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Default");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDefaultRequest(value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Rfc 3339.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='Rfc3339Async(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> Rfc3339Async(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Rfc3339");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRfc3339Request(value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Rfc 3339.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='Rfc3339(DateTimeOffset,RequestContext)']/*" />
        public virtual Response Rfc3339(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Rfc3339");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRfc3339Request(value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Rfc 7231.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='Rfc7231Async(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> Rfc7231Async(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Rfc7231");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRfc7231Request(value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Rfc 7231.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='Rfc7231(DateTimeOffset,RequestContext)']/*" />
        public virtual Response Rfc7231(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.Rfc7231");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRfc7231Request(value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Unix timestamp.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='UnixTimestampAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> UnixTimestampAsync(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.UnixTimestamp");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimestampRequest(value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Unix timestamp.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='UnixTimestamp(DateTimeOffset,RequestContext)']/*" />
        public virtual Response UnixTimestamp(DateTimeOffset value, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Header.UnixTimestamp");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimestampRequest(value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Unix timestamp array.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='UnixTimestampArrayAsync(IEnumerable{DateTimeOffset},RequestContext)']/*" />
        public virtual async Task<Response> UnixTimestampArrayAsync(IEnumerable<DateTimeOffset> value, RequestContext context = null)
        {
            Argument.AssertNotNull(value, nameof(value));

            using var scope = ClientDiagnostics.CreateScope("Header.UnixTimestampArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimestampArrayRequest(value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Unix timestamp array.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="DateTimeOffset"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Header.xml" path="doc/members/member[@name='UnixTimestampArray(IEnumerable{DateTimeOffset},RequestContext)']/*" />
        public virtual Response UnixTimestampArray(IEnumerable<DateTimeOffset> value, RequestContext context = null)
        {
            Argument.AssertNotNull(value, nameof(value));

            using var scope = ClientDiagnostics.CreateScope("Header.UnixTimestampArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimestampArrayRequest(value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDefaultRequest(DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/encode/datetime/header/default", false);
            request.Uri = uri;
            request.Headers.Add("value", value, "R");
            return message;
        }

        internal HttpMessage CreateRfc3339Request(DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/encode/datetime/header/rfc3339", false);
            request.Uri = uri;
            request.Headers.Add("value", value, "O");
            return message;
        }

        internal HttpMessage CreateRfc7231Request(DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/encode/datetime/header/rfc7231", false);
            request.Uri = uri;
            request.Headers.Add("value", value, "R");
            return message;
        }

        internal HttpMessage CreateUnixTimestampRequest(DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/encode/datetime/header/unix-timestamp", false);
            request.Uri = uri;
            request.Headers.Add("value", value, "U");
            return message;
        }

        internal HttpMessage CreateUnixTimestampArrayRequest(IEnumerable<DateTimeOffset> value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/encode/datetime/header/unix-timestamp-array", false);
            request.Uri = uri;
            request.Headers.AddDelimited("value", value, ",", "U");
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
