// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using _Specs_.Azure.ClientGenerator.Core.Internal;
using _Specs_.Azure.ClientGenerator.Core.Internal.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Tests
{
    public class InternalClientTests : _Specs_AzureClientGeneratorCoreInternalTestBase
    {
        public InternalClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task PublicOnly_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            InternalClient client = CreateInternalClient(endpoint);

            Response response = await client.PublicOnlyAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        public async Task PublicOnly_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            InternalClient client = CreateInternalClient(endpoint);

            Response<PublicModel> response = await client.PublicOnlyAsync("<name>");
        }

        [Test]
        public async Task PublicOnly_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            InternalClient client = CreateInternalClient(endpoint);

            Response response = await client.PublicOnlyAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        public async Task PublicOnly_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            InternalClient client = CreateInternalClient(endpoint);

            Response<PublicModel> response = await client.PublicOnlyAsync("<name>");
        }
    }
}
