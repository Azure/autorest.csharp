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
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PetRestClient. </summary>
        public PetRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetByPetIdRequest(string petId)
        {
            var message = pipeline.CreateMessage();
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

            using var scope = clientDiagnostics.CreateScope("PetClient.GetByPetId");
            scope.Start();
            try
            {
                using var message = CreateGetByPetIdRequest(petId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Pet.DeserializePet(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using var scope = clientDiagnostics.CreateScope("PetClient.GetByPetId");
            scope.Start();
            try
            {
                using var message = CreateGetByPetIdRequest(petId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Pet.DeserializePet(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateAddPetRequest(Pet petParam)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/extensibleenums/pet/addPet", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(petParam);
            request.Content = content;
            return message;
        }
        /// <param name="petParam"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Pet>> AddPetAsync(Pet petParam, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PetClient.AddPet");
            scope.Start();
            try
            {
                using var message = CreateAddPetRequest(petParam);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Pet.DeserializePet(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <param name="petParam"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Pet> AddPet(Pet petParam, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PetClient.AddPet");
            scope.Start();
            try
            {
                using var message = CreateAddPetRequest(petParam);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Pet.DeserializePet(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
