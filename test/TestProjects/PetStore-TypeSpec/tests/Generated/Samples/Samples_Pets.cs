// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using PetStore;
using PetStore.Models;

namespace PetStore.Samples
{
    public partial class Samples_Pets
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Delete_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Delete(1234);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Delete_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.DeleteAsync(1234);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Delete_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Delete(1234);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Delete_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.DeleteAsync(1234);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Read_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Read(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Read_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.ReadAsync(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Read_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.Read(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Read_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.ReadAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Read_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Read(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Read_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.ReadAsync(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Read_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.Read(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Read_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.ReadAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Create_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = client.Create(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Create_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                age = 1234,
            });
            Response response = await client.CreateAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Create_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Pet pet = new Pet("<name>", 1234);
            Response<Pet> response = client.Create(pet);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Create_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Pet pet = new Pet("<name>", 1234);
            Response<Pet> response = await client.CreateAsync(pet);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Create_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                tag = "<tag>",
                age = 1234,
            });
            Response response = client.Create(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Create_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                tag = "<tag>",
                age = 1234,
            });
            Response response = await client.CreateAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Create_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Pet pet = new Pet("<name>", 1234)
            {
                Tag = "<tag>",
            };
            Response<Pet> response = client.Create(pet);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Create_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Pet pet = new Pet("<name>", 1234)
            {
                Tag = "<tag>",
            };
            Response<Pet> response = await client.CreateAsync(pet);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetPetByKind_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetPetByKind("dog");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetPetByKind_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetPetByKindAsync("dog");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetPetByKind_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.GetPetByKind(PetKind.Dog);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetPetByKind_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.GetPetByKindAsync(PetKind.Dog);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetPetByKind_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetPetByKind("dog");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetPetByKind_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetPetByKindAsync("dog");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetPetByKind_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.GetPetByKind(PetKind.Dog);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetPetByKind_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.GetPetByKindAsync(PetKind.Dog);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFirstPet_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetFirstPet(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFirstPet_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetFirstPetAsync(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFirstPet_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.GetFirstPet();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFirstPet_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.GetFirstPetAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFirstPet_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetFirstPet(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFirstPet_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetFirstPetAsync(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("tag").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFirstPet_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = client.GetFirstPet(start: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFirstPet_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Pet> response = await client.GetFirstPetAsync(start: 1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFish_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetFish(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("size").ToString());
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFish_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetFishAsync(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("size").ToString());
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFish_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Fish> response = client.GetFish();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFish_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Fish> response = await client.GetFishAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFish_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.GetFish("<kind>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("size").ToString());
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFish_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.GetFishAsync("<kind>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("size").ToString());
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_GetFish_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Fish> response = client.GetFish(kind: "<kind>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_GetFish_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response<Fish> response = await client.GetFishAsync(kind: "<kind>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Refresh_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Refresh();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Refresh_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.RefreshAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Pets_Refresh_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = client.Refresh();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Pets_Refresh_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Pets client = new PetStoreClient(endpoint).GetPetsClient();

            Response response = await client.RefreshAsync();

            Console.WriteLine(response.Status);
        }
    }
}
