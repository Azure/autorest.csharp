// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ApiVersionInCadl.Models;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace ApiVersionInCadl.Samples
{
    public class Samples_ApiVersionInCadlClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBatchDetectionResult()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ApiVersionInCadlClient(endpoint, credential);

            Response response = client.GetBatchDetectionResult(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBatchDetectionResult_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ApiVersionInCadlClient(endpoint, credential);

            Response response = client.GetBatchDetectionResult(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBatchDetectionResult_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ApiVersionInCadlClient(endpoint, credential);

            Response response = await client.GetBatchDetectionResultAsync(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBatchDetectionResult_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ApiVersionInCadlClient(endpoint, credential);

            Response response = await client.GetBatchDetectionResultAsync(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBatchDetectionResult_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new ApiVersionInCadlClient(endpoint, credential);

            var result = await client.GetBatchDetectionResultAsync(Guid.NewGuid());
        }
    }
}
