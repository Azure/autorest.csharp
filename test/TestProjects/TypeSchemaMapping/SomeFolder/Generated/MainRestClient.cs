// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CustomNamespace;
using TypeSchemaMapping.Models;

namespace TypeSchemaMapping
{
    internal partial class MainRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of MainRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public MainRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateOperationRequest(CustomizedModel body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/Operation/", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> OperationAsync(CustomizedModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Operation(CustomizedModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationStructRequest(RenamedModelStruct? body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationStruct/", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The ModelStruct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RenamedModelStruct>> OperationStructAsync(RenamedModelStruct? body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationStructRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedModelStruct value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RenamedModelStruct.DeserializeRenamedModelStruct(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The ModelStruct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RenamedModelStruct> OperationStruct(RenamedModelStruct? body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationStructRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedModelStruct value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RenamedModelStruct.DeserializeRenamedModelStruct(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationSecondModelRequest(SecondModel body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationSecondModel", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The SecondModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SecondModel>> OperationSecondModelAsync(SecondModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationSecondModelRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecondModel value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SecondModel.DeserializeSecondModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The SecondModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SecondModel> OperationSecondModel(SecondModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationSecondModelRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SecondModel value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SecondModel.DeserializeSecondModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationThirdModelRequest(RenamedThirdModel body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationThirdModel", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The ThirdModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RenamedThirdModel>> OperationThirdModelAsync(RenamedThirdModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationThirdModelRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedThirdModel value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RenamedThirdModel.DeserializeRenamedThirdModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The ThirdModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RenamedThirdModel> OperationThirdModel(RenamedThirdModel body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationThirdModelRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedThirdModel value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RenamedThirdModel.DeserializeRenamedThirdModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationModelWithArrayOfEnumRequest(ModelWithArrayOfEnum body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationModelWithArrayOfEnum", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The ModelWithArrayOfEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithArrayOfEnum>> OperationModelWithArrayOfEnumAsync(ModelWithArrayOfEnum body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationModelWithArrayOfEnumRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithArrayOfEnum value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ModelWithArrayOfEnum.DeserializeModelWithArrayOfEnum(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The ModelWithArrayOfEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithArrayOfEnum> OperationModelWithArrayOfEnum(ModelWithArrayOfEnum body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationModelWithArrayOfEnumRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithArrayOfEnum value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ModelWithArrayOfEnum.DeserializeModelWithArrayOfEnum(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationWithInternalModelRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationWithInternalModel", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithInternalModel>> OperationWithInternalModelAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithInternalModelRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithInternalModel value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ModelWithInternalModel.DeserializeModelWithInternalModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithInternalModel> OperationWithInternalModel(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithInternalModelRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithInternalModel value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ModelWithInternalModel.DeserializeModelWithInternalModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationWithAbstractModelRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationWithAbstractModel", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithAbstractModel>> OperationWithAbstractModelAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithAbstractModelRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithAbstractModel value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ModelWithAbstractModel.DeserializeModelWithAbstractModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithAbstractModel> OperationWithAbstractModel(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithAbstractModelRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithAbstractModel value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ModelWithAbstractModel.DeserializeModelWithAbstractModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationWithListOfInternalModelRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationWithListOfInternalModel", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithListOfInternalModel>> OperationWithListOfInternalModelAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithListOfInternalModelRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithListOfInternalModel value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ModelWithListOfInternalModel.DeserializeModelWithListOfInternalModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithListOfInternalModel> OperationWithListOfInternalModel(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithListOfInternalModelRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithListOfInternalModel value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ModelWithListOfInternalModel.DeserializeModelWithListOfInternalModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationWithPublicModelWithInternalPropertyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationWithPublicModelWithInternalProperty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<PublicModelWithInternalProperty>> OperationWithPublicModelWithInternalPropertyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithPublicModelWithInternalPropertyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PublicModelWithInternalProperty value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PublicModelWithInternalProperty.DeserializePublicModelWithInternalProperty(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PublicModelWithInternalProperty> OperationWithPublicModelWithInternalProperty(CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationWithPublicModelWithInternalPropertyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PublicModelWithInternalProperty value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PublicModelWithInternalProperty.DeserializePublicModelWithInternalProperty(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
