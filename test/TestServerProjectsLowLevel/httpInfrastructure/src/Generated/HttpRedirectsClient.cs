// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure_LowLevel
{
    // Data plane generated client.
    /// <summary> The HttpRedirects service client. </summary>
    public partial class HttpRedirectsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HttpRedirectsClient for mocking. </summary>
        protected HttpRedirectsClient()
        {
        }

        /// <summary> Initializes a new instance of HttpRedirectsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public HttpRedirectsClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestHttpInfrastructureTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of HttpRedirectsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public HttpRedirectsClient(AzureKeyCredential credential, Uri endpoint, AutoRestHttpInfrastructureTestServiceClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutoRestHttpInfrastructureTestServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Return 300 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head300Async(RequestContext)']/*" />
        public virtual async Task<Response> Head300Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head300");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead300Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 300 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head300(RequestContext)']/*" />
        public virtual Response Head300(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head300");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead300Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 300 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get300Async(RequestContext)']/*" />
        public virtual async Task<Response> Get300Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get300");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet300Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 300 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get300(RequestContext)']/*" />
        public virtual Response Get300(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get300");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet300Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 301 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head301Async(RequestContext)']/*" />
        public virtual async Task<Response> Head301Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head301");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead301Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 301 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head301(RequestContext)']/*" />
        public virtual Response Head301(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head301");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead301Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 301 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get301Async(RequestContext)']/*" />
        public virtual async Task<Response> Get301Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get301");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet301Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 301 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get301(RequestContext)']/*" />
        public virtual Response Get301(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get301");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet301Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put true Boolean value in request returns 301.  This request should not be automatically redirected, but should return the received 301 to the caller for evaluation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Put301Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Put301Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Put301");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut301Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put true Boolean value in request returns 301.  This request should not be automatically redirected, but should return the received 301 to the caller for evaluation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Put301(RequestContent,RequestContext)']/*" />
        public virtual Response Put301(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Put301");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut301Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 302 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head302Async(RequestContext)']/*" />
        public virtual async Task<Response> Head302Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head302");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead302Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 302 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head302(RequestContext)']/*" />
        public virtual Response Head302(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head302");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead302Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 302 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get302Async(RequestContext)']/*" />
        public virtual async Task<Response> Get302Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get302");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet302Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return 302 status code and redirect to /http/success/200
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get302(RequestContext)']/*" />
        public virtual Response Get302(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get302");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet302Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Patch true Boolean value in request returns 302.  This request should not be automatically redirected, but should return the received 302 to the caller for evaluation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Patch302Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Patch302Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Patch302");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch302Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Patch true Boolean value in request returns 302.  This request should not be automatically redirected, but should return the received 302 to the caller for evaluation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Patch302(RequestContent,RequestContext)']/*" />
        public virtual Response Patch302(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Patch302");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch302Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Post true Boolean value in request returns 303.  This request should be automatically redirected usign a get, ultimately returning a 200 status code
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Post303Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Post303Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Post303");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost303Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Post true Boolean value in request returns 303.  This request should be automatically redirected usign a get, ultimately returning a 200 status code
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Post303(RequestContent,RequestContext)']/*" />
        public virtual Response Post303(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Post303");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost303Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Redirect with 307, resulting in a 200 success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head307Async(RequestContext)']/*" />
        public virtual async Task<Response> Head307Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead307Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Redirect with 307, resulting in a 200 success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Head307(RequestContext)']/*" />
        public virtual Response Head307(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Head307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead307Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Redirect get with 307, resulting in a 200 success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get307Async(RequestContext)']/*" />
        public virtual async Task<Response> Get307Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet307Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Redirect get with 307, resulting in a 200 success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Get307(RequestContext)']/*" />
        public virtual Response Get307(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Get307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet307Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] options redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Options307Async(RequestContext)']/*" />
        public virtual async Task<Response> Options307Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Options307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptions307Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] options redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Options307(RequestContext)']/*" />
        public virtual Response Options307(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Options307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptions307Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Put307Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Put307Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Put307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut307Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Put307(RequestContent,RequestContext)']/*" />
        public virtual Response Put307(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Put307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut307Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Patch redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Patch307Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Patch307Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Patch307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch307Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Patch redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Patch307(RequestContent,RequestContext)']/*" />
        public virtual Response Patch307(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Patch307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatch307Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Post redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Post307Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Post307Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Post307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost307Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Post redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Post307(RequestContent,RequestContext)']/*" />
        public virtual Response Post307(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Post307");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost307Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Delete307Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Delete307Async(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Delete307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete307Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete redirected with 307, resulting in a 200 after redirect
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HttpRedirectsClient.xml" path="doc/members/member[@name='Delete307(RequestContent,RequestContext)']/*" />
        public virtual Response Delete307(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpRedirectsClient.Delete307");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete307Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHead300Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200300);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet300Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200300);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateHead301Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200301);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet301Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200301);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePut301Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier301);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHead302Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200302);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet302Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200302);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePatch302Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier302);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePost303Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200303);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/303", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHead307Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet307Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateOptions307Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePut307Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePatch307Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePost307Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDelete307Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200307);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200300;
        private static ResponseClassifier ResponseClassifier200300 => _responseClassifier200300 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 300 });
        private static ResponseClassifier _responseClassifier200301;
        private static ResponseClassifier ResponseClassifier200301 => _responseClassifier200301 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 301 });
        private static ResponseClassifier _responseClassifier301;
        private static ResponseClassifier ResponseClassifier301 => _responseClassifier301 ??= new StatusCodeClassifier(stackalloc ushort[] { 301 });
        private static ResponseClassifier _responseClassifier200302;
        private static ResponseClassifier ResponseClassifier200302 => _responseClassifier200302 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 302 });
        private static ResponseClassifier _responseClassifier302;
        private static ResponseClassifier ResponseClassifier302 => _responseClassifier302 ??= new StatusCodeClassifier(stackalloc ushort[] { 302 });
        private static ResponseClassifier _responseClassifier200303;
        private static ResponseClassifier ResponseClassifier200303 => _responseClassifier200303 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 303 });
        private static ResponseClassifier _responseClassifier200307;
        private static ResponseClassifier ResponseClassifier200307 => _responseClassifier200307 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 307 });
    }
}
