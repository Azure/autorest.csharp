// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Parameters_LowLevel
{
    // Data plane generated client.
    /// <summary> The ParametersLowlevel service client. </summary>
    public partial class ParametersLowlevelClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ParametersLowlevelClient for mocking. </summary>
        protected ParametersLowlevelClient()
        {
        }

        /// <summary> Initializes a new instance of ParametersLowlevelClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public ParametersLowlevelClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new ParametersLowlevelClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ParametersLowlevelClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public ParametersLowlevelClient(AzureKeyCredential credential, Uri endpoint, ParametersLowlevelClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ParametersLowlevelClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] No RequestBody and ResponseBody
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="status"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='NoRequestBodyResponseBodyAsync(int,int?,int,string,RequestContext)']/*" />
        public virtual async Task<Response> NoRequestBodyResponseBodyAsync(int id, int? top = null, int skip = 12, string status = "start", RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.NoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyResponseBodyRequest(id, top, skip, status, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No RequestBody and ResponseBody
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="status"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='NoRequestBodyResponseBody(int,int?,int,string,RequestContext)']/*" />
        public virtual Response NoRequestBodyResponseBody(int id, int? top = null, int skip = 12, string status = "start", RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.NoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyResponseBodyRequest(id, top, skip, status, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RequestBody and ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='RequestBodyResponseBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RequestBodyResponseBodyAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.RequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyResponseBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RequestBody and ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='RequestBodyResponseBody(RequestContent,RequestContext)']/*" />
        public virtual Response RequestBodyResponseBody(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.RequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyResponseBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='DeleteNoRequestBodyResponseBodyAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteNoRequestBodyResponseBodyAsync(string resourceName, RequestContext context = null)
        {
            Argument.AssertNotNull(resourceName, nameof(resourceName));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.DeleteNoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteNoRequestBodyResponseBodyRequest(resourceName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='DeleteNoRequestBodyResponseBody(string,RequestContext)']/*" />
        public virtual Response DeleteNoRequestBodyResponseBody(string resourceName, RequestContext context = null)
        {
            Argument.AssertNotNull(resourceName, nameof(resourceName));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.DeleteNoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteNoRequestBodyResponseBodyRequest(resourceName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No RequestBody and No ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='NoRequestBodyNoResponseBodyAsync(RequestContext)']/*" />
        public virtual async Task<Response> NoRequestBodyNoResponseBodyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.NoRequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyNoResponseBodyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No RequestBody and No ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='NoRequestBodyNoResponseBody(RequestContext)']/*" />
        public virtual Response NoRequestBodyNoResponseBody(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.NoRequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyNoResponseBodyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RequestBody and No ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='RequestBodyNoResponseBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RequestBodyNoResponseBodyAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.RequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyNoResponseBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RequestBody and No ResponseBody
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
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='RequestBodyNoResponseBody(RequestContent,RequestContext)']/*" />
        public virtual Response RequestBodyNoResponseBody(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.RequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyNoResponseBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional PathParameters
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathParametersAsync(int,int,string,RequestContext)']/*" />
        public virtual async Task<Response> OptionalPathParametersAsync(int id, int skip, string name = "start", RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathParametersRequest(id, skip, name, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional PathParameters
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathParameters(int,int,string,RequestContext)']/*" />
        public virtual Response OptionalPathParameters(int id, int skip, string name = "start", RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathParametersRequest(id, skip, name, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional path parameters with mixed sequence
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathParametersWithMixedSequenceAsync(int,string,int,RequestContext)']/*" />
        public virtual async Task<Response> OptionalPathParametersWithMixedSequenceAsync(int id, string name = "start", int skip = 12, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathParametersWithMixedSequence");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathParametersWithMixedSequenceRequest(id, name, skip, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional path parameters with mixed sequence
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathParametersWithMixedSequence(int,string,int,RequestContext)']/*" />
        public virtual Response OptionalPathParametersWithMixedSequence(int id, string name = "start", int skip = 12, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathParametersWithMixedSequence");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathParametersWithMixedSequenceRequest(id, name, skip, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional path/body parameters with mixed sequence
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="max"> Query parameter max. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathBodyParametersWithMixedSequenceAsync(string,int,RequestContent,int,int?,int,RequestContext)']/*" />
        public virtual async Task<Response> OptionalPathBodyParametersWithMixedSequenceAsync(string name, int skip, RequestContent content, int id = 123, int? top = null, int max = 50, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathBodyParametersWithMixedSequence");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathBodyParametersWithMixedSequenceRequest(name, skip, content, id, top, max, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Optional path/body parameters with mixed sequence
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Query parameter status. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="max"> Query parameter max. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParametersLowlevelClient.xml" path="doc/members/member[@name='OptionalPathBodyParametersWithMixedSequence(string,int,RequestContent,int,int?,int,RequestContext)']/*" />
        public virtual Response OptionalPathBodyParametersWithMixedSequence(string name, int skip, RequestContent content, int id = 123, int? top = null, int max = 50, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ParametersLowlevelClient.OptionalPathBodyParametersWithMixedSequence");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOptionalPathBodyParametersWithMixedSequenceRequest(name, skip, content, id, top, max, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateNoRequestBodyResponseBodyRequest(int id, int? top, int skip, string status, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            uri.AppendQuery("id", id, true);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            uri.AppendQuery("skip", skip, true);
            if (status != null)
            {
                uri.AppendQuery("status", status, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRequestBodyResponseBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteNoRequestBodyResponseBodyRequest(string resourceName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            uri.AppendQuery("resourceName", resourceName, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNoRequestBodyNoResponseBodyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test2", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateRequestBodyNoResponseBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test2", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOptionalPathParametersRequest(int id, int skip, string name, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test3/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("skip", skip, true);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateOptionalPathParametersWithMixedSequenceRequest(int id, string name, int skip, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test4/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("skip", skip, true);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateOptionalPathBodyParametersWithMixedSequenceRequest(string name, int skip, RequestContent content, int id, int? top, int max, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test5/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("skip", skip, true);
            if (top != null)
            {
                uri.AppendQuery("top", top.Value, true);
            }
            uri.AppendQuery("max", max, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
