// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_complex_LowLevel
{
    /// <summary> The Polymorphism service client. </summary>
    public partial class PolymorphismClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;

        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }

        /// <summary> Initializes a new instance of PolymorphismClient for mocking. </summary>
        protected PolymorphismClient()
        {
        }

        /// <summary> Initializes a new instance of PolymorphismClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public PolymorphismClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestComplexTestServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestComplexTestServiceClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetValidAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetValidRequest();
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetValid(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetValidRequest();
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutValidAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutValidRequest(content);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutValid(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutValidRequest(content);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fish.type: string,
        ///   species: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetDotSyntaxAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetDotSyntax");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDotSyntaxRequest();
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fish.type: string,
        ///   species: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetDotSyntax(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetDotSyntax");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDotSyntaxRequest();
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   sampleSalmon: {
        ///     fish.type: string,
        ///     species: string,
        ///     location: string,
        ///     iswild: boolean
        ///   },
        ///   salmons: [DotSalmon],
        ///   sampleFish: {
        ///     fish.type: string,
        ///     species: string
        ///   },
        ///   fishes: [DotFish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetComposedWithDiscriminatorAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComposedWithDiscriminatorRequest();
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   sampleSalmon: {
        ///     fish.type: string,
        ///     species: string,
        ///     location: string,
        ///     iswild: boolean
        ///   },
        ///   salmons: [DotSalmon],
        ///   sampleFish: {
        ///     fish.type: string,
        ///     species: string
        ///   },
        ///   fishes: [DotFish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetComposedWithDiscriminator(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComposedWithDiscriminatorRequest();
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   sampleSalmon: {
        ///     fish.type: string,
        ///     species: string,
        ///     location: string,
        ///     iswild: boolean
        ///   },
        ///   salmons: [DotSalmon],
        ///   sampleFish: {
        ///     fish.type: string,
        ///     species: string
        ///   },
        ///   fishes: [DotFish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetComposedWithoutDiscriminatorAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithoutDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComposedWithoutDiscriminatorRequest();
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   sampleSalmon: {
        ///     fish.type: string,
        ///     species: string,
        ///     location: string,
        ///     iswild: boolean
        ///   },
        ///   salmons: [DotSalmon],
        ///   sampleFish: {
        ///     fish.type: string,
        ///     species: string
        ///   },
        ///   fishes: [DotFish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetComposedWithoutDiscriminator(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithoutDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComposedWithoutDiscriminatorRequest();
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [
        ///     {
        ///       fishtype: string,
        ///       species: string,
        ///       length: number,
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetComplicatedAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComplicated");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComplicatedRequest();
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [
        ///     {
        ///       fishtype: string,
        ///       species: string,
        ///       length: number,
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetComplicated(RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComplicated");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComplicatedRequest();
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [
        ///     {
        ///       fishtype: string (required),
        ///       species: string,
        ///       length: number (required),
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutComplicatedAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutComplicated");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutComplicatedRequest(content);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [
        ///     {
        ///       fishtype: string (required),
        ///       species: string,
        ///       length: number (required),
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutComplicated(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutComplicated");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutComplicatedRequest(content);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [
        ///     {
        ///       fishtype: string (required),
        ///       species: string,
        ///       length: number (required),
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [
        ///     {
        ///       fishtype: string,
        ///       species: string,
        ///       length: number,
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutMissingDiscriminatorAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutMissingDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutMissingDiscriminatorRequest(content);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [
        ///     {
        ///       fishtype: string (required),
        ///       species: string,
        ///       length: number (required),
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   fishtype: string,
        ///   species: string,
        ///   length: number,
        ///   siblings: [
        ///     {
        ///       fishtype: string,
        ///       species: string,
        ///       length: number,
        ///       siblings: [Fish]
        ///     }
        ///   ],
        ///   location: string,
        ///   iswild: boolean
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutMissingDiscriminator(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutMissingDiscriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutMissingDiscriminatorRequest(content);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required &apos;birthday&apos; field - the request should not be allowed from the client. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutValidMissingRequiredAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutValidMissingRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutValidMissingRequiredRequest(content);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required &apos;birthday&apos; field - the request should not be allowed from the client. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   fishtype: string (required),
        ///   species: string,
        ///   length: number (required),
        ///   siblings: [Fish]
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutValidMissingRequired(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.PutValidMissingRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutValidMissingRequiredRequest(content);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreatePutValidRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetDotSyntaxRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/dotsyntax", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetComposedWithDiscriminatorRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetComposedWithoutDiscriminatorRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithoutDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetComplicatedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreatePutComplicatedRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreatePutMissingDiscriminatorRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/missingdiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreatePutValidMissingRequiredRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/missingrequired/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
