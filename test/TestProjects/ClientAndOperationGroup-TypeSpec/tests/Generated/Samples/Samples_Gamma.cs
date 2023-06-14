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

namespace Azure.ClientAndOperationGroupService.Samples
{
    internal class Samples_Gamma
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Four()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = client.Four();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Four_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = client.Four();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Four_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Four_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Five()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = client.Five();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Five_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = client.Five();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Five_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Five_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
