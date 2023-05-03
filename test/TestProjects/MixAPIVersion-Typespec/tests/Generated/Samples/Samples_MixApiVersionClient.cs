// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace MixApiVersion.Samples
{
    public class Samples_MixApiVersionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MixApiVersionClient(endpoint);

            Response response = client.Delete("<name>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Read()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MixApiVersionClient(endpoint);

            Response response = client.Read(1234);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Create()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MixApiVersionClient(endpoint);

            var data = new
            {
                age = 1234,
            };

            Response response = client.Create(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("age").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPets()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MixApiVersionClient(endpoint);

            foreach (var data in client.GetPets())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("petId").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }
    }
}
