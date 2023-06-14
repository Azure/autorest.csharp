// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using ModelsTypeSpec.Models;

namespace ModelsTypeSpec
{
    // Data plane generated client.
    /// <summary> CADL project to test various types of models. </summary>
    public partial class ModelsTypeSpecClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ModelsTypeSpecClient for mocking. </summary>
        protected ModelsTypeSpecClient()
        {
        }

        /// <summary> Initializes a new instance of ModelsTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ModelsTypeSpecClient(Uri endpoint) : this(endpoint, new ModelsTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ModelsTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ModelsTypeSpecClient(Uri endpoint, ModelsTypeSpecClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ModelsTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='GetOutputDiscriminatorModelAsync(CancellationToken)']/*" />
        public virtual async Task<Response<OutputBaseModelWithDiscriminator>> GetOutputDiscriminatorModelAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetOutputDiscriminatorModelAsync(context).ConfigureAwait(false);
            return Response.FromValue(OutputBaseModelWithDiscriminator.FromResponse(response), response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='GetOutputDiscriminatorModel(CancellationToken)']/*" />
        public virtual Response<OutputBaseModelWithDiscriminator> GetOutputDiscriminatorModel(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetOutputDiscriminatorModel(context);
            return Response.FromValue(OutputBaseModelWithDiscriminator.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetOutputDiscriminatorModelAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='GetOutputDiscriminatorModelAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetOutputDiscriminatorModelAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.GetOutputDiscriminatorModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOutputDiscriminatorModelRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetOutputDiscriminatorModel(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='GetOutputDiscriminatorModel(RequestContext)']/*" />
        public virtual Response GetOutputDiscriminatorModel(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.GetOutputDiscriminatorModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOutputDiscriminatorModelRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Input model that has property of its own type. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripAsync(InputModel,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripModel>> InputToRoundTripAsync(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InputToRoundTripAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripModel.FromResponse(response), response);
        }

        /// <summary> Input model that has property of its own type. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTrip(InputModel,CancellationToken)']/*" />
        public virtual Response<RoundTripModel> InputToRoundTrip(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InputToRoundTrip(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Input model that has property of its own type
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripAsync(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> InputToRoundTripAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTrip");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Input model that has property of its own type
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTrip(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTrip(RequestContent,RequestContext)']/*" />
        public virtual Response InputToRoundTrip(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTrip");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Input to RoundTripPrimitive. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripPrimitiveAsync(InputModel,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripPrimitiveModel>> InputToRoundTripPrimitiveAsync(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InputToRoundTripPrimitiveAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripPrimitiveModel.FromResponse(response), response);
        }

        /// <summary> Input to RoundTripPrimitive. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripPrimitive(InputModel,CancellationToken)']/*" />
        public virtual Response<RoundTripPrimitiveModel> InputToRoundTripPrimitive(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InputToRoundTripPrimitive(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripPrimitiveModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripPrimitive
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripPrimitiveAsync(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripPrimitiveAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> InputToRoundTripPrimitiveAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripPrimitive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripPrimitiveRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripPrimitive
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripPrimitive(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripPrimitive(RequestContent,RequestContext)']/*" />
        public virtual Response InputToRoundTripPrimitive(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripPrimitive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripPrimitiveRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Input to RoundTripOptional. </summary>
        /// <param name="input"> The RoundTripOptionalModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripOptionalAsync(RoundTripOptionalModel,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripOptionalModel>> InputToRoundTripOptionalAsync(RoundTripOptionalModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InputToRoundTripOptionalAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripOptionalModel.FromResponse(response), response);
        }

        /// <summary> Input to RoundTripOptional. </summary>
        /// <param name="input"> The RoundTripOptionalModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripOptional(RoundTripOptionalModel,CancellationToken)']/*" />
        public virtual Response<RoundTripOptionalModel> InputToRoundTripOptional(RoundTripOptionalModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InputToRoundTripOptional(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripOptionalModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripOptional
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripOptionalAsync(RoundTripOptionalModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripOptionalAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> InputToRoundTripOptionalAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripOptionalRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripOptional
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripOptional(RoundTripOptionalModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripOptional(RequestContent,RequestContext)']/*" />
        public virtual Response InputToRoundTripOptional(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripOptionalRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Input to RoundTripReadOnly. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripReadOnlyAsync(InputModel,CancellationToken)']/*" />
        [Obsolete("deprecated for test")]
        public virtual async Task<Response<RoundTripReadOnlyModel>> InputToRoundTripReadOnlyAsync(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InputToRoundTripReadOnlyAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripReadOnlyModel.FromResponse(response), response);
        }

        /// <summary> Input to RoundTripReadOnly. </summary>
        /// <param name="input"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripReadOnly(InputModel,CancellationToken)']/*" />
        [Obsolete("deprecated for test")]
        public virtual Response<RoundTripReadOnlyModel> InputToRoundTripReadOnly(InputModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InputToRoundTripReadOnly(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripReadOnlyModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripReadOnly
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripReadOnlyAsync(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripReadOnlyAsync(RequestContent,RequestContext)']/*" />
        [Obsolete("deprecated for test")]
        public virtual async Task<Response> InputToRoundTripReadOnlyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripReadOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripReadOnlyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Input to RoundTripReadOnly
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToRoundTripReadOnly(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputToRoundTripReadOnly(RequestContent,RequestContext)']/*" />
        [Obsolete("deprecated for test")]
        public virtual Response InputToRoundTripReadOnly(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputToRoundTripReadOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToRoundTripReadOnlyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RoundTrip to Output. </summary>
        /// <param name="input"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputAsync(RoundTripModel,CancellationToken)']/*" />
        public virtual async Task<Response<OutputModel>> RoundTripToOutputAsync(RoundTripModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RoundTripToOutputAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(OutputModel.FromResponse(response), response);
        }

        /// <summary> RoundTrip to Output. </summary>
        /// <param name="input"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutput(RoundTripModel,CancellationToken)']/*" />
        public virtual Response<OutputModel> RoundTripToOutput(RoundTripModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RoundTripToOutput(input.ToRequestContent(), context);
            return Response.FromValue(OutputModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] RoundTrip to Output
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripToOutputAsync(RoundTripModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RoundTripToOutputAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripToOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripToOutputRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RoundTrip to Output
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripToOutput(RoundTripModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutput(RequestContent,RequestContext)']/*" />
        public virtual Response RoundTripToOutput(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripToOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripToOutputRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Input recursive model. </summary>
        /// <param name="input"> The InputRecursiveModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputRecursiveAsync(InputRecursiveModel,CancellationToken)']/*" />
        public virtual async Task<Response> InputRecursiveAsync(InputRecursiveModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InputRecursiveAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Input recursive model. </summary>
        /// <param name="input"> The InputRecursiveModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputRecursive(InputRecursiveModel,CancellationToken)']/*" />
        public virtual Response InputRecursive(InputRecursiveModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InputRecursive(input.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Input recursive model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputRecursiveAsync(InputRecursiveModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputRecursiveAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> InputRecursiveAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputRecursive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputRecursiveRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Input recursive model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputRecursive(InputRecursiveModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='InputRecursive(RequestContent,RequestContext)']/*" />
        public virtual Response InputRecursive(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.InputRecursive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputRecursiveRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RoundTrip recursive model. </summary>
        /// <param name="input"> The RoundTripRecursiveModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripRecursiveAsync(RoundTripRecursiveModel,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripRecursiveModel>> RoundTripRecursiveAsync(RoundTripRecursiveModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RoundTripRecursiveAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripRecursiveModel.FromResponse(response), response);
        }

        /// <summary> RoundTrip recursive model. </summary>
        /// <param name="input"> The RoundTripRecursiveModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripRecursive(RoundTripRecursiveModel,CancellationToken)']/*" />
        public virtual Response<RoundTripRecursiveModel> RoundTripRecursive(RoundTripRecursiveModel input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RoundTripRecursive(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripRecursiveModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] RoundTrip recursive model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripRecursiveAsync(RoundTripRecursiveModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripRecursiveAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RoundTripRecursiveAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripRecursive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripRecursiveRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] RoundTrip recursive model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripRecursive(RoundTripRecursiveModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripRecursive(RequestContent,RequestContext)']/*" />
        public virtual Response RoundTripRecursive(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripRecursive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripRecursiveRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns model that has property of its own type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='SelfReferenceAsync(CancellationToken)']/*" />
        public virtual async Task<Response<ErrorModel>> SelfReferenceAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SelfReferenceAsync(context).ConfigureAwait(false);
            return Response.FromValue(ErrorModel.FromResponse(response), response);
        }

        /// <summary> Returns model that has property of its own type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='SelfReference(CancellationToken)']/*" />
        public virtual Response<ErrorModel> SelfReference(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SelfReference(context);
            return Response.FromValue(ErrorModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Returns model that has property of its own type
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SelfReferenceAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='SelfReferenceAsync(RequestContext)']/*" />
        public virtual async Task<Response> SelfReferenceAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.SelfReference");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSelfReferenceRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns model that has property of its own type
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SelfReference(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='SelfReference(RequestContext)']/*" />
        public virtual Response SelfReference(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.SelfReference");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSelfReferenceRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns RoundTripOnNoUse. </summary>
        /// <param name="input"> The RoundTripOnNoUse to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputWithNoUseBaseAsync(RoundTripOnNoUse,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripOnNoUse>> RoundTripToOutputWithNoUseBaseAsync(RoundTripOnNoUse input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RoundTripToOutputWithNoUseBaseAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripOnNoUse.FromResponse(response), response);
        }

        /// <summary> Returns RoundTripOnNoUse. </summary>
        /// <param name="input"> The RoundTripOnNoUse to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputWithNoUseBase(RoundTripOnNoUse,CancellationToken)']/*" />
        public virtual Response<RoundTripOnNoUse> RoundTripToOutputWithNoUseBase(RoundTripOnNoUse input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RoundTripToOutputWithNoUseBase(input.ToRequestContent(), context);
            return Response.FromValue(RoundTripOnNoUse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Returns RoundTripOnNoUse
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripToOutputWithNoUseBaseAsync(RoundTripOnNoUse,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputWithNoUseBaseAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RoundTripToOutputWithNoUseBaseAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripToOutputWithNoUseBase");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripToOutputWithNoUseBaseRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns RoundTripOnNoUse
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RoundTripToOutputWithNoUseBase(RoundTripOnNoUse,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelsTypeSpecClient.xml" path="doc/members/member[@name='RoundTripToOutputWithNoUseBase(RequestContent,RequestContext)']/*" />
        public virtual Response RoundTripToOutputWithNoUseBase(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ModelsTypeSpecClient.RoundTripToOutputWithNoUseBase");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripToOutputWithNoUseBaseRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetOutputDiscriminatorModelRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pet", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateInputToRoundTripRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/inputToRoundTrip", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateInputToRoundTripPrimitiveRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/inputToRoundTripPrimitive", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateInputToRoundTripOptionalRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/inputToRoundTripOptional", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateInputToRoundTripReadOnlyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/inputToRoundTripReadOnly", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateRoundTripToOutputRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/roundTripToOutput", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateInputRecursiveRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/inputRecursive", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateRoundTripRecursiveRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/roundTripRecursive", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSelfReferenceRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/selfReference", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRoundTripToOutputWithNoUseBaseRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
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
