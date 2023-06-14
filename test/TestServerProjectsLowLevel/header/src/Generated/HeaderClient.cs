// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace header_LowLevel
{
    // Data plane generated client.
    /// <summary> The Header service client. </summary>
    public partial class HeaderClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HeaderClient for mocking. </summary>
        protected HeaderClient()
        {
        }

        /// <summary> Initializes a new instance of HeaderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public HeaderClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new HeaderClientOptions())
        {
        }

        /// <summary> Initializes a new instance of HeaderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public HeaderClient(AzureKeyCredential credential, Uri endpoint, HeaderClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new HeaderClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header value "User-Agent": "overwrite"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userAgent"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamExistingKeyAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ParamExistingKeyAsync(string userAgent, RequestContext context = null)
        {
            Argument.AssertNotNull(userAgent, nameof(userAgent));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamExistingKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamExistingKeyRequest(userAgent, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header value "User-Agent": "overwrite"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="userAgent"> Send a post request with header value "User-Agent": "overwrite". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userAgent"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamExistingKey(string,RequestContext)']/*" />
        public virtual Response ParamExistingKey(string userAgent, RequestContext context = null)
        {
            Argument.AssertNotNull(userAgent, nameof(userAgent));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamExistingKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamExistingKeyRequest(userAgent, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "User-Agent": "overwrite"
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseExistingKeyAsync(RequestContext)']/*" />
        public virtual async Task<Response> ResponseExistingKeyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseExistingKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseExistingKeyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "User-Agent": "overwrite"
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseExistingKey(RequestContext)']/*" />
        public virtual Response ResponseExistingKey(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseExistingKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseExistingKeyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header value "Content-Type": "text/html"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentType"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamProtectedKeyAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ParamProtectedKeyAsync(string contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(contentType, nameof(contentType));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamProtectedKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamProtectedKeyRequest(contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header value "Content-Type": "text/html"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="contentType"> Send a post request with header value "Content-Type": "text/html". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentType"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamProtectedKey(string,RequestContext)']/*" />
        public virtual Response ParamProtectedKey(string contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(contentType, nameof(contentType));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamProtectedKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamProtectedKeyRequest(contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "Content-Type": "text/html"
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseProtectedKeyAsync(RequestContext)']/*" />
        public virtual async Task<Response> ResponseProtectedKeyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseProtectedKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseProtectedKeyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "Content-Type": "text/html"
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseProtectedKey(RequestContext)']/*" />
        public virtual Response ResponseProtectedKey(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseProtectedKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseProtectedKeyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamIntegerAsync(string,int,RequestContext)']/*" />
        public virtual async Task<Response> ParamIntegerAsync(string scenario, int value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamInteger");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamIntegerRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 1 or "scenario": "negative", "value": -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 1 or -2. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamInteger(string,int,RequestContext)']/*" />
        public virtual Response ParamInteger(string scenario, int value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamInteger");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamIntegerRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 1 or -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseIntegerAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseIntegerAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseInteger");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseIntegerRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 1 or -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseInteger(string,RequestContext)']/*" />
        public virtual Response ResponseInteger(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseInteger");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseIntegerRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamLongAsync(string,long,RequestContext)']/*" />
        public virtual async Task<Response> ParamLongAsync(string scenario, long value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamLong");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamLongRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 105 or "scenario": "negative", "value": -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 105 or -2. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamLong(string,long,RequestContext)']/*" />
        public virtual Response ParamLong(string scenario, long value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamLong");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamLongRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 105 or -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseLongAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseLongAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseLong");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseLongRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 105 or -2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseLong(string,RequestContext)']/*" />
        public virtual Response ResponseLong(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseLong");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseLongRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamFloatAsync(string,float,RequestContext)']/*" />
        public virtual async Task<Response> ParamFloatAsync(string scenario, float value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamFloat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamFloatRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 0.07 or "scenario": "negative", "value": -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 0.07 or -3.0. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamFloat(string,float,RequestContext)']/*" />
        public virtual Response ParamFloat(string scenario, float value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamFloat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamFloatRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 0.07 or -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseFloatAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseFloatAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseFloat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseFloatRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 0.07 or -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseFloat(string,RequestContext)']/*" />
        public virtual Response ResponseFloat(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseFloat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseFloatRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDoubleAsync(string,double,RequestContext)']/*" />
        public virtual async Task<Response> ParamDoubleAsync(string scenario, double value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDouble");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDoubleRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "positive", "value": 7e120 or "scenario": "negative", "value": -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="value"> Send a post request with header values 7e120 or -3.0. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDouble(string,double,RequestContext)']/*" />
        public virtual Response ParamDouble(string scenario, double value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDouble");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDoubleRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 7e120 or -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDoubleAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseDoubleAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDouble");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDoubleRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": 7e120 or -3.0
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "positive" or "negative". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDouble(string,RequestContext)']/*" />
        public virtual Response ResponseDouble(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDouble");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDoubleRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamBoolAsync(string,bool,RequestContext)']/*" />
        public virtual async Task<Response> ParamBoolAsync(string scenario, bool value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamBool");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamBoolRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "true", "value": true or "scenario": "false", "value": false
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="value"> Send a post request with header values true or false. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamBool(string,bool,RequestContext)']/*" />
        public virtual Response ParamBool(string scenario, bool value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamBool");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamBoolRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": true or false
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseBoolAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseBoolAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseBool");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseBoolRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header value "value": true or false
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "true" or "false". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseBool(string,RequestContext)']/*" />
        public virtual Response ResponseBool(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseBool");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseBoolRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": ""
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamStringAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> ParamStringAsync(string scenario, string value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamString");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamStringRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "The quick brown fox jumps over the lazy dog" or "scenario": "null", "value": null or "scenario": "empty", "value": ""
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values "The quick brown fox jumps over the lazy dog" or null or "". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamString(string,string,RequestContext)']/*" />
        public virtual Response ParamString(string scenario, string value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamString");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamStringRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "The quick brown fox jumps over the lazy dog" or null or ""
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseStringAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseStringAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseString");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseStringRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "The quick brown fox jumps over the lazy dog" or null or ""
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseString(string,RequestContext)']/*" />
        public virtual Response ResponseString(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseString");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseStringRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDateAsync(string,DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> ParamDateAsync(string scenario, DateTimeOffset value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDateRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "2010-01-01" or "scenario": "min", "value": "0001-01-01"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01" or "0001-01-01". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDate(string,DateTimeOffset,RequestContext)']/*" />
        public virtual Response ParamDate(string scenario, DateTimeOffset value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDateRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "2010-01-01" or "0001-01-01"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDateAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseDateAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDateRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "2010-01-01" or "0001-01-01"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDate(string,RequestContext)']/*" />
        public virtual Response ResponseDate(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDateRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDatetimeAsync(string,DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> ParamDatetimeAsync(string scenario, DateTimeOffset value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDatetime");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDatetimeRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "2010-01-01T12:34:56Z" or "scenario": "min", "value": "0001-01-01T00:00:00Z"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDatetime(string,DateTimeOffset,RequestContext)']/*" />
        public virtual Response ParamDatetime(string scenario, DateTimeOffset value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDatetime");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDatetimeRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDatetimeAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseDatetimeAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDatetime");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDatetimeRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "2010-01-01T12:34:56Z" or "0001-01-01T00:00:00Z"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDatetime(string,RequestContext)']/*" />
        public virtual Response ResponseDatetime(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDatetime");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDatetimeRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDatetimeRfc1123Async(string,DateTimeOffset?,RequestContext)']/*" />
        public virtual async Task<Response> ParamDatetimeRfc1123Async(string scenario, DateTimeOffset? value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDatetimeRfc1123Request(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "Wed, 01 Jan 2010 12:34:56 GMT" or "scenario": "min", "value": "Mon, 01 Jan 0001 00:00:00 GMT"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="value"> Send a post request with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDatetimeRfc1123(string,DateTimeOffset?,RequestContext)']/*" />
        public virtual Response ParamDatetimeRfc1123(string scenario, DateTimeOffset? value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDatetimeRfc1123");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDatetimeRfc1123Request(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDatetimeRfc1123Async(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseDatetimeRfc1123Async(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDatetimeRfc1123Request(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "min". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDatetimeRfc1123(string,RequestContext)']/*" />
        public virtual Response ResponseDatetimeRfc1123(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDatetimeRfc1123");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDatetimeRfc1123Request(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDurationAsync(string,TimeSpan,RequestContext)']/*" />
        public virtual async Task<Response> ParamDurationAsync(string scenario, TimeSpan value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDuration");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDurationRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "P123DT22H14M12.011S"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "P123DT22H14M12.011S". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamDuration(string,TimeSpan,RequestContext)']/*" />
        public virtual Response ParamDuration(string scenario, TimeSpan value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamDuration");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamDurationRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "P123DT22H14M12.011S"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDurationAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseDurationAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDuration");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDurationRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "P123DT22H14M12.011S"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseDuration(string,RequestContext)']/*" />
        public virtual Response ResponseDuration(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseDuration");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseDurationRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> or <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamByteAsync(string,BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> ParamByteAsync(string scenario, BinaryData value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamByteRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "啊齄丂狛狜隣郎隣兀﨩"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="value"> Send a post request with header values "啊齄丂狛狜隣郎隣兀﨩". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> or <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamByte(string,BinaryData,RequestContext)']/*" />
        public virtual Response ParamByte(string scenario, BinaryData value, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamByteRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "啊齄丂狛狜隣郎隣兀﨩"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseByteAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseByteAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseByteRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "啊齄丂狛狜隣郎隣兀﨩"
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseByte(string,RequestContext)']/*" />
        public virtual Response ResponseByte(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseByteRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY' . Allowed values: "White" | "black" | "GREY". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamEnumAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> ParamEnumAsync(string scenario, string value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamEnum");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamEnumRequest(scenario, value, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a post request with header values "scenario": "valid", "value": "GREY" or "scenario": "null", "value": null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="value"> Send a post request with header values 'GREY' . Allowed values: "White" | "black" | "GREY". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ParamEnum(string,string,RequestContext)']/*" />
        public virtual Response ParamEnum(string scenario, string value = null, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ParamEnum");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParamEnumRequest(scenario, value, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "GREY" or null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseEnumAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ResponseEnumAsync(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseEnum");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseEnumRequest(scenario, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a response with header values "GREY" or null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scenario"> Send a post request with header values "scenario": "valid" or "null" or "empty". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scenario"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='ResponseEnum(string,RequestContext)']/*" />
        public virtual Response ResponseEnum(string scenario, RequestContext context = null)
        {
            Argument.AssertNotNull(scenario, nameof(scenario));

            using var scope = ClientDiagnostics.CreateScope("HeaderClient.ResponseEnum");
            scope.Start();
            try
            {
                using HttpMessage message = CreateResponseEnumRequest(scenario, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='CustomRequestIdAsync(RequestContext)']/*" />
        public virtual async Task<Response> CustomRequestIdAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.CustomRequestId");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCustomRequestIdRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
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
        /// <include file="Docs/HeaderClient.xml" path="doc/members/member[@name='CustomRequestId(RequestContext)']/*" />
        public virtual Response CustomRequestId(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HeaderClient.CustomRequestId");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCustomRequestIdRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateParamExistingKeyRequest(string userAgent, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/existingkey", false);
            request.Uri = uri;
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseExistingKeyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/existingkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamProtectedKeyRequest(string contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/protectedkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseProtectedKeyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/protectedkey", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamIntegerRequest(string scenario, int value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseIntegerRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/integer", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamLongRequest(string scenario, long value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseLongRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/long", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamFloatRequest(string scenario, float value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseFloatRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/float", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamDoubleRequest(string scenario, double value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseDoubleRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/double", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamBoolRequest(string scenario, bool value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseBoolRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/bool", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamStringRequest(string scenario, string value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseStringRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/string", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamDateRequest(string scenario, DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "D");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseDateRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/date", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamDatetimeRequest(string scenario, DateTimeOffset value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "O");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseDatetimeRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/datetime", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamDatetimeRfc1123Request(string scenario, DateTimeOffset? value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value.Value, "R");
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseDatetimeRfc1123Request(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/datetimerfc1123", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamDurationRequest(string scenario, TimeSpan value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value, "P");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseDurationRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/duration", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamByteRequest(string scenario, BinaryData value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("value", value.ToArray(), "D");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseByteRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/byte", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParamEnumRequest(string scenario, string value, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/param/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            if (value != null)
            {
                request.Headers.Add("value", value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateResponseEnumRequest(string scenario, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/response/prim/enum", false);
            request.Uri = uri;
            request.Headers.Add("scenario", scenario);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCustomRequestIdRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/header/custom/x-ms-client-request-id/9C4D50EE-2D56-4CD3-8152-34347DC9F2B0", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
