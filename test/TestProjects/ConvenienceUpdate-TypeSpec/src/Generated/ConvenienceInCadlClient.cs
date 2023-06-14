// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using ConvenienceInCadl.Models;

namespace ConvenienceInCadl
{
    // Data plane generated client.
    /// <summary> Typespec project to test various types of convenience methods. </summary>
    public partial class ConvenienceInCadlClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ConvenienceInCadlClient. </summary>
        public ConvenienceInCadlClient() : this(new ConvenienceInCadlClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConvenienceInCadlClient. </summary>
        /// <param name="options"> The options for configuring the client. </param>
        public ConvenienceInCadlClient(ConvenienceInCadlClientOptions options)
        {
            options ??= new ConvenienceInCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _apiVersion = options.Version;
        }

        /// <summary> No initial operation methods. In the updated version, we add the protocol method and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='UpdateConvenienceAsync(CancellationToken)']/*" />
        public virtual async Task<Response<Model>> UpdateConvenienceAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UpdateConvenienceAsync(context).ConfigureAwait(false);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary> No initial operation methods. In the updated version, we add the protocol method and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='UpdateConvenience(CancellationToken)']/*" />
        public virtual Response<Model> UpdateConvenience(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UpdateConvenience(context);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] No initial operation methods. In the updated version, we add the protocol method and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UpdateConvenienceAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='UpdateConvenienceAsync(RequestContext)']/*" />
        public virtual async Task<Response> UpdateConvenienceAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.UpdateConvenience");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateConvenienceRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No initial operation methods. In the updated version, we add the protocol method and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UpdateConvenience(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='UpdateConvenience(RequestContext)']/*" />
        public virtual Response UpdateConvenience(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.UpdateConvenience");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateConvenienceRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No initial operation methods. In the updated version, we add the protocol method and convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalBeforeRequiredAsync(Model,int?,CancellationToken)']/*" />
        public virtual async Task<Response> ConvenienceOptionalBeforeRequiredAsync(Model required, int? optional = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceOptionalBeforeRequiredAsync(required.ToRequestContent(), optional, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> No initial operation methods. In the updated version, we add the protocol method and convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalBeforeRequired(Model,int?,CancellationToken)']/*" />
        public virtual Response ConvenienceOptionalBeforeRequired(Model required, int? optional = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceOptionalBeforeRequired(required.ToRequestContent(), optional, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] No initial operation methods. In the updated version, we add the protocol method and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalBeforeRequiredAsync(Model,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalBeforeRequiredAsync(RequestContent,int?,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceOptionalBeforeRequiredAsync(RequestContent content, int? optional = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalBeforeRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalBeforeRequiredRequest(content, optional, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No initial operation methods. In the updated version, we add the protocol method and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalBeforeRequired(Model,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalBeforeRequired(RequestContent,int?,RequestContext)']/*" />
        public virtual Response ConvenienceOptionalBeforeRequired(RequestContent content, int? optional = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalBeforeRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalBeforeRequiredRequest(content, optional, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method. In the updated version, we add the convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolValueAsync(CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ProtocolValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ProtocolAsync(context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method. In the updated version, we add the convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolValue(CancellationToken)']/*" />
        public virtual Response<Model> ProtocolValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Protocol(context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolValueAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolAsync(RequestContext)']/*" />
        public virtual async Task<Response> ProtocolAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.Protocol");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolValue(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='Protocol(RequestContext)']/*" />
        public virtual Response Protocol(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.Protocol");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional RequestContext and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithOptionalValueAsync(CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceWithOptionalValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ConvenienceWithOptionalAsync(context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional RequestContext and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithOptionalValue(CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceWithOptionalValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ConvenienceWithOptional(context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceWithOptionalValueAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithOptionalAsync(RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceWithOptionalAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceWithOptionalRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceWithOptionalValue(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithOptional(RequestContext)']/*" />
        public virtual Response ConvenienceWithOptional(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceWithOptionalRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with required RequestContext and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithRequiredAsync(CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceWithRequiredAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceWithRequiredAsync(context).ConfigureAwait(false);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary> Operation has protocol method with required RequestContext and convenience method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithRequired(CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceWithRequired(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceWithRequired(context);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceWithRequiredAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithRequiredAsync(RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceWithRequiredAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceWithRequiredRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceWithRequired(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceWithRequired(RequestContext)']/*" />
        public virtual Response ConvenienceWithRequired(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceWithRequiredRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method marked with convenience method, but the convenience method should not be generated.
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
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceShouldNotGenerateAsync(RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceShouldNotGenerateAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceShouldNotGenerate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceShouldNotGenerateRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method marked with convenience method, but the convenience method should not be generated.
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
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceShouldNotGenerate(RequestContext)']/*" />
        public virtual Response ConvenienceShouldNotGenerate(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceShouldNotGenerate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceShouldNotGenerateRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method, but the convenience method should not be generated even it marks the convenience decorator.
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
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolShouldNotGenerateConvenienceAsync(RequestContext)']/*" />
        public virtual async Task<Response> ProtocolShouldNotGenerateConvenienceAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolShouldNotGenerateConvenience");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolShouldNotGenerateConvenienceRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method, but the convenience method should not be generated even it marks the convenience decorator.
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
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolShouldNotGenerateConvenience(RequestContext)']/*" />
        public virtual Response ProtocolShouldNotGenerateConvenience(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolShouldNotGenerateConvenience");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolShouldNotGenerateConvenienceRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with optional query parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalQueryValueAsync(int?,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ProtocolOptionalQueryValueAsync(int? optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalQueryValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ProtocolOptionalQueryAsync(optional, context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with optional query parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalQueryValue(int?,CancellationToken)']/*" />
        public virtual Response<Model> ProtocolOptionalQueryValue(int? optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalQueryValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ProtocolOptionalQuery(optional, context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with optional query parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalQueryValueAsync(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalQueryAsync(int?,RequestContext)']/*" />
        public virtual async Task<Response> ProtocolOptionalQueryAsync(int? optional = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalQuery");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalQueryRequest(optional, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with optional query parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalQueryValue(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalQuery(int?,RequestContext)']/*" />
        public virtual Response ProtocolOptionalQuery(int? optional = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalQuery");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalQueryRequest(optional, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with required query parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredQueryValueAsync(int,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ProtocolRequiredQueryValueAsync(int required, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredQueryValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ProtocolRequiredQueryAsync(required, context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with required query parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredQueryValue(int,CancellationToken)']/*" />
        public virtual Response<Model> ProtocolRequiredQueryValue(int required, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredQueryValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ProtocolRequiredQuery(required, context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with required query parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolRequiredQueryValueAsync(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredQueryAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> ProtocolRequiredQueryAsync(int required, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredQuery");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequiredQueryRequest(required, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with required query parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolRequiredQueryValue(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredQuery(int,RequestContext)']/*" />
        public virtual Response ProtocolRequiredQuery(int required, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredQuery");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequiredQueryRequest(required, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with optional model parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalModelValueAsync(Model,CancellationToken)']/*" />
        public virtual async Task<Response> ProtocolOptionalModelValueAsync(Model optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalModelValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ProtocolOptionalModelAsync(optional?.ToRequestContent(), context).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with optional model parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalModelValue(Model,CancellationToken)']/*" />
        public virtual Response ProtocolOptionalModelValue(Model optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalModelValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ProtocolOptionalModel(optional?.ToRequestContent(), context);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with optional model parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalModelValueAsync(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalModelAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ProtocolOptionalModelAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalModelRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with optional model parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalModelValue(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalModel(RequestContent,RequestContext)']/*" />
        public virtual Response ProtocolOptionalModel(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalModelRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation only has protocol method with required model parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredModelAsync(Model,CancellationToken)']/*" />
        public virtual async Task<Response> ProtocolRequiredModelAsync(Model required, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ProtocolRequiredModelAsync(required.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Initial operation only has protocol method with required model parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredModel(Model,CancellationToken)']/*" />
        public virtual Response ProtocolRequiredModel(Model required, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ProtocolRequiredModel(required.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with required model parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolRequiredModelAsync(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredModelAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ProtocolRequiredModelAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequiredModelRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation only has protocol method with required model parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolRequiredModel(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolRequiredModel(RequestContent,RequestContext)']/*" />
        public virtual Response ProtocolRequiredModel(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolRequiredModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolRequiredModelRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional query parameter and optional RequestContext and convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithOptionalValueAsync(int?,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceOptionalQueryWithOptionalValueAsync(int? optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ConvenienceOptionalQueryWithOptionalAsync(optional, context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional query parameter and optional RequestContext and convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithOptionalValue(int?,CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceOptionalQueryWithOptionalValue(int? optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ConvenienceOptionalQueryWithOptional(optional, context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional query parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalQueryWithOptionalValueAsync(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithOptionalAsync(int?,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceOptionalQueryWithOptionalAsync(int? optional = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalQueryWithOptionalRequest(optional, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional query parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalQueryWithOptionalValue(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithOptional(int?,RequestContext)']/*" />
        public virtual Response ConvenienceOptionalQueryWithOptional(int? optional = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalQueryWithOptionalRequest(optional, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with required query parameter and optional RequestContext and convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithOptionalValueAsync(int,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceRequiredQueryWithOptionalValueAsync(int required, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ConvenienceRequiredQueryWithOptionalAsync(required, context).ConfigureAwait(false);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with required query parameter and optional RequestContext and convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithOptionalValue(int,CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceRequiredQueryWithOptionalValue(int required, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ConvenienceRequiredQueryWithOptional(required, context);
                return Response.FromValue(Model.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required query parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredQueryWithOptionalValueAsync(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithOptionalAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceRequiredQueryWithOptionalAsync(int required, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredQueryWithOptionalRequest(required, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required query parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredQueryWithOptionalValue(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithOptional(int,RequestContext)']/*" />
        public virtual Response ConvenienceRequiredQueryWithOptional(int required, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredQueryWithOptionalRequest(required, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional query parameter and required RequestContext and convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithRequiredAsync(int?,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceOptionalQueryWithRequiredAsync(int? optional = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceOptionalQueryWithRequiredAsync(optional, context).ConfigureAwait(false);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary> Operation has protocol method with optional query parameter and required RequestContext and convenience method. </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithRequired(int?,CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceOptionalQueryWithRequired(int? optional = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceOptionalQueryWithRequired(optional, context);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional query parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalQueryWithRequiredAsync(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithRequiredAsync(int?,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceOptionalQueryWithRequiredAsync(int? optional, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalQueryWithRequiredRequest(optional, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional query parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalQueryWithRequired(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalQueryWithRequired(int?,RequestContext)']/*" />
        public virtual Response ConvenienceOptionalQueryWithRequired(int? optional, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalQueryWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalQueryWithRequiredRequest(optional, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with required query parameter and required RequestContext and convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithRequiredAsync(int,CancellationToken)']/*" />
        public virtual async Task<Response<Model>> ConvenienceRequiredQueryWithRequiredAsync(int required, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceRequiredQueryWithRequiredAsync(required, context).ConfigureAwait(false);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary> Operation has protocol method with required query parameter and required RequestContext and convenience method. </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithRequired(int,CancellationToken)']/*" />
        public virtual Response<Model> ConvenienceRequiredQueryWithRequired(int required, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceRequiredQueryWithRequired(required, context);
            return Response.FromValue(Model.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required query parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredQueryWithRequiredAsync(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithRequiredAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceRequiredQueryWithRequiredAsync(int required, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredQueryWithRequiredRequest(required, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required query parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredQueryWithRequired(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="required"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredQueryWithRequired(int,RequestContext)']/*" />
        public virtual Response ConvenienceRequiredQueryWithRequired(int required, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredQueryWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredQueryWithRequiredRequest(required, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional body parameter and optional RequestContext and convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithOptionalValueAsync(Model,CancellationToken)']/*" />
        public virtual async Task<Response> ConvenienceOptionalModelWithOptionalValueAsync(Model optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ConvenienceOptionalModelWithOptionalAsync(optional?.ToRequestContent(), context).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional body parameter and optional RequestContext and convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithOptionalValue(Model,CancellationToken)']/*" />
        public virtual Response ConvenienceOptionalModelWithOptionalValue(Model optional = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithOptionalValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = ConvenienceOptionalModelWithOptional(optional?.ToRequestContent(), context);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional body parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalModelWithOptionalValueAsync(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithOptionalAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceOptionalModelWithOptionalAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalModelWithOptionalRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional body parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalModelWithOptionalValue(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithOptional(RequestContent,RequestContext)']/*" />
        public virtual Response ConvenienceOptionalModelWithOptional(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalModelWithOptionalRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with required body parameter and optional RequestContext and convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredModelWithOptionalAsync(Model,CancellationToken)']/*" />
        public virtual async Task<Response> ConvenienceRequiredModelWithOptionalAsync(Model required, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceRequiredModelWithOptionalAsync(required.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Operation has protocol method with required body parameter and optional RequestContext and convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredModelWithOptional(Model,CancellationToken)']/*" />
        public virtual Response ConvenienceRequiredModelWithOptional(Model required, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceRequiredModelWithOptional(required.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required body parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredModelWithOptionalAsync(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredModelWithOptionalAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceRequiredModelWithOptionalAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredModelWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredModelWithOptionalRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with required body parameter and optional RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceRequiredModelWithOptional(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceRequiredModelWithOptional(RequestContent,RequestContext)']/*" />
        public virtual Response ConvenienceRequiredModelWithOptional(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceRequiredModelWithOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceRequiredModelWithOptionalRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has protocol method with optional body parameter and required RequestContext and convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithRequiredAsync(Model,CancellationToken)']/*" />
        public virtual async Task<Response> ConvenienceOptionalModelWithRequiredAsync(Model optional = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ConvenienceOptionalModelWithRequiredAsync(optional?.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Operation has protocol method with optional body parameter and required RequestContext and convenience method. </summary>
        /// <param name="optional"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithRequired(Model,CancellationToken)']/*" />
        public virtual Response ConvenienceOptionalModelWithRequired(Model optional = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ConvenienceOptionalModelWithRequired(optional?.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional body parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalModelWithRequiredAsync(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithRequiredAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ConvenienceOptionalModelWithRequiredAsync(RequestContent content, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalModelWithRequiredRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation has protocol method with optional body parameter and required RequestContext and convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ConvenienceOptionalModelWithRequired(Model,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ConvenienceOptionalModelWithRequired(RequestContent,RequestContext)']/*" />
        public virtual Response ConvenienceOptionalModelWithRequired(RequestContent content, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ConvenienceOptionalModelWithRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateConvenienceOptionalModelWithRequiredRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initial operation has protocol method with optioanl parameter before required parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalBeforeRequiredAsync(Model,int?,CancellationToken)']/*" />
        public virtual async Task<Response> ProtocolOptionalBeforeRequiredAsync(Model required, int? optional = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ProtocolOptionalBeforeRequiredAsync(required.ToRequestContent(), optional, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Initial operation has protocol method with optioanl parameter before required parameter. In the updated version, we add the convenience method. </summary>
        /// <param name="required"> The Model to use. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalBeforeRequired(Model,int?,CancellationToken)']/*" />
        public virtual Response ProtocolOptionalBeforeRequired(Model required, int? optional = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(required, nameof(required));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ProtocolOptionalBeforeRequired(required.ToRequestContent(), optional, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Initial operation has protocol method with optioanl parameter before required parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalBeforeRequiredAsync(Model,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalBeforeRequiredAsync(RequestContent,int?,RequestContext)']/*" />
        public virtual async Task<Response> ProtocolOptionalBeforeRequiredAsync(RequestContent content, int? optional = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalBeforeRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalBeforeRequiredRequest(content, optional, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Initial operation has protocol method with optioanl parameter before required parameter. In the updated version, we add the convenience method.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ProtocolOptionalBeforeRequired(Model,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="optional"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConvenienceInCadlClient.xml" path="doc/members/member[@name='ProtocolOptionalBeforeRequired(RequestContent,int?,RequestContext)']/*" />
        public virtual Response ProtocolOptionalBeforeRequired(RequestContent content, int? optional = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConvenienceInCadlClient.ProtocolOptionalBeforeRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateProtocolOptionalBeforeRequiredRequest(content, optional, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateUpdateConvenienceRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/updateConvenience", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceOptionalBeforeRequiredRequest(RequestContent content, int? optional, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceOptionalBeforeRequired", false);
            if (optional != null)
            {
                uri.AppendQuery("optional", optional.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateProtocolRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocol", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceWithOptionalRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceWithOptional", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceWithRequiredRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceWithRequired", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceShouldNotGenerateRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceShouldNotGenerate", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateProtocolShouldNotGenerateConvenienceRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolShouldNotGenerateConvenience", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateProtocolOptionalQueryRequest(int? optional, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolOptionalQuery", false);
            if (optional != null)
            {
                uri.AppendQuery("optional", optional.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateProtocolRequiredQueryRequest(int required, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolRequiredQuery", false);
            uri.AppendQuery("required", required, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateProtocolOptionalModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolOptionalModel", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateProtocolRequiredModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolRequiredModel", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateConvenienceOptionalQueryWithOptionalRequest(int? optional, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceOptionalQueryWithOptional", false);
            if (optional != null)
            {
                uri.AppendQuery("optional", optional.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceRequiredQueryWithOptionalRequest(int required, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceRequiredQueryWithOptional", false);
            uri.AppendQuery("required", required, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceOptionalQueryWithRequiredRequest(int? optional, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceOptionalQueryWithRequired", false);
            if (optional != null)
            {
                uri.AppendQuery("optional", optional.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceRequiredQueryWithRequiredRequest(int required, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceRequiredQueryWithRequired", false);
            uri.AppendQuery("required", required, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateConvenienceOptionalModelWithOptionalRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceOptionalModelWithOptional", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateConvenienceRequiredModelWithOptionalRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceRequiredModelWithOptional", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateConvenienceOptionalModelWithRequiredRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/convenienceOptionalModelWithRequired", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateProtocolOptionalBeforeRequiredRequest(RequestContent content, int? optional, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/protocolOptionalBeforeRequired", false);
            if (optional != null)
            {
                uri.AppendQuery("optional", optional.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
