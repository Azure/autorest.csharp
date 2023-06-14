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
    internal class Samples_Beta
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Two()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = client.Two();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Two_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = client.Two();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Two_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = await client.TwoAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Two_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = await client.TwoAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Three()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = client.Three();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Three_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = client.Three();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Three_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = await client.ThreeAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Three_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint).GetBetaClient();

            Response response = await client.ThreeAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
