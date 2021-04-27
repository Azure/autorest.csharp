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

#pragma warning disable AZC0007

namespace body_complex_LowLevel
{
    /// <summary> The Polymorphism service client. </summary>
    public partial class PolymorphismClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;
        private readonly string apiVersion;

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
            Pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetValidAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetValidRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetValid(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetValidRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetValid"/> and <see cref="GetValidAsync"/> operations. </summary>
        private Request CreateGetValidRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutValidAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutValid(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutValid"/> and <see cref="PutValidAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreatePutValidRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDotSyntaxAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetDotSyntaxRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDotSyntax(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetDotSyntaxRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetDotSyntax"/> and <see cref="GetDotSyntaxAsync"/> operations. </summary>
        private Request CreateGetDotSyntaxRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/dotsyntax", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetComposedWithDiscriminatorAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComposedWithDiscriminatorRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetComposedWithDiscriminator(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComposedWithDiscriminatorRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetComposedWithDiscriminator"/> and <see cref="GetComposedWithDiscriminatorAsync"/> operations. </summary>
        private Request CreateGetComposedWithDiscriminatorRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetComposedWithoutDiscriminatorAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComposedWithoutDiscriminatorRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetComposedWithoutDiscriminator(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComposedWithoutDiscriminatorRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetComposedWithoutDiscriminator"/> and <see cref="GetComposedWithoutDiscriminatorAsync"/> operations. </summary>
        private Request CreateGetComposedWithoutDiscriminatorRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithoutDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetComplicatedAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComplicatedRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetComplicated(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetComplicatedRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetComplicated"/> and <see cref="GetComplicatedAsync"/> operations. </summary>
        private Request CreateGetComplicatedRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>location</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>iswild</term>
        ///     <term>boolean</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// Schema for <c>Fish</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutComplicatedAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutComplicatedRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>location</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>iswild</term>
        ///     <term>boolean</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// Schema for <c>Fish</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutComplicated(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutComplicatedRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutComplicated"/> and <see cref="PutComplicatedAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreatePutComplicatedRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>location</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>iswild</term>
        ///     <term>boolean</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// Schema for <c>Fish</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMissingDiscriminatorAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutMissingDiscriminatorRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>location</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>iswild</term>
        ///     <term>boolean</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// Schema for <c>Fish</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMissingDiscriminator(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutMissingDiscriminatorRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutMissingDiscriminator"/> and <see cref="PutMissingDiscriminatorAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreatePutMissingDiscriminatorRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/missingdiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required &apos;birthday&apos; field - the request should not be allowed from the client. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutValidMissingRequiredAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidMissingRequiredRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required &apos;birthday&apos; field - the request should not be allowed from the client. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listeader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listeader>
        ///   <item>
        ///     <term>fishtype</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>species</term>
        ///     <term>string</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>length</term>
        ///     <term>number</term>
        ///     <term>Yes</term>
        ///    <term></term>
        ///   </item>
        ///   <item>
        ///     <term>siblings</term>
        ///     <term>Fish[]</term>
        ///     <term></term>
        ///    <term></term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutValidMissingRequired(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidMissingRequiredRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutValidMissingRequired"/> and <see cref="PutValidMissingRequiredAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreatePutValidMissingRequiredRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphism/missingrequired/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }
    }
}
