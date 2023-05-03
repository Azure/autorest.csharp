// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace PetStore.Samples
{
    public class Samples_PetStoreClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Read()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.Read(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Create()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = client.Create(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPetByKind()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetPetByKind("<kind>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFirstPet()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetFirstPet(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }
    }
}
