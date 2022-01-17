// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using xms_error_responses.Models;

namespace xms_error_responses
{
    internal partial class PetRestClient
    {
        private Uri endpoint;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of PetRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        public PetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            this.endpoint = endpoint ?? new Uri("http://localhost:3000");
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetPetByIdRequest(string petId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/errorStatusCodes/Pets/", false);
            uri.AppendPath(petId, true);
            uri.AppendPath("/GetPet", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Gets pets by id. </summary>
        /// <param name="petId"> pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="petId"/> is null. </exception>
        public async Task<Response<Pet>> GetPetByIdAsync(string petId, CancellationToken cancellationToken = default)
        {
            if (petId == null)
            {
                throw new ArgumentNullException(nameof(petId));
            }

            using var message = CreateGetPetByIdRequest(petId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Pet.DeserializePet(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 202:
                    return Response.FromValue((Pet)null, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets pets by id. </summary>
        /// <param name="petId"> pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="petId"/> is null. </exception>
        public Response<Pet> GetPetById(string petId, CancellationToken cancellationToken = default)
        {
            if (petId == null)
            {
                throw new ArgumentNullException(nameof(petId));
            }

            using var message = CreateGetPetByIdRequest(petId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Pet.DeserializePet(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 202:
                    return Response.FromValue((Pet)null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDoSomethingRequest(string whatAction)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/errorStatusCodes/Pets/doSomething/", false);
            uri.AppendPath(whatAction, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Asks pet to do something. </summary>
        /// <param name="whatAction"> what action the pet should do. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="whatAction"/> is null. </exception>
        public async Task<Response<PetAction>> DoSomethingAsync(string whatAction, CancellationToken cancellationToken = default)
        {
            if (whatAction == null)
            {
                throw new ArgumentNullException(nameof(whatAction));
            }

            using var message = CreateDoSomethingRequest(whatAction);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PetAction value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PetAction.DeserializePetAction(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Asks pet to do something. </summary>
        /// <param name="whatAction"> what action the pet should do. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="whatAction"/> is null. </exception>
        public Response<PetAction> DoSomething(string whatAction, CancellationToken cancellationToken = default)
        {
            if (whatAction == null)
            {
                throw new ArgumentNullException(nameof(whatAction));
            }

            using var message = CreateDoSomethingRequest(whatAction);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PetAction value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PetAction.DeserializePetAction(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHasModelsParamRequest(string models)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/errorStatusCodes/Pets/hasModelsParam", false);
            if (models != null)
            {
                uri.AppendQuery("models", models, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Ensure you can correctly deserialize the returned PetActionError and deserialization doesn&apos;t conflict with the input param name &apos;models&apos;. </summary>
        /// <param name="models"> Make sure model deserialization doesn&apos;t conflict with this param name, which has input name &apos;models&apos;. Use client default value in call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> HasModelsParamAsync(string models = "value1", CancellationToken cancellationToken = default)
        {
            using var message = CreateHasModelsParamRequest(models);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Ensure you can correctly deserialize the returned PetActionError and deserialization doesn&apos;t conflict with the input param name &apos;models&apos;. </summary>
        /// <param name="models"> Make sure model deserialization doesn&apos;t conflict with this param name, which has input name &apos;models&apos;. Use client default value in call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response HasModelsParam(string models = "value1", CancellationToken cancellationToken = default)
        {
            using var message = CreateHasModelsParamRequest(models);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
