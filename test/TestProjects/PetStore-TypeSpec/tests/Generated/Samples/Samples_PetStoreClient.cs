// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using PetStore.Models;

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
        public void Example_Delete_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.DeleteAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.DeleteAsync(1234);
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
        public void Example_Read_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.Read(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Read_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.ReadAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Read_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.ReadAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Read_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var result = await client.ReadAsync(1234);
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
        public void Example_Create_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var data = new
            {
                name = "<name>",
                tag = "<tag>",
                age = 1234,
            };

            Response response = client.Create(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Create_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var data = new
            {
                name = "<name>",
                age = 1234,
            };

            Response response = await client.CreateAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Create_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var data = new
            {
                name = "<name>",
                tag = "<tag>",
                age = 1234,
            };

            Response response = await client.CreateAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Create_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var pet = new Pet("<name>", 1234)
            {
                Tag = "<Tag>",
            };
            var result = await client.CreateAsync(pet);
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
        public void Example_GetPetByKind_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetPetByKind("<kind>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPetByKind_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetPetByKindAsync("<kind>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPetByKind_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetPetByKindAsync("<kind>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPetByKind_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var result = await client.GetPetByKindAsync(null);
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

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFirstPet_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetFirstPet(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFirstPet_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetFirstPetAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFirstPet_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetFirstPetAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFirstPet_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var result = await client.GetFirstPetAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFish()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetFish("<kind>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFish_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = client.GetFish("<kind>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFish_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetFishAsync("<kind>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFish_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            Response response = await client.GetFishAsync("<kind>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("size").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFish_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PetStoreClient(endpoint);

            var result = await client.GetFishAsync("<kind>");
        }
    }
}
