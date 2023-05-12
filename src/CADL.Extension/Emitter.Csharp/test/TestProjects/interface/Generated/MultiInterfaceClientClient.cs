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
using TypeSpec.TestServer.MultiInterfaceClient.Models;

namespace TypeSpec.TestServer.MultiInterfaceClient
{
    // Data plane generated client.
    /// <summary> The MultiInterfaceClient service client. </summary>
    public partial class MultiInterfaceClientClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MultiInterfaceClientClient. </summary>
        public MultiInterfaceClientClient() : this(new Uri("http://localhost:3000"), new MultiInterfaceClientClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MultiInterfaceClientClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MultiInterfaceClientClient(Uri endpoint, MultiInterfaceClientClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new MultiInterfaceClientClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Dog>> GetDogsConvenientValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetDogsConvenientValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetDogsConvenientAsync(context).ConfigureAwait(false);
                return Response.FromValue(Dog.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Dog> GetDogsConvenientValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetDogsConvenientValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = GetDogsConvenient(context);
                return Response.FromValue(Dog.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='GetDogsConvenientAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDogsConvenientAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetDogsConvenient");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDogsConvenientRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='GetDogsConvenient(RequestContext)']/*" />
        public virtual Response GetDogsConvenient(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetDogsConvenient");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDogsConvenientRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="input"> The Dog to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<Response<Dog>> SetDogsAsync(Dog input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SetDogsAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Dog.FromResponse(response), response);
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="input"> The Dog to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual Response<Dog> SetDogs(Dog input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SetDogs(input.ToRequestContent(), context);
            return Response.FromValue(Dog.FromResponse(response), response);
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='SetDogsAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SetDogsAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.SetDogs");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetDogsRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='SetDogs(RequestContent,RequestContext)']/*" />
        public virtual Response SetDogs(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.SetDogs");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetDogsRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Cat>> GetCatValuesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetCatValues");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetCatsAsync(context).ConfigureAwait(false);
                return Response.FromValue(Cat.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Cat> GetCatValues(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetCatValues");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = GetCats(context);
                return Response.FromValue(Cat.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='GetCatsAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetCatsAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetCats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCatsRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='GetCats(RequestContext)']/*" />
        public virtual Response GetCats(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.GetCats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCatsRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="input"> The Cat to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<Response<Cat>> SetCatsAsync(Cat input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SetCatsAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Cat.FromResponse(response), response);
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="input"> The Cat to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual Response<Cat> SetCats(Cat input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SetCats(input.ToRequestContent(), context);
            return Response.FromValue(Cat.FromResponse(response), response);
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='SetCatsAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SetCatsAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.SetCats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetCatsRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Illustrate grouping operations on subclient. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/MultiInterfaceClientClient.xml" path="doc/members/member[@name='SetCats(RequestContent,RequestContext)']/*" />
        public virtual Response SetCats(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MultiInterfaceClientClient.SetCats");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetCatsRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetDogsConvenientRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/dogs", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateSetDogsRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/dogs/models", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetCatsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/cats", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateSetCatsRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/cats", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
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
