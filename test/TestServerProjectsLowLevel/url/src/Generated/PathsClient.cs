// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace url_LowLevel
{
    // Data plane generated client.
    /// <summary> The Paths service client. </summary>
    public partial class PathsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PathsClient for mocking. </summary>
        protected PathsClient()
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public PathsClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestUrlTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public PathsClient(AzureKeyCredential credential, Uri endpoint, AutoRestUrlTestServiceClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutoRestUrlTestServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Get true Boolean value on path
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetBooleanTrueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetBooleanTrueAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetBooleanTrue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanTrueRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get true Boolean value on path
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetBooleanTrue(RequestContext)']/*" />
        public virtual Response GetBooleanTrue(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetBooleanTrue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanTrueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get false Boolean value on path
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetBooleanFalseAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetBooleanFalseAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetBooleanFalse");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanFalseRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get false Boolean value on path
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetBooleanFalse(RequestContext)']/*" />
        public virtual Response GetBooleanFalse(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetBooleanFalse");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanFalseRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '1000000' integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetIntOneMillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetIntOneMillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetIntOneMillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntOneMillionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '1000000' integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetIntOneMillion(RequestContext)']/*" />
        public virtual Response GetIntOneMillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetIntOneMillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntOneMillionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-1000000' integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetIntNegativeOneMillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetIntNegativeOneMillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntNegativeOneMillionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-1000000' integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetIntNegativeOneMillion(RequestContext)']/*" />
        public virtual Response GetIntNegativeOneMillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetIntNegativeOneMillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntNegativeOneMillionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '10000000000' 64 bit integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetTenBillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetTenBillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetTenBillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTenBillionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '10000000000' 64 bit integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetTenBillion(RequestContext)']/*" />
        public virtual Response GetTenBillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetTenBillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetTenBillionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-10000000000' 64 bit integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetNegativeTenBillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetNegativeTenBillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetNegativeTenBillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNegativeTenBillionRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-10000000000' 64 bit integer value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='GetNegativeTenBillion(RequestContext)']/*" />
        public virtual Response GetNegativeTenBillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetNegativeTenBillion");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNegativeTenBillionRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '1.034E+20' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='FloatScientificPositiveAsync(RequestContext)']/*" />
        public virtual async Task<Response> FloatScientificPositiveAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.FloatScientificPositive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatScientificPositiveRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '1.034E+20' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='FloatScientificPositive(RequestContext)']/*" />
        public virtual Response FloatScientificPositive(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.FloatScientificPositive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatScientificPositiveRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-1.034E-20' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='FloatScientificNegativeAsync(RequestContext)']/*" />
        public virtual async Task<Response> FloatScientificNegativeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.FloatScientificNegative");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatScientificNegativeRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-1.034E-20' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='FloatScientificNegative(RequestContext)']/*" />
        public virtual Response FloatScientificNegative(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.FloatScientificNegative");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatScientificNegativeRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '9999999.999' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DoubleDecimalPositiveAsync(RequestContext)']/*" />
        public virtual async Task<Response> DoubleDecimalPositiveAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DoubleDecimalPositive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleDecimalPositiveRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '9999999.999' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DoubleDecimalPositive(RequestContext)']/*" />
        public virtual Response DoubleDecimalPositive(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DoubleDecimalPositive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleDecimalPositiveRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-9999999.999' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DoubleDecimalNegativeAsync(RequestContext)']/*" />
        public virtual async Task<Response> DoubleDecimalNegativeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DoubleDecimalNegative");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleDecimalNegativeRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '-9999999.999' numeric value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DoubleDecimalNegative(RequestContext)']/*" />
        public virtual Response DoubleDecimalNegative(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DoubleDecimalNegative");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleDecimalNegativeRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUnicodeAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringUnicodeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUnicode");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUnicodeRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '啊齄丂狛狜隣郎隣兀﨩' multi-byte string value
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUnicode(RequestContext)']/*" />
        public virtual Response StringUnicode(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUnicode");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUnicodeRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'begin!*'();:@ &amp;=+$,/?#[]end
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUrlEncodedAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringUrlEncodedAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUrlEncoded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUrlEncodedRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'begin!*'();:@ &amp;=+$,/?#[]end
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUrlEncoded(RequestContext)']/*" />
        public virtual Response StringUrlEncoded(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUrlEncoded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUrlEncodedRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'begin!*'();:@&amp;=+$,end
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUrlNonEncodedAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringUrlNonEncodedAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUrlNonEncoded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUrlNonEncodedRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'begin!*'();:@&amp;=+$,end
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringUrlNonEncoded(RequestContext)']/*" />
        public virtual Response StringUrlNonEncoded(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringUrlNonEncoded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringUrlNonEncodedRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get ''
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringEmptyAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringEmptyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringEmptyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get ''
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringEmpty(RequestContext)']/*" />
        public virtual Response StringEmpty(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringEmptyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (should throw)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="stringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringNullAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> StringNullAsync(string stringPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(stringPath, nameof(stringPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringNullRequest(stringPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (should throw)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringPath"> null string value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="stringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='StringNull(string,RequestContext)']/*" />
        public virtual Response StringNull(string stringPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(stringPath, nameof(stringPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.StringNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringNullRequest(stringPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get using uri with 'green color' in path parameter
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumPath"> send the value green. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="enumPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='EnumValidAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> EnumValidAsync(string enumPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(enumPath, nameof(enumPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.EnumValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumValidRequest(enumPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get using uri with 'green color' in path parameter
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumPath"> send the value green. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="enumPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='EnumValid(string,RequestContext)']/*" />
        public virtual Response EnumValid(string enumPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(enumPath, nameof(enumPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.EnumValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumValidRequest(enumPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (should throw on the client before the request is sent on wire)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumPath"> send null should throw. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="enumPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='EnumNullAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> EnumNullAsync(string enumPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(enumPath, nameof(enumPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.EnumNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumNullRequest(enumPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (should throw on the client before the request is sent on wire)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumPath"> send null should throw. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="enumPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='EnumNull(string,RequestContext)']/*" />
        public virtual Response EnumNull(string enumPath, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(enumPath, nameof(enumPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.EnumNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumNullRequest(enumPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="bytePath"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteMultiByteAsync(BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> ByteMultiByteAsync(BinaryData bytePath, RequestContext context = null)
        {
            Argument.AssertNotNull(bytePath, nameof(bytePath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteMultiByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteMultiByteRequest(bytePath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="bytePath"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteMultiByte(BinaryData,RequestContext)']/*" />
        public virtual Response ByteMultiByte(BinaryData bytePath, RequestContext context = null)
        {
            Argument.AssertNotNull(bytePath, nameof(bytePath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteMultiByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteMultiByteRequest(bytePath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '' as byte array
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteEmptyAsync(RequestContext)']/*" />
        public virtual async Task<Response> ByteEmptyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteEmptyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '' as byte array
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteEmpty(RequestContext)']/*" />
        public virtual Response ByteEmpty(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteEmptyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as byte array (should throw)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="bytePath"> null as byte array (should throw). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteNullAsync(BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> ByteNullAsync(BinaryData bytePath, RequestContext context = null)
        {
            Argument.AssertNotNull(bytePath, nameof(bytePath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteNullRequest(bytePath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as byte array (should throw)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="bytePath"> null as byte array (should throw). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bytePath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ByteNull(BinaryData,RequestContext)']/*" />
        public virtual Response ByteNull(BinaryData bytePath, RequestContext context = null)
        {
            Argument.AssertNotNull(bytePath, nameof(bytePath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ByteNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteNullRequest(bytePath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '2012-01-01' as date
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> DateValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '2012-01-01' as date
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateValid(RequestContext)']/*" />
        public virtual Response DateValid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date - this should throw or be unusable on the client side, depending on date representation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateNullAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> DateNullAsync(DateTimeOffset datePath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateNullRequest(datePath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date - this should throw or be unusable on the client side, depending on date representation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="datePath"> null as date (should throw). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateNull(DateTimeOffset,RequestContext)']/*" />
        public virtual Response DateNull(DateTimeOffset datePath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateNullRequest(datePath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '2012-01-01T01:01:01Z' as date-time
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateTimeValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> DateTimeValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateTimeValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get '2012-01-01T01:01:01Z' as date-time
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
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateTimeValid(RequestContext)']/*" />
        public virtual Response DateTimeValid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateTimeValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date-time, should be disallowed or throw depending on representation of date-time
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateTimeNullAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> DateTimeNullAsync(DateTimeOffset dateTimePath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateTimeNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeNullRequest(dateTimePath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date-time, should be disallowed or throw depending on representation of date-time
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateTimePath"> null as date-time. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='DateTimeNull(DateTimeOffset,RequestContext)']/*" />
        public virtual Response DateTimeNull(DateTimeOffset dateTimePath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.DateTimeNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeNullRequest(dateTimePath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'lorem' encoded value as 'bG9yZW0' (base64url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="base64UrlPath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='Base64UrlAsync(BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> Base64UrlAsync(BinaryData base64UrlPath, RequestContext context = null)
        {
            Argument.AssertNotNull(base64UrlPath, nameof(base64UrlPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.Base64Url");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBase64UrlRequest(base64UrlPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'lorem' encoded value as 'bG9yZW0' (base64url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="base64UrlPath"> base64url encoded value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="base64UrlPath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='Base64Url(BinaryData,RequestContext)']/*" />
        public virtual Response Base64Url(BinaryData base64UrlPath, RequestContext context = null)
        {
            Argument.AssertNotNull(base64UrlPath, nameof(base64UrlPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.Base64Url");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBase64UrlRequest(base64UrlPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayPath"> an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayPath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ArrayCsvInPathAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayCsvInPathAsync(IEnumerable<string> arrayPath, RequestContext context = null)
        {
            Argument.AssertNotNull(arrayPath, nameof(arrayPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ArrayCsvInPath");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayCsvInPathRequest(arrayPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayPath"> an array of string ['ArrayPath1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="arrayPath"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='ArrayCsvInPath(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayCsvInPath(IEnumerable<string> arrayPath, RequestContext context = null)
        {
            Argument.AssertNotNull(arrayPath, nameof(arrayPath));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.ArrayCsvInPath");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayCsvInPathRequest(arrayPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get the date 2016-04-13 encoded value as '1460505600' (Unix time)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='UnixTimeUrlAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> UnixTimeUrlAsync(DateTimeOffset unixTimeUrlPath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.UnixTimeUrl");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimeUrlRequest(unixTimeUrlPath, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get the date 2016-04-13 encoded value as '1460505600' (Unix time)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="unixTimeUrlPath"> Unix time encoded value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathsClient.xml" path="doc/members/member[@name='UnixTimeUrl(DateTimeOffset,RequestContext)']/*" />
        public virtual Response UnixTimeUrl(DateTimeOffset unixTimeUrlPath, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PathsClient.UnixTimeUrl");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnixTimeUrlRequest(unixTimeUrlPath, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetBooleanTrueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/bool/true/", false);
            uri.AppendPath(true, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetBooleanFalseRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/bool/false/", false);
            uri.AppendPath(false, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetIntOneMillionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/1000000/", false);
            uri.AppendPath(1000000, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetIntNegativeOneMillionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/-1000000/", false);
            uri.AppendPath(-1000000, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTenBillionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/long/10000000000/", false);
            uri.AppendPath(10000000000L, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetNegativeTenBillionRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/long/-10000000000/", false);
            uri.AppendPath(-10000000000L, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateFloatScientificPositiveRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/float/1.034E+20/", false);
            uri.AppendPath(1.034E+20F, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateFloatScientificNegativeRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/float/-1.034E-20/", false);
            uri.AppendPath(-1.034E-20F, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDoubleDecimalPositiveRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/double/9999999.999/", false);
            uri.AppendPath(9999999.999, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDoubleDecimalNegativeRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/double/-9999999.999/", false);
            uri.AppendPath(-9999999.999, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringUnicodeRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/unicode/", false);
            uri.AppendPath("啊齄丂狛狜隣郎隣兀﨩", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringUrlEncodedRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend/", false);
            uri.AppendPath("begin!*'();:@ &=+$,/?#[]end", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringUrlNonEncodedRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/begin!*'();:@&=+$,end/", false);
            uri.AppendPath("begin!*'();:@&=+$,end", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringEmptyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/empty/", false);
            uri.AppendPath("", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringNullRequest(string stringPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier400);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(stringPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateEnumValidRequest(string enumPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/enum/green%20color/", false);
            uri.AppendPath(enumPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateEnumNullRequest(string enumPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier400);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/null/", false);
            uri.AppendPath(enumPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateByteMultiByteRequest(BinaryData bytePath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/multibyte/", false);
            uri.AppendPath(bytePath.ToArray(), "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateByteEmptyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/empty/", false);
            uri.AppendPath(new byte[] { }, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateByteNullRequest(BinaryData bytePath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier400);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/byte/null/", false);
            uri.AppendPath(bytePath.ToArray(), "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/date/2012-01-01/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateNullRequest(DateTimeOffset datePath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier400);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/date/null/", false);
            uri.AppendPath(datePath, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateTimeValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/datetime/2012-01-01T01%3A01%3A01Z/", false);
            uri.AppendPath(new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "O", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset dateTimePath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier400);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/datetime/null/", false);
            uri.AppendPath(dateTimePath, "O", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateBase64UrlRequest(BinaryData base64UrlPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/string/bG9yZW0/", false);
            uri.AppendPath(base64UrlPath.ToArray(), "U", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayCsvInPathRequest(IEnumerable<string> arrayPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/array/ArrayPath1%2cbegin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend%2c%2c/", false);
            uri.AppendPath(arrayPath, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateUnixTimeUrlRequest(DateTimeOffset unixTimeUrlPath, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paths/int/1460505600/", false);
            uri.AppendPath(unixTimeUrlPath, "U", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier400;
        private static ResponseClassifier ResponseClassifier400 => _responseClassifier400 ??= new StatusCodeClassifier(stackalloc ushort[] { 400 });
    }
}
