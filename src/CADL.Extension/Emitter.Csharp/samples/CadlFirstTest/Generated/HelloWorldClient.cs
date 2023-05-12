// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Demo.HelloWorld.Models;

namespace Demo.HelloWorld
{
    // Data plane generated client.
    /// <summary> The HelloWorld service client. </summary>
    public partial class HelloWorldClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HelloWorldClient. </summary>
        public HelloWorldClient() : this(new HelloWorldClientOptions())
        {
        }

        /// <summary> Initializes a new instance of HelloWorldClient. </summary>
        /// <param name="options"> The options for configuring the client. </param>
        public HelloWorldClient(HelloWorldClientOptions options)
        {
            options ??= new HelloWorldClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _apiVersion = options.Version;
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Thing>> TopActionValueAsync(DateTimeOffset action, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopActionValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await TopActionAsync(action, context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Thing> TopActionValue(DateTimeOffset action, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopActionValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = TopAction(action, context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='TopActionAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> TopActionAsync(DateTimeOffset action, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='TopAction(DateTimeOffset,RequestContext)']/*" />
        public virtual Response TopAction(DateTimeOffset action, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Thing>> TopAction2ValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await TopAction2Async(context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Thing> TopAction2Value(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = TopAction2(context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='TopAction2Async(RequestContext)']/*" />
        public virtual async Task<Response> TopAction2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> top level method2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='TopAction2(RequestContext)']/*" />
        public virtual Response TopAction2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        public virtual async Task<Response<Thing>> AnonymousBodyAsync(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AnonymousBodyAsync(thing.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        public virtual Response<Thing> AnonymousBody(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AnonymousBody(thing.ToRequestContent(), context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='AnonymousBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> AnonymousBodyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.AnonymousBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnonymousBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='AnonymousBody(RequestContent,RequestContext)']/*" />
        public virtual Response AnonymousBody(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.AnonymousBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnonymousBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Thing>> SayHiValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.SayHiValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await SayHiAsync(context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Thing> SayHiValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.SayHiValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = SayHi(context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='SayHiAsync(RequestContext)']/*" />
        public virtual async Task<Response> SayHiAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.SayHi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSayHiRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='SayHi(RequestContext)']/*" />
        public virtual Response SayHi(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.SayHi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSayHiRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="action"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> is null. </exception>
        public virtual async Task<Response<Thing>> HelloAgainAsync(RoundTripModel action, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(action, nameof(action));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await HelloAgainAsync(action.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> Return hi again. </summary>
        /// <param name="action"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> is null. </exception>
        public virtual Response<Thing> HelloAgain(RoundTripModel action, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(action, nameof(action));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = HelloAgain(action.ToRequestContent(), context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> Return hi again. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='HelloAgainAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> HelloAgainAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='HelloAgain(RequestContent,RequestContext)']/*" />
        public virtual Response HelloAgain(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Thing>> HelloDemo2ValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloDemo2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await HelloDemo2Async(context).ConfigureAwait(false);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Thing> HelloDemo2Value(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloDemo2Value");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = HelloDemo2(context);
                return Response.FromValue(Thing.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='HelloDemo2Async(RequestContext)']/*" />
        public virtual async Task<Response> HelloDemo2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/HelloWorldClient.xml" path="doc/members/member[@name='HelloDemo2(RequestContext)']/*" />
        public virtual Response HelloDemo2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HelloWorldClient.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateTopActionRequest(DateTimeOffset action, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/top/", false);
            uri.AppendPath(action, "O", true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateTopAction2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/top2", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateAnonymousBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/anonymousBody", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSayHiRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/hello", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateHelloAgainRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/againHi", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHelloDemo2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/demoHi", false);
            uri.AppendQuery("api-version", _apiVersion, true);
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
