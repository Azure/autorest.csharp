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
using PetStore.Models;

namespace PetStore
{
    // Data plane generated client.
    /// <summary> Manage your pets. You can delete or get the Pet from pet store. </summary>
    public partial class PetStoreClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PetStoreClient for mocking. </summary>
        protected PetStoreClient()
        {
        }

        /// <summary> Initializes a new instance of PetStoreClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public PetStoreClient(Uri endpoint) : this(endpoint, new PetStoreClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PetStoreClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public PetStoreClient(Uri endpoint, PetStoreClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new PetStoreClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// [Protocol Method]delete.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Delete a pet.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='DeleteAsync(int,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> DeleteAsync(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]delete.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Delete a pet.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='Delete(int,global::Azure.RequestContext)']/*" />
        public virtual Response Delete(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> ReadAsync(int petId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ReadAsync(petId, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> Read(int petId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Read(petId, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]Returns a pet. Supports eTags.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Read(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='ReadAsync(int,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> ReadAsync(int petId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Returns a pet. Supports eTags.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Read(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='Read(int,global::Azure.RequestContext)']/*" />
        public virtual Response Read(int petId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="pet"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        public virtual async Task<Response<Pet>> CreateAsync(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateAsync(pet.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="pet"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        public virtual Response<Pet> Create(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Create(pet.ToRequestContent(), context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(Pet,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='CreateAsync(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> CreateAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(Pet,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='Create(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual Response Create(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="kind"> The PetKind to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> GetPetByKindAsync(PetKind kind, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetPetByKindAsync(kind.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="kind"> The PetKind to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> GetPetByKind(PetKind kind, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetPetByKind(kind.ToString(), context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPetByKind(PetKind,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The PetKind to use. Allowed values: &quot;dog&quot; | &quot;cat&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="kind"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='GetPetByKindAsync(string,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> GetPetByKindAsync(string kind, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.GetPetByKind");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetByKindRequest(kind, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPetByKind(PetKind,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The PetKind to use. Allowed values: &quot;dog&quot; | &quot;cat&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="kind"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='GetPetByKind(string,global::Azure.RequestContext)']/*" />
        public virtual Response GetPetByKind(string kind, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.GetPetByKind");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetByKindRequest(kind, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="start"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> GetFirstPetAsync(int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetFirstPetAsync(start, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="start"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> GetFirstPet(int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetFirstPet(start, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstPet(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='GetFirstPetAsync(int?,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> GetFirstPetAsync(int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.GetFirstPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFirstPetRequest(start, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstPet(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/PetStoreClient.xml" path="doc/members/member[@name='GetFirstPet(int?,global::Azure.RequestContext)']/*" />
        public virtual Response GetFirstPet(int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("PetStoreClient.GetFirstPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFirstPetRequest(start, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateReadRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200304);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetPetByKindRequest(string kind, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(kind, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetFirstPetRequest(int? start, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets", false);
            if (start != null)
            {
                uri.AppendQuery("start", start.Value, true);
            }
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
        private static ResponseClassifier _responseClassifier200304;
        private static ResponseClassifier ResponseClassifier200304 => _responseClassifier200304 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 304 });
    }
}
