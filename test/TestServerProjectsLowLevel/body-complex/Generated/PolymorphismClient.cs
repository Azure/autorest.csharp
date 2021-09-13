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
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private Uri endpoint;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolymorphismRestClient RestClient;

        /// <summary> Initializes a new instance of PolymorphismClient for mocking. </summary>
        protected PolymorphismClient()
        {
        }

        /// <summary> Initializes a new instance of PolymorphismClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
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
            var authPolicy = new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            RestClient = new PolymorphismRestClient(_clientDiagnostics, _pipeline, endpoint);
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
        public virtual async Task<Response> GetValidAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetValid");
            scope.Start();
            try
            {
                return await RestClient.GetValidAsync(options).ConfigureAwait(false);
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
        public virtual Response GetValid(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetValid");
            scope.Start();
            try
            {
                return RestClient.GetValid(options);
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
                return await RestClient.PutValidAsync(content, options).ConfigureAwait(false);
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
                return RestClient.PutValid(content, options);
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
        public virtual async Task<Response> GetDotSyntaxAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetDotSyntax");
            scope.Start();
            try
            {
                return await RestClient.GetDotSyntaxAsync(options).ConfigureAwait(false);
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
        public virtual Response GetDotSyntax(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetDotSyntax");
            scope.Start();
            try
            {
                return RestClient.GetDotSyntax(options);
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
        public virtual async Task<Response> GetComposedWithDiscriminatorAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithDiscriminator");
            scope.Start();
            try
            {
                return await RestClient.GetComposedWithDiscriminatorAsync(options).ConfigureAwait(false);
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
        public virtual Response GetComposedWithDiscriminator(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithDiscriminator");
            scope.Start();
            try
            {
                return RestClient.GetComposedWithDiscriminator(options);
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
        public virtual async Task<Response> GetComposedWithoutDiscriminatorAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithoutDiscriminator");
            scope.Start();
            try
            {
                return await RestClient.GetComposedWithoutDiscriminatorAsync(options).ConfigureAwait(false);
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
        public virtual Response GetComposedWithoutDiscriminator(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComposedWithoutDiscriminator");
            scope.Start();
            try
            {
                return RestClient.GetComposedWithoutDiscriminator(options);
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
        public virtual async Task<Response> GetComplicatedAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComplicated");
            scope.Start();
            try
            {
                return await RestClient.GetComplicatedAsync(options).ConfigureAwait(false);
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
        public virtual Response GetComplicated(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphismClient.GetComplicated");
            scope.Start();
            try
            {
                return RestClient.GetComplicated(options);
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
                return await RestClient.PutComplicatedAsync(content, options).ConfigureAwait(false);
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
                return RestClient.PutComplicated(content, options);
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
                return await RestClient.PutMissingDiscriminatorAsync(content, options).ConfigureAwait(false);
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
                return RestClient.PutMissingDiscriminator(content, options);
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
                return await RestClient.PutValidMissingRequiredAsync(content, options).ConfigureAwait(false);
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
                return RestClient.PutValidMissingRequired(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
