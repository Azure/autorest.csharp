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
using ModelReaderWriterValidationTypeSpec.Models;

namespace ModelReaderWriterValidationTypeSpec
{
    // Data plane generated client.
    /// <summary> This is a typespec project to validation the model reader writer functionalities. </summary>
    public partial class ModelReaderWriterValidationTypeSpecClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ModelReaderWriterValidationTypeSpecClient for mocking. </summary>
        protected ModelReaderWriterValidationTypeSpecClient()
        {
        }

        /// <summary> Initializes a new instance of ModelReaderWriterValidationTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ModelReaderWriterValidationTypeSpecClient(Uri endpoint) : this(endpoint, new ModelReaderWriterValidationTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ModelReaderWriterValidationTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ModelReaderWriterValidationTypeSpecClient(Uri endpoint, ModelReaderWriterValidationTypeSpecClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            options ??= new ModelReaderWriterValidationTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <param name="body"> The <see cref="ModelAsStruct"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op1Async(ModelAsStruct,CancellationToken)']/*" />
        public virtual async Task<Response<ModelAsStruct>> Op1Async(ModelAsStruct body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = await Op1Async(content, context).ConfigureAwait(false);
            return Response.FromValue(ModelAsStruct.FromResponse(response), response);
        }

        /// <param name="body"> The <see cref="ModelAsStruct"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op1(ModelAsStruct,CancellationToken)']/*" />
        public virtual Response<ModelAsStruct> Op1(ModelAsStruct body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = Op1(content, context);
            return Response.FromValue(ModelAsStruct.FromResponse(response), response);
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
        /// Please try the simpler <see cref="Op1Async(ModelAsStruct,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op1Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Op1Async(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op1");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp1Request(content, context);
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
        /// Please try the simpler <see cref="Op1(ModelAsStruct,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op1(RequestContent,RequestContext)']/*" />
        public virtual Response Op1(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op1");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp1Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The <see cref="ModelWithPersistableOnly"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op2Async(ModelWithPersistableOnly,CancellationToken)']/*" />
        public virtual async Task<Response<ModelWithPersistableOnly>> Op2Async(ModelWithPersistableOnly body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = await Op2Async(content, context).ConfigureAwait(false);
            return Response.FromValue(ModelWithPersistableOnly.FromResponse(response), response);
        }

        /// <param name="body"> The <see cref="ModelWithPersistableOnly"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op2(ModelWithPersistableOnly,CancellationToken)']/*" />
        public virtual Response<ModelWithPersistableOnly> Op2(ModelWithPersistableOnly body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = Op2(content, context);
            return Response.FromValue(ModelWithPersistableOnly.FromResponse(response), response);
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
        /// Please try the simpler <see cref="Op2Async(ModelWithPersistableOnly,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op2Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Op2Async(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp2Request(content, context);
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
        /// Please try the simpler <see cref="Op2(ModelWithPersistableOnly,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op2(RequestContent,RequestContext)']/*" />
        public virtual Response Op2(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp2Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The <see cref="BaseModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op3Async(BaseModel,CancellationToken)']/*" />
        public virtual async Task<Response<BaseModel>> Op3Async(BaseModel body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = await Op3Async(content, context).ConfigureAwait(false);
            return Response.FromValue(BaseModel.FromResponse(response), response);
        }

        /// <param name="body"> The <see cref="BaseModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op3(BaseModel,CancellationToken)']/*" />
        public virtual Response<BaseModel> Op3(BaseModel body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = Op3(content, context);
            return Response.FromValue(BaseModel.FromResponse(response), response);
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
        /// Please try the simpler <see cref="Op3Async(BaseModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op3Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Op3Async(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op3");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp3Request(content, context);
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
        /// Please try the simpler <see cref="Op3(BaseModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op3(RequestContent,RequestContext)']/*" />
        public virtual Response Op3(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op3");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp3Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The <see cref="AvailabilitySetData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op4Async(AvailabilitySetData,CancellationToken)']/*" />
        public virtual async Task<Response<AvailabilitySetData>> Op4Async(AvailabilitySetData body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = await Op4Async(content, context).ConfigureAwait(false);
            return Response.FromValue(AvailabilitySetData.FromResponse(response), response);
        }

        /// <param name="body"> The <see cref="AvailabilitySetData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op4(AvailabilitySetData,CancellationToken)']/*" />
        public virtual Response<AvailabilitySetData> Op4(AvailabilitySetData body, CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = Op4(content, context);
            return Response.FromValue(AvailabilitySetData.FromResponse(response), response);
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
        /// Please try the simpler <see cref="Op4Async(AvailabilitySetData,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op4Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> Op4Async(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op4");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp4Request(content, context);
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
        /// Please try the simpler <see cref="Op4(AvailabilitySetData,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op4(RequestContent,RequestContext)']/*" />
        public virtual Response Op4(RequestContent content, RequestContext context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op4");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp4Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op5Async(CancellationToken)']/*" />
        public virtual async Task<Response<ResourceProviderData>> Op5Async(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await Op5Async(context).ConfigureAwait(false);
            return Response.FromValue(ResourceProviderData.FromResponse(response), response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op5(CancellationToken)']/*" />
        public virtual Response<ResourceProviderData> Op5(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Op5(context);
            return Response.FromValue(ResourceProviderData.FromResponse(response), response);
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
        /// Please try the simpler <see cref="Op5Async(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op5Async(RequestContext)']/*" />
        public virtual async Task<Response> Op5Async(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op5");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp5Request(context);
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
        /// Please try the simpler <see cref="Op5(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ModelReaderWriterValidationTypeSpecClient.xml" path="doc/members/member[@name='Op5(RequestContext)']/*" />
        public virtual Response Op5(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ModelReaderWriterValidationTypeSpecClient.Op5");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOp5Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOp1Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/api/ModelAsStruct", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOp2Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/api/ModelWithPersistableOnly", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOp3Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/api/DiscriminatedSet", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOp4Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/api/AvailabilitySet", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOp5Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/api/ResourceProvider", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
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
