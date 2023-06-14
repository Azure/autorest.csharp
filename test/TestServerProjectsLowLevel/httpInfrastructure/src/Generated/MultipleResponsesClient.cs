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
    /// <summary> The MultipleResponses service client. </summary>
    public partial class MultipleResponsesClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MultipleResponsesClient for mocking. </summary>
        protected MultipleResponsesClient()
        {
        }

        /// <summary> Initializes a new instance of MultipleResponsesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MultipleResponsesClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestHttpInfrastructureTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MultipleResponsesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public MultipleResponsesClient(AzureKeyCredential credential, Uri endpoint, AutoRestHttpInfrastructureTestServiceClientOptions options)
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
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError200ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model204NoModelDefaultError200ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError200ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError200Valid(RequestContext)']/*" />
        public virtual Response Get200Model204NoModelDefaultError200Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError200ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError204ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model204NoModelDefaultError204ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError204ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError204Valid(RequestContext)']/*" />
        public virtual Response Get200Model204NoModelDefaultError204Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError204ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 201 response with valid payload: {'statusCode': '201'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError201InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model204NoModelDefaultError201InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError201InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 201 response with valid payload: {'statusCode': '201'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError201Invalid(RequestContext)']/*" />
        public virtual Response Get200Model204NoModelDefaultError201Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError201InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with no payload:
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError202NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model204NoModelDefaultError202NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError202NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with no payload:
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError202None(RequestContext)']/*" />
        public virtual Response Get200Model204NoModelDefaultError202None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError202NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model204NoModelDefaultError400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model204NoModelDefaultError400Valid(RequestContext)']/*" />
        public virtual Response Get200Model204NoModelDefaultError400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model204NoModelDefaultError400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError200ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model201ModelDefaultError200ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError200ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError200Valid(RequestContext)']/*" />
        public virtual Response Get200Model201ModelDefaultError200Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError200ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError201ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model201ModelDefaultError201ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError201ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError201Valid(RequestContext)']/*" />
        public virtual Response Get200Model201ModelDefaultError201Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError201ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200Model201ModelDefaultError400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200Model201ModelDefaultError400Valid(RequestContext)']/*" />
        public virtual Response Get200Model201ModelDefaultError400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200Model201ModelDefaultError400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError200Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA201ModelC404ModelDDefaultError200Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'httpCode': '201'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'httpCode': '201'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError201Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA201ModelC404ModelDDefaultError201Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'httpStatusCode': '404'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'httpStatusCode': '404'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError404Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA201ModelC404ModelDDefaultError404Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA201ModelC404ModelDDefaultError400Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA201ModelC404ModelDDefaultError400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError202NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultError202NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError202NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError202None(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultError202None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError202NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError204NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultError204NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError204NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError204None(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultError204None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError204NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultError400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultError400Valid(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultError400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultError400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with an unexpected payload {'property': 'value'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone202InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultNone202InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone202InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with an unexpected payload {'property': 'value'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone202Invalid(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultNone202Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone202InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone204NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultNone204NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone204NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 204 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone204None(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultNone204None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone204NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone400NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultNone400NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone400NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone400None(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultNone400None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone400NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with an unexpected payload {'property': 'value'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone400InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get202None204NoneDefaultNone400InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone400InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with an unexpected payload {'property': 'value'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get202None204NoneDefaultNone400Invalid(RequestContext)']/*" />
        public virtual Response Get202None204NoneDefaultNone400Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet202None204NoneDefaultNone400InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA200ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultModelA200ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA200ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with valid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA200Valid(RequestContext)']/*" />
        public virtual Response GetDefaultModelA200Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA200ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA200NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultModelA200NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA200NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA200None(RequestContext)']/*" />
        public virtual Response GetDefaultModelA200None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA200NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultModelA400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA400Valid(RequestContext)']/*" />
        public virtual Response GetDefaultModelA400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA400NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultModelA400NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA400NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultModelA400None(RequestContext)']/*" />
        public virtual Response GetDefaultModelA400None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultModelA400NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone200InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultNone200InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone200InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload: {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone200Invalid(RequestContext)']/*" />
        public virtual Response GetDefaultNone200Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone200InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone200NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultNone200NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone200NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone200None(RequestContext)']/*" />
        public virtual Response GetDefaultNone200None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone200NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone400InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultNone400InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone400InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with valid payload: {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone400Invalid(RequestContext)']/*" />
        public virtual Response GetDefaultNone400Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone400InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone400NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultNone400NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone400NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='GetDefaultNone400None(RequestContext)']/*" />
        public virtual Response GetDefaultNone400None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultNone400NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA200NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200None(RequestContext)']/*" />
        public virtual Response Get200ModelA200None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with payload {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA200ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with payload {'statusCode': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA200Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload {'statusCodeInvalid': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA200InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload {'statusCodeInvalid': '200'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA200Invalid(RequestContext)']/*" />
        public virtual Response Get200ModelA200Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA200InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload client should treat as an http error with no error model
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400NoneAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA400NoneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400NoneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 400 response with no payload client should treat as an http error with no error model
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400None(RequestContext)']/*" />
        public virtual Response Get200ModelA400None(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400None");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400NoneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with payload {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA400ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with payload {'statusCode': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA400Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload {'statusCodeInvalid': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA400InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400InvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 200 response with invalid payload {'statusCodeInvalid': '400'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA400Invalid(RequestContext)']/*" />
        public virtual Response Get200ModelA400Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA400InvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with payload {'statusCode': '202'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA202ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> Get200ModelA202ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA202Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA202ValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send a 202 response with payload {'statusCode': '202'}
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
        /// <include file="Docs/MultipleResponsesClient.xml" path="doc/members/member[@name='Get200ModelA202Valid(RequestContext)']/*" />
        public virtual Response Get200ModelA202Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA202Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGet200ModelA202ValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError200ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError204ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError201InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError202NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model204NoModelDefaultError400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError200ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError201ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200Model201ModelDefaultError400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/B/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError200ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201404);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError201ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201404);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/201/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError404ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201404);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/404/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA201ModelC404ModelDDefaultError400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201404);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/201/C/404/D/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultError202NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/202/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultError204NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/204/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultError400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/Error/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone202InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/202/invalid", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone204NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/204/none", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone400NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGet202None204NoneDefaultNone400InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/202/none/204/none/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGetDefaultModelA200ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDefaultModelA200NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/200/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDefaultModelA400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDefaultModelA400NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/A/response/400/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDefaultNone200InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/200/invalid", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGetDefaultNone200NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/200/none", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGetDefaultNone400InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/400/invalid", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGetDefaultNone400NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/default/none/response/400/none", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateGet200ModelA200NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA200ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA200InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/200/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA400NoneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/none", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA400ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA400InvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/400/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGet200ModelA202ValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/payloads/200/A/response/202/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200204;
        private static ResponseClassifier ResponseClassifier200204 => _responseClassifier200204 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 204 });
        private static ResponseClassifier _responseClassifier200201;
        private static ResponseClassifier ResponseClassifier200201 => _responseClassifier200201 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201 });
        private static ResponseClassifier _responseClassifier200201404;
        private static ResponseClassifier ResponseClassifier200201404 => _responseClassifier200201404 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201, 404 });
        private static ResponseClassifier _responseClassifier202204;
        private static ResponseClassifier ResponseClassifier202204 => _responseClassifier202204 ??= new StatusCodeClassifier(stackalloc ushort[] { 202, 204 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
