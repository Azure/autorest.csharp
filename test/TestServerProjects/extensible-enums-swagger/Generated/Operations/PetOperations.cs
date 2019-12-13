// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using extensible_enums_swagger.Models.V20160707;

namespace extensible_enums_swagger
{
    internal static class PetOperations
    {
        public static async ValueTask<Response<Pet>> GetByPetIdAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string petId, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (petId == null)
            {
                throw new ArgumentNullException(nameof(petId));
            }

            using var scope = clientDiagnostics.CreateScope("extensible_enums_swagger.GetByPetId");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/extensibleenums/pet/", false);
                request.Uri.AppendPath(petId, true);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Pet.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response<Pet>> AddPetAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Pet? petParam, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            using var scope = clientDiagnostics.CreateScope("extensible_enums_swagger.AddPet");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/extensibleenums/pet/addPet", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                var writer = content.JsonWriter;
                petParam?.Serialize(writer);
                request.Content = content;
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Pet.Deserialize(document.RootElement);
                            return Response.FromValue(value, response);
                        }
                    default:
                        throw new Exception();
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
