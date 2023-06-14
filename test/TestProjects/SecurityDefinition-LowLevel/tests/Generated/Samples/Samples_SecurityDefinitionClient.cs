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

namespace SecurityDefinition_LowLevel.Samples
{
    public class Samples_SecurityDefinitionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SecurityDefinitionClient(endpoint, credential);

            var data = new { };

            Response response = client.Operation(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SecurityDefinitionClient(endpoint, credential);

            var data = new
            {
                Code = "<Code>",
                Status = "<Status>",
            };

            Response response = client.Operation(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SecurityDefinitionClient(endpoint, credential);

            var data = new { };

            Response response = await client.OperationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new SecurityDefinitionClient(endpoint, credential);

            var data = new
            {
                Code = "<Code>",
                Status = "<Status>",
            };

            Response response = await client.OperationAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
