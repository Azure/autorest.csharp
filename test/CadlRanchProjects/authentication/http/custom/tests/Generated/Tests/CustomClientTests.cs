// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Authentication.Http.Custom;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Authentication.Http.Custom.Tests
{
    public class CustomClientTests : AuthenticationHttpCustomTestBase
    {
        public CustomClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Valid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomClient client = CreateCustomClient(credential, endpoint);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Valid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomClient client = CreateCustomClient(credential, endpoint);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Invalid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomClient client = CreateCustomClient(credential, endpoint);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Invalid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            CustomClient client = CreateCustomClient(credential, endpoint);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }
    }
}
