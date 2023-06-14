// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_formdata_urlencoded.Models;

namespace body_formdata_urlencoded
{
    internal partial class FormdataurlencodedRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of FormdataurlencodedRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public FormdataurlencodedRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateUpdatePetWithFormRequest(int petId, PetType petType, PetFood petFood, int petAge, string name, string status)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/formsdataurlencoded/pet/add/", false);
            uri.AppendPath(petId, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var content = new FormUrlEncodedContent();
            content.Add("pet_type", petType.ToSerialString());
            content.Add("pet_food", petFood.ToString());
            content.Add("pet_age", petAge.ToString());
            if (name != null)
            {
                content.Add("name", name);
            }
            if (status != null)
            {
                content.Add("status", status);
            }
            request.Content = content;
            return message;
        }

        /// <summary> Updates a pet in the store with form data. </summary>
        /// <param name="petId"> ID of pet that needs to be updated. </param>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        /// <param name="name"> Updated name of the pet. </param>
        /// <param name="status"> Updated status of the pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> UpdatePetWithFormAsync(int petId, PetType petType, PetFood petFood, int petAge, string name = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateUpdatePetWithFormRequest(petId, petType, petFood, petAge, name, status);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 405:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a pet in the store with form data. </summary>
        /// <param name="petId"> ID of pet that needs to be updated. </param>
        /// <param name="petType"> Can take a value of dog, or cat, or fish. </param>
        /// <param name="petFood"> Can take a value of meat, or fish, or plant. </param>
        /// <param name="petAge"> How many years is it old?. </param>
        /// <param name="name"> Updated name of the pet. </param>
        /// <param name="status"> Updated status of the pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response UpdatePetWithForm(int petId, PetType petType, PetFood petFood, int petAge, string name = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateUpdatePetWithFormRequest(petId, petType, petFood, petAge, name, status);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 405:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePartialConstantBodyRequest(PostContentSchemaGrantType grantType, string service, string accessToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/formsdataurlencoded/partialConstantBody", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var content = new FormUrlEncodedContent();
            content.Add("grant_type", grantType.ToString());
            content.Add("service", service);
            content.Add("access_token", accessToken);
            request.Content = content;
            return message;
        }

        /// <summary> Test a partially constant formdata body. Pass in { grant_type: 'access_token', access_token: 'foo', service: 'bar' } to pass the test. </summary>
        /// <param name="grantType"> Constant part of a formdata body. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="accessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> or <paramref name="accessToken"/> is null. </exception>
        public async Task<Response> PartialConstantBodyAsync(PostContentSchemaGrantType grantType, string service, string accessToken, CancellationToken cancellationToken = default)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            using var message = CreatePartialConstantBodyRequest(grantType, service, accessToken);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Test a partially constant formdata body. Pass in { grant_type: 'access_token', access_token: 'foo', service: 'bar' } to pass the test. </summary>
        /// <param name="grantType"> Constant part of a formdata body. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="accessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> or <paramref name="accessToken"/> is null. </exception>
        public Response PartialConstantBody(PostContentSchemaGrantType grantType, string service, string accessToken, CancellationToken cancellationToken = default)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            using var message = CreatePartialConstantBodyRequest(grantType, service, accessToken);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
