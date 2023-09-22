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
using _Type.Model.Usage;
using _Type.Model.Usage.Models;

namespace _Type.Model.Usage.Tests
{
    public class UsageClientTests : _TypeModelUsageTestBase
    {
        public UsageClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Input_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Input_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            InputRecord input = new InputRecord("<requiredProp>");
            Response response = await client.InputAsync(input);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Input_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Input_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            InputRecord input = new InputRecord("<requiredProp>");
            Response response = await client.InputAsync(input);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Output_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            Response response = await client.OutputAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        public async Task Output_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            Response<OutputRecord> response = await client.OutputAsync();
        }

        [Test]
        public async Task Output_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            Response response = await client.OutputAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        public async Task Output_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            Response<OutputRecord> response = await client.OutputAsync();
        }

        [Test]
        public async Task InputAndOutput_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAndOutputAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        public async Task InputAndOutput_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            InputOutputRecord body = new InputOutputRecord("<requiredProp>");
            Response<InputOutputRecord> response = await client.InputAndOutputAsync(body);
        }

        [Test]
        public async Task InputAndOutput_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                requiredProp = "<requiredProp>",
            });
            Response response = await client.InputAndOutputAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("requiredProp").ToString());
        }

        [Test]
        public async Task InputAndOutput_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UsageClient client = CreateUsageClient(endpoint);

            InputOutputRecord body = new InputOutputRecord("<requiredProp>");
            Response<InputOutputRecord> response = await client.InputAndOutputAsync(body);
        }
    }
}
