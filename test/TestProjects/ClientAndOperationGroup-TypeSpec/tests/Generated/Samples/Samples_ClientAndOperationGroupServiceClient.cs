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
    public class Samples_ClientAndOperationGroupServiceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Zero()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = client.Zero();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Zero_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = client.Zero();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Zero_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = await client.ZeroAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Zero_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = await client.ZeroAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_One()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = client.One();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_One_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = client.One();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_One_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = await client.OneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_One_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ClientAndOperationGroupServiceClient(endpoint);

            Response response = await client.OneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
