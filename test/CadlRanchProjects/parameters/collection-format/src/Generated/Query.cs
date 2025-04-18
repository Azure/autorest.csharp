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

namespace Parameters.CollectionFormat
{
    // Data plane generated sub-client.
    /// <summary> The Query sub-client. </summary>
    public partial class Query
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Query for mocking. </summary>
        protected Query()
        {
        }

        /// <summary> Initializes a new instance of Query. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service host. </param>
        internal Query(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Multi.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='MultiAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> MultiAsync(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Multi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMultiRequest(colors, context);
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
        /// [Protocol Method] Multi.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='Multi(IEnumerable{string},RequestContext)']/*" />
        public virtual Response Multi(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Multi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMultiRequest(colors, context);
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
        /// [Protocol Method] Ssv.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='SsvAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> SsvAsync(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Ssv");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSsvRequest(colors, context);
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
        /// [Protocol Method] Ssv.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='Ssv(IEnumerable{string},RequestContext)']/*" />
        public virtual Response Ssv(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Ssv");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSsvRequest(colors, context);
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
        /// [Protocol Method] Pipes.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='PipesAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> PipesAsync(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Pipes");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePipesRequest(colors, context);
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
        /// [Protocol Method] Pipes.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='Pipes(IEnumerable{string},RequestContext)']/*" />
        public virtual Response Pipes(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Pipes");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePipesRequest(colors, context);
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
        /// [Protocol Method] Csv.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='CsvAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> CsvAsync(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Csv");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCsvRequest(colors, context);
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
        /// [Protocol Method] Csv.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="colors"> Possible values for colors are [blue,red,green]. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="colors"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Query.xml" path="doc/members/member[@name='Csv(IEnumerable{string},RequestContext)']/*" />
        public virtual Response Csv(IEnumerable<string> colors, RequestContext context = null)
        {
            Argument.AssertNotNull(colors, nameof(colors));

            using var scope = ClientDiagnostics.CreateScope("Query.Csv");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCsvRequest(colors, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateMultiRequest(IEnumerable<string> colors, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/collection-format/query/multi", false);
            if (colors != null && !(colors is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                foreach (var param in colors)
                {
                    uri.AppendQuery("colors", param, true);
                }
            }
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateSsvRequest(IEnumerable<string> colors, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/collection-format/query/ssv", false);
            if (colors != null && !(colors is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("colors", colors, " ", true);
            }
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreatePipesRequest(IEnumerable<string> colors, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/collection-format/query/pipes", false);
            if (colors != null && !(colors is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("colors", colors, "|", true);
            }
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateCsvRequest(IEnumerable<string> colors, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/collection-format/query/csv", false);
            if (colors != null && !(colors is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                uri.AppendQueryDelimited("colors", colors, ",", true);
            }
            request.Uri = uri;
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
