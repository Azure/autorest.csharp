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
using extensible_enums_swagger.Models;

namespace extensible_enums_swagger
{
    internal partial class PetRestClient
    {
        private string host;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of PetRestClient. </summary>
        public PetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetByPetIdRequest(string petId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/extensibleenums/pet/", false);
            uri.AppendPath(petId, true);
            request.Uri = uri;
            return message;
        }

        /// <param name="petId"> Pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Pet>> GetByPetIdAsync(string petId, CancellationToken cancellationToken = default)
        {
            if (petId == null)
            {
                throw new ArgumentNullException(nameof(petId));
            }

            using var message = CreateGetByPetIdRequest(petId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = Pet.DeserializePet(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <param name="petId"> Pet id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Pet> GetByPetId(string petId, CancellationToken cancellationToken = default)
        {
            if (petId == null)
            {
                throw new ArgumentNullException(nameof(petId));
            }

            using var message = CreateGetByPetIdRequest(petId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = Pet.DeserializePet(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAddPetRequest(Pet petParam)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/extensibleenums/pet/addPet", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            if (petParam != null)
            {
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(petParam);
                request.Content = content;
            }
            return message;
        }

        /// <param name="petParam"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Pet>> AddPetAsync(Pet petParam = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAddPetRequest(petParam);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = Pet.DeserializePet(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <param name="petParam"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Pet> AddPet(Pet petParam = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAddPetRequest(petParam);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Pet value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = Pet.DeserializePet(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
