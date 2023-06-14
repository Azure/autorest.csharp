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
    /// <summary> The Queries service client. </summary>
    public partial class QueriesClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of QueriesClient for mocking. </summary>
        protected QueriesClient()
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public QueriesClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestUrlTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public QueriesClient(AzureKeyCredential credential, Uri endpoint, AutoRestUrlTestServiceClientOptions options)
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanTrueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetBooleanTrueAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanTrue");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanTrue(RequestContext)']/*" />
        public virtual Response GetBooleanTrue(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanTrue");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanFalseAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetBooleanFalseAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanFalse");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanFalse(RequestContext)']/*" />
        public virtual Response GetBooleanFalse(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanFalse");
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
        /// [Protocol Method] Get null Boolean value on query (query string should be absent)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanNullAsync(bool?,RequestContext)']/*" />
        public virtual async Task<Response> GetBooleanNullAsync(bool? boolQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanNullRequest(boolQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null Boolean value on query (query string should be absent)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="boolQuery"> null boolean value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetBooleanNull(bool?,RequestContext)']/*" />
        public virtual Response GetBooleanNull(bool? boolQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetBooleanNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBooleanNullRequest(boolQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntOneMillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetIntOneMillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntOneMillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntOneMillion(RequestContext)']/*" />
        public virtual Response GetIntOneMillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntOneMillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntNegativeOneMillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetIntNegativeOneMillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntNegativeOneMillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntNegativeOneMillion(RequestContext)']/*" />
        public virtual Response GetIntNegativeOneMillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntNegativeOneMillion");
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
        /// [Protocol Method] Get null integer value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntNullAsync(int?,RequestContext)']/*" />
        public virtual async Task<Response> GetIntNullAsync(int? intQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntNullRequest(intQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null integer value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="intQuery"> null integer value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetIntNull(int?,RequestContext)']/*" />
        public virtual Response GetIntNull(int? intQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetIntNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetIntNullRequest(intQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetTenBillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetTenBillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetTenBillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetTenBillion(RequestContext)']/*" />
        public virtual Response GetTenBillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetTenBillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetNegativeTenBillionAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetNegativeTenBillionAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetNegativeTenBillion");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetNegativeTenBillion(RequestContext)']/*" />
        public virtual Response GetNegativeTenBillion(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetNegativeTenBillion");
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
        /// [Protocol Method] Get 'null 64 bit integer value (no query param in uri)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetLongNullAsync(long?,RequestContext)']/*" />
        public virtual async Task<Response> GetLongNullAsync(long? longQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetLongNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLongNullRequest(longQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get 'null 64 bit integer value (no query param in uri)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="longQuery"> null 64 bit integer value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='GetLongNull(long?,RequestContext)']/*" />
        public virtual Response GetLongNull(long? longQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.GetLongNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLongNullRequest(longQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatScientificPositiveAsync(RequestContext)']/*" />
        public virtual async Task<Response> FloatScientificPositiveAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatScientificPositive");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatScientificPositive(RequestContext)']/*" />
        public virtual Response FloatScientificPositive(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatScientificPositive");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatScientificNegativeAsync(RequestContext)']/*" />
        public virtual async Task<Response> FloatScientificNegativeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatScientificNegative");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatScientificNegative(RequestContext)']/*" />
        public virtual Response FloatScientificNegative(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatScientificNegative");
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
        /// [Protocol Method] Get null numeric value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatNullAsync(float?,RequestContext)']/*" />
        public virtual async Task<Response> FloatNullAsync(float? floatQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatNullRequest(floatQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null numeric value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="floatQuery"> null numeric value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='FloatNull(float?,RequestContext)']/*" />
        public virtual Response FloatNull(float? floatQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.FloatNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatNullRequest(floatQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleDecimalPositiveAsync(RequestContext)']/*" />
        public virtual async Task<Response> DoubleDecimalPositiveAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleDecimalPositive");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleDecimalPositive(RequestContext)']/*" />
        public virtual Response DoubleDecimalPositive(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleDecimalPositive");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleDecimalNegativeAsync(RequestContext)']/*" />
        public virtual async Task<Response> DoubleDecimalNegativeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleDecimalNegative");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleDecimalNegative(RequestContext)']/*" />
        public virtual Response DoubleDecimalNegative(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleDecimalNegative");
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
        /// [Protocol Method] Get null numeric value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleNullAsync(double?,RequestContext)']/*" />
        public virtual async Task<Response> DoubleNullAsync(double? doubleQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleNullRequest(doubleQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null numeric value (no query parameter)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="doubleQuery"> null numeric value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DoubleNull(double?,RequestContext)']/*" />
        public virtual Response DoubleNull(double? doubleQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DoubleNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDoubleNullRequest(doubleQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringUnicodeAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringUnicodeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringUnicode");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringUnicode(RequestContext)']/*" />
        public virtual Response StringUnicode(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringUnicode");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringUrlEncodedAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringUrlEncodedAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringUrlEncoded");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringUrlEncoded(RequestContext)']/*" />
        public virtual Response StringUrlEncoded(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringUrlEncoded");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringEmptyAsync(RequestContext)']/*" />
        public virtual async Task<Response> StringEmptyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringEmpty");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringEmpty(RequestContext)']/*" />
        public virtual Response StringEmpty(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringEmpty");
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
        /// [Protocol Method] Get null (no query parameter in url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringNullAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> StringNullAsync(string stringQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringNullRequest(stringQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (no query parameter in url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="stringQuery"> null string value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='StringNull(string,RequestContext)']/*" />
        public virtual Response StringNull(string stringQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.StringNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringNullRequest(stringQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get using uri with query parameter 'green color'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumQuery"> 'green color' enum value. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='EnumValidAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> EnumValidAsync(string enumQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.EnumValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumValidRequest(enumQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get using uri with query parameter 'green color'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumQuery"> 'green color' enum value. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='EnumValid(string,RequestContext)']/*" />
        public virtual Response EnumValid(string enumQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.EnumValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumValidRequest(enumQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (no query parameter in url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumQuery"> null string value. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='EnumNullAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> EnumNullAsync(string enumQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.EnumNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumNullRequest(enumQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null (no query parameter in url)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="enumQuery"> null string value. Allowed values: "red color" | "green color" | "blue color". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='EnumNull(string,RequestContext)']/*" />
        public virtual Response EnumNull(string enumQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.EnumNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateEnumNullRequest(enumQuery, context);
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
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteMultiByteAsync(BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> ByteMultiByteAsync(BinaryData byteQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteMultiByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteMultiByteRequest(byteQuery, context);
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
        /// <param name="byteQuery"> '啊齄丂狛狜隣郎隣兀﨩' multibyte value as utf-8 encoded byte array. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteMultiByte(BinaryData,RequestContext)']/*" />
        public virtual Response ByteMultiByte(BinaryData byteQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteMultiByte");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteMultiByteRequest(byteQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteEmptyAsync(RequestContext)']/*" />
        public virtual async Task<Response> ByteEmptyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteEmpty");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteEmpty(RequestContext)']/*" />
        public virtual Response ByteEmpty(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteEmpty");
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
        /// [Protocol Method] Get null as byte array (no query parameters in uri)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteNullAsync(BinaryData,RequestContext)']/*" />
        public virtual async Task<Response> ByteNullAsync(BinaryData byteQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteNullRequest(byteQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as byte array (no query parameters in uri)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="byteQuery"> null as byte array (no query parameters in uri). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ByteNull(BinaryData,RequestContext)']/*" />
        public virtual Response ByteNull(BinaryData byteQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ByteNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateByteNullRequest(byteQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> DateValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateValid");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateValid(RequestContext)']/*" />
        public virtual Response DateValid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateValid");
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
        /// [Protocol Method] Get null as date - this should result in no query parameters in uri
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateNullAsync(DateTimeOffset?,RequestContext)']/*" />
        public virtual async Task<Response> DateNullAsync(DateTimeOffset? dateQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateNullRequest(dateQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date - this should result in no query parameters in uri
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateQuery"> null as date (no query parameters in uri). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateNull(DateTimeOffset?,RequestContext)']/*" />
        public virtual Response DateNull(DateTimeOffset? dateQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateNullRequest(dateQuery, context);
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateTimeValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> DateTimeValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateTimeValid");
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
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateTimeValid(RequestContext)']/*" />
        public virtual Response DateTimeValid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateTimeValid");
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
        /// [Protocol Method] Get null as date-time, should result in no query parameters in uri
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateTimeNullAsync(DateTimeOffset?,RequestContext)']/*" />
        public virtual async Task<Response> DateTimeNullAsync(DateTimeOffset? dateTimeQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateTimeNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeNullRequest(dateTimeQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get null as date-time, should result in no query parameters in uri
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dateTimeQuery"> null as date-time (no query parameters). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='DateTimeNull(DateTimeOffset?,RequestContext)']/*" />
        public virtual Response DateTimeNull(DateTimeOffset? dateTimeQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.DateTimeNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDateTimeNullRequest(dateTimeQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvValidAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringCsvValidAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvValidRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvValid(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringCsvValid(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvValidRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a null array of string using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvNullAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringCsvNullAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvNullRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a null array of string using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> a null array of string using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvNull(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringCsvNull(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvNullRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an empty array [] of string using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvEmptyAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringCsvEmptyAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvEmptyRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an empty array [] of string using the csv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the csv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringCsvEmpty(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringCsvEmpty(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringCsvEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringCsvEmptyRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringNoCollectionFormatEmptyAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringNoCollectionFormatEmptyAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringNoCollectionFormatEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringNoCollectionFormatEmptyRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Array query has no defined collection format, should default to csv. Pass in ['hello', 'nihao', 'bonjour'] for the 'arrayQuery' parameter to the service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> Array-typed query parameter. Pass in ['hello', 'nihao', 'bonjour']. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringNoCollectionFormatEmpty(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringNoCollectionFormatEmpty(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringNoCollectionFormatEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringNoCollectionFormatEmptyRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringSsvValidAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringSsvValidAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringSsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringSsvValidRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the ssv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringSsvValid(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringSsvValid(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringSsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringSsvValidRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringTsvValidAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringTsvValidAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringTsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringTsvValidRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the tsv-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringTsvValid(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringTsvValid(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringTsvValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringTsvValidRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringPipesValidAsync(IEnumerable{string},RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringPipesValidAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringPipesValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringPipesValidRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' , null, ''] using the pipes-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringPipesValid(IEnumerable{string},RequestContext)']/*" />
        public virtual Response ArrayStringPipesValid(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringPipesValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringPipesValidRequest(arrayQuery, context);
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
            uri.AppendPath("/queries/bool/true", false);
            uri.AppendQuery("boolQuery", true, true);
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
            uri.AppendPath("/queries/bool/false", false);
            uri.AppendQuery("boolQuery", false, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetBooleanNullRequest(bool? boolQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/bool/null", false);
            if (boolQuery != null)
            {
                uri.AppendQuery("boolQuery", boolQuery.Value, true);
            }
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
            uri.AppendPath("/queries/int/1000000", false);
            uri.AppendQuery("intQuery", 1000000, true);
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
            uri.AppendPath("/queries/int/-1000000", false);
            uri.AppendQuery("intQuery", -1000000, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetIntNullRequest(int? intQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/int/null", false);
            if (intQuery != null)
            {
                uri.AppendQuery("intQuery", intQuery.Value, true);
            }
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
            uri.AppendPath("/queries/long/10000000000", false);
            uri.AppendQuery("longQuery", 10000000000L, true);
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
            uri.AppendPath("/queries/long/-10000000000", false);
            uri.AppendQuery("longQuery", -10000000000L, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetLongNullRequest(long? longQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/long/null", false);
            if (longQuery != null)
            {
                uri.AppendQuery("longQuery", longQuery.Value, true);
            }
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
            uri.AppendPath("/queries/float/1.034E+20", false);
            uri.AppendQuery("floatQuery", 1.034E+20F, true);
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
            uri.AppendPath("/queries/float/-1.034E-20", false);
            uri.AppendQuery("floatQuery", -1.034E-20F, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateFloatNullRequest(float? floatQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/float/null", false);
            if (floatQuery != null)
            {
                uri.AppendQuery("floatQuery", floatQuery.Value, true);
            }
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
            uri.AppendPath("/queries/double/9999999.999", false);
            uri.AppendQuery("doubleQuery", 9999999.999, true);
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
            uri.AppendPath("/queries/double/-9999999.999", false);
            uri.AppendQuery("doubleQuery", -9999999.999, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDoubleNullRequest(double? doubleQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/double/null", false);
            if (doubleQuery != null)
            {
                uri.AppendQuery("doubleQuery", doubleQuery.Value, true);
            }
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
            uri.AppendPath("/queries/string/unicode/", false);
            uri.AppendQuery("stringQuery", "啊齄丂狛狜隣郎隣兀﨩", true);
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
            uri.AppendPath("/queries/string/begin%21%2A%27%28%29%3B%3A%40%20%26%3D%2B%24%2C%2F%3F%23%5B%5Dend", false);
            uri.AppendQuery("stringQuery", "begin!*'();:@ &=+$,/?#[]end", true);
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
            uri.AppendPath("/queries/string/empty", false);
            uri.AppendQuery("stringQuery", "", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringNullRequest(string stringQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/string/null", false);
            if (stringQuery != null)
            {
                uri.AppendQuery("stringQuery", stringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateEnumValidRequest(string enumQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/enum/green%20color", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateEnumNullRequest(string enumQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/enum/null", false);
            if (enumQuery != null)
            {
                uri.AppendQuery("enumQuery", enumQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateByteMultiByteRequest(BinaryData byteQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/byte/multibyte", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery.ToArray(), "D", true);
            }
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
            uri.AppendPath("/queries/byte/empty", false);
            uri.AppendQuery("byteQuery", new byte[] { }, "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateByteNullRequest(BinaryData byteQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/byte/null", false);
            if (byteQuery != null)
            {
                uri.AppendQuery("byteQuery", byteQuery.ToArray(), "D", true);
            }
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
            uri.AppendPath("/queries/date/2012-01-01", false);
            uri.AppendQuery("dateQuery", new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), "D", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateNullRequest(DateTimeOffset? dateQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/date/null", false);
            if (dateQuery != null)
            {
                uri.AppendQuery("dateQuery", dateQuery.Value, "D", true);
            }
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
            uri.AppendPath("/queries/datetime/2012-01-01T01%3A01%3A01Z", false);
            uri.AppendQuery("dateTimeQuery", new DateTimeOffset(2012, 1, 1, 1, 1, 1, 0, TimeSpan.Zero), "O", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDateTimeNullRequest(DateTimeOffset? dateTimeQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/datetime/null", false);
            if (dateTimeQuery != null)
            {
                uri.AppendQuery("dateTimeQuery", dateTimeQuery.Value, "O", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringCsvValidRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringCsvNullRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/null", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringCsvEmptyRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/csv/string/empty", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringNoCollectionFormatEmptyRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/none/string/empty", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringSsvValidRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/ssv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, " ", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringTsvValidRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/tsv/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "\t", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringPipesValidRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/pipes/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, "|", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
