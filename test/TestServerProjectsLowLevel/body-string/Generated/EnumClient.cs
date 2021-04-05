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

namespace body_string
{
    /// <summary> The Enum service client. </summary>
    public partial class EnumClient
    {
        protected HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;

        /// <summary> Initializes a new instance of EnumClient for mocking. </summary>
        protected EnumClient()
        {
        }

        /// <summary> Initializes a new instance of EnumClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal EnumClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestSwaggerBATServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestSwaggerBATServiceClientOptions();
            Pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            this.endpoint = endpoint;
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetNotExpandableAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetNotExpandableRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetNotExpandable(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetNotExpandableRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetNotExpandable"/> and <see cref="GetNotExpandableAsync"/> operations. </summary>
        protected Request CreateGetNotExpandableRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNotExpandableAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutNotExpandableRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNotExpandable(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutNotExpandableRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutNotExpandable"/> and <see cref="PutNotExpandableAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        protected Request CreatePutNotExpandableRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetReferencedAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetReferencedRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetReferenced(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetReferencedRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetReferenced"/> and <see cref="GetReferencedAsync"/> operations. </summary>
        protected Request CreateGetReferencedRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutReferencedAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutReferencedRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutReferenced(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutReferencedRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutReferenced"/> and <see cref="PutReferencedAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        protected Request CreatePutReferencedRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetReferencedConstantAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetReferencedConstantRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetReferencedConstant(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetReferencedConstantRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetReferencedConstant"/> and <see cref="GetReferencedConstantAsync"/> operations. </summary>
        protected Request CreateGetReferencedConstantRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutReferencedConstantAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutReferencedConstantRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutReferencedConstant(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutReferencedConstantRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutReferencedConstant"/> and <see cref="PutReferencedConstantAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        protected Request CreatePutReferencedConstantRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }
    }
}
